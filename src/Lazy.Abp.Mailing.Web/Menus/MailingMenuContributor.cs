using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.Mailing.Web.Menus
{
    public class MailingMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(MailingMenus.Prefix, displayName: "Mailing", "~/Mailing", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}