using System.Threading.Tasks;
using Lazy.Abp.Mailing.Localization;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.Mailing.Blazor.Host
{
    public class MailingHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<MailingResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Mailing.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
