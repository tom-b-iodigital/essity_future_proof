using System.ComponentModel;

namespace Essity.FutureProof.Domain.Enums
{
    public enum ProductMoistness
    {
        NotSet,
        [Description("wet")]
        Moist,
        [Description("dry")]
        Dry
    }
}
