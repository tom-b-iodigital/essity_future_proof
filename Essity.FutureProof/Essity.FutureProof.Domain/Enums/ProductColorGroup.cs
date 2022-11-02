using System.ComponentModel;

namespace Essity.FutureProof.Domain.Enums
{
    public enum ProductColorGroup
    {
        NotSet,
        [Description("white")]
        White,
        [Description("blue")]
        Colored
    }
}
