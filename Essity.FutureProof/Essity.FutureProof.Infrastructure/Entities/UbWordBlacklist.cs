using System.ComponentModel.DataAnnotations;

namespace Essity.FutureProof.Infrastructure.Entities
{
    public class UbWordBlacklist
    {
        [Key]
        public int Id { get; set; }

        public string? Word { get; set; }
    }
}