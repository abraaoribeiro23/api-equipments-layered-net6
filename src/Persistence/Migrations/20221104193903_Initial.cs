using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emsh_equipment_model_state_hourly_earning",
                columns: table => new
                {
                    emsh_uuid_equipment_model_state_hourly_earning = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emsh_uuid_equipment_model = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emsh_uuid_equipment_state = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emsh_nm_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_emsh_equipment_model_state_hourly_earning", x => x.emsh_uuid_equipment_model_state_hourly_earning);
                });

            migrationBuilder.CreateTable(
                name: "eqmo_equipment_model",
                columns: table => new
                {
                    eqmo_uuid_equipment_model = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    eqmo_tx_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_eqmo_equipment_model", x => x.eqmo_uuid_equipment_model);
                });

            migrationBuilder.CreateTable(
                name: "eqst_equipment_state",
                columns: table => new
                {
                    eqst_uuid_equipment_state = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    eqst_tx_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    eqst_tx_color = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_eqst_equipment_state", x => x.eqst_uuid_equipment_state);
                });

            migrationBuilder.CreateTable(
                name: "equi_equipment",
                columns: table => new
                {
                    equi_uuid_equipment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    equi_tx_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    equi_uuid_equipment_model = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_equi_equipment", x => x.equi_uuid_equipment);
                    table.ForeignKey(
                        name: "FK_equi_equipment_eqmo_equipment_model_equi_uuid_equipment_model",
                        column: x => x.equi_uuid_equipment_model,
                        principalTable: "eqmo_equipment_model",
                        principalColumn: "eqmo_uuid_equipment_model",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "eqph_equipment_position_history",
                columns: table => new
                {
                    eqph_uuid_equipment_position_history = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    eqph_uuid_equipment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    eqph_dt_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    eqph_nm_lat = table.Column<double>(type: "float", nullable: false),
                    eqph_nm_lon = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_eqph_equipment_position_history", x => x.eqph_uuid_equipment_position_history);
                    table.ForeignKey(
                        name: "FK_eqph_equipment_position_history_equi_equipment_eqph_uuid_equipment",
                        column: x => x.eqph_uuid_equipment,
                        principalTable: "equi_equipment",
                        principalColumn: "equi_uuid_equipment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "eqsh_equipment_state_history",
                columns: table => new
                {
                    eqsh_uuid_equipment_state_history = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    eqsh_uuid_equipment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    eqsh_uuid_equipment_state = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    eqsh_dt_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_eqsh_equipment_state_history", x => x.eqsh_uuid_equipment_state_history);
                    table.ForeignKey(
                        name: "FK_eqsh_equipment_state_history_equi_equipment_eqsh_uuid_equipment",
                        column: x => x.eqsh_uuid_equipment,
                        principalTable: "equi_equipment",
                        principalColumn: "equi_uuid_equipment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eqph_equipment_position_history_eqph_uuid_equipment",
                table: "eqph_equipment_position_history",
                column: "eqph_uuid_equipment");

            migrationBuilder.CreateIndex(
                name: "IX_eqsh_equipment_state_history_eqsh_uuid_equipment",
                table: "eqsh_equipment_state_history",
                column: "eqsh_uuid_equipment");

            migrationBuilder.CreateIndex(
                name: "IX_equi_equipment_equi_uuid_equipment_model",
                table: "equi_equipment",
                column: "equi_uuid_equipment_model");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emsh_equipment_model_state_hourly_earning");

            migrationBuilder.DropTable(
                name: "eqph_equipment_position_history");

            migrationBuilder.DropTable(
                name: "eqsh_equipment_state_history");

            migrationBuilder.DropTable(
                name: "eqst_equipment_state");

            migrationBuilder.DropTable(
                name: "equi_equipment");

            migrationBuilder.DropTable(
                name: "eqmo_equipment_model");
        }
    }
}
