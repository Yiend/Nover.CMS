﻿using Volo.Abp.Identity;
using Volo.Abp.Reflection;

namespace Nover.CMS.Application.Contracts.Permissions
{
    public static class NoverCmsIdentityPermissions
    {
        public static class Users
        {
            // 分配人员给组织单元权限
            public const string DistributionOrganizationUnit = IdentityPermissions.Users.Default + ".DistributionOrganizationUnit";
        }

        public static class Roles
        {
            public const string AddOrganizationUnitRole = IdentityPermissions.Roles.Default + ".AddOrganizationUnitRole";
        }

        public static class OrganitaionUnits
        {
            public const string Default = IdentityPermissions.GroupName + ".OrganitaionUnits";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class ClaimTypes
        {
            public const string Default = IdentityPermissions.GroupName + ".ClaimTypes";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(IdentityPermissions));
        }
    }
}
