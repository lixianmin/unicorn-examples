/********************************************************************
created:    2022-10-24
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using Client.Network;

namespace Client
{
    public class Player
    {
        /// <summary>
        /// 从server拿到数据，设置到玩家身上
        /// </summary>
        /// <param name="info"></param>
        public void SetPlayerInfo(PlayerInfo info)
        {
            if (info.id == 0)
            {
                return;
            }
            
            _info = info;
            LoadModel(info.modelPath);
        }

        /// <summary>
        /// 加载玩家模型
        /// </summary>
        /// <param name="path"></param>
        public void LoadModel(string path)
        {
            
        }

        /// <summary>
        /// 注意，hostPlayer的玩家id不是从playerInfo中取到的，是单独设置过来的，否则这里默认取到的就是0啦
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            return _info.id;
        }

        private PlayerInfo _info;
    }
}