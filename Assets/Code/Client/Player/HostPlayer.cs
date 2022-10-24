/********************************************************************
created:    2022-10-24
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

namespace Client
{
    public class HostPlayer: Player
    {
        /// <summary>
        /// 定义成static的类，会在assembly加载的时候初始化，从而规避多线程访问的问题
        /// </summary>
        static HostPlayer()
        {
            
        }

        private HostPlayer()
        {
            
        }
        
        public Wallet GetWallet()
        {
            return _wallet;
        }
        
        /// <summary>
        /// singleton实例
        /// </summary>
        public static readonly HostPlayer Instance = new();
        private readonly Wallet _wallet = new ();
    }
}