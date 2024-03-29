/********************************************************************
created:    2022-08-16
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using Unicorn;
using Unicorn.UI;
using UnityEngine;

namespace Client.UI
{
    public class UIBag: UIWindowBase
    {
        public override string GetAssetPath()
        {
            return "Assets/res/prefabs/ui/uibag.prefab";
        }
        
        protected override void OnLoaded()
        { 
            _btnBag.UI.onClick.AddListener(_OnClickBtnBag);
            _btnClose.UI.onClick.AddListener(_OnClickBtnClose);
            Logo.Info("bag is OnLoaded, button position={0}", _btnBagTransform.UI.position);
        }

        private void _OnClickBtnBag()
        {
            Logo.Info("click button bag");
            
            // 如果是临时变量，则要求填充window参数
            UIWidget<UIText> title = new( "title", this);
            title.UI.text = "hello world";
        }

        private void _OnClickBtnClose()
        {
            UIManager.It.CloseWindow(GetType());
        }
        
        protected override void OnOpened()
        {
            Logo.Info("bag is OnOpened");
        }

        protected override void OnActivated()
        {
            Logo.Info("bag is OnActivated");
        }

        protected override void OnDeactivating()
        {
            Logo.Info("bag is OnDeactivating");
        }

        protected override void OnClosing()
        {
            Logo.Info("bag is OnClosing");
        }

        protected override void OnUnloading()
        {
            Logo.Info("bag is OnUnloading");
            _btnBag.UI.onClick.RemoveListener(_OnClickBtnBag);
            _btnClose.UI.onClick.RemoveListener(_OnClickBtnClose);
        }

        protected override void SlowUpdate(float deltaTime)
        {
            
        }
        
        // 所有成员变量统一扔到class的最后面
        private readonly UIWidget<UIButton> _btnBag = new(  "btn_bag");
        // UIWidget也可以支持Transform，如果需要gameObject请直接使用transform.gameObject即可
        private readonly UIWidget<Transform> _btnBagTransform = new(  "btn_bag");
        private readonly UIWidget<UIButton> _btnClose = new("btn_close");
    }
}