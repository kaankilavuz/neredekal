﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeredeKal.HotelService.Persistence.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Hotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppHotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ContactName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ContactSurname = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ContactInformation_Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContactInformation_Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location_City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Location_District = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Location_Address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppHotels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppHotels_Id",
                table: "AppHotels",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppHotels");
        }
    }
}
