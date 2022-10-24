/********************************************************************
created:    2022-10-24
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

namespace Client.Network
{
    public class NetManager
    {
        static NetManager()
        {
            
        }

        private NetManager()
        {
            
        }

        public void Connect()
        {
            // 因为缺少服务器逻辑，这里模拟一下网络连接成功后，把数据设置到客户端的逻辑
            Console.WriteLine("network connected~");
            var wallet = HostPlayer.Instance.GetWallet();
            wallet.SetDiamond(56);
            wallet.SetGold(1029);
        }

        public static readonly NetManager Instance = new();
    }
}