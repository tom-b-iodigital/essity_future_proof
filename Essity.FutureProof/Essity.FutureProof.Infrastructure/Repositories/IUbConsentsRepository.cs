using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbConsentsRepository
    {
        Task SaveConsentsForConsumerAsync(IEnumerable<int> consentIds, UbConsumer consumer, string? version = null, int? contentTypeId = null, int? contentNodeId = null);

        Task SaveConsentForConsumerAsync(int consentId, UbConsumer consumer, string? version = null, int? contentTypeId = null, int? contentNodeId = null);

        List<UbConsent> GetConsentsForSource(string source);

        UbConsent? GetConsent(string source, string typeCode);

        UbConsent? GetConsentById(int consentId);

        IEnumerable<UbConsent> GetConsentByIds(int[] consentIds);

        UbConsumerConsent? GetConsumerConsent(int consentId, int consumerId, int siteId);

        int GetNumberOfConsumerConsentByType(int consentId);

        int GetNumberOfConsumerConsentByType(int consentId, int siteId);

        void UpdateDoubleOptIn(int consumerId, int consentId, bool value);

        bool ConsentExists(int consentId, int consumerId, int siteId);

        void UnsubscribeConsent(int consumerId, int consentId);

        Task<(int singleOptins, int doubleOptins)> GetContestNewsletterOptinsForCampaignAsync(int campaignId);
    }
}