using System.ComponentModel;

namespace Essity.FutureProof.Domain.Enums
{
    public enum ProductNumberOfLayers
    {
        NotSet,
        [Description("2layers")]
        Two = 2,
        [Description("3layers")]
        Three = 3,
        [Description("4layers")]
        Four = 4,
        [Description("5layers")]
        Five = 5
    }
}
