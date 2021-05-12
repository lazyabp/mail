using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Mailing
{
    [Dependency(ReplaceServices = true)]
    public class MailingBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Mailing";
    }
}
