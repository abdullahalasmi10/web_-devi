using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B201210597.Migrations
{
    public partial class cc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_salons_Doctors_DoctorId",
                table: "salons");

            migrationBuilder.DropTable(
                name: "DoctorSonRandevu");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "salons",
                newName: "koaforId");

            migrationBuilder.RenameIndex(
                name: "IX_salons_DoctorId",
                table: "salons",
                newName: "IX_salons_koaforId");

            migrationBuilder.RenameColumn(
                name: "Doctor",
                table: "Randevular",
                newName: "koafor");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Appointments",
                newName: "koaforId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                newName: "IX_Appointments_koaforId");

            migrationBuilder.CreateTable(
                name: "koafors",
                columns: table => new
                {
                    koaforId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    koaforName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salonId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_koafors", x => x.koaforId);
                    table.ForeignKey(
                        name: "FK_koafors_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId");
                    table.ForeignKey(
                        name: "FK_koafors_salons_salonId",
                        column: x => x.salonId,
                        principalTable: "salons",
                        principalColumn: "salonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SonRandevukoafor",
                columns: table => new
                {
                    Randevularid = table.Column<int>(type: "int", nullable: false),
                    koaforskoaforId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SonRandevukoafor", x => new { x.Randevularid, x.koaforskoaforId });
                    table.ForeignKey(
                        name: "FK_SonRandevukoafor_koafors_koaforskoaforId",
                        column: x => x.koaforskoaforId,
                        principalTable: "koafors",
                        principalColumn: "koaforId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SonRandevukoafor_Randevular_Randevularid",
                        column: x => x.Randevularid,
                        principalTable: "Randevular",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_koafors_AppointmentId",
                table: "koafors",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_koafors_salonId",
                table: "koafors",
                column: "salonId");

            migrationBuilder.CreateIndex(
                name: "IX_SonRandevukoafor_koaforskoaforId",
                table: "SonRandevukoafor",
                column: "koaforskoaforId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_koafors_koaforId",
                table: "Appointments",
                column: "koaforId",
                principalTable: "koafors",
                principalColumn: "koaforId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salons_koafors_koaforId",
                table: "salons",
                column: "koaforId",
                principalTable: "koafors",
                principalColumn: "koaforId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_koafors_koaforId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_salons_koafors_koaforId",
                table: "salons");

            migrationBuilder.DropTable(
                name: "SonRandevukoafor");

            migrationBuilder.DropTable(
                name: "koafors");

            migrationBuilder.RenameColumn(
                name: "koaforId",
                table: "salons",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_salons_koaforId",
                table: "salons",
                newName: "IX_salons_DoctorId");

            migrationBuilder.RenameColumn(
                name: "koafor",
                table: "Randevular",
                newName: "Doctor");

            migrationBuilder.RenameColumn(
                name: "koaforId",
                table: "Appointments",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_koaforId",
                table: "Appointments",
                newName: "IX_Appointments_DoctorId");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salonId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId");
                    table.ForeignKey(
                        name: "FK_Doctors_salons_salonId",
                        column: x => x.salonId,
                        principalTable: "salons",
                        principalColumn: "salonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSonRandevu",
                columns: table => new
                {
                    DoctorsDoctorId = table.Column<int>(type: "int", nullable: false),
                    Randevularid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSonRandevu", x => new { x.DoctorsDoctorId, x.Randevularid });
                    table.ForeignKey(
                        name: "FK_DoctorSonRandevu_Doctors_DoctorsDoctorId",
                        column: x => x.DoctorsDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSonRandevu_Randevular_Randevularid",
                        column: x => x.Randevularid,
                        principalTable: "Randevular",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AppointmentId",
                table: "Doctors",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_salonId",
                table: "Doctors",
                column: "salonId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSonRandevu_Randevularid",
                table: "DoctorSonRandevu",
                column: "Randevularid");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salons_Doctors_DoctorId",
                table: "salons",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");
        }
    }
}
