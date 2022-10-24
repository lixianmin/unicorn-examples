/********************************************************************
created:    2022-10-24
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System;

namespace Client
{
    public class Wallet
    {
        public void SetGold(int gold)
        {
            if (_gold != gold && gold >= 0)
            {
                _gold = gold;
                OnGoldChanged?.Invoke();
            }
        }

        public void SetDiamond(int diamond)
        {
            if (_diamond != diamond && diamond >= 0)
            {
                _diamond = diamond;
                OnDiamonChanged?.Invoke();
            }
        }
        
        public int GetGold()
        {
            return _gold;
        }

        public int GetDiamond()
        {
            return _diamond;
        }

        public event Action OnGoldChanged;
        public event Action OnDiamonChanged;
        
        private int _gold;
        private int _diamond;
    }
}