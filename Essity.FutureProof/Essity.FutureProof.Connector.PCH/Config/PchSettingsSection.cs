using System.Configuration;

namespace Essity.FutureProof.Connector.PCH.Config
{
    public class PchSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("settings", IsDefaultCollection = true)]
        public PchSettingCollection PchSettings
        {
            get { return (PchSettingCollection)this["settings"]; }
            set { this["settings"] = value; }
        }
    }
}