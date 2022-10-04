/********************************************************************
created:    2022-08-17
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System;
using Unicorn.UI;
using UnityEngine;

namespace Client.UI
{
    public class UIMain : UIWindowBase
    {
        public override string GetResourcePath()
        {
            return "Assets/res/prefabs/uimain.prefab";
        }
        
        private readonly UIWidget<UIButton> _btnOpenBag = new( "btn_open_bag");
        private readonly UIWidget<UIButton> _btnCloseBag = new( "btn_close_bag");
        
        private readonly UIWidget<UIButton> _btnOpenShop = new( "btn_open_shop");
        private readonly UIWidget<UIButton> _btnCloseShop = new( "btn_close_shop");

        private readonly UIWidget<UIButton> _btnCollectGarbage = new( "btn_collect_garbage");

        public override void OnLoaded()
        {
            _btnOpenBag.UI.onClick.AddListener(OnClickOpenBag);
            _btnCloseBag.UI.onClick.AddListener(OnClickCloseBag);
            _btnOpenShop.UI.onClick.AddListener(OnClickOpenShop);
            _btnCloseShop.UI.onClick.AddListener(OnClickCloseShop);
            
            _btnCollectGarbage.UI.onClick.AddListener(OnClickBtnCollectGarbage);
        }
        
        private void OnClickOpenBag()
        {
            UIManager.OpenWindow(typeof(UIBag));
        }
        
        private void OnClickCloseBag()
        {
            UIManager.CloseWindow(typeof(UIBag));
        }
        
        private void OnClickOpenShop()
        {
            UIManager.OpenWindow(typeof(UIShop));
        }
        
        private void OnClickCloseShop()
        {
            UIManager.CloseWindow(typeof(UIShop));
        }
        
        private void OnClickBtnCollectGarbage()
        {
            UIManager.CloseWindow(typeof(UIShop));
            UIManager.CloseWindow(typeof(UIBag));
            
            Resources.UnloadUnusedAssets();
            GC.Collect();
            Console.WriteLine("gc done");
        }
    }
}