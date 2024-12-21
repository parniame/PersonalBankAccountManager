using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addisPaidtotransactionPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 90, DateTimeKind.Local).AddTicks(1206),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(8092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 90, DateTimeKind.Local).AddTicks(615),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 90, DateTimeKind.Local).AddTicks(1004),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(7917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 89, DateTimeKind.Local).AddTicks(8145),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(5082));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 89, DateTimeKind.Local).AddTicks(7855),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(4766));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "TransactionPlan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 87, DateTimeKind.Local).AddTicks(4386),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 621, DateTimeKind.Local).AddTicks(1189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 87, DateTimeKind.Local).AddTicks(4151),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 621, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 89, DateTimeKind.Local).AddTicks(1276),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 622, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 89, DateTimeKind.Local).AddTicks(907),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 622, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 87, DateTimeKind.Local).AddTicks(2546),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 87, DateTimeKind.Local).AddTicks(2197),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(9017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 86, DateTimeKind.Local).AddTicks(8966),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(5587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 86, DateTimeKind.Local).AddTicks(8593),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(5230));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "TransactionPlan");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(8092),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 90, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(7511),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 90, DateTimeKind.Local).AddTicks(615));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(7917),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 90, DateTimeKind.Local).AddTicks(1004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(5082),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 89, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(4766),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 89, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 621, DateTimeKind.Local).AddTicks(1189),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 87, DateTimeKind.Local).AddTicks(4386));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 621, DateTimeKind.Local).AddTicks(915),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 87, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 622, DateTimeKind.Local).AddTicks(8281),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 89, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 622, DateTimeKind.Local).AddTicks(7872),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 89, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(9322),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 87, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(9017),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 87, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(5587),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 86, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(5230),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 19, 20, 5, 28, 86, DateTimeKind.Local).AddTicks(8593));
        }
    }
}
