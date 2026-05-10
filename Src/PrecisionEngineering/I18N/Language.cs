using PrecisionEngineering.I18N;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Lang = System.Collections.Generic.Dictionary<string, string>;

namespace PrecisionEngineering.I18N
{
    //using Lang = Dictionary<string, string>;
    internal class Language
    {
        readonly static Dictionary<ModSettings.Languages, CultureInfo> LANGUAGE = new Dictionary<ModSettings.Languages, CultureInfo>
        {
            {ModSettings.Languages.en_US,new CultureInfo("en-US") },
            {ModSettings.Languages.zh_CN,new CultureInfo("zh-CN") },
            {ModSettings.Languages.zh_TW,new CultureInfo("zh-TW") },
            {ModSettings.Languages.zh_HK,new CultureInfo("zh-HK") }
        };

        public static CultureInfo getLanguage(ModSettings.Languages lanCode)
        {
            if (LANGUAGE.ContainsKey(lanCode))
            {
                return LANGUAGE[lanCode]; 
            }
            return LANGUAGE[ModSettings.Languages.en_US];
        }
    }
}
