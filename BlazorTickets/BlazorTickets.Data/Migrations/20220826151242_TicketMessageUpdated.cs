using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorTickets.Data.Migrations
{
    public partial class TicketMessageUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fm",
                table: "TicketMessages",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TicketMessages",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "TicketMessages",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fm",
                table: "TicketMessages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TicketMessages");

            migrationBuilder.DropColumn(
                name: "To",
                table: "TicketMessages");
        }
    }
}
