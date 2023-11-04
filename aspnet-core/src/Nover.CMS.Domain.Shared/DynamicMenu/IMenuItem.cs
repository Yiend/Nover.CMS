using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace Nover.CMS.Domain.Shared
{
    public interface IMenuItem
    {
        [NotNull]
        Guid ParentId { get; }

        string Name { get; }
        
        string DisplayName { get; }
        
        [CanBeNull]
        string Url { get; }
        
        [CanBeNull]
        string UrlMvc { get; }
        
        [CanBeNull]
        string UrlBlazor { get; }
        
        [CanBeNull]
        string UrlAngular { get; }
        
        [CanBeNull]
        string Permission { get; }
        
        [CanBeNull]
        string LResourceTypeName { get; }
        
        [CanBeNull]
        string LResourceTypeAssemblyName { get; }
    }
}