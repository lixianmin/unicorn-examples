/********************************************************************
created:    2022-10-24
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using Client.Network;
using Unicorn.Collections;
using UnityEngine.Networking.Types;

namespace Client
{
    public class PlayerManager
    {
        /// <summary>
        /// 定义成static的类，会在assembly加载的时候初始化，从而规避多线程访问的问题
        /// </summary>
        static PlayerManager()
        {
            
        }

        private PlayerManager()
        {
            
        }

        public void AddPlayer(PlayerInfo info)
        {
            var playerId = info.id;
            bool isHostPlayer = playerId != HostPlayer.Instance.GetId();
            Player player = isHostPlayer ? HostPlayer.Instance : new ElsePlayer();
            player.SetPlayerInfo(info);
            _players.Add(playerId, player);
        }

        /// <summary>
        /// singleton实例
        /// </summary>
        public static readonly PlayerManager Instance = new();

        private readonly IntTable _players = new();
    }
}