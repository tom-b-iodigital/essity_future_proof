using Essity.FutureProof.Connector.PCH.Enums;
using System.Configuration;

namespace Essity.FutureProof.Connector.PCH.Config
{
    public static class PchSettings
    {
        public static PchSettingElement? GetPchSetting(PchMode mode)
        {
            PchSettingElement? returnRmsSettingsElement = null;

            PchSettingsSection? pchSettingsSection = ConfigurationManager.GetSection("pchSettings") as PchSettingsSection;

            if (pchSettingsSection != null)
            {
                foreach (PchSettingElement settingsElement in pchSettingsSection.PchSettings)
                {
                    if (settingsElement.Name.Equals(mode.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        returnRmsSettingsElement = settingsElement;
                    }
                }
                return returnRmsSettingsElement;
            }
            return null;
        }
    }
}