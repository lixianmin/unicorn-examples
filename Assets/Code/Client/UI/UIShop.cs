/********************************************************************
created:    2022-08-16
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using Metadata;
using Unicorn.UI;

namespace Client.UI
{
    public class UIShop: UIWindowBase
    {
        public override string GetResourcePath()
        {
            return "Assets/res/prefabs/ui/uishop.prefab";
        }

        public override RenderQueue GetRenderQueue()
        {
            return RenderQueue.Geometry;
        }

        private readonly UIWidget<UIText> _title = new( "shop_title");
        private readonly UIWidget<UIButton> _btnShop = new( "btn_shop");

        protected override void OnLoaded()
        {
            _btnShop.UI.onClick.AddListener(_OnClickButtonShop);
            Console.WriteLine("shop is OnLoaded");

            var manager = GameMetadataManager.Instance;
            var template = manager.GetTemplate<WeaponTemplate>(2);
            if (template != null)
            {
                Console.WriteLine(template.name);
            }
        }
        
        protected override void OnUnloading()
        {
            _btnShop.UI.onClick.RemoveListener(_OnClickButtonShop);
            Console.WriteLine("shop is OnUnloading");
        }

        private void _OnClickButtonShop()
        {
            _title.UI.text = "this is shop title";
        }
        
        protected override void OnOpened()
        {
            Console.WriteLine("shop is OnOpened");
        }

        protected override void OnActivated()
        {
            Console.WriteLine("shop is OnActivated");
        }

        protected override void OnDeactivating()
        {
            Console.WriteLine("shop is OnDeactivating");
        }

        protected override void OnClosing()
        {
            Console.WriteLine("shop is OnClosing");
        }
    }
}