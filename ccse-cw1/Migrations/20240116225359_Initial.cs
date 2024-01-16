using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ccse_cw1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    MaxSpaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TourBookingId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RoomBookingId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tour_Booking_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tour_Booking_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room_Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Booking_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_Booking_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    RoomBookingId = table.Column<int>(type: "int", nullable: true),
                    TourBookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_Room_Booking_RoomBookingId",
                        column: x => x.RoomBookingId,
                        principalTable: "Room_Booking",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Discount_Tour_Booking_TourBookingId",
                        column: x => x.TourBookingId,
                        principalTable: "Tour_Booking",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b35b119-51a3-473b-93b3-87dd67ad38d8", null, "admin", "admin" },
                    { "415cc9ad-88f9-4780-9b08-1ff8f3637147", null, "customer", "customer" },
                    { "bed20bfa-f7b9-4b86-b452-35737bb9f826", null, "manager", "manager" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Description", "Name", "Operator" },
                values: new object[,]
                {
                    { 1, null, "Hilton London Hotel", "Hilton" },
                    { 2, null, "London Marriott Hotel", "Marriott" },
                    { 3, null, "Travelodge Brighton Seafront", "Travelodge" },
                    { 4, null, "Kings Hotel Brighton", "Kings Hotel" },
                    { 5, null, "Leonardo Hotel Brighton", "Leonardo" },
                    { 6, null, "Nevis Bank Inn, Fort William", "Nevis Bank Inn" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "HotelId", "Price", "RoomBookingId", "RoomType" },
                values: new object[,]
                {
                    { 1, 1, 375, null, "Single" },
                    { 2, 1, 775, null, "Double" },
                    { 3, 1, 950, null, "FamilySuite" },
                    { 4, 1, 375, null, "Single" },
                    { 5, 1, 775, null, "Double" },
                    { 6, 1, 950, null, "FamilySuite" },
                    { 7, 1, 375, null, "Single" },
                    { 8, 1, 775, null, "Double" },
                    { 9, 1, 950, null, "FamilySuite" },
                    { 10, 1, 375, null, "Single" },
                    { 11, 1, 775, null, "Double" },
                    { 12, 1, 950, null, "FamilySuite" },
                    { 13, 1, 375, null, "Single" },
                    { 14, 1, 775, null, "Double" },
                    { 15, 1, 950, null, "FamilySuite" },
                    { 16, 1, 375, null, "Single" },
                    { 17, 1, 775, null, "Double" },
                    { 18, 1, 950, null, "FamilySuite" },
                    { 19, 1, 375, null, "Single" },
                    { 20, 1, 775, null, "Double" },
                    { 21, 1, 950, null, "FamilySuite" },
                    { 22, 1, 375, null, "Single" },
                    { 23, 1, 775, null, "Double" },
                    { 24, 1, 950, null, "FamilySuite" },
                    { 25, 1, 375, null, "Single" },
                    { 26, 1, 775, null, "Double" },
                    { 27, 1, 950, null, "FamilySuite" },
                    { 28, 1, 375, null, "Single" },
                    { 29, 1, 775, null, "Double" },
                    { 30, 1, 950, null, "FamilySuite" },
                    { 31, 1, 375, null, "Single" },
                    { 32, 1, 775, null, "Double" },
                    { 33, 1, 950, null, "FamilySuite" },
                    { 34, 1, 375, null, "Single" },
                    { 35, 1, 775, null, "Double" },
                    { 36, 1, 950, null, "FamilySuite" },
                    { 37, 1, 375, null, "Single" },
                    { 38, 1, 775, null, "Double" },
                    { 39, 1, 950, null, "FamilySuite" },
                    { 40, 1, 375, null, "Single" },
                    { 41, 1, 775, null, "Double" },
                    { 42, 1, 950, null, "FamilySuite" },
                    { 43, 1, 375, null, "Single" },
                    { 44, 1, 775, null, "Double" },
                    { 45, 1, 950, null, "FamilySuite" },
                    { 46, 1, 375, null, "Single" },
                    { 47, 1, 775, null, "Double" },
                    { 48, 1, 950, null, "FamilySuite" },
                    { 49, 1, 375, null, "Single" },
                    { 50, 1, 775, null, "Double" },
                    { 51, 1, 950, null, "FamilySuite" },
                    { 52, 1, 375, null, "Single" },
                    { 53, 1, 775, null, "Double" },
                    { 54, 1, 950, null, "FamilySuite" },
                    { 55, 1, 375, null, "Single" },
                    { 56, 1, 775, null, "Double" },
                    { 57, 1, 950, null, "FamilySuite" },
                    { 58, 1, 375, null, "Single" },
                    { 59, 1, 775, null, "Double" },
                    { 60, 1, 950, null, "FamilySuite" },
                    { 61, 2, 300, null, "Single" },
                    { 62, 2, 500, null, "Double" },
                    { 63, 2, 900, null, "FamilySuite" },
                    { 64, 2, 300, null, "Single" },
                    { 65, 2, 500, null, "Double" },
                    { 66, 2, 900, null, "FamilySuite" },
                    { 67, 2, 300, null, "Single" },
                    { 68, 2, 500, null, "Double" },
                    { 69, 2, 900, null, "FamilySuite" },
                    { 70, 2, 300, null, "Single" },
                    { 71, 2, 500, null, "Double" },
                    { 72, 2, 900, null, "FamilySuite" },
                    { 73, 2, 300, null, "Single" },
                    { 74, 2, 500, null, "Double" },
                    { 75, 2, 900, null, "FamilySuite" },
                    { 76, 2, 300, null, "Single" },
                    { 77, 2, 500, null, "Double" },
                    { 78, 2, 900, null, "FamilySuite" },
                    { 79, 2, 300, null, "Single" },
                    { 80, 2, 500, null, "Double" },
                    { 81, 2, 900, null, "FamilySuite" },
                    { 82, 2, 300, null, "Single" },
                    { 83, 2, 500, null, "Double" },
                    { 84, 2, 900, null, "FamilySuite" },
                    { 85, 2, 300, null, "Single" },
                    { 86, 2, 500, null, "Double" },
                    { 87, 2, 900, null, "FamilySuite" },
                    { 88, 2, 300, null, "Single" },
                    { 89, 2, 500, null, "Double" },
                    { 90, 2, 900, null, "FamilySuite" },
                    { 91, 2, 300, null, "Single" },
                    { 92, 2, 500, null, "Double" },
                    { 93, 2, 900, null, "FamilySuite" },
                    { 94, 2, 300, null, "Single" },
                    { 95, 2, 500, null, "Double" },
                    { 96, 2, 900, null, "FamilySuite" },
                    { 97, 2, 300, null, "Single" },
                    { 98, 2, 500, null, "Double" },
                    { 99, 2, 900, null, "FamilySuite" },
                    { 100, 2, 300, null, "Single" },
                    { 101, 2, 500, null, "Double" },
                    { 102, 2, 900, null, "FamilySuite" },
                    { 103, 2, 300, null, "Single" },
                    { 104, 2, 500, null, "Double" },
                    { 105, 2, 900, null, "FamilySuite" },
                    { 106, 2, 300, null, "Single" },
                    { 107, 2, 500, null, "Double" },
                    { 108, 2, 900, null, "FamilySuite" },
                    { 109, 2, 300, null, "Single" },
                    { 110, 2, 500, null, "Double" },
                    { 111, 2, 900, null, "FamilySuite" },
                    { 112, 2, 300, null, "Single" },
                    { 113, 2, 500, null, "Double" },
                    { 114, 2, 900, null, "FamilySuite" },
                    { 115, 2, 300, null, "Single" },
                    { 116, 2, 500, null, "Double" },
                    { 117, 2, 900, null, "FamilySuite" },
                    { 118, 2, 300, null, "Single" },
                    { 119, 2, 500, null, "Double" },
                    { 120, 2, 900, null, "FamilySuite" },
                    { 121, 3, 80, null, "Single" },
                    { 122, 3, 120, null, "Double" },
                    { 123, 3, 150, null, "FamilySuite" },
                    { 124, 3, 80, null, "Single" },
                    { 125, 3, 120, null, "Double" },
                    { 126, 3, 150, null, "FamilySuite" },
                    { 127, 3, 80, null, "Single" },
                    { 128, 3, 120, null, "Double" },
                    { 129, 3, 150, null, "FamilySuite" },
                    { 130, 3, 80, null, "Single" },
                    { 131, 3, 120, null, "Double" },
                    { 132, 3, 150, null, "FamilySuite" },
                    { 133, 3, 80, null, "Single" },
                    { 134, 3, 120, null, "Double" },
                    { 135, 3, 150, null, "FamilySuite" },
                    { 136, 3, 80, null, "Single" },
                    { 137, 3, 120, null, "Double" },
                    { 138, 3, 150, null, "FamilySuite" },
                    { 139, 3, 80, null, "Single" },
                    { 140, 3, 120, null, "Double" },
                    { 141, 3, 150, null, "FamilySuite" },
                    { 142, 3, 80, null, "Single" },
                    { 143, 3, 120, null, "Double" },
                    { 144, 3, 150, null, "FamilySuite" },
                    { 145, 3, 80, null, "Single" },
                    { 146, 3, 120, null, "Double" },
                    { 147, 3, 150, null, "FamilySuite" },
                    { 148, 3, 80, null, "Single" },
                    { 149, 3, 120, null, "Double" },
                    { 150, 3, 150, null, "FamilySuite" },
                    { 151, 3, 80, null, "Single" },
                    { 152, 3, 120, null, "Double" },
                    { 153, 3, 150, null, "FamilySuite" },
                    { 154, 3, 80, null, "Single" },
                    { 155, 3, 120, null, "Double" },
                    { 156, 3, 150, null, "FamilySuite" },
                    { 157, 3, 80, null, "Single" },
                    { 158, 3, 120, null, "Double" },
                    { 159, 3, 150, null, "FamilySuite" },
                    { 160, 3, 80, null, "Single" },
                    { 161, 3, 120, null, "Double" },
                    { 162, 3, 150, null, "FamilySuite" },
                    { 163, 3, 80, null, "Single" },
                    { 164, 3, 120, null, "Double" },
                    { 165, 3, 150, null, "FamilySuite" },
                    { 166, 3, 80, null, "Single" },
                    { 167, 3, 120, null, "Double" },
                    { 168, 3, 150, null, "FamilySuite" },
                    { 169, 3, 80, null, "Single" },
                    { 170, 3, 120, null, "Double" },
                    { 171, 3, 150, null, "FamilySuite" },
                    { 172, 3, 80, null, "Single" },
                    { 173, 3, 120, null, "Double" },
                    { 174, 3, 150, null, "FamilySuite" },
                    { 175, 3, 80, null, "Single" },
                    { 176, 3, 120, null, "Double" },
                    { 177, 3, 150, null, "FamilySuite" },
                    { 178, 3, 80, null, "Single" },
                    { 179, 3, 120, null, "Double" },
                    { 180, 3, 150, null, "FamilySuite" },
                    { 181, 4, 180, null, "Single" },
                    { 182, 4, 400, null, "Double" },
                    { 183, 4, 520, null, "FamilySuite" },
                    { 184, 4, 180, null, "Single" },
                    { 185, 4, 400, null, "Double" },
                    { 186, 4, 520, null, "FamilySuite" },
                    { 187, 4, 180, null, "Single" },
                    { 188, 4, 400, null, "Double" },
                    { 189, 4, 520, null, "FamilySuite" },
                    { 190, 4, 180, null, "Single" },
                    { 191, 4, 400, null, "Double" },
                    { 192, 4, 520, null, "FamilySuite" },
                    { 193, 4, 180, null, "Single" },
                    { 194, 4, 400, null, "Double" },
                    { 195, 4, 520, null, "FamilySuite" },
                    { 196, 4, 180, null, "Single" },
                    { 197, 4, 400, null, "Double" },
                    { 198, 4, 520, null, "FamilySuite" },
                    { 199, 4, 180, null, "Single" },
                    { 200, 4, 400, null, "Double" },
                    { 201, 4, 520, null, "FamilySuite" },
                    { 202, 4, 180, null, "Single" },
                    { 203, 4, 400, null, "Double" },
                    { 204, 4, 520, null, "FamilySuite" },
                    { 205, 4, 180, null, "Single" },
                    { 206, 4, 400, null, "Double" },
                    { 207, 4, 520, null, "FamilySuite" },
                    { 208, 4, 180, null, "Single" },
                    { 209, 4, 400, null, "Double" },
                    { 210, 4, 520, null, "FamilySuite" },
                    { 211, 4, 180, null, "Single" },
                    { 212, 4, 400, null, "Double" },
                    { 213, 4, 520, null, "FamilySuite" },
                    { 214, 4, 180, null, "Single" },
                    { 215, 4, 400, null, "Double" },
                    { 216, 4, 520, null, "FamilySuite" },
                    { 217, 4, 180, null, "Single" },
                    { 218, 4, 400, null, "Double" },
                    { 219, 4, 520, null, "FamilySuite" },
                    { 220, 4, 180, null, "Single" },
                    { 221, 4, 400, null, "Double" },
                    { 222, 4, 520, null, "FamilySuite" },
                    { 223, 4, 180, null, "Single" },
                    { 224, 4, 400, null, "Double" },
                    { 225, 4, 520, null, "FamilySuite" },
                    { 226, 4, 180, null, "Single" },
                    { 227, 4, 400, null, "Double" },
                    { 228, 4, 520, null, "FamilySuite" },
                    { 229, 4, 180, null, "Single" },
                    { 230, 4, 400, null, "Double" },
                    { 231, 4, 520, null, "FamilySuite" },
                    { 232, 4, 180, null, "Single" },
                    { 233, 4, 400, null, "Double" },
                    { 234, 4, 520, null, "FamilySuite" },
                    { 235, 4, 180, null, "Single" },
                    { 236, 4, 400, null, "Double" },
                    { 237, 4, 520, null, "FamilySuite" },
                    { 238, 4, 180, null, "Single" },
                    { 239, 4, 400, null, "Double" },
                    { 240, 4, 520, null, "FamilySuite" },
                    { 241, 5, 180, null, "Single" },
                    { 242, 5, 400, null, "Double" },
                    { 243, 5, 520, null, "FamilySuite" },
                    { 244, 5, 180, null, "Single" },
                    { 245, 5, 400, null, "Double" },
                    { 246, 5, 520, null, "FamilySuite" },
                    { 247, 5, 180, null, "Single" },
                    { 248, 5, 400, null, "Double" },
                    { 249, 5, 520, null, "FamilySuite" },
                    { 250, 5, 180, null, "Single" },
                    { 251, 5, 400, null, "Double" },
                    { 252, 5, 520, null, "FamilySuite" },
                    { 253, 5, 180, null, "Single" },
                    { 254, 5, 400, null, "Double" },
                    { 255, 5, 520, null, "FamilySuite" },
                    { 256, 5, 180, null, "Single" },
                    { 257, 5, 400, null, "Double" },
                    { 258, 5, 520, null, "FamilySuite" },
                    { 259, 5, 180, null, "Single" },
                    { 260, 5, 400, null, "Double" },
                    { 261, 5, 520, null, "FamilySuite" },
                    { 262, 5, 180, null, "Single" },
                    { 263, 5, 400, null, "Double" },
                    { 264, 5, 520, null, "FamilySuite" },
                    { 265, 5, 180, null, "Single" },
                    { 266, 5, 400, null, "Double" },
                    { 267, 5, 520, null, "FamilySuite" },
                    { 268, 5, 180, null, "Single" },
                    { 269, 5, 400, null, "Double" },
                    { 270, 5, 520, null, "FamilySuite" },
                    { 271, 5, 180, null, "Single" },
                    { 272, 5, 400, null, "Double" },
                    { 273, 5, 520, null, "FamilySuite" },
                    { 274, 5, 180, null, "Single" },
                    { 275, 5, 400, null, "Double" },
                    { 276, 5, 520, null, "FamilySuite" },
                    { 277, 5, 180, null, "Single" },
                    { 278, 5, 400, null, "Double" },
                    { 279, 5, 520, null, "FamilySuite" },
                    { 280, 5, 180, null, "Single" },
                    { 281, 5, 400, null, "Double" },
                    { 282, 5, 520, null, "FamilySuite" },
                    { 283, 5, 180, null, "Single" },
                    { 284, 5, 400, null, "Double" },
                    { 285, 5, 520, null, "FamilySuite" },
                    { 286, 5, 180, null, "Single" },
                    { 287, 5, 400, null, "Double" },
                    { 288, 5, 520, null, "FamilySuite" },
                    { 289, 5, 180, null, "Single" },
                    { 290, 5, 400, null, "Double" },
                    { 291, 5, 520, null, "FamilySuite" },
                    { 292, 5, 180, null, "Single" },
                    { 293, 5, 400, null, "Double" },
                    { 294, 5, 520, null, "FamilySuite" },
                    { 295, 5, 180, null, "Single" },
                    { 296, 5, 400, null, "Double" },
                    { 297, 5, 520, null, "FamilySuite" },
                    { 298, 5, 180, null, "Single" },
                    { 299, 5, 400, null, "Double" },
                    { 300, 5, 520, null, "FamilySuite" },
                    { 301, 6, 90, null, "Single" },
                    { 302, 6, 100, null, "Double" },
                    { 303, 6, 155, null, "FamilySuite" },
                    { 304, 6, 90, null, "Single" },
                    { 305, 6, 100, null, "Double" },
                    { 306, 6, 155, null, "FamilySuite" },
                    { 307, 6, 90, null, "Single" },
                    { 308, 6, 100, null, "Double" },
                    { 309, 6, 155, null, "FamilySuite" },
                    { 310, 6, 90, null, "Single" },
                    { 311, 6, 100, null, "Double" },
                    { 312, 6, 155, null, "FamilySuite" },
                    { 313, 6, 90, null, "Single" },
                    { 314, 6, 100, null, "Double" },
                    { 315, 6, 155, null, "FamilySuite" },
                    { 316, 6, 90, null, "Single" },
                    { 317, 6, 100, null, "Double" },
                    { 318, 6, 155, null, "FamilySuite" },
                    { 319, 6, 90, null, "Single" },
                    { 320, 6, 100, null, "Double" },
                    { 321, 6, 155, null, "FamilySuite" },
                    { 322, 6, 90, null, "Single" },
                    { 323, 6, 100, null, "Double" },
                    { 324, 6, 155, null, "FamilySuite" },
                    { 325, 6, 90, null, "Single" },
                    { 326, 6, 100, null, "Double" },
                    { 327, 6, 155, null, "FamilySuite" },
                    { 328, 6, 90, null, "Single" },
                    { 329, 6, 100, null, "Double" },
                    { 330, 6, 155, null, "FamilySuite" },
                    { 331, 6, 90, null, "Single" },
                    { 332, 6, 100, null, "Double" },
                    { 333, 6, 155, null, "FamilySuite" },
                    { 334, 6, 90, null, "Single" },
                    { 335, 6, 100, null, "Double" },
                    { 336, 6, 155, null, "FamilySuite" },
                    { 337, 6, 90, null, "Single" },
                    { 338, 6, 100, null, "Double" },
                    { 339, 6, 155, null, "FamilySuite" },
                    { 340, 6, 90, null, "Single" },
                    { 341, 6, 100, null, "Double" },
                    { 342, 6, 155, null, "FamilySuite" },
                    { 343, 6, 90, null, "Single" },
                    { 344, 6, 100, null, "Double" },
                    { 345, 6, 155, null, "FamilySuite" },
                    { 346, 6, 90, null, "Single" },
                    { 347, 6, 100, null, "Double" },
                    { 348, 6, 155, null, "FamilySuite" },
                    { 349, 6, 90, null, "Single" },
                    { 350, 6, 100, null, "Double" },
                    { 351, 6, 155, null, "FamilySuite" },
                    { 352, 6, 90, null, "Single" },
                    { 353, 6, 100, null, "Double" },
                    { 354, 6, 155, null, "FamilySuite" },
                    { 355, 6, 90, null, "Single" },
                    { 356, 6, 100, null, "Double" },
                    { 357, 6, 155, null, "FamilySuite" },
                    { 358, 6, 90, null, "Single" },
                    { 359, 6, 100, null, "Double" },
                    { 360, 6, 155, null, "FamilySuite" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_RoomBookingId",
                table: "Discount",
                column: "RoomBookingId",
                unique: true,
                filter: "[RoomBookingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_TourBookingId",
                table: "Discount",
                column: "TourBookingId",
                unique: true,
                filter: "[TourBookingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelId",
                table: "Room",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Booking_BookingId",
                table: "Room_Booking",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Booking_RoomId",
                table: "Room_Booking",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Booking_BookingId",
                table: "Tour_Booking",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Booking_TourId",
                table: "Tour_Booking",
                column: "TourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Room_Booking");

            migrationBuilder.DropTable(
                name: "Tour_Booking");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Tour");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
