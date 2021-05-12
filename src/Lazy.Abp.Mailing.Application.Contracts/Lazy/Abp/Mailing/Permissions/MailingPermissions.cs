using Volo.Abp.Reflection;

namespace Lazy.Abp.Mailing.Permissions
{
    public class MailingPermissions
    {
        public const string GroupName = "Mailing";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MailingPermissions));
        }

        public class Template
        {
            public const string Default = GroupName + ".Template";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class SmtpAccount
        {
            public const string Default = GroupName + ".SmtpAccount";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class MailTask
        {
            public const string Default = GroupName + ".MailTask";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}