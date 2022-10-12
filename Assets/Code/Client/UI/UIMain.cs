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
        public override string GetResourcePath()
        {
            return "Assets/res/prefabs/ui/uimain.prefab";
        }
        
        private readonly UIWidget<UIButton> _btnOpenBag = new( "btn_open_bag");
        private readonly UIWidget<UIButton> _btnCloseBag = new( "btn_close_bag");
        
        private readonly UIWidget<UIButton> _btnOpenShop = new( "btn_open_shop");
        private readonly UIWidget<UIButton> _btnCloseShop = new( "btn_close_shop");

        private readonly UIWidget<UIButton> _btnCollectGarbage = new( "btn_collect_garbage");
        private readonly EventListener _listener = new EventListener();

        protected override void OnLoaded()
        {
            // 统一注册事件
            _listener.AddListener(_btnOpenBag.UI.onClick, OnClickOpenBag);
            _listener.AddListener(_btnCloseBag.UI.onClick, OnClickCloseBag);
            _listener.AddListener(_btnOpenShop.UI.onClick, OnClickOpenShop);
            _listener.AddListener(_btnCloseShop.UI.onClick, OnClickCloseShop);
            _listener.AddListener(_btnCollectGarbage.UI.onClick, OnClickBtnCollectGarbage);
        }

        protected override void OnUnloading()
        {
            // 统一移除所有注册的事件
            _listener.RemoveAllListeners();
        }

        private void OnClickOpenBag()
        {
            UIManager.Instance.OpenWindow(typeof(UIBag));
        }
        
        private void OnClickCloseBag()
        {
            UIManager.Instance.CloseWindow(typeof(UIBag));
        }
        
        private void OnClickOpenShop()
        {
            UIManager.Instance.OpenWindow(typeof(UIShop));
        }
        
        private void OnClickCloseShop()
        {
            UIManager.Instance.CloseWindow(typeof(UIShop));
        }
        
        private void OnClickBtnCollectGarbage()
        {
            UIManager.Instance.CloseWindow(typeof(UIShop));
            UIManager.Instance.CloseWindow(typeof(UIBag));
            
            Resources.UnloadUnusedAssets();
            GC.Collect();
            Console.WriteLine("gc done");
        }
    }
}