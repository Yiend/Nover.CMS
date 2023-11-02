using System;
using System.Collections.Generic;
using Volo.Abp.ObjectExtending;

namespace Nover.CMS.Domain.Shared
{
    [Serializable]
    public class TryCreateMenuItemsEto : ExtensibleObject
    {
        public List<TryCreateMenuItemEto> Items { get; set; }

        public TryCreateMenuItemsEto(List<TryCreateMenuItemEto> items)
        {
            Items = items;
        }
    }
}