/********************************************************************
created:    2022-08-17
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System;
using Unicorn;
using Unicorn.UI;
using UnityEngine;

namespace Client.UI
{
    public class UIMain : UIWindowBase
    {
        public override string GetAssetPath()
        {
            return "Assets/res/prefabs/ui/uimain.prefab";
        }
        
        protected override void OnLoaded()
        {
            // 统一注册事件
            _dog.AddListener(_btnOpenBag.UI.onClick, OnClickOpenBag);
            _dog.AddListener(_btnCloseBag.UI.onClick, OnClickCloseBag);
            _dog.AddListener(_btnOpenShop.UI.onClick, OnClickOpenShop);
            _dog.AddListener(_btnCloseShop.UI.onClick, OnClickCloseShop);
            _dog.AddListener(_btnCollectGarbage.UI.onClick, OnClickBtnCollectGarbage);
        }

        protected override void OnUnloading()
        {
            // 统一移除所有注册的事件
            _dog.RemoveAllListeners();
        }

        private void OnClickOpenBag()
        {
            UIManager.It.OpenWindow(typeof(UIBag));
        }
        
        private void OnClickCloseBag()
        {
            UIManager.It.CloseWindow(typeof(UIBag));
        }
        
        private void OnClickOpenShop()
        {
            UIManager.It.OpenWindow(typeof(UIShop));
        }
        
        private void OnClickCloseShop()
        {
            UIManager.It.CloseWindow(typeof(UIShop));
        }
        
        private void OnClickBtnCollectGarbage()
        {
            UIManager.It.CloseWindow(typeof(UIShop));
            UIManager.It.CloseWindow(typeof(UIBag));
            
            Resources.UnloadUnusedAssets();
            GC.Collect();
            Logo.Info("gc done");
        }
        
        // 所有成员变量统一扔到class的最后面
        private readonly UIWidget<UIButton> _btnOpenBag = new( "btn_open_bag");
        private readonly UIWidget<UIButton> _btnCloseBag = new( "btn_close_bag");
        
        private readonly UIWidget<UIButton> _btnOpenShop = new( "btn_open_shop");
        private readonly UIWidget<UIButton> _btnCloseShop = new( "btn_close_shop");

        private readonly UIWidget<UIButton> _btnCollectGarbage = new( "btn_collect_garbage");
        private readonly EventDog _dog = new ();
    }
}