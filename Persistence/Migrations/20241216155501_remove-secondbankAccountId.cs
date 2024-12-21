using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removesecondbankAccountId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondBankAccountId",
                table: "Transaction");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 681, DateTimeKind.Local).AddTicks(7509),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 266, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 681, DateTimeKind.Local).AddTicks(6960),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 266, DateTimeKind.Local).AddTicks(395));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 681, DateTimeKind.Local).AddTicks(7340),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 266, DateTimeKind.Local).AddTicks(748));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 681, DateTimeKind.Local).AddTicks(4531),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 265, DateTimeKind.Local).AddTicks(7985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 681, DateTimeKind.Local).AddTicks(4216),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 265, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 677, DateTimeKind.Local).AddTicks(1286),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(7767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 677, DateTimeKind.Local).AddTicks(996),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 678, DateTimeKind.Local).AddTicks(7929),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 263, DateTimeKind.Local).AddTicks(3592));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 678, DateTimeKind.Local).AddTicks(7570),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 263, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 676, DateTimeKind.Local).AddTicks(9186),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 676, DateTimeKind.Local).AddTicks(8630),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(5687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 676, DateTimeKind.Local).AddTicks(5295),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 676, DateTimeKind.Local).AddTicks(4963),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(2031));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 266, DateTimeKind.Local).AddTicks(900),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 681, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 266, DateTimeKind.Local).AddTicks(395),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 681, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 266, DateTimeKind.Local).AddTicks(748),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 681, DateTimeKind.Local).AddTicks(7340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 265, DateTimeKind.Local).AddTicks(7985),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 681, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 265, DateTimeKind.Local).AddTicks(7722),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 681, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(7767),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 677, DateTimeKind.Local).AddTicks(1286));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(7513),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 677, DateTimeKind.Local).AddTicks(996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 263, DateTimeKind.Local).AddTicks(3592),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 678, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 263, DateTimeKind.Local).AddTicks(3251),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 678, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.AddColumn<Guid>(
                name: "SecondBankAccountId",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(5980),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 676, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(5687),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 676, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(2360),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 676, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 16, 19, 23, 27, 261, DateTimeKind.Local).AddTicks(2031),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 16, 19, 25, 0, 676, DateTimeKind.Local).AddTicks(4963));
        }
    }
}
