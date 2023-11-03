using System;
using Volo.Abp.Reflection;

namespace Nover.CMS.Permissions;

public static class NoverCmsPermissions
{
    public const string GroupName = "CMS";
    public const string DynamicMenuGroupName = GroupName+ "DynamicMenu";
    public const string OpenIddictGroupName = GroupName + "OpenIddict";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(NoverCmsPermissions));
    }

    public class MenuItem
    {
        public const string Default = DynamicMenuGroupName + ".MenuItem";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class OpenIddictApplication
    {
        /// <summary>
        /// OpenIddictApplication
        /// </summary>
        public const string Default = OpenIddictGroupName + ".Application";

        /// <summary>
        /// 获取应用程序列表
        /// </summary>
        public const string List = Default + ".List";

        /// <summary>
        /// 编辑应用程序
        /// </summary>
        public const string Update = Default + ".Update";
    }
}
