using Volo.Abp.Settings;

namespace Nover.CMS.Settings;

public class NoverCmsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CMSSettings.MySetting1));
    }
}
