using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UbEqualitySurvey> UbEqualitySurveys => Set<UbEqualitySurvey>();

        public DbSet<UbContestSubmission> UbContestSubmissions => Set<UbContestSubmission>();

        public DbSet<UbContestCode> UbContestCodes => Set<UbContestCode>();

        public DbSet<UbContestCampaign> UbContestCampaigns => Set<UbContestCampaign>();

        public DbSet<UbReview> UbReviews => Set<UbReview>();

        public DbSet<UbComment> UbComments => Set<UbComment>();

        public DbSet<UbConsent> UbConsents => Set<UbConsent>();

        public DbSet<UbConsentType> UbConsentTypes => Set<UbConsentType>();

        public DbSet<UbConsumerConsent> UbConsumerConsents => Set<UbConsumerConsent>();

        public DbSet<UbConsumer> UbConsumers => Set<UbConsumer>();

        public DbSet<UbContact> UbContacts => Set<UbContact>();

        public DbSet<UbWebLike> UbWebLikes => Set<UbWebLike>();

        public DbSet<UbProductTracking> UbProductTrackings => Set<UbProductTracking>();

        public DbSet<UbWordBlacklist> UbWordBlacklists => Set<UbWordBlacklist>();

        public DbSet<UbDataCleanupLog> UbDataCleanupLogs => Set<UbDataCleanupLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UbComment>()
                .Property(e => e.Author)
                .IsUnicode(true);

            modelBuilder.Entity<UbComment>()
                .Property(e => e.CommentText)
                .IsUnicode(true);

            modelBuilder.Entity<UbConsent>()
                .Property(e => e.Source)
                .IsUnicode(true);

            modelBuilder.Entity<UbConsent>()
                .Property(e => e.Title)
                .IsUnicode(true);

            modelBuilder.Entity<UbConsent>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<UbConsent>()
                .HasMany(e => e.UbConsumerConsents)
                .WithOne(e => e.UbConsent)
                .HasForeignKey(e => e.ConsentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UbConsentType>()
                .Property(e => e.Code)
                .IsUnicode(true);

            modelBuilder.Entity<UbConsentType>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<UbConsentType>()
                .HasMany(e => e.UbConsents)
                .WithOne(e => e.UbConsentType)
                .HasForeignKey(e => e.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UbConsumer>()
                .Property(e => e.FirstName)
                .IsUnicode(true);

            modelBuilder.Entity<UbConsumer>()
                .Property(e => e.LastName)
                .IsUnicode(true);

            modelBuilder.Entity<UbConsumer>()
                .Property(e => e.Email)
                .IsUnicode(true);

            modelBuilder.Entity<UbConsumer>()
                .Property(e => e.Extra)
                .IsUnicode(true);

            modelBuilder.Entity<UbConsumer>()
                .HasMany(e => e.UbConsumerConsents)
                .WithOne(e => e.UbConsumer)
                .HasForeignKey(e => e.ConsumerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UbConsumer>()
                .HasMany(e => e.UbEqualitySurveys)
                .WithOne(e => e.Consumer)
                .HasForeignKey(e => e.ConsumerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UbContact>()
                .Property(e => e.Message)
                .IsUnicode(true);

            modelBuilder.Entity<UbWebLike>()
                .Property(e => e.CookieName)
                .IsUnicode(true);

            modelBuilder.Entity<UbContestCode>()
                .HasOne(e => e.UbContestCampaign)
                .WithMany(e => e.UbContestCodes)
                .HasForeignKey(e => e.CampaignId);

            modelBuilder.Entity<UbContact>()
                .HasOne(e => e.UbConsumer)
                .WithMany(e => e.UbContacts)
                .HasForeignKey(e => e.ConsumerId);

            modelBuilder.Entity<UbContestSubmission>()
                .HasOne(e => e.UbConsumer)
                .WithMany(e => e.UbContestSubmissions)
                .HasForeignKey(e => e.ConsumerId);

            modelBuilder.Entity<UbContestSubmission>()
                .HasOne(e => e.UbContestCampaign)
                .WithMany(e => e.UbContestSubmissions)
                .HasForeignKey(e => e.CampaignId);

            modelBuilder.Entity<UbContestCode>()
                .Property(e => e.ActionCode)
                .HasMaxLength(30);

            modelBuilder.Entity<UbContestSubmission>()
                .Property(e => e.ActionCode)
                .HasMaxLength(30);

            modelBuilder.Entity<UbContestCode>()
                .HasIndex(p => p.CampaignId);

            modelBuilder.Entity<UbReview>()
                .HasKey(r => r.ReviewId);

            modelBuilder.Entity<UbReview>()
                .HasOne(r => r.UbConsumer)
                .WithMany(r => r.UbReviews)
                .HasForeignKey(r => r.ConsumerId);

            modelBuilder.Entity<UbWordBlacklist>()
               .HasKey(d => d.Id);

            modelBuilder.Entity<UbDataCleanupLog>()
               .HasKey(d => d.Id);

            modelBuilder.Entity<UbConsumerConsent>()
                .HasKey(cc => new { cc.ConsumerId, cc.ConsentId });
        }

        public async Task<int?> GetCmsPropertyDataIdAsync(int? contentTypeId = null, int? contentNodeId = null)
        {
            if (!contentTypeId.HasValue || !contentNodeId.HasValue)
            {
                return null;
            }

            var query = @"SELECT TOP 1 pd.[id] FROM [dbo].[umbracoPropertyData] pd inner join [dbo].[umbracoContentVersion] cv
                       on pd.[versionId] = cv.id
                       inner join umbracoDocument d on d.nodeId = cv.nodeid
                       where [propertytypeid] =
                           (SELECT top 1[id]
                               FROM [dbo].[cmsPropertyType]
                               where alias = 'bodytext' and [contentTypeId] = @contentTypeId) and cv.nodeid = @contentNodeId
                               and published = 1 and [current] = 1";

            return await Database.ExecuteSqlRawAsync(
                sql: query,
                    new SqlParameter("@contentTypeId", contentTypeId.Value),
                    new SqlParameter("@contentNodeId", contentNodeId.Value));
        }
    }
}