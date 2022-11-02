using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IDataCleanupRepository
    {
        Task<IEnumerable<int>> GetSiteIdsForContactsCleanupAsync(DateTimeOffset offset);

        Task<IEnumerable<int>> GetSiteIdsForConsumersCleanupAsync(DateTimeOffset offset, string source);

        Task<(IEnumerable<UbConsumer> consumersToDelete, int totalDoubleOptins)> GetConsumersForCleanupAsync(int siteId, string source, DateTimeOffset offset, int limit);

        Task<(IEnumerable<UbContact> contacts, IEnumerable<int> singleOptinConsumerIds)> GetContactsForCleanupAsync(int siteId, DateTimeOffset offset, int limit);

        Task<UbDataCleanupLog> CleanupContactsAsync(int siteId, IEnumerable<int> contactIds, IEnumerable<int> consumerIds, string extraInfo, bool saveChanges);

        Task<bool> VerifyCleanupContactsResultAsync(int[] contactIdsExpectedToBeDeleted, int[] consumerIdsExpectedToBeDeleted);

        Task<int> RemoveConsumersWithConsentsAsync(IEnumerable<int> consumerIds, bool saveChanges = false);

        Task<(int nrOfDeletedSubmissions, int nrOfDeletedConsumers)> BatchCleanupSubmissionsAsync(IEnumerable<int> submissionIds, bool saveChanges);

        Task<bool> VerifyCleanupPromotionsResultAsync(int campaignId);

        Task<IEnumerable<string?>> GetContactFormExtraInfoFieldsAsync();

        Task<IEnumerable<string?>> GetContestSubmissionExtraInfoFieldsAsync();
    }
}