/********************************************************************
created:    2022-09-08
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using Client.Network;
using Client.UI;
using Client.Web;
using Unicorn;
using Unicorn.UI;
using UnityEngine;

namespace Client
{
    /// <summary>
    /// MbGame是项目入口, 不允许在client项目中建立其它的MonoBehaviour脚本, 原因是逻辑上不同对象的Update()方法通常有先后顺序要求, 
    /// 而如果使用不同的MonoBehaviour脚本的话,这个顺序将难以控制
    /// </summary>
    public class MbGame : MonoBehaviour
    {
        /// <summary>
        /// Start()方法除了可以是Coroutine，也可以是async方法(在main thread中的执行).
        ///
        /// 因为Coroutine强依赖于MonoBehaviour，如果MonoBehaviour被disable，则Coroutine执行流程中间，因此不推荐使用Coroutine. 
        /// 多数情况可以使用自组织的Update()方法代替，如果遇到Delay(5s)之类的特殊场景，可以考虑使用async/await或Unicorn.CoroutineManager
        ///
        /// 注意：async/await目前（2022-10-09）在WebGL中无法正确支持
        /// 
        /// 参考：(【Unity】协程的火辣姐妹-- 异步async await](https://www.bilibili.com/video/BV1sT4y1o7Dz)
        /// 参考：https://github.com/Cysharp/UniTask 
        /// 参考：https://forum.unity.com/threads/async-await-and-webgl-builds.472994/page-2
        /// 参考：https://forum.unity.com/threads/c-async-await-can-totally-replace-coroutine.1026571/
        /// </summary>
        private async void Start()
        {
            // 避免Game对象在场景切换的时候被干掉
            GameObject.DontDestroyOnLoad(gameObject);
            _unicornMain.Init();

            await _metadataManager.LoadMetadata();

            // 连接网络，真实项目中应该是点击登录按钮之后
            NetManager.Instance.Connect();

            // 加载并打开ui主界面
            UIManager.Instance.OpenWindow(typeof(UIMain));
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
        private readonly GameWebManager _webManger = new();
    }
}