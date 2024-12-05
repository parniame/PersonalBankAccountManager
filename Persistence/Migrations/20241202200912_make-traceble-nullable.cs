using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class maketraceblenullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(4596),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(5017),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(1324));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(2057),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 152, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(1744),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 152, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(6293),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(5989),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 432, DateTimeKind.Local).AddTicks(3140),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(8816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 432, DateTimeKind.Local).AddTicks(2811),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(8455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Picture",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(9646),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(5452));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Picture",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(9320),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(5128));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(4326),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(3965),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(506),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(6200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(85),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(5752));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(1521),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(5231));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(915),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(1324),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(5017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 152, DateTimeKind.Local).AddTicks(8275),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 152, DateTimeKind.Local).AddTicks(7906),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 435, DateTimeKind.Local).AddTicks(1744));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(2092),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(1763),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(5989));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(8816),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 432, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(8455),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 432, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Picture",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(5452),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(9646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Picture",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(5128),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(83),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(9678),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(6200),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(5752),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 39, 12, 431, DateTimeKind.Local).AddTicks(85));
        }
    }
}
