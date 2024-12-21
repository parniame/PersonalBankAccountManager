using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class maketillThisDatedatetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(8092),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 810, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(7511),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 810, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(7917),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 810, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TillThisDate",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SmallDateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(5082),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 809, DateTimeKind.Local).AddTicks(9215));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(4766),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 809, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 621, DateTimeKind.Local).AddTicks(1189),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 807, DateTimeKind.Local).AddTicks(3178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 621, DateTimeKind.Local).AddTicks(915),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 807, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 622, DateTimeKind.Local).AddTicks(8281),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 809, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 622, DateTimeKind.Local).AddTicks(7872),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 809, DateTimeKind.Local).AddTicks(1027));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(9322),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 807, DateTimeKind.Local).AddTicks(1264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(9017),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 807, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(5587),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 806, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(5230),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 806, DateTimeKind.Local).AddTicks(6813));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 810, DateTimeKind.Local).AddTicks(2538),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(8092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 810, DateTimeKind.Local).AddTicks(1905),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 810, DateTimeKind.Local).AddTicks(2299),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(7917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TillThisDate",
                table: "TransactionPlan",
                type: "SmallDateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 809, DateTimeKind.Local).AddTicks(9215),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(5082));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 809, DateTimeKind.Local).AddTicks(8867),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 623, DateTimeKind.Local).AddTicks(4766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 807, DateTimeKind.Local).AddTicks(3178),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 621, DateTimeKind.Local).AddTicks(1189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 807, DateTimeKind.Local).AddTicks(2897),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 621, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 809, DateTimeKind.Local).AddTicks(1413),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 622, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 809, DateTimeKind.Local).AddTicks(1027),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 622, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 807, DateTimeKind.Local).AddTicks(1264),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 807, DateTimeKind.Local).AddTicks(862),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(9017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 806, DateTimeKind.Local).AddTicks(7205),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(5587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 17, 21, 25, 55, 806, DateTimeKind.Local).AddTicks(6813),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 18, 16, 21, 38, 620, DateTimeKind.Local).AddTicks(5230));
        }
    }
}
