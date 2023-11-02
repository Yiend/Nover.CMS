using Volo.Abp.Reflection;

namespace Nover.CMS.Permissions;

public static class NoverCmsPermissions
{
    public const string GroupName = "CMS";
    public const string DynamicMenuGroupName = GroupName+ "DynamicMenu";

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
}
