/********************************************************************
created:    2022-08-12
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System;
using System.Collections;
using System.IO;
using Metadata;
using Unicorn;
using Unicorn.Web;
using UnityEngine;

namespace Client
{
    class GameMetadataManager : MetadataManager
    {
        static GameMetadataManager()
        {
        }

        private GameMetadataManager()
        {
        }

        public T GetTemplate<T>(int idTemplate) where T : Template
        {
            return base.GetTemplate(typeof(T), idTemplate) as T;
        }

        public T GetConfig<T>() where T : Config
        {
            return base.GetConfig(typeof(T)) as T;
        }

        internal IEnumerator LoadMetadata()
        {
            // todo prototype editor的显示不全
            if (Application.isEditor)
            {
                EnableXmlMetadata();
                yield break;
            }
            
            var nodes = new[]
            {
                LoadFileAsync("Assets/res/metadata/metadata.bytes", stream => LoadRawStream(stream)),
                LoadFileAsync("Assets/res/metadata/metadata@.bytes", LoadIncrementStream),
                LoadFileAsync("Assets/res/metadata/locale.zh_cn.bytes", LoadLocaleTextStream)
            };

            for (int i = 0; i < nodes.Length;)
            {
                if (nodes[i].IsDone)
                {
                    i++;
                }
                else
                {
                    yield return null;
                }
            }
            
            var version = GetMetadataVersion();
            Logo.Info("[LoadMetadata()] Metadata Loaded, metadataVersion={0}.", version.ToString());
        }

        private static IWebNode LoadFileAsync(string key, Action<Stream> handler)
        {
            return WebManager.It.LoadAsset(new WebArgument{key = key}, node =>
            {
                if (!node.IsSucceeded)
                {
                    Logo.Error($"[LoadFileAsync()] load file failed, key={key}");
                    return;
                }
                
                var textAsset = node.Asset as TextAsset;
                if (textAsset != null && null != handler)
                {
                    var stream = new MemoryStream(textAsset.bytes);
                    handler(stream);
                    // Logo.Info(handler);
                }
                else
                {
                    Logo.Error($"textAsset={textAsset}, handler={handler}");
                }
            });
        }

        public new static readonly GameMetadataManager It = new();
    }
}