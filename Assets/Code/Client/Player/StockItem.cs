/********************************************************************
created:    2022-10-24
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System;
using Metadata;

namespace Client
{
    public class StockItem
    {
        public StockItem(int slot, int idTemplate)
        {
            _slot = slot;
            _template = GameMetadataManager.It.GetTemplate<StockItemTemplate>(idTemplate);

            if (_template is null)
            {
                throw new ArgumentException($"idTemplate={idTemplate} is not a valid StockItemTemplate");
            }
        }

        public int GetSlot()
        {
            return _slot;
        }

        public StockItemTemplate GetTemplate()
        {
            return _template;
        }
        
        public string GetName()
        {
            return _template.name;
        }
        
        private int _slot;          // 在背包中的位置
        private StockItemTemplate _template;
    }
}