using System.Runtime.Serialization;
using Essity.FutureProof.Domain.Enums;

namespace Essity.FutureProof.Domain.Models
{
    [Serializable]
    [DataContract]
    public class AssetWithGroupedRenditions
    {
        [DataMember]
        public string? Name { get; set; }

        [DataMember]
        public string? Ean { get; set; }

        [DataMember]
        public DomainProductAssetType AssetType { get; set; }

        [DataMember]
        public IEnumerable<KeyValuePair<RenditionType, string>>? Renditions { get; set; }
    }
}