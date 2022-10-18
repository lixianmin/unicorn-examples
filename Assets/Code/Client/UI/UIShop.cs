/********************************************************************
created:    2022-08-16
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System.Text;
using Metadata;
using Unicorn;
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
        private readonly UIWidget<UIButton> _btnFindWeapons = new( "btn_find_weapons");

        protected override void OnLoaded()
        {
            _btnFindWeapons.UI.onClick.AddListener(_OnClickButtonFindWeapons);
            Console.WriteLine("shop is OnLoaded");
        }
        
        protected override void OnUnloading()
        {
            _btnFindWeapons.UI.onClick.RemoveListener(_OnClickButtonFindWeapons);
            Console.WriteLine("shop is OnUnloading");
        }

        private void _OnClickButtonFindWeapons()
        {
            var sbText = StringBuilderPool.Spawn();
            var manager = GameMetadataManager.Instance;
            
            // 按id取template对象
            const int idTemplate = 2;
            var template = manager.GetTemplate<WeaponTemplate>(idTemplate);
            if (template != null)
            {
                sbText.AppendLine($"name={template.name}, price={(int) template.price}");
            }
            
            // 遍历所有的template对象
            foreach (var pair in manager.GetTemplateTable(typeof(WeaponTemplate)))
            {
                var template1 = pair.Value;
                sbText.AppendLine($"weaponId= {template1.id}");
            }

            // 加载config
            var systemConfig = manager.GetConfig<SystemConfig>();
            sbText.AppendLine($"lod={systemConfig.lodLevel}");
            
            _title.UI.text = StringBuilderPool.GetStringAndRecycle(sbText);
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