using Microsoft.EntityFrameworkCore.Migrations;

namespace Lazy.Abp.Mailing.Migrations
{
    public partial class MailBody : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "MailingMailTasks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "MailingMailTasks");
        }
    }
}
