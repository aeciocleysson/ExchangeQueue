using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeQueue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Exchange",
                table: "Queues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RountingKey",
                table: "Queues",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exchange",
                table: "Queues");

            migrationBuilder.DropColumn(
                name: "RountingKey",
                table: "Queues");
        }
    }
}
