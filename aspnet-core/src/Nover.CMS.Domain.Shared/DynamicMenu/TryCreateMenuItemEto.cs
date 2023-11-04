using System;
using System.Collections.Generic;
using Volo.Abp.ObjectExtending;

namespace Nover.CMS.Domain.Shared
{
    [Serializable]
    public class TryCreateMenuItemEto : ExtensibleObject, IMenuItem
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }

        public bool InAdministration { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Url { get; set; }

        public string UrlMvc { get; set; }

        public string UrlBlazor { get; set; }

        public string UrlAngular { get; set; }

        public string Permission { get; set; }

        public int? Order { get; set; }

        public string Icon { get; set; }

        public string Target { get; set; }

        public bool IsDisabled { get; set; }

        public string LResourceTypeName { get; set; }

        public string LResourceTypeAssemblyName { get; set; }

        public virtual List<TryCreateMenuItemEto> MenuItems { get; set; } = new List<TryCreateMenuItemEto>();
        public TryCreateMenuItemEto()
        {
        }

        //public TryCreateMenuItemEto(Guid parentId, bool inAdministration, string name, string displayName,
        //    string url, string urlMvc, string urlBlazor, string urlAngular, string permission, int? order, string icon,
        //    string target, bool isDisabled, string lResourceTypeName, string lResourceTypeAssemblyName)
        //{
        //    ParentId = parentId;
        //    InAdministration = inAdministration;
        //    Name = name;
        //    DisplayName = displayName;
        //    Url = url;
        //    UrlMvc = urlMvc;
        //    UrlBlazor = urlBlazor;
        //    UrlAngular = urlAngular;
        //    Permission = permission;
        //    Order = order;
        //    Icon = icon;
        //    Target = target;
        //    IsDisabled = isDisabled;
        //    LResourceTypeName = lResourceTypeName;
        //    LResourceTypeAssemblyName = lResourceTypeAssemblyName;
        //}
    }
}