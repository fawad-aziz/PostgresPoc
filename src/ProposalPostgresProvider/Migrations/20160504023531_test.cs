using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ProposalPostgresProvider.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    ActivityTypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.ActivityTypeId);
                });
            migrationBuilder.CreateTable(
                name: "ProposalState",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalState", x => x.StateId);
                });
            migrationBuilder.CreateTable(
                name: "ProposalType",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalType", x => x.TypeId);
                });
            migrationBuilder.CreateTable(
                name: "Proposal",
                columns: table => new
                {
                    ProposalId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ActivityTypeActivityTypeId = table.Column<int>(nullable: true),
                    CampaignId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CurrencyCode = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    ProgramId = table.Column<int>(nullable: false),
                    ProposalStateStateId = table.Column<int>(nullable: true),
                    ProposalTypeTypeId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposal", x => x.ProposalId);
                    table.ForeignKey(
                        name: "FK_Proposal_ActivityType_ActivityTypeActivityTypeId",
                        column: x => x.ActivityTypeActivityTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "ActivityTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposal_ProposalState_ProposalStateStateId",
                        column: x => x.ProposalStateStateId,
                        principalTable: "ProposalState",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposal_ProposalType_ProposalTypeTypeId",
                        column: x => x.ProposalTypeTypeId,
                        principalTable: "ProposalType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Proposal");
            migrationBuilder.DropTable("ActivityType");
            migrationBuilder.DropTable("ProposalState");
            migrationBuilder.DropTable("ProposalType");
        }
    }
}
