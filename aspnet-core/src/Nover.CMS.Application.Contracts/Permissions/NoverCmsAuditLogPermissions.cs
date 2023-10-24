using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Reflection;

namespace Nover.CMS.Application.Contracts.Permissions
{
    public static class NoverCmsAuditLogPermissions
    {
        public const string GroupName = "AbpAuditLogging";
        public static class AuditLogs
        {
            public const string Default = GroupName + ".Default";
            public const string Delete = GroupName + ".Delete";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(NoverCmsAuditLogPermissions));
        }
    }
}
