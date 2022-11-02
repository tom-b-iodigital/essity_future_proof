using System.ComponentModel.DataAnnotations;

namespace Essity.FutureProof.Infrastructure.Entities
{
    public partial class UbComment
    {
        public int Id { get; set; }

        public int NodeId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Author { get; set; }

        [Required]
        public string? CommentText { get; set; }

        public int SiteId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}