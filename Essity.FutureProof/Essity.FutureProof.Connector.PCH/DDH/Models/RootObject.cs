namespace Essity.FutureProof.Connector.PCH.DDH.Models
{
    public class RootObject
    {
        public RootObject()
        {
            Products = new List<DdhProduct>();
        }

        public IEnumerable<DdhProduct> Products { get; set; }
    }
}
