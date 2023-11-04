using Nover.CMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Nover.CMS.Domain
{
    public class MenuItem : AggregateRoot<Guid>, IMenuItem
    {
        /// <summary>
        /// Name of the parent menu item.
        /// </summary>
        public virtual Guid ParentId { get; protected set; }

        /// <summary>
        /// It will be a child of the Administration menu item if true.
        /// Effect only if <see cref="ParentName"/> is null.
        /// </summary>
        public virtual bool InAdministration { get; protected set; }

        /// <summary>
        /// Unique name of the menu in the application.
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Display name of the menu item.
        /// </summary>
        public virtual string DisplayName { get; protected set; }

        /// <summary>
        /// The URL to navigate when this menu item is selected.
        /// </summary>
        public virtual string Url { get; protected set; }

        /// <summary>
        /// The special MVC frontend URL to navigate when this menu item is selected.
        /// </summary>
        public virtual string UrlMvc { get; protected set; }

        /// <summary>
        /// The special Blazor frontend URL to navigate when this menu item is selected.
        /// </summary>
        public virtual string UrlBlazor { get; protected set; }

        /// <summary>
        /// The special Angular frontend URL to navigate when this menu item is selected.
        /// </summary>
        public virtual string UrlAngular { get; protected set; }

        /// <summary>
        /// The required permission to display this menu item.
        /// </summary>
        public virtual string Permission { get; protected set; }

        /// <summary>
        /// The Display order of the menu.
        /// Default value: 1000.
        /// </summary>
        public virtual int? Order { get; protected set; }

        /// <summary>
        /// Icon of the menu item if exists.
        /// </summary>
        public virtual string Icon { get; protected set; }

        /// <summary>
        /// Target of the menu item. Can be null, "_blank", "_self", "_parent", "_top" or a frame name for web applications.
        /// </summary>
        public virtual string Target { get; protected set; }

        /// <summary>
        /// Can be used to disable this menu item.
        /// </summary>
        public virtual bool IsDisabled { get; protected set; }

        public virtual string LResourceTypeName { get; protected set; }

        public virtual string LResourceTypeAssemblyName { get; protected set; }


        [ForeignKey(nameof(ParentId))]
        public virtual List<MenuItem> MenuItems { get; protected set; }


        protected MenuItem()
        {
            MenuItems = new List<MenuItem>();
        }

        public MenuItem(
            Guid id,
            Guid parentId,
            bool inAdministration,
            string name,
            string displayName,
            string url,
            string urlMvc,
            string urlBlazor,
            string urlAngular,
            string permission,
            int? order,
            string icon,
            string target,
            bool isDisabled,
            string lResourceTypeName,
            string lResourceTypeAssemblyName,
            List<MenuItem> menuItems
        ) : base(id)
        {
            ParentId = parentId;
            InAdministration = inAdministration;
            Name = name;
            DisplayName = displayName;
            Url = url;
            UrlMvc = urlMvc;
            UrlBlazor = urlBlazor;
            UrlAngular = urlAngular;
            Permission = permission;
            Order = order;
            Icon = icon;
            Target = target;
            IsDisabled = isDisabled;
            LResourceTypeName = lResourceTypeName;
            LResourceTypeAssemblyName = lResourceTypeAssemblyName;
            MenuItems = menuItems ?? new List<MenuItem>();
        }
    }
}