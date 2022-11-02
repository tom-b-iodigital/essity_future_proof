using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbContestRepository
    {
        Task<List<UbContestSubmission>> GetSubmissionsByCampaignAsync(int campaignId);

        Task<int> InsertContestSubmissionAsync(UbContestSubmission submission);

        Task<bool> ValidatePromotionCodeAsync(string promotionCode, int campaignId);

        IEnumerable<UbContestCampaign> GetContestCampaigns(int siteId);

        IEnumerable<UbContestCampaign> GetContestCampaigns();

        UbContestCampaign? GetContestCampaign(int campaignId);

        Task<IEnumerable<UbContestSubmission>> GetAlreadyWonMomentsAsync(int campaignId, int siteId);

        Task<bool> CheckContestCodeExistsAsync(string contestCode, int campaignId);

        Task<IEnumerable<UbContestSubmission>> GetContestSubmissionsAsync(string query, string queryEncrypted, int campaignId);

        UbContestSubmission? GetContestSubmission(int submissionId, string email);

        int GetContestSubmissionsTotal(int campaignId);

        Task<int> GetContestSubmissionsTotalAsync(int campaignId);

        int GetContestSubmissionsTotalFromStartdate(int campaignId, DateTime startdate);

        Task<string> UpdateContestSubmissionAsync(UbContestSubmission submission);

        int InsertContestCampaign(string name, int siteId);
    }
}