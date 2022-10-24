/********************************************************************
created:    2022-10-24
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System.Collections.Generic;
using Unicorn;
using Unicorn.Collections;

namespace Client
{
    public class BagManager
    {
        /// <summary>
        /// 定义成static的类，会在assembly加载的时候初始化，从而规避多线程访问的问题
        /// </summary>
        static BagManager()
        {
            
        }

        public void AddStock(StockItem stock)
        {
            // 入参一定要检查
            if (stock != null)
            {
                _stocks.Add(stock.GetSlot(), stock);
            }
        }

        public StockItem RemoveStock(int id)
        {
            var index = _stocks.TryIndexValue(id, out object stock);
            if (index >= 0)
            {
                _stocks.RemoveAt(index);
                return stock as StockItem;
            }

            return null;
        }

        public StockItem GetStock(int id)
        {
            return _stocks.GetEx(id) as StockItem;
        }

        public IEnumerable<StockItem> GetAllStocks()
        {
            foreach (StockItem stock in _stocks.Values)
            {
                yield return stock;
            }
        }

        /// <summary>
        /// singleton实例
        /// </summary>
        public static readonly BagManager Instance = new();

        private readonly IntTable _stocks = new();
    }
}