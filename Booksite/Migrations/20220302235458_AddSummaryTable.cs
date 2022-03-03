﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Booksite.Migrations
{
    public partial class AddSummaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         //   migrationBuilder.CreateTable(
           //     name: "Books",
             //   columns: table => new
               // {
                 //   BookId = table.Column<long>(nullable: false)
                   //     .Annotation("Sqlite:Autoincrement", true),
              //      Title = table.Column<string>(nullable: true),
                //    Author = table.Column<string>(nullable: true),
               //     Publisher = table.Column<string>(nullable: true),
               //     Isbn = table.Column<string>(nullable: true),
               //     Classification = table.Column<string>(nullable: true),
             //       Category = table.Column<string>(nullable: true),
                 //   PageCount = table.Column<int>(nullable: false),
                 ///   Price = table.Column<double>(nullable: false)
              ///  },
          ///      constraints: table =>
             //   {
               //     table.PrimaryKey("PK_Books", x => x.BookId);
              //  });

            migrationBuilder.CreateTable(
                name: "Summary",
                columns: table => new
                {
                    SummaryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summary", x => x.SummaryId);
                });

            migrationBuilder.CreateTable(
                name: "BasketLineItem",
                columns: table => new
                {
                    LineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    SummaryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketLineItem", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_BasketLineItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketLineItem_Summary_SummaryId",
                        column: x => x.SummaryId,
                        principalTable: "Summary",
                        principalColumn: "SummaryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_BookId",
                table: "BasketLineItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_SummaryId",
                table: "BasketLineItem",
                column: "SummaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketLineItem");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Summary");
        }
    }
}