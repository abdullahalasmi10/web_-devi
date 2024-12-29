using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B201210597.Migrations
{
    public partial class A : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salonId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Randevular");

            migrationBuilder.AddColumn<string>(
                name: "salon",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salon",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "Randevular");

            migrationBuilder.AddColumn<int>(
                name: "salonId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
