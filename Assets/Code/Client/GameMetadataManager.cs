
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

            var tasks = new[]
            {
                LoadFileAsync("metadata.raw"),
                LoadFileAsync("metadata@.raw"),
                LoadFileAsync("locale.zh_cn.raw")
            };
            
            await Task.WhenAll(tasks);
            
            LoadRawStream(tasks[0].Result); // 加载原始的metadata数据
            LoadIncreamentStream(tasks[1].Result); // 加载增量导出的metadata数据
            LoadLocaleTextStream(tasks[2].Result); // 加载locale相关数据
            
            var version = GetMetadataVersion();
            Console.WriteLine("[LoadMetadata()] Metadata Loaded, metadataVersion={0}.", version.ToString());
        }

        private static Task<Stream> LoadFileAsync(string localPath)
        {
            var fullPath = PathTools.GetExportPath(localPath);
            // Task.Run()是使用其它线程读取数据
            var task = Task.Run<Stream>(()=>
            {
                if (File.Exists(fullPath))
                {
                    try
                    {
                        var buffer = File.ReadAllBytes(fullPath);
                        return new MemoryStream(buffer);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[LoadFileAsync()] load file failed, fullPath={fullPath}, ex={ex}");
                    }
                }
                else
                {
                    Console.WriteLine($"[LoadFileAsync()] file does not exist, fullPath={fullPath}");
                }
                return null;
            });
            return task;
        }
        
        public new static GameMetadataManager Instance => MetadataManager.Instance as GameMetadataManager;
    }
}