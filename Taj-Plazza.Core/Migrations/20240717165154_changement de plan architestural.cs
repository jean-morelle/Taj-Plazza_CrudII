using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TajPlazza.Core.Migrations
{
    /// <inheritdoc />
    public partial class changementdeplanarchitestural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Evenements_EvenementId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Utilisateurs_UtilisateurId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_EvenementId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UtilisateurId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DateDeReservation",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EvenementId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Activites",
                table: "EvenementReservers");

            migrationBuilder.DropColumn(
                name: "DateDebut",
                table: "EvenementReservers");

            migrationBuilder.DropColumn(
                name: "DateFin",
                table: "EvenementReservers");

            migrationBuilder.DropColumn(
                name: "LieuEvenement",
                table: "EvenementReservers");

            migrationBuilder.RenameColumn(
                name: "UtilisateurId",
                table: "Reservations",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "NombreDePersonne",
                table: "Reservations",
                newName: "CategorieId");

            migrationBuilder.AddColumn<string>(
                name: "AccessoireAjouter",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Desciption",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageURl",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Evenements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "NombreDePersonne",
                table: "Evenements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NoteASavoir",
                table: "Evenements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NombreDePersonne",
                table: "EvenementReservers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "EvenementReservers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCategorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CategorieId",
                table: "Reservations",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_EvenementReservers_ReservationId",
                table: "EvenementReservers",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvenementReservers_Reservations_ReservationId",
                table: "EvenementReservers",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Categories_CategorieId",
                table: "Reservations",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvenementReservers_Reservations_ReservationId",
                table: "EvenementReservers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Categories_CategorieId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CategorieId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_EvenementReservers_ReservationId",
                table: "EvenementReservers");

            migrationBuilder.DropColumn(
                name: "AccessoireAjouter",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Desciption",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ImageURl",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "NombreDePersonne",
                table: "Evenements");

            migrationBuilder.DropColumn(
                name: "NoteASavoir",
                table: "Evenements");

            migrationBuilder.DropColumn(
                name: "NombreDePersonne",
                table: "EvenementReservers");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "EvenementReservers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "Reservations",
                newName: "UtilisateurId");

            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "Reservations",
                newName: "NombreDePersonne");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateDeReservation",
                table: "Reservations",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "EvenementId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Evenements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Activites",
                table: "EvenementReservers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateDebut",
                table: "EvenementReservers",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateFin",
                table: "EvenementReservers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LieuEvenement",
                table: "EvenementReservers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EvenementId",
                table: "Reservations",
                column: "EvenementId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UtilisateurId",
                table: "Reservations",
                column: "UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_ClientId",
                table: "Reservations",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Evenements_EvenementId",
                table: "Reservations",
                column: "EvenementId",
                principalTable: "Evenements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Utilisateurs_UtilisateurId",
                table: "Reservations",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
