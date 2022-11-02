using System.Configuration;

namespace Essity.FutureProof.Connector.PCH.Config
{
    public class PchSettingElement : ConfigurationElement
    {
        [ConfigurationProperty("environment", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["environment"]; }
            set { this["environment"] = value; }
        }

        [ConfigurationProperty("tokenSubscriptionKey", IsRequired = false)]
        public string TokenSubscriptionKey
        {
            get { return (string)this["tokenSubscriptionKey"]; }
            set { this["tokenSubscriptionKey"] = value; }
        }

        [ConfigurationProperty("tokenUrl", IsRequired = false)]
        public string TokenUrl
        {
            get { return (string)this["tokenUrl"]; }
            set { this["tokenUrl"] = value; }
        }

        [ConfigurationProperty("apiUrl", IsRequired = true)]
        public string ApiUrl
        {
            get { return (string)this["apiUrl"]; }
            set { this["apiUrl"] = value; }
        }

        [ConfigurationProperty("apiSubscriptionKey", IsRequired = false)]
        public string ApiSubscriptionKey
        {
            get { return (string)this["apiSubscriptionKey"]; }
            set { this["apiSubscriptionKey"] = value; }
        }

        [ConfigurationProperty("clientsecret")]
        public string ClientSecret
        {
            get { return (string)this["clientsecret"]; }
            set { this["clientsecret"] = value; }
        }
    }
}