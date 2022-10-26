using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElevatorReport.Data.Migrations
{
    public partial class _202210241629 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 203)
                .OldAnnotation("Relational:ColumnOrder", 204);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 204)
                .OldAnnotation("Relational:ColumnOrder", 205);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 201)
                .OldAnnotation("Relational:ColumnOrder", 202);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 202)
                .OldAnnotation("Relational:ColumnOrder", 203);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Relational:ColumnOrder", 201);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Users",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Users",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 204)
                .OldAnnotation("Relational:ColumnOrder", 203);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifiedBy",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 205)
                .OldAnnotation("Relational:ColumnOrder", 204);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 202)
                .OldAnnotation("Relational:ColumnOrder", 201);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 203)
                .OldAnnotation("Relational:ColumnOrder", 202);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 201)
                .OldAnnotation("Relational:ColumnOrder", 0);
        }
    }
}
