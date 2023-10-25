using Nover.CMS.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Nover.CMS.Settings;

public class NoverCmsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CMSSettings.MySetting1));

        context.Add(new SettingDefinition(NoverCmsSettings.AllowedMaxFileSize,
               "1024",
               L("DisplayName:File.AllowedMaxFileSize"),
               L("Description:File.AllowedMaxFileSize")
               )
                   .WithProperty("Group1", "File")
                   .WithProperty("Group2", "Upload")
                   .WithProperty("Type", "number"),

               new SettingDefinition(NoverCmsSettings.AllowedUploadFormats,
                   ".jpg,.jpeg,.png,.gif,.txt",
                   L("DisplayName:File.AllowedUploadFormats"),
                   L("Description:File.AllowedUploadFormats")
               )
                   .WithProperty("Group1", "File")
                   .WithProperty("Group2", "Upload")
                   .WithProperty("Type", "text")
               );
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CMSResource>(name);
    }
}
