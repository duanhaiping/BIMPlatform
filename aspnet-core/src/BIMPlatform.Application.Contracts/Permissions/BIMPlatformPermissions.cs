namespace BIMPlatform.Permissions
{
    public static class BIMPlatformPermissions
    {
        public const string GroupName = "BIMPlatform";


        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
        private class PermissionType
        {
            public const string Default = ".Default";
            public const string Create = ".Create";
            public const string Update = ".Update";
            public const string Delete = ".Delete";
            public const string Manage = ".Manage";
            public const string Audit = ".Audit"; //审核是审查和核实，有时无最终决定权；
            public const string Approve = ".Approve"; //审批是审查和批准。随时有最终决定权。
            public const string Apply = ".Apply";
        }
        public class Project
        {
            public const string Default = GroupName + ".Project" + PermissionType.Default;
            public const string Create= GroupName + ".Project" + PermissionType.Create;
            public const string Update = GroupName + ".Project" + PermissionType.Update;
            public const string Delete = GroupName + ".Project" + PermissionType.Delete;
        }

        public class Tenant
        {
            private const string moduleName = ".Tenant";
            public const string Default = GroupName + moduleName + PermissionType.Default;
            public const string Create = GroupName + moduleName + PermissionType.Create;
            public const string Update = GroupName + moduleName + PermissionType.Update;
            public const string Delete = GroupName + moduleName + PermissionType.Delete;
        }
    }
}
       
