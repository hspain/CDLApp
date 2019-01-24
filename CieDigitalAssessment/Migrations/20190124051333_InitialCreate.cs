using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CieDigitalAssessment.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(unicode: false, nullable: false),
                    LastName = table.Column<string>(unicode: false, nullable: false),
                    AddressCity = table.Column<string>(unicode: false, nullable: false),
                    AddressState = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    AddressZip = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    AddressStreet = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AddressStreet = table.Column<string>(unicode: false, nullable: false),
                    AddressCity = table.Column<string>(unicode: false, nullable: false),
                    AddressZip = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    AddressName = table.Column<string>(unicode: false, nullable: false),
                    Nickname = table.Column<string>(unicode: false, nullable: false),
                    AddressState = table.Column<string>(unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(unicode: false, nullable: false),
                    DateMade = table.Column<DateTime>(type: "datetime", nullable: false),
                    Director = table.Column<string>(unicode: false, nullable: false),
                    BoxArtURL = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieCopyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCopyStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalBoxStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalBoxStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Username = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(unicode: false, nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateLoggedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    StripeToken = table.Column<string>(unicode: false, nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_81",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentalBox",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_42",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_36",
                        column: x => x.StatusId,
                        principalTable: "RentalBoxStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DateTransacted = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(15, 2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(15, 2)", nullable: false),
                    TransactionStatusId = table.Column<int>(nullable: false),
                    TransactionTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_108",
                        column: x => x.TransactionStatusId,
                        principalTable: "TransactionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_115",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieCopy",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    RentalBoxId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    MovieCopyStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCopy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_60",
                        column: x => x.MovieCopyStatus,
                        principalTable: "MovieCopyStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_53",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_50",
                        column: x => x.RentalBoxId,
                        principalTable: "RentalBox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMovieCopy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    MovieCopyId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMovieCopy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_69",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_66",
                        column: x => x.MovieCopyId,
                        principalTable: "MovieCopy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionMovieCopy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    MovieCopyId = table.Column<int>(nullable: false),
                    TransactionId = table.Column<int>(nullable: false),
                    MovieAmount = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionMovieCopy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_93",
                        column: x => x.MovieCopyId,
                        principalTable: "MovieCopy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_99",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fkIdx_69",
                table: "CustomerMovieCopy",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_66",
                table: "CustomerMovieCopy",
                column: "MovieCopyId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_60",
                table: "MovieCopy",
                column: "MovieCopyStatus");

            migrationBuilder.CreateIndex(
                name: "fkIdx_53",
                table: "MovieCopy",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_50",
                table: "MovieCopy",
                column: "RentalBoxId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_42",
                table: "RentalBox",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_36",
                table: "RentalBox",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_108",
                table: "Transaction",
                column: "TransactionStatusId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_115",
                table: "Transaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_93",
                table: "TransactionMovieCopy",
                column: "MovieCopyId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_99",
                table: "TransactionMovieCopy",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_81",
                table: "User",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerMovieCopy");

            migrationBuilder.DropTable(
                name: "TransactionMovieCopy");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MovieCopy");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "MovieCopyStatus");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "RentalBox");

            migrationBuilder.DropTable(
                name: "TransactionStatus");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "RentalBoxStatus");
        }
    }
}
