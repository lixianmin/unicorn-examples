
/********************************************************************
created:    2022-08-12
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System;
using System.IO;
using System.Threading.Tasks;
using Metadata;
using Unicorn;

namespace Client
{
    class GameMetadataManager : MetadataManager
    {
        internal GameMetadataManager()
        {
            MetadataManager.Instance = this;
        }

        public T GetTemplate<T>(int idTemplate) where T : Template
        {
            return base.GetTemplate(typeof(T), idTemplate) as T;
        }

        public T GetConfig<T>() where T : Config
        {
            return base.GetConfig(typeof(T)) as T;
        }
        
        internal async Task LoadMetadata()
        {
            // todo prototype editor的显示不全
            // todo 现在xml的格式支持还未加进来
            if (IsXmlMetadata)
            {
                return;
            }
            
            {
                // 加载原始的metadata数据
                var rawPath = PathTools.GetFullPath("metadata.raw");

                try
                {
                    // rawStream不能使用using销毁，因为会被记录到LoadAid对象中
                    var rawStream = await LoadFileAsync(rawPath);
                    LoadRawStream(rawStream);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"[CoLoadMetadata()] load metadata failed, rawPath={rawPath}, ex={ex}");
                }
            }
            
            {
                // 加载增量导出的metadata数据
                var incrementPath = PathTools.GetFullPath("metadata@.raw");
                if (File.Exists(incrementPath))
                {
                    try
                    {
                        var stream = await LoadFileAsync(incrementPath);
                        LoadIncreamentStream(stream);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"[CoLoadMetadata()] load increment metadata failed, incrementPath={incrementPath}, ex={ex}");
                    }
                }
            }
            
            {
                // 加载locale相关数据
                var localePath = PathTools.GetFullPath("locale.zh_cn.raw");
                if (File.Exists(localePath))
                {
                    try
                    {
                        var stream = await LoadFileAsync(localePath);
                        LoadLocaleTextStream(stream);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"[CoLoadMetadata()] load locale text failed, localePath={localePath}, ex={ex}");
                    }
                }
            }
            
            var version = GetMetadataVersion();
            Console.WriteLine("[_CoLoadMetadata()] Metadata Loaded, metadataVersion={0}.", version.ToString());
        }

        private static Task<Stream> LoadFileAsync(string filePath)
        {
            // Task.Run()是使用其它线程读取数据
            var task = Task.Run<Stream>(()=> new MemoryStream(File.ReadAllBytes(filePath)));
            return task;
        }
        
        public new static GameMetadataManager Instance => MetadataManager.Instance as GameMetadataManager;
    }
}