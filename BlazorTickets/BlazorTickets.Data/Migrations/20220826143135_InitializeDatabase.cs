﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorTickets.Data.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "varchar(50)", nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(150)", nullable: true),
                    Mail = table.Column<string>(type: "varchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "varchar(50)", nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(150)", nullable: true),
                    Mail = table.Column<string>(type: "varchar(300)", nullable: true),
                    Department = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketStatuses_SystemUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketStatuses_SystemUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketTypes_SystemUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketTypes_SystemUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    RequestedForId = table.Column<int>(type: "int", nullable: true),
                    Owner = table.Column<string>(type: "varchar(150)", nullable: false),
                    OwnerGroupId = table.Column<int>(type: "int", nullable: true),
                    OwnerUserId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    StatusDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_SystemGroups_OwnerGroupId",
                        column: x => x.OwnerGroupId,
                        principalTable: "SystemGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_SystemUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_SystemUsers_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_SystemUsers_RequestedForId",
                        column: x => x.RequestedForId,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_SystemUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_TicketStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TicketStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_TicketTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TicketTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<long>(type: "bigint", nullable: true),
                    FileContentType = table.Column<string>(type: "varchar(50)", nullable: false),
                    FileName = table.Column<string>(type: "varchar(50)", nullable: false),
                    FileLocalPath = table.Column<string>(type: "varchar(500)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketAttachments_SystemUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketAttachments_SystemUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketAttachments_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketHistorylogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<long>(type: "bigint", nullable: true),
                    ChangedById = table.Column<int>(type: "int", nullable: true),
                    ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OldStatusId = table.Column<int>(type: "int", nullable: true),
                    NewStatusId = table.Column<int>(type: "int", nullable: true),
                    ChangeUserDesc = table.Column<string>(type: "varchar(1000)", nullable: false),
                    ChangeSystemDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelegatedGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketHistorylogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketHistorylogs_SystemGroups_DelegatedGroupId",
                        column: x => x.DelegatedGroupId,
                        principalTable: "SystemGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketHistorylogs_SystemUsers_ChangedById",
                        column: x => x.ChangedById,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketHistorylogs_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketHistorylogs_TicketStatuses_NewStatusId",
                        column: x => x.NewStatusId,
                        principalTable: "TicketStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketHistorylogs_TicketStatuses_OldStatusId",
                        column: x => x.OldStatusId,
                        principalTable: "TicketStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<long>(type: "bigint", nullable: true),
                    Body = table.Column<string>(type: "ntext", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketMessages_SystemUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketMessages_SystemUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "SystemUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketMessages_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachments_CreatedById",
                table: "TicketAttachments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachments_TicketId",
                table: "TicketAttachments",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachments_UpdatedById",
                table: "TicketAttachments",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistorylogs_ChangedById",
                table: "TicketHistorylogs",
                column: "ChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistorylogs_DelegatedGroupId",
                table: "TicketHistorylogs",
                column: "DelegatedGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistorylogs_NewStatusId",
                table: "TicketHistorylogs",
                column: "NewStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistorylogs_OldStatusId",
                table: "TicketHistorylogs",
                column: "OldStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistorylogs_TicketId",
                table: "TicketHistorylogs",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessages_CreatedById",
                table: "TicketMessages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessages_TicketId",
                table: "TicketMessages",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessages_UpdatedById",
                table: "TicketMessages",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatedById",
                table: "Tickets",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OwnerGroupId",
                table: "Tickets",
                column: "OwnerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OwnerUserId",
                table: "Tickets",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RequestedForId",
                table: "Tickets",
                column: "RequestedForId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TypeId",
                table: "Tickets",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UpdatedById",
                table: "Tickets",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatuses_CreatedById",
                table: "TicketStatuses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatuses_UpdatedById",
                table: "TicketStatuses",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_CreatedById",
                table: "TicketTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_UpdatedById",
                table: "TicketTypes",
                column: "UpdatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketAttachments");

            migrationBuilder.DropTable(
                name: "TicketHistorylogs");

            migrationBuilder.DropTable(
                name: "TicketMessages");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "SystemGroups");

            migrationBuilder.DropTable(
                name: "TicketStatuses");

            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropTable(
                name: "SystemUsers");
        }
    }
}
