using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RevInfotech.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AccountNo = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DBO = table.Column<DateTime>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Sponsor = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    LoginAlert = table.Column<bool>(nullable: false),
                    CodeCard = table.Column<bool>(nullable: false),
                    TwoFactorTrans = table.Column<bool>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false),
                    TicketUserId = table.Column<long>(nullable: false),
                    ProfileCompleted = table.Column<bool>(nullable: false),
                    FacebookUserId = table.Column<string>(nullable: true),
                    GoogleUserId = table.Column<string>(nullable: true),
                    TwitterUserId = table.Column<string>(nullable: true),
                    LinkedInUserId = table.Column<string>(nullable: true),
                    SocialProviderName = table.Column<string>(nullable: true),
                    AutoPay = table.Column<bool>(nullable: false),
                    PinCode = table.Column<string>(nullable: true),
                    KYCCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryEntitys",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    StatusID = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntitys", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "GenericSetting",
                columns: table => new
                {
                    SettingID = table.Column<Guid>(nullable: false),
                    AdminAccountId = table.Column<string>(nullable: false),
                    SettingName = table.Column<string>(nullable: false),
                    SubSettingName = table.Column<string>(nullable: false),
                    DefaultTextValue20_1 = table.Column<string>(maxLength: 20, nullable: true),
                    DefaultTextValue20_2 = table.Column<string>(maxLength: 20, nullable: true),
                    DefaultTextValue50_1 = table.Column<string>(maxLength: 50, nullable: true),
                    DefaultTextValue50_2 = table.Column<string>(maxLength: 50, nullable: true),
                    DefaultTextValue100_1 = table.Column<string>(maxLength: 100, nullable: true),
                    DefaultTextValue100_2 = table.Column<string>(maxLength: 100, nullable: true),
                    DefaultTextValue250_1 = table.Column<string>(maxLength: 250, nullable: true),
                    DefaultTextValue250_2 = table.Column<string>(maxLength: 250, nullable: true),
                    DefaultTextMax = table.Column<string>(nullable: true),
                    DefaultTextMax1 = table.Column<string>(nullable: true),
                    DefaultTextMax2 = table.Column<string>(nullable: true),
                    DefaultTextMax3 = table.Column<string>(nullable: true),
                    DefaultTextMax4 = table.Column<string>(nullable: true),
                    DefalutInteger1 = table.Column<int>(nullable: false),
                    DefalutInteger2 = table.Column<int>(nullable: false),
                    DefalutInteger3 = table.Column<int>(nullable: false),
                    DefalutInteger4 = table.Column<int>(nullable: false),
                    DefalutInteger5 = table.Column<int>(nullable: false),
                    DefaultDecimal1 = table.Column<decimal>(type: "decimal(18, 8)", nullable: false),
                    DefaultDecimal2 = table.Column<decimal>(type: "decimal(18, 8)", nullable: false),
                    DefaultDecimal3 = table.Column<decimal>(type: "decimal(18, 8)", nullable: false),
                    DefaultDecimal4 = table.Column<decimal>(type: "decimal(18, 8)", nullable: false),
                    DefaultDecimal5 = table.Column<decimal>(type: "decimal(18, 8)", nullable: false),
                    DefaultDateTime1 = table.Column<DateTime>(nullable: true),
                    DefaultDateTime2 = table.Column<DateTime>(nullable: true),
                    DefaultDateTime3 = table.Column<DateTime>(nullable: true),
                    DefaultDateTime4 = table.Column<DateTime>(nullable: true),
                    DefaultDateTime5 = table.Column<DateTime>(nullable: true),
                    DefaultBool1 = table.Column<bool>(nullable: false),
                    DefaultBool2 = table.Column<bool>(nullable: false),
                    DefaultBool3 = table.Column<bool>(nullable: false),
                    DefaultBool4 = table.Column<bool>(nullable: false),
                    DefaultBool5 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericSetting", x => new { x.SettingID, x.AdminAccountId, x.SettingName, x.SubSettingName });
                    table.UniqueConstraint("AK_GenericSetting_AdminAccountId_SettingID_SettingName_SubSettingName", x => new { x.AdminAccountId, x.SettingID, x.SettingName, x.SubSettingName });
                });

            migrationBuilder.CreateTable(
                name: "StateEntitys",
                columns: table => new
                {
                    StateID = table.Column<Guid>(nullable: false),
                    StateName = table.Column<string>(nullable: true),
                    StatusID = table.Column<bool>(nullable: false),
                    StateCode = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateEntitys", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "UserCodeCardEntity",
                columns: table => new
                {
                    CodeId = table.Column<int>(nullable: false),
                    AccountNo = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCodeCardEntity", x => new { x.CodeId, x.AccountNo });
                    table.UniqueConstraint("AK_UserCodeCardEntity_AccountNo_CodeId", x => new { x.AccountNo, x.CodeId });
                });

            migrationBuilder.CreateTable(
                name: "UserSecurityQuestion",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false),
                    AccountId = table.Column<string>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecurityQuestion", x => new { x.QuestionId, x.AccountId });
                    table.UniqueConstraint("AK_UserSecurityQuestion_AccountId_QuestionId", x => new { x.AccountId, x.QuestionId });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "BlogEntitys",
                columns: table => new
                {
                    BlogID = table.Column<Guid>(nullable: false),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    CategoryID = table.Column<Guid>(nullable: false),
                    BlogHeading = table.Column<string>(nullable: true),
                    StatusID = table.Column<bool>(nullable: false),
                    RouteName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogEntitys", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_BlogEntitys_CategoryEntitys_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "CategoryEntitys",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityEntitys",
                columns: table => new
                {
                    CityID = table.Column<Guid>(nullable: false),
                    StateName = table.Column<string>(nullable: true),
                    StatusID = table.Column<bool>(nullable: false),
                    CityCode = table.Column<string>(nullable: true),
                    PinCode = table.Column<string>(nullable: true),
                    StateID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityEntitys", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_CityEntitys_StateEntitys_StateID",
                        column: x => x.StateID,
                        principalTable: "StateEntitys",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogDescriptions",
                columns: table => new
                {
                    BlogDescriptionID = table.Column<Guid>(nullable: false),
                    BlogID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StatusID = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogDescriptions", x => x.BlogDescriptionID);
                    table.ForeignKey(
                        name: "FK_BlogDescriptions_BlogEntitys_BlogID",
                        column: x => x.BlogID,
                        principalTable: "BlogEntitys",
                        principalColumn: "BlogID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogImages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BlogID = table.Column<Guid>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    StatusID = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BlogImages_BlogEntitys_BlogID",
                        column: x => x.BlogID,
                        principalTable: "BlogEntitys",
                        principalColumn: "BlogID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_BlogDescriptions_BlogID",
                table: "BlogDescriptions",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogEntitys_CategoryID",
                table: "BlogEntitys",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_BlogID",
                table: "BlogImages",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_CityEntitys_StateID",
                table: "CityEntitys",
                column: "StateID");
        }

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
                name: "BlogDescriptions");

            migrationBuilder.DropTable(
                name: "BlogImages");

            migrationBuilder.DropTable(
                name: "CityEntitys");

            migrationBuilder.DropTable(
                name: "GenericSetting");

            migrationBuilder.DropTable(
                name: "UserCodeCardEntity");

            migrationBuilder.DropTable(
                name: "UserSecurityQuestion");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BlogEntitys");

            migrationBuilder.DropTable(
                name: "StateEntitys");

            migrationBuilder.DropTable(
                name: "CategoryEntitys");
        }
    }
}
