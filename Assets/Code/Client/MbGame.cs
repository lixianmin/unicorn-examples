/********************************************************************
created:    2022-09-08
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using Client.UI;
using Unicorn;
using Unicorn.UI;
using UnityEngine;

namespace Client
{
    /// <summary>
    /// MbGame是项目入口, 通常不允许在client项目中建立其它的MonoBehaviour脚本, 原因是逻辑上不同对象的Update()方法通常有先后顺序要求, 
    /// 如果使用不同的MonoBehaviour脚本的话,这个顺序将难以控制
    /// </summary>
    public class MbGame : MonoBehaviour
    {
        private async void Start()
        {
            // 避免Game对象在场景切换的时候被干掉
            GameObject.DontDestroyOnLoad(gameObject);
            _unicornMain.Init();

            await _metadataManager.LoadMetadata();

            // 加载并打开ui主界面
            UIManager.OpenWindow(typeof(UIMain));
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _unicornMain.Update(deltaTime);
            _game.Update(deltaTime);
        }

        private readonly UnicornMain _unicornMain = UnicornMain.Instance;
        private readonly Game _game = new();
        private readonly GameMetadataManager _metadataManager = new();
    }
}