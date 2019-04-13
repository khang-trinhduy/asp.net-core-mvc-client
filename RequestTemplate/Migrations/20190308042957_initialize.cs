using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RequestTemplate.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    AppliedPosition = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Kind = table.Column<int>(nullable: false),
                    FlowId = table.Column<int>(nullable: true),
                    RequesterId = table.Column<Guid>(nullable: true),
                    Contents = table.Column<string>(nullable: true),
                    File0 = table.Column<string>(nullable: true),
                    File1 = table.Column<string>(nullable: true),
                    File2 = table.Column<string>(nullable: true),
                    File3 = table.Column<string>(nullable: true),
                    File4 = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ApplicantId = table.Column<int>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Product = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestId = table.Column<int>(nullable: true),
                    Start = table.Column<int>(nullable: false),
                    End = table.Column<int>(nullable: false),
                    CurrentStage = table.Column<string>(nullable: true),
                    Stage1 = table.Column<int>(nullable: false),
                    Name1 = table.Column<string>(nullable: true),
                    Task1 = table.Column<string>(nullable: true),
                    Assignee1 = table.Column<string>(nullable: true),
                    Owner1 = table.Column<string>(nullable: true),
                    File1 = table.Column<string>(nullable: true),
                    Stage2 = table.Column<int>(nullable: false),
                    Name2 = table.Column<string>(nullable: true),
                    Task2 = table.Column<string>(nullable: true),
                    Assignee2 = table.Column<string>(nullable: true),
                    Owner2 = table.Column<string>(nullable: true),
                    File2 = table.Column<string>(nullable: true),
                    Stage3 = table.Column<int>(nullable: false),
                    Name3 = table.Column<string>(nullable: true),
                    Task3 = table.Column<string>(nullable: true),
                    Assignee3 = table.Column<string>(nullable: true),
                    Owner3 = table.Column<string>(nullable: true),
                    File3 = table.Column<string>(nullable: true),
                    Stage4 = table.Column<int>(nullable: false),
                    Name4 = table.Column<string>(nullable: true),
                    Task4 = table.Column<string>(nullable: true),
                    Assignee4 = table.Column<string>(nullable: true),
                    Owner4 = table.Column<string>(nullable: true),
                    File4 = table.Column<string>(nullable: true),
                    Stage5 = table.Column<int>(nullable: false),
                    Name5 = table.Column<string>(nullable: true),
                    Task5 = table.Column<string>(nullable: true),
                    Assignee5 = table.Column<string>(nullable: true),
                    Owner5 = table.Column<string>(nullable: true),
                    File5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flows_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flows_RequestId",
                table: "Flows",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ApplicantId",
                table: "Requests",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FlowId",
                table: "Requests",
                column: "FlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Flows_FlowId",
                table: "Requests",
                column: "FlowId",
                principalTable: "Flows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flows_Requests_RequestId",
                table: "Flows");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Flows");
        }
    }
}
