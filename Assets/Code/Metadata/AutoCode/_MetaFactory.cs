
// Warning: all code of this file are generated automatically, so do not modify it manually ~
// Any questions are welcome, mailto:lixianmin@gmail.com

using System;
using System.Collections;

namespace Metadata
{
    public class OuterMetaFactory
    {
        [UnityEngine.Scripting.Preserve]
        private static Hashtable _GetLookupTableByName ()
        {
            return new Hashtable(3)
            {
                { "Metadata.SystemConfig", new MetaCreator(()=> new Metadata.SystemConfig()) },
                { "Metadata.WeaponTemplate", new MetaCreator(()=> new Metadata.WeaponTemplate()) },
                { "Metadata.WeaponTemplate+Stat", new MetaCreator(()=> new Metadata.WeaponTemplate.Stat()) },
            };
        }
    }
}
