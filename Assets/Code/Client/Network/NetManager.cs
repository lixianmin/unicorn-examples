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
            Console.WriteLine("fake network connected~");
            var wallet = HostPlayer.Instance.GetWallet();
            wallet.SetDiamond(56);
            wallet.SetGold(1029);

            // 加载一波玩家的数据到PlayerManager中，这里操作的全是Data层/Model层
            var playerManager = PlayerManager.Instance;
            var allPlayerInfos = new PlayerInfo[10];
            for (int i= 0; i< allPlayerInfos.Length; i++)
            {
                var playerInfo = allPlayerInfos[i];
                playerInfo.id = i;
                playerManager.AddPlayer(playerInfo);
            }
        }

        public static readonly NetManager Instance = new();
    }
}