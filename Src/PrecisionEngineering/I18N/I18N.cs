using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace PrecisionEngineering.I18N
{
    internal class I18N
    {
        static ModSettings.Languages languageName = ModSettings.LanguageCode;
        static Dictionary<string, string> curLanguage = Language.getLanguage(languageName);
        static Dictionary<string, string> EN_US_LANGUAGE = Language.getLanguage(ModSettings.Languages.en_US);

        public static void SetLanguage(ModSettings.Languages lanCode) 
        {
            languageName = lanCode; 
            curLanguage = Language.getLanguage(languageName);
        }

        public static string Trans(string key) 
        {
            if (curLanguage.ContainsKey(key))
            {
                return curLanguage[key];
            }
            if (EN_US_LANGUAGE.ContainsKey(key))
            {
                return EN_US_LANGUAGE[key];
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
