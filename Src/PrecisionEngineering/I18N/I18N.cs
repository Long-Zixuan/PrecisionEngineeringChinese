using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using LangCode = PrecisionEngineering.ModSettings.Languages;
using static GeneratedString;
using System.Resources;

namespace PrecisionEngineering.I18N
{
    internal class I18n
    {
        static LangCode languageName = ModSettings.LanguageCode;
        static CultureInfo curLanguage = Language.getLanguage(languageName);
        static CultureInfo EN_US_LANGUAGE = Language.getLanguage(LangCode.en_US);
        static ResourceManager resourceMgr = new ResourceManager("PrecisionEngineering.I18N." + curLanguage.Name, typeof(I18n).Assembly);
        static ResourceManager EN_US_RESOURCE = new ResourceManager("PrecisionEngineering.I18N." + EN_US_LANGUAGE.Name, typeof(I18n).Assembly);

        public static void SetLanguage(LangCode lanCode) 
        {
            languageName = lanCode; 
            curLanguage = Language.getLanguage(languageName);
            resourceMgr = new ResourceManager("PrecisionEngineering.I18N." + curLanguage.Name, typeof(I18n).Assembly);
        }

        public static string Trans(string key, params object[] args)
        {
            try
            {
                var s = resourceMgr.GetString(key, curLanguage);
                if (s.Equals(key))
                {
                    try
                    {
                        s = EN_US_RESOURCE.GetString(key, EN_US_LANGUAGE);
                        return string.Format(s, args);
                    }
                    catch
                    {
                        return key;
                    }
                }
                return string.Format(s, args);
            }
            catch 
            {
                try
                {
                    var s = EN_US_RESOURCE.GetString(key, EN_US_LANGUAGE);
                    return string.Format(s, args);
                }
                catch
                {
                    return key;
                }
            }
        }

        public static bool HasTrans(string key)
        {
            try
            {
                var s = resourceMgr.GetString(key, curLanguage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
