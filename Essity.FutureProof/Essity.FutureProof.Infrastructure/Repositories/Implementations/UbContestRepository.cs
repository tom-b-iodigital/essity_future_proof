using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbContestRepository : BaseRepository, IUbContestRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbContestRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        /// <summary>
        /// Returns <see cref="List{UbContestSubmission}"/> from given campaign
        /// </summary>
        /// <param name="campaignId">CampaignId</param>
        /// <returns>List of Submissions in that campaign</returns>
        public async Task<List<UbContestSubmission>> GetSubmissionsByCampaignAsync(int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbContestSubmissions.Where(c => c.CampaignId == campaignId).ToListAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Saves a <see cref="UbContestSubmission"/> to the database
        /// </summary>
        /// <param name="submission">Submission to save</param>
        /// <returns>SaveResult</returns>
        public async Task<int> InsertContestSubmissionAsync(UbContestSubmission submission)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (SkipSaveData)
                {
                    return 0;
                }

                dataContext.UbContestSubmissions.Add(submission);
                int result = await dataContext.SaveChangesAsync().ConfigureAwait(false);

                if (result > 0)
                {
                    return submission.Id;
                }

                return -1;
            }
        }

        public int InsertContestCampaign(string name, int siteId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (SkipSaveData)
                {
                    return 0;
                }

                UbContestCampaign campaign = new UbContestCampaign
                {
                    Name = name,
                    SiteId = siteId,
                };

                if (!dataContext.UbContestCampaigns.Any(x => x.SiteId.Equals(siteId) && (x.Name ?? "").Equals(name)))
                {
                    dataContext.UbContestCampaigns.Add(campaign);
                    int result = dataContext.SaveChanges();

                    if (result > 0)
                    {
                        return campaign.Id;
                    }
                }

                return -1;
            }
        }

        public IEnumerable<UbContestCampaign> GetContestCampaigns(int siteId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbContestCampaigns.Where(s => s.SiteId == siteId || s.Id == 0 || s.SiteId == -1).ToList();
            }
        }

        public IEnumerable<UbContestCampaign> GetContestCampaigns()
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbContestCampaigns.ToList();
            }
        }

        public UbContestCampaign? GetContestCampaign(int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbContestCampaigns.Find(campaignId);
            }
        }

        /// <summary>
        /// Checks if the code exists and if it hasn't already been used
        /// </summary>
        /// <param name="promotionCode">Promo Code</param>
        /// <param name="campaignId">Campaign Id</param>
        /// <returns>True if valid & unused promotion code, False otherwise</returns>
        public async Task<bool> ValidatePromotionCodeAsync(string promotionCode, int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return promotionCode == "UBPROMOTEST" ||
                   await CheckContestCodeExistsAsync(promotionCode, campaignId).ConfigureAwait(false) &&
                    !await dataContext.UbContestSubmissions.AnyAsync(c => c.ActionCode == promotionCode && c.CampaignId.Equals(campaignId)).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Checks if a code exists
        /// </summary>
        /// <param name="contestCode">Contest Code</param>
        /// <param name="campaignId">Campaign Id</param>
        /// <returns>True or false</returns>
        public async Task<bool> CheckContestCodeExistsAsync(string contestCode, int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbContestCodes
                .AnyAsync(c => c.ActionCode == contestCode && c.CampaignId.Equals(campaignId))
                .ConfigureAwait(false);
            }
        }

        public int GetContestSubmissionsTotal(int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbContestSubmissions.Count(c => c.CampaignId.Equals(campaignId));
            }
        }

        public async Task<int> GetContestSubmissionsTotalAsync(int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbContestSubmissions
                .Where(c => c.CampaignId.Equals(campaignId))
                .CountAsync()
                .ConfigureAwait(false);
            }
        }

        public int GetContestSubmissionsTotalFromStartdate(int campaignId, DateTime startdate)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbContestSubmissions.Count(c => c.CampaignId.Equals(campaignId) && c.DateCreated >= startdate);
            }
        }

        /// <summary>
        /// Get all submissions based on a query
        /// </summary>
        /// <param name="query">Part of the name/email or contest code</param>
        /// <param name="queryEncrypted">Query Encrypted</param>
        /// <param name="campaignId">Campaign Id</param>
        /// <returns>A list of submissions</returns>
        public async Task<IEnumerable<UbContestSubmission>> GetContestSubmissionsAsync(string query, string queryEncrypted, int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbContestSubmissions
                .Where(c => c.CampaignId.Equals(campaignId) &&
                            (c.ActionCode == query || (c.UbConsumer.FirstName ?? "").Contains(query) ||
                             (c.UbConsumer.LastName ?? "").Contains(query) || (c.UbConsumer.Email ?? "").Equals(queryEncrypted)))
                .ToListAsync()
                .ConfigureAwait(false);
            }
        }

        public UbContestSubmission? GetContestSubmission(int submissionId, string email)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbContestSubmissions.FirstOrDefault(x => (x.UbConsumer.Email ?? "").Equals(email) && x.Id.Equals(submissionId));
            }
        }

        public async Task<string> UpdateContestSubmissionAsync(UbContestSubmission submission)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (SkipSaveData)
                {
                    return "Data does not need saving";
                }

                try
                {
                    var existSubm = await dataContext.UbContestSubmissions.FirstOrDefaultAsync(x => x.Id.Equals(submission.Id)).ConfigureAwait(false);
                    if (existSubm != null)
                    {
                        existSubm.Extra = submission.Extra;
                    }

                    int result = await dataContext.SaveChangesAsync().ConfigureAwait(false);

                    return result > 0 ? string.Empty : "Error while saving";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public async Task<IEnumerable<UbContestSubmission>> GetAlreadyWonMomentsAsync(int campaignId, int siteId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbContestSubmissions
                .Where(x => x.CampaignId.Equals(campaignId) && (x.Extra ?? "").Contains("\"HasWon\":true"))
                .ToListAsync()
                .ConfigureAwait(false);
            }
        }
    }
}