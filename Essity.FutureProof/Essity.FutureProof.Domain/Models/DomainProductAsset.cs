using System.Runtime.Serialization;
using Essity.FutureProof.Domain.Enums;

namespace Essity.FutureProof.Domain.Models
{
    [Serializable]
    [DataContract]
    public class DomainProductAsset
    {
        [DataMember]
        public string? Name { get; set; }

        [DataMember]
        public string? Value { get; set; }

        [DataMember]
        public DomainProductAssetType AssetType { get; set; }

        [DataMember]
        public RenditionType Rendition { get; set; }

        public override int GetHashCode() => (Name + Value + AssetType.ToString() + Rendition.ToString()).GetHashCode();

        public override string ToString() => GetHashCode().ToString();
    }
}