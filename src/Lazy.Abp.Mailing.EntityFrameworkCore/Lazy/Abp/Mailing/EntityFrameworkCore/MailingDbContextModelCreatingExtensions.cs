using System;
using Lazy.Abp.Mailing.MailTasks;
using Lazy.Abp.Mailing.SmtpAccounts;
using Lazy.Abp.Mailing.Templates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.Mailing.EntityFrameworkCore
{
    public static class MailingDbContextModelCreatingExtensions
    {
        public static void ConfigureMailing(
            this ModelBuilder builder,
            Action<MailingModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MailingModelBuilderConfigurationOptions(
                MailingDbProperties.DbTablePrefix,
                MailingDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
            builder.Entity<Template>(b =>
            {
                b.ToTable(options.TablePrefix + "Templates", options.Schema);
                b.ConfigureByConvention();


                /* Configure more properties here */
            });


            builder.Entity<SmtpAccount>(b =>
            {
                b.ToTable(options.TablePrefix + "SmtpAccounts", options.Schema);
                b.ConfigureByConvention();


                /* Configure more properties here */
            });


            builder.Entity<MailTask>(b =>
            {
                b.ToTable(options.TablePrefix + "MailTasks", options.Schema);
                b.ConfigureByConvention();

                b.HasMany(q => q.Logs).WithOne().HasForeignKey(x => x.MailTaskId).IsRequired();
                /* Configure more properties here */
            });


            builder.Entity<MailLog>(b =>
            {
                b.ToTable(options.TablePrefix + "MailLogs", options.Schema);
                b.ConfigureByConvention();


                /* Configure more properties here */
            });
        }
    }
}