using System.Configuration;

namespace Essity.FutureProof.Connector.PCH.Config
{
    [ConfigurationCollection(typeof(PchSettingElement))]
    public class PchSettingCollection : ConfigurationElementCollection
    {
        protected override string ElementName
        {
            get { return "PCH"; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PchSettingElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PchSettingElement)element).Name;
        }
    }
}