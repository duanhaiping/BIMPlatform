using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BIMPlatform.Migrations
{
    public partial class updateProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConstructionUnits",
                table: "Pro_Project");

            migrationBuilder.DropColumn(
                name: "LaunchUser",
                table: "Pro_Project");

            migrationBuilder.AddColumn<float>(
                name: "Area",
                table: "Pro_Project",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ConsultingUnit",
                table: "Pro_Project",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Principal",
                table: "Pro_Project",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Pro_Project");

            migrationBuilder.DropColumn(
                name: "ConsultingUnit",
                table: "Pro_Project");

            migrationBuilder.DropColumn(
                name: "Principal",
                table: "Pro_Project");

            migrationBuilder.AddColumn<string>(
                name: "ConstructionUnits",
                table: "Pro_Project",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LaunchUser",
                table: "Pro_Project",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
