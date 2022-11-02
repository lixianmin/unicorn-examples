/********************************************************************
created:    2022-08-16
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using Unicorn.UI;
using UnityEngine;

namespace Client.UI
{
    public class UIBag: UIWindowBase
    {
        public override string GetResourcePath()
        {
            return "Assets/res/prefabs/ui/uibag.prefab";
        }
        
        protected override void OnLoaded()
        { 
            UIWidget<UIText> title = new( "title", this);
            _btnBag.UI.onClick.AddListener(()=>{
                Console.WriteLine("click button");
                title.UI.text = "hello world";
            });
            
            Console.WriteLine("bag is OnLoaded, button position={0}", _btnBagTransform.UI.position);
        }
        
        protected override void OnOpened()
        {
            Console.WriteLine("bag is OnOpened");
        }

        protected override void OnActivated()
        {
            Console.WriteLine("bag is OnActivated");
        }

        protected override void OnDeactivating()
        {
            Console.WriteLine("bag is OnDeactivating");
        }

        protected override void OnClosing()
        {
            Console.WriteLine("bag is OnClosing");
        }

        protected override void OnUnloading()
        {
            Console.WriteLine("bag is OnUnloading");
        }

        protected override void SlowUpdate(float deltaTime)
        {
            
        }
        
        // 所有成员变量统一扔到class的最后面
        private readonly UIWidget<UIButton> _btnBag = new(  "btn_bag");
        // UIWidget也可以支持Transform，如果需要gameObject请直接使用transform.gameObject即可
        private readonly UIWidget<Transform> _btnBagTransform = new(  "btn_bag");
    }
}