
/********************************************************************
created:    2022-08-12
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System;
using System.IO;
using Unicorn;

namespace Client
{
    class GameMetadataManager : Metadata.MetadataManager
    {
        internal GameMetadataManager()
        {
            Instance = this;
        }

        internal void LoadMetadata()
        {
            if (IsXmlMetadata)
            {
                return;
            }
            
            {
                // 加载原始的metadata数据
                var rawPath = PathTools.GetFullPath("metadata.raw");
                // rawStream不能使用using销毁，会被记录到LoadAid对象中
                var rawStream = File.OpenRead(rawPath);

                try
                {
                    LoadRawStream(rawStream);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("[CoLoadMetadata()] load metadata failed, rawPath={0}, ex={1}", rawPath,
                        ex.ToString());
                }
            }

            {
                // 加载增量导出的metadata数据
                var incrementPath = PathTools.GetFullPath("metadata@.raw");
                if (File.Exists(incrementPath))
                {
                    try
                    {
                        var bytes = File.ReadAllBytes(incrementPath);
                        var stream = new MemoryStream(bytes);
                        LoadIncreamentStream(stream);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(
                            "[CoLoadMetadata()] load increment metadata failed, incrementPath={0}, ex={1}",
                            incrementPath, ex.ToString());
                    }
                }
            }

            {
                // 加载locale相关数据
                var localePath = PathTools.GetFullPath("local.zh_cn.raw");
                if (File.Exists(localePath))
                {
                    try
                    {
                        var bytes = File.ReadAllBytes(localePath);
                        var stream = new MemoryStream(bytes);
                        LoadLocaleTextStream(stream);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("[CoLoadMetadata()] load locale text failed, localePath={0}, ex={1}",
                            localePath, ex.ToString());
                    }
                }
            }

            var version = GetMetadataVersion();
            Console.WriteLine("[_CoLoadMetadata()] Metadata Loaded, metadataVersion={0}.", version.ToString());
        }
    }
}