using Lazy.Abp.Mailing.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.Mailing.Permissions
{
    public class MailingPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MailingPermissions.GroupName, L("Permission:Mailing"));

            var templatePermission = myGroup.AddPermission(MailingPermissions.Template.Default, L("Permission:Template"));
            templatePermission.AddChild(MailingPermissions.Template.Create, L("Permission:Create"));
            templatePermission.AddChild(MailingPermissions.Template.Update, L("Permission:Update"));
            templatePermission.AddChild(MailingPermissions.Template.Delete, L("Permission:Delete"));

            var smtpAccountPermission = myGroup.AddPermission(MailingPermissions.SmtpAccount.Default, L("Permission:SmtpAccount"));
            smtpAccountPermission.AddChild(MailingPermissions.SmtpAccount.Create, L("Permission:Create"));
            smtpAccountPermission.AddChild(MailingPermissions.SmtpAccount.Update, L("Permission:Update"));
            smtpAccountPermission.AddChild(MailingPermissions.SmtpAccount.Delete, L("Permission:Delete"));

            var mailTaskPermission = myGroup.AddPermission(MailingPermissions.MailTask.Default, L("Permission:MailTask"));
            mailTaskPermission.AddChild(MailingPermissions.MailTask.Create, L("Permission:Create"));
            mailTaskPermission.AddChild(MailingPermissions.MailTask.Update, L("Permission:Update"));
            mailTaskPermission.AddChild(MailingPermissions.MailTask.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MailingResource>(name);
        }
    }
}