using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityCodeFirst.Migrations
{
    public partial class TableClientAddedAndFilled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime", maxLength: 7, nullable: false),
                    CooperationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("INSERT INTO Client(FirstName,LastName,ContractDate,CooperationType) VALUES('Martin','Scorseze', '2012-03-06','Partial')");
            migrationBuilder.Sql("INSERT INTO Client(FirstName,LastName,ContractDate,CooperationType) VALUES('Patric','Stewart', GETDATE(),'Partial')");
            migrationBuilder.Sql("INSERT INTO Client(FirstName,LastName,ContractDate,CooperationType) VALUES('Jimmy','Hendrix', GETDATE(),'Partial')");
            migrationBuilder.Sql("INSERT INTO Client(FirstName,LastName,ContractDate,CooperationType) VALUES('Grayce','Kelly', GETDATE(),'SemiPartnership')");
            migrationBuilder.Sql("INSERT INTO Client(FirstName,LastName,ContractDate,CooperationType) VALUES('John','BonJovi', GETDATE(),'Full')");
            migrationBuilder.Sql("INSERT INTO Project(Name,Budget,StartedDate,ClientId) VALUES('Oslo','10000', GETDATE(),1)");
            migrationBuilder.Sql("INSERT INTO Project(Name,Budget,StartedDate,ClientId) VALUES('Praha','30000', GETDATE(),2)");
            migrationBuilder.Sql("INSERT INTO Project(Name,Budget,StartedDate,ClientId) VALUES('Helsinky','20000', GETDATE(),2)");
            migrationBuilder.Sql("INSERT INTO Project(Name,Budget,StartedDate,ClientId) VALUES('Berlin','40000', GETDATE(),3)");
            migrationBuilder.Sql("INSERT INTO Project(Name,Budget,StartedDate,ClientId) VALUES('Magdeburg','50000', GETDATE(),4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Budget", "Name", "StartedDate" },
                values: new object[] { 5, 4000m, "Laundry", new DateTime(2019, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
