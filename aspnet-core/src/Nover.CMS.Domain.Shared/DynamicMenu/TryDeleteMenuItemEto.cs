using System;
using JetBrains.Annotations;
using Volo.Abp.ObjectExtending;

namespace Nover.CMS.Domain.Shared
{
    [Serializable]
    public class TryDeleteMenuItemEto : ExtensibleObject
    {
        [NotNull]
        public string Name { get; set; }

        public TryDeleteMenuItemEto([NotNull] string name)
        {
            Name = name;
        }
    }
}