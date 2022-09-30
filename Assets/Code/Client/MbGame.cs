
/********************************************************************
created:    2022-09-08
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using Unicorn;
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