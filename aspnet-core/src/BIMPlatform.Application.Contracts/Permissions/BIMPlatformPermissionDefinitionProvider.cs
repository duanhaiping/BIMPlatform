using BIMPlatform.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace BIMPlatform.Permissions
{
    public class BIMPlatformPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BIMPlatformPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BIMPlatformPermissions.MyPermission1, L("Permission:MyPermission1"));
            var projectPermissions = myGroup.AddPermission(BIMPlatformPermissions.Project.Default, L("Permission:Project"), MultiTenancySides.Tenant);
            projectPermissions.AddChild(BIMPlatformPermissions.Project.Create, L("Permission:Create"), MultiTenancySides.Tenant);
            projectPermissions.AddChild(BIMPlatformPermissions.Project.Update, L("Permission:Update"), MultiTenancySides.Tenant);
            projectPermissions.AddChild(BIMPlatformPermissions.Project.Delete, L("Permission:Delete"), MultiTenancySides.Tenant);

            var tenantManagemetPermissions = myGroup.AddPermission(BIMPlatformPermissions.Tenant.Default, L("Permission:Tenant"), MultiTenancySides.Host);
            tenantManagemetPermissions.AddChild(BIMPlatformPermissions.Tenant.Create, L("Permission:Create"), MultiTenancySides.Host);
            tenantManagemetPermissions.AddChild(BIMPlatformPermissions.Tenant.Update, L("Permission:Update"), MultiTenancySides.Host);
            tenantManagemetPermissions.AddChild(BIMPlatformPermissions.Tenant.Delete, L("Permission:Delete"), MultiTenancySides.Host);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BIMPlatformResource>(name);
        }
    }
}
