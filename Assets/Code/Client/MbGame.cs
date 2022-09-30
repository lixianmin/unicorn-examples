
/********************************************************************
created:    2022-09-08
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System;
using System.Collections;
using System.IO;
using Metadata;
using Unicorn;
using Unicorn.UI;
using UnityEngine;

namespace Client
{
    public class MbGame: MonoBehaviour
    {
        private void Start()
        {
            // 避免Game对象在场景切换的时候被干掉
            GameObject.DontDestroyOnLoad(gameObject);
            _unicornMain.Init();
            
            CoroutineManager.StartCoroutine(_CoLoadMetadata());
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _unicornMain.Update(deltaTime);
            _game.Update(deltaTime);
        }
        
        private IEnumerator _CoLoadMetadata()
        {
            if (MetadataManager.Instance is not GameMetadataManager metadataManager)
            {
                yield break;
            }
            
            var fullPath = PathTools.DefaultBasePath +  "/metadata.raw";
            Console.WriteLine(fullPath);
            if (!fullPath.IsNullOrEmptyEx())
            {
                try
                {
                    var stream = File.OpenRead(fullPath);
                    metadataManager.LoadRawStream(stream);
                }catch(Exception ex)
                {
                    Console.Error.WriteLine("[_CoLoadMetadata()] load metadata failed, ex={0}", ex.ToString());
                }
            }

            var version = metadataManager.GetMetadataVersion();
            Console.WriteLine("[_CoLoadMetadata()] Metadata Loaded, metadataVersion={0}.", version.ToString());

            // UIManager.OpenWindow(typeof(UIMain));
            // UIManager.OpenWindow(typeof(UIAdjustNumber));
        }

        private readonly UnicornMain _unicornMain = UnicornMain.Instance;
        private readonly Game _game = new();
        private readonly GameMetadataManager _metadataManager = new();
    }
}