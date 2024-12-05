using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class makepictureuntraceble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Picture");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 923, DateTimeKind.Local).AddTicks(5688),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(5231));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 923, DateTimeKind.Local).AddTicks(5076),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 923, DateTimeKind.Local).AddTicks(5491),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(5017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 923, DateTimeKind.Local).AddTicks(2391),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 923, DateTimeKind.Local).AddTicks(2038),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(1744));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 918, DateTimeKind.Local).AddTicks(4934),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 918, DateTimeKind.Local).AddTicks(4590),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(5989));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 920, DateTimeKind.Local).AddTicks(2631),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 432, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 920, DateTimeKind.Local).AddTicks(2212),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 432, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 918, DateTimeKind.Local).AddTicks(2664),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 918, DateTimeKind.Local).AddTicks(2306),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 917, DateTimeKind.Local).AddTicks(8490),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 917, DateTimeKind.Local).AddTicks(8076),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(85));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(5231),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 923, DateTimeKind.Local).AddTicks(5688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(4596),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 923, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(5017),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 923, DateTimeKind.Local).AddTicks(5491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(2057),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 923, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(1744),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 923, DateTimeKind.Local).AddTicks(2038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(6293),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 918, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(5989),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 918, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 432, DateTimeKind.Local).AddTicks(3140),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 920, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 432, DateTimeKind.Local).AddTicks(2811),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 920, DateTimeKind.Local).AddTicks(2212));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Picture",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Picture",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(9646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(4326),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 918, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(3965),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 918, DateTimeKind.Local).AddTicks(2306));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(506),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 917, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(85),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 44, 13, 917, DateTimeKind.Local).AddTicks(8076));
        }
    }
}
