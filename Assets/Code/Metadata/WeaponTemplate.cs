/********************************************************************
created:    2022-10-14
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System.Collections.Generic;

namespace Metadata
{
    /// <summary>
    /// 当同一个类型可能有多个实例的时候，使用Template类型
    /// </summary>
    public class WeaponTemplate : Template
    {
        /// <summary>
        /// 支持嵌套类型，需要实现IMetadata这个空接口
        /// </summary>
        public class Stat : IMetadata
        {
            public int key; // 属性类型
            public float val; // 属性值;
        }

        /// <summary>
        /// todo 本地化的内容，现在还不正确
        /// </summary>
        public List<Stat> stats = new(); // 支持List，但不支持Dictionary
        public LocaleText name; // 需要本地化的内容，使用LocalText类型
        public string[] gfxPaths; // 支持数组
        public Int32_t price; // 某些关键的数值类型，为了防止内存修改器，可以使用加密类型
        public Float_t weight; // float对应的加密类型
    }
}