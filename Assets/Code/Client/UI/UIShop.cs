/********************************************************************
created:    2022-08-16
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using Metadata;
using Unicorn;
using Unicorn.UI;

namespace Client.UI
{
    public class UIShop: UIWindowBase
    {
        public override string GetAssetPath()
        {
            return "uishop";
        }

        public override RenderQueue GetRenderQueue()
        {
            return RenderQueue.Geometry;
        }
        
        protected override void OnLoaded()
        {
            // UI加载之后，先取从model层取数据
            _RefreshTextGold();
            // 然后挂载事件，监听model层的数据变化
            var wallet = HostPlayer.Instance.GetWallet();
            wallet.OnGoldChanged += _RefreshTextGold;
            
            _btnFindWeapons.UI.onClick.AddListener(_OnClickButtonFindWeapons);
            _btnBuyWeapon.UI.onClick.AddListener(_OnClickBuyWeapon);
            
            Logo.Info("shop is OnLoaded");
        }

        private void _RefreshTextGold()
        {
            var wallet = HostPlayer.Instance.GetWallet();
            _textGold.UI.text = "gold: " + wallet.GetGold();
        }

        private void _OnClickBuyWeapon()
        {
            // 真实的代码逻辑应该是直接发送网络消息，请示服务器购买物品，如果购买成功，则返回消息修改model层的数据，
            // 然后UI会因为监听了model层数据变化的事件，从而得到更新
            var price = 100;
            var wallet = HostPlayer.Instance.GetWallet();
            var gold = wallet.GetGold();
            var remains = gold - price;
            wallet.SetGold(remains);
        }

        protected override void OnUnloading()
        {
            // UI卸载之前，记得把监听的事件销毁，否则会导致UI无法真正unload
            var wallet = HostPlayer.Instance.GetWallet();
            wallet.OnGoldChanged -= _RefreshTextGold;
            
            _btnBuyWeapon.UI.onClick.RemoveAllListeners();
            _btnFindWeapons.UI.onClick.RemoveAllListeners();
            Logo.Info("shop is OnUnloading");
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
            Logo.Info("shop is OnOpened");
        }

        protected override void OnActivated()
        {
            Logo.Info("shop is OnActivated");
        }

        protected override void OnDeactivating()
        {
            Logo.Info("shop is OnDeactivating");
        }

        protected override void OnClosing()
        {
            Logo.Info("shop is OnClosing");
        }
        
        // 所有成员变量统一扔到class的最后面
        private readonly UIWidget<UIText> _title = new( "shop_title");
        private readonly UIWidget<UIButton> _btnFindWeapons = new( "btn_find_weapons");

        private readonly UIWidget<UIText> _textGold = new("text_gold");
        private readonly UIWidget<UIButton> _btnBuyWeapon = new( "btn_buy_weapon");
    }
}