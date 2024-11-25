using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addtraceablebank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 992, DateTimeKind.Local).AddTicks(6005),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 24, 20, 11, 20, 881, DateTimeKind.Local).AddTicks(9905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 992, DateTimeKind.Local).AddTicks(5351),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 24, 20, 11, 20, 881, DateTimeKind.Local).AddTicks(9299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 992, DateTimeKind.Local).AddTicks(5807),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 24, 20, 11, 20, 881, DateTimeKind.Local).AddTicks(9707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(6358),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 11, 24, 20, 11, 20, 880, DateTimeKind.Local).AddTicks(798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(5972),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 11, 24, 20, 11, 20, 880, DateTimeKind.Local).AddTicks(403));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorID",
                table: "Models.Entities.Bank",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatorID",
                table: "Models.Entities.Bank",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models.Entities.Bank_CreatorID",
                table: "Models.Entities.Bank",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Models.Entities.Bank_UpdatorID",
                table: "Models.Entities.Bank",
                column: "UpdatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Models.Entities.Bank_User_CreatorID",
                table: "Models.Entities.Bank",
                column: "CreatorID",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models.Entities.Bank_User_UpdatorID",
                table: "Models.Entities.Bank",
                column: "UpdatorID",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models.Entities.Bank_User_CreatorID",
                table: "Models.Entities.Bank");

            migrationBuilder.DropForeignKey(
                name: "FK_Models.Entities.Bank_User_UpdatorID",
                table: "Models.Entities.Bank");

            migrationBuilder.DropIndex(
                name: "IX_Models.Entities.Bank_CreatorID",
                table: "Models.Entities.Bank");

            migrationBuilder.DropIndex(
                name: "IX_Models.Entities.Bank_UpdatorID",
                table: "Models.Entities.Bank");

            migrationBuilder.DropColumn(
                name: "CreatorID",
                table: "Models.Entities.Bank");

            migrationBuilder.DropColumn(
                name: "UpdatorID",
                table: "Models.Entities.Bank");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 24, 20, 11, 20, 881, DateTimeKind.Local).AddTicks(9905),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 992, DateTimeKind.Local).AddTicks(6005));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 24, 20, 11, 20, 881, DateTimeKind.Local).AddTicks(9299),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 992, DateTimeKind.Local).AddTicks(5351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 24, 20, 11, 20, 881, DateTimeKind.Local).AddTicks(9707),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 992, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 24, 20, 11, 20, 880, DateTimeKind.Local).AddTicks(798),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 24, 20, 11, 20, 880, DateTimeKind.Local).AddTicks(403),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(5972));
        }
    }
}
