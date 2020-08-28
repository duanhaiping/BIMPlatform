using Volo.Abp.Settings;

namespace BIMPlatform.Settings
{
    public class BIMPlatformSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(BIMPlatformSettings.MySetting1));
        }
    }
}
