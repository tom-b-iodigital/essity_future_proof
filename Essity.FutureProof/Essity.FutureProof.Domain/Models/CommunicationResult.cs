using Essity.FutureProof.Domain.Interfaces;

namespace Essity.FutureProof.Domain.Models
{
    public class CommunicationResult<T>
            where T : IDomainProduct
    {
        public IEnumerable<T>? Items { get; set; }

        public bool HasErrors { get; set; }

        public Exception? Error { get; set; }
    }
}