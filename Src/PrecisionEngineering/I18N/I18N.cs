using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using LangCode = PrecisionEngineering.ModSettings.Languages;

namespace PrecisionEngineering.I18N
{
    internal class I18n
    {
        static LangCode languageName = ModSettings.LanguageCode;
        static Dictionary<string, string> curLanguage = Language.getLanguage(languageName);
        static Dictionary<string, string> EN_US_LANGUAGE = Language.getLanguage(LangCode.en_US);

        public static void SetLanguage(LangCode lanCode) 
        {
            languageName = lanCode; 
            curLanguage = Language.getLanguage(languageName);
        }

        public static string Trans(string key, params object[] args) 
        {
            if (curLanguage.ContainsKey(key))
            {
                return string.Format(curLanguage[key],args);
            }
            if (EN_US_LANGUAGE.ContainsKey(key))
            {
                return string.Format(EN_US_LANGUAGE[key],args);
            }
            return key;
        }

        public static bool HasTrans(string key)
        {
            if (curLanguage.ContainsKey(key))
            {
                return true;
            }
            if (EN_US_LANGUAGE.ContainsKey(key))
            {
                return true;
            }
            return false;
        }
    }
}
