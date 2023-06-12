using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudapp.Migrations
{
    /// <inheritdoc />
    public partial class Employeewithloginmodelnulable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemember",
                table: "sinup_Logins");

            migrationBuilder.AlterColumn<long>(
                name: "phone",
                table: "sinup_Logins",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "phone",
                table: "sinup_Logins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemember",
                table: "sinup_Logins",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
