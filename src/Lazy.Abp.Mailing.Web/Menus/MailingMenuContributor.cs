using Lazy.Abp.Mailing.Localization;
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
            var l = context.GetLocalizer<MailingResource>();
            //Add main menu items.

            context.Menu.AddItem(
                new ApplicationMenuItem(MailingMenus.MailTask, l["Menu:MailTask"], "/Mailing/MailTasks/MailTask")
            );
            context.Menu.AddItem(
                new ApplicationMenuItem(MailingMenus.SmtpAccount, l["Menu:SmtpAccount"], "/Mailing/SmtpAccounts/SmtpAccount")
            );
            context.Menu.AddItem(
                new ApplicationMenuItem(MailingMenus.Template, l["Menu:Template"], "/Mailing/Templates/Template")
            );

            return Task.CompletedTask;
        }
    }
}