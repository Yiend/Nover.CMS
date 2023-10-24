using Nover.CMS.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace Nover.CMS.Application.Contracts.Features
{
    public class NoverCmsFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var group = context.AddGroup(NoverCmsFeatures.GroupName);

            group.AddFeature(NoverCmsFeatures.SocialLogins, "true", L("Feature:SocialLogins")
                , valueType: new ToggleStringValueType());
            group.AddFeature(NoverCmsFeatures.UserCount, "10", L("Feature:UserCount")
                , valueType: new FreeTextStringValueType(new NumericValueValidator(1, 1000)));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CMSResource>(name);
        }
    }
}