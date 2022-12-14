// <auto-generated />
using System;
using Essity.FutureProof.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Essity.FutureProof.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221108083023_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("NodeId")
                        .HasColumnType("int");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UbComments");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbConsent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("UbConsents");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbConsentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("UbConsentTypes");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbConsumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Extra")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PageUrl")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Referer")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("SiteId")
                        .HasColumnType("int");

                    b.Property<string>("SourceTags")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("UserAgent")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.ToTable("UbConsumers");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbConsumerConsent", b =>
                {
                    b.Property<int>("ConsumerId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ConsentId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int?>("CMSPropertyDataId")
                        .HasColumnType("int");

                    b.Property<string>("ConsentVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUnsubscribed")
                        .HasColumnType("bit");

                    b.Property<bool>("OptInConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("ConsumerId", "ConsentId");

                    b.HasIndex("ConsentId");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("OptInConfirmed");

                    b.ToTable("UbConsumerConsents");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConsumerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExtraInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.ToTable("UbContacts");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbContestCampaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AggregatedData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UbContestCampaigns");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbContestCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ActionCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("CampaignId", "ActionCode");

                    b.ToTable("UbContestCodes");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbContestSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ActionCode")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("ConsumerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Extra")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("ConsumerId");

                    b.ToTable("UbContestSubmissions");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbDataCleanupLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExtraInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NrOfDeletedConsumers")
                        .HasColumnType("int");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UbDataCleanupLogs");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbEqualitySurvey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ConsumerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<decimal>("HouseholdAverageScore")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HouseholdScores")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.Property<int>("StatementHouseholdSharedResponsibility")
                        .HasColumnType("int");

                    b.Property<int>("StatementParentsInfluenceFuture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.ToTable("UbEqualitySurveys");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbProductTracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GpimProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HashCode")
                        .HasColumnType("int");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UbProductTrackings");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<string>("BrandReply")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BrandReplyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ConsumerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ReviewRating")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("ReviewId");

                    b.HasIndex("ConsumerId");

                    b.ToTable("UbReviews");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbWebLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CookieName")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsLike")
                        .HasColumnType("bit");

                    b.Property<int>("NodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UbWebLikes");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbWordBlacklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Word")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UbWordBlacklists");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbConsent", b =>
                {
                    b.HasOne("Essity.FutureProof.Infrastructure.Entities.UbConsentType", "UbConsentType")
                        .WithMany("UbConsents")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UbConsentType");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbConsumerConsent", b =>
                {
                    b.HasOne("Essity.FutureProof.Infrastructure.Entities.UbConsent", "UbConsent")
                        .WithMany("UbConsumerConsents")
                        .HasForeignKey("ConsentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Essity.FutureProof.Infrastructure.Entities.UbConsumer", "UbConsumer")
                        .WithMany("UbConsumerConsents")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UbConsent");

                    b.Navigation("UbConsumer");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbContact", b =>
                {
                    b.HasOne("Essity.FutureProof.Infrastructure.Entities.UbConsumer", "UbConsumer")
                        .WithMany("UbContacts")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UbConsumer");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbContestCode", b =>
                {
                    b.HasOne("Essity.FutureProof.Infrastructure.Entities.UbContestCampaign", "UbContestCampaign")
                        .WithMany("UbContestCodes")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UbContestCampaign");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbContestSubmission", b =>
                {
                    b.HasOne("Essity.FutureProof.Infrastructure.Entities.UbContestCampaign", "UbContestCampaign")
                        .WithMany("UbContestSubmissions")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Essity.FutureProof.Infrastructure.Entities.UbConsumer", "UbConsumer")
                        .WithMany("UbContestSubmissions")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UbConsumer");

                    b.Navigation("UbContestCampaign");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbEqualitySurvey", b =>
                {
                    b.HasOne("Essity.FutureProof.Infrastructure.Entities.UbConsumer", "Consumer")
                        .WithMany("UbEqualitySurveys")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Consumer");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbReview", b =>
                {
                    b.HasOne("Essity.FutureProof.Infrastructure.Entities.UbConsumer", "UbConsumer")
                        .WithMany("UbReviews")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UbConsumer");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbConsent", b =>
                {
                    b.Navigation("UbConsumerConsents");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbConsentType", b =>
                {
                    b.Navigation("UbConsents");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbConsumer", b =>
                {
                    b.Navigation("UbConsumerConsents");

                    b.Navigation("UbContacts");

                    b.Navigation("UbContestSubmissions");

                    b.Navigation("UbEqualitySurveys");

                    b.Navigation("UbReviews");
                });

            modelBuilder.Entity("Essity.FutureProof.Infrastructure.Entities.UbContestCampaign", b =>
                {
                    b.Navigation("UbContestCodes");

                    b.Navigation("UbContestSubmissions");
                });
#pragma warning restore 612, 618
        }
    }
}
