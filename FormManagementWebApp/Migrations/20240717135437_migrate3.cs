using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormManagementWebApp.Migrations
{
    /// <inheritdoc />
    public partial class migrate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Forms_FormId",
                table: "Fields");

            migrationBuilder.AlterColumn<Guid>(
                name: "FormId",
                table: "Fields",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Forms_FormId",
                table: "Fields",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Forms_FormId",
                table: "Fields");

            migrationBuilder.AlterColumn<Guid>(
                name: "FormId",
                table: "Fields",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Forms_FormId",
                table: "Fields",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id");
        }
    }
}
