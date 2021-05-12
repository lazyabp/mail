namespace Lazy.Abp.Mailing
{
    public static class MailingDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Mailing";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Mailing";
    }
}
