using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectoryService.Infrastructure.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class DS3b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "positions",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "positions",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "locations",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "locations",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "departments_locations",
                newName: "location_id");

            migrationBuilder.RenameColumn(
                name: "IsPrimary",
                table: "departments_locations",
                newName: "is_primary");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "departments_locations",
                newName: "department_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "departments",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "departments",
                newName: "parent_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "departments",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "department_positions",
                newName: "position_id");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "department_positions",
                newName: "department_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "positions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "positions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "locations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "locations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "departments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "departments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "timezone('utc', now())",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateIndex(
                name: "IX_departments_locations_department_id",
                table: "departments_locations",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_departments_locations_location_id",
                table: "departments_locations",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_departments_parent_id",
                table: "departments",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_department_positions_department_id",
                table: "department_positions",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_department_positions_position_id",
                table: "department_positions",
                column: "position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_department_positions_departments_department_id",
                table: "department_positions",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_department_positions_positions_position_id",
                table: "department_positions",
                column: "position_id",
                principalTable: "positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_departments_parent_id",
                table: "departments",
                column: "parent_id",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_locations_departments_department_id",
                table: "departments_locations",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_locations_locations_location_id",
                table: "departments_locations",
                column: "location_id",
                principalTable: "locations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_department_positions_departments_department_id",
                table: "department_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_department_positions_positions_position_id",
                table: "department_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_departments_parent_id",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_locations_departments_department_id",
                table: "departments_locations");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_locations_locations_location_id",
                table: "departments_locations");

            migrationBuilder.DropIndex(
                name: "IX_departments_locations_department_id",
                table: "departments_locations");

            migrationBuilder.DropIndex(
                name: "IX_departments_locations_location_id",
                table: "departments_locations");

            migrationBuilder.DropIndex(
                name: "IX_departments_parent_id",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_department_positions_department_id",
                table: "department_positions");

            migrationBuilder.DropIndex(
                name: "IX_department_positions_position_id",
                table: "department_positions");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "positions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "positions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "locations",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "locations",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "location_id",
                table: "departments_locations",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "is_primary",
                table: "departments_locations",
                newName: "IsPrimary");

            migrationBuilder.RenameColumn(
                name: "department_id",
                table: "departments_locations",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "departments",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                table: "departments",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "departments",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "position_id",
                table: "department_positions",
                newName: "PositionId");

            migrationBuilder.RenameColumn(
                name: "department_id",
                table: "department_positions",
                newName: "DepartmentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "positions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "timezone('utc', now())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "positions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "timezone('utc', now())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "locations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "timezone('utc', now())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "locations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "timezone('utc', now())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "departments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "timezone('utc', now())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "departments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "timezone('utc', now())");
        }
    }
}
