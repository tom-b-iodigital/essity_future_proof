using System.ComponentModel;

namespace Essity.FutureProof.Domain.Enums
{
    public enum ProductPackFormat
    {
        [Description("box-format")]
        BoxFormat,
        [Description("half-sheet")]
        HalfSheet,
        [Description("full-sheet")]
        FullSheet,
        [Description("pocket-pack")]
        PocketFormat,
        [Description("roll")]
        Roll,
        [Description("soft-pack")]
        SoftPack,
        [Description("cube-format")]
        CubeFormat
    }
}
