using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Essity.FutureProof.Infrastructure.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "UbComments",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NodeId = table.Column<int>(type: "int", nullable: false),
            //        Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SiteId = table.Column<int>(type: "int", nullable: false),
            //        DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbComments", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbConsentTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbConsentTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbConsumers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        Extra = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SourceTags = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
            //        UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //        PageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
            //        Referer = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
            //        DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        SiteId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbConsumers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbContestCampaigns",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SiteId = table.Column<int>(type: "int", nullable: false),
            //        AggregatedData = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbContestCampaigns", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbDataCleanupLogs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Type = table.Column<int>(type: "int", nullable: false),
            //        SiteId = table.Column<int>(type: "int", nullable: false),
            //        NrOfDeletedConsumers = table.Column<int>(type: "int", nullable: false),
            //        ExtraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbDataCleanupLogs", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbProductTrackings",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        GpimProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SiteId = table.Column<int>(type: "int", nullable: false),
            //        HashCode = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbProductTrackings", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbWebLikes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CookieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NodeId = table.Column<int>(type: "int", nullable: false),
            //        DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IsLike = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbWebLikes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbWordBlacklists",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Word = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbWordBlacklists", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbConsents",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TypeId = table.Column<int>(type: "int", nullable: false),
            //        Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbConsents", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UbConsents_UbConsentTypes_TypeId",
            //            column: x => x.TypeId,
            //            principalTable: "UbConsentTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbContacts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ConsumerId = table.Column<int>(type: "int", nullable: false),
            //        ExtraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbContacts", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UbContacts_UbConsumers_ConsumerId",
            //            column: x => x.ConsumerId,
            //            principalTable: "UbConsumers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbEqualitySurveys",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        HouseholdScores = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
            //        HouseholdAverageScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        StatementParentsInfluenceFuture = table.Column<int>(type: "int", nullable: false),
            //        StatementHouseholdSharedResponsibility = table.Column<int>(type: "int", nullable: false),
            //        DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        SiteId = table.Column<int>(type: "int", nullable: false),
            //        ConsumerId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbEqualitySurveys", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UbEqualitySurveys_UbConsumers_ConsumerId",
            //            column: x => x.ConsumerId,
            //            principalTable: "UbConsumers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbReviews",
            //    columns: table => new
            //    {
            //        ReviewId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ReviewDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ReviewRating = table.Column<double>(type: "float", nullable: false),
            //        DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ConsumerId = table.Column<int>(type: "int", nullable: false),
            //        ProductId = table.Column<int>(type: "int", nullable: false),
            //        Visible = table.Column<bool>(type: "bit", nullable: false),
            //        ProductUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        BrandReplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        BrandReply = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbReviews", x => x.ReviewId);
            //        table.ForeignKey(
            //            name: "FK_UbReviews_UbConsumers_ConsumerId",
            //            column: x => x.ConsumerId,
            //            principalTable: "UbConsumers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbContestCodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ActionCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CampaignId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbContestCodes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UbContestCodes_UbContestCampaigns_CampaignId",
            //            column: x => x.CampaignId,
            //            principalTable: "UbContestCampaigns",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbContestSubmissions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ActionCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
            //        Extra = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ConsumerId = table.Column<int>(type: "int", nullable: false),
            //        CampaignId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbContestSubmissions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UbContestSubmissions_UbConsumers_ConsumerId",
            //            column: x => x.ConsumerId,
            //            principalTable: "UbConsumers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UbContestSubmissions_UbContestCampaigns_CampaignId",
            //            column: x => x.CampaignId,
            //            principalTable: "UbContestCampaigns",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UbConsumerConsents",
            //    columns: table => new
            //    {
            //        ConsumerId = table.Column<int>(type: "int", nullable: false),
            //        ConsentId = table.Column<int>(type: "int", nullable: false),
            //        DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        OptInConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        IsUnsubscribed = table.Column<bool>(type: "bit", nullable: false),
            //        ConsentVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CMSPropertyDataId = table.Column<int>(type: "int", nullable: true),
            //        SiteId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UbConsumerConsents", x => new { x.ConsumerId, x.ConsentId });
            //        table.ForeignKey(
            //            name: "FK_UbConsumerConsents_UbConsents_ConsentId",
            //            column: x => x.ConsentId,
            //            principalTable: "UbConsents",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_UbConsumerConsents_UbConsumers_ConsumerId",
            //            column: x => x.ConsumerId,
            //            principalTable: "UbConsumers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbConsents_TypeId",
            //    table: "UbConsents",
            //    column: "TypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbConsumerConsents_ConsentId",
            //    table: "UbConsumerConsents",
            //    column: "ConsentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbConsumerConsents_ConsumerId",
            //    table: "UbConsumerConsents",
            //    column: "ConsumerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbConsumerConsents_OptInConfirmed",
            //    table: "UbConsumerConsents",
            //    column: "OptInConfirmed");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbConsumers_Email",
            //    table: "UbConsumers",
            //    column: "Email");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbContacts_ConsumerId",
            //    table: "UbContacts",
            //    column: "ConsumerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbContestCodes_CampaignId",
            //    table: "UbContestCodes",
            //    column: "CampaignId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbContestCodes_CampaignId_ActionCode",
            //    table: "UbContestCodes",
            //    columns: new[] { "CampaignId", "ActionCode" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbContestSubmissions_CampaignId",
            //    table: "UbContestSubmissions",
            //    column: "CampaignId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbContestSubmissions_ConsumerId",
            //    table: "UbContestSubmissions",
            //    column: "ConsumerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbEqualitySurveys_ConsumerId",
            //    table: "UbEqualitySurveys",
            //    column: "ConsumerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UbReviews_ConsumerId",
            //    table: "UbReviews",
            //    column: "ConsumerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UbComments");

            migrationBuilder.DropTable(
                name: "UbConsumerConsents");

            migrationBuilder.DropTable(
                name: "UbContacts");

            migrationBuilder.DropTable(
                name: "UbContestCodes");

            migrationBuilder.DropTable(
                name: "UbContestSubmissions");

            migrationBuilder.DropTable(
                name: "UbDataCleanupLogs");

            migrationBuilder.DropTable(
                name: "UbEqualitySurveys");

            migrationBuilder.DropTable(
                name: "UbProductTrackings");

            migrationBuilder.DropTable(
                name: "UbReviews");

            migrationBuilder.DropTable(
                name: "UbWebLikes");

            migrationBuilder.DropTable(
                name: "UbWordBlacklists");

            migrationBuilder.DropTable(
                name: "UbConsents");

            migrationBuilder.DropTable(
                name: "UbContestCampaigns");

            migrationBuilder.DropTable(
                name: "UbConsumers");

            migrationBuilder.DropTable(
                name: "UbConsentTypes");
        }
    }
}