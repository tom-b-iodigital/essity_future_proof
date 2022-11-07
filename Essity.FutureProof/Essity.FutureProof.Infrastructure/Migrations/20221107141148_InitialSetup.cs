using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Essity.FutureProof.Infrastructure.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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