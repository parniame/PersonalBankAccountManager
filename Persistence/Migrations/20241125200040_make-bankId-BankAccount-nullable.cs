using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class makebankIdBankAccountnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 728, DateTimeKind.Local).AddTicks(190),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 992, DateTimeKind.Local).AddTicks(6005));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 727, DateTimeKind.Local).AddTicks(9535),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 992, DateTimeKind.Local).AddTicks(5351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 728, DateTimeKind.Local).AddTicks(7),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 992, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 725, DateTimeKind.Local).AddTicks(8049),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 725, DateTimeKind.Local).AddTicks(7610),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(5972));

            migrationBuilder.AlterColumn<Guid>(
                name: "BankId",
                table: "BankAccount",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 728, DateTimeKind.Local).AddTicks(190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 992, DateTimeKind.Local).AddTicks(5351),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 727, DateTimeKind.Local).AddTicks(9535));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 992, DateTimeKind.Local).AddTicks(5807),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 728, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(6358),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 725, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(5972),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 725, DateTimeKind.Local).AddTicks(7610));

            migrationBuilder.AlterColumn<Guid>(
                name: "BankId",
                table: "BankAccount",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
