using PrecisionEngineering.I18N;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lang = System.Collections.Generic.Dictionary<string, string>;

namespace PrecisionEngineering.I18N
{
    //using Lang = Dictionary<string, string>;
    internal class Language
    {

        readonly static Lang ZH_CN = new Lang
        {
            { "unit.gaocheng","高程: {0}" },
            { "unit.gao","高: {0}" },
            { "unit.ge_mi","{0:#}格 ({1:#}米)" },
            { "unit.ge","{0:#}格" },
            { "unit.mi","{0:#}米" },
            { "unit.ma","{0:#}码" },
            { "unit.yinchi","{0:#}英尺" },
            { "unit.ma_yinchi","{0:#}码  {1:#}英尺"},
            { "option.zitidaxiao","字体大小" },
            { "option.changui","常规" },
            { "option.da","大" },
            { "option.teda","特大" },
            { "option.jiliangdanwei","计量单位"},
            { "option.yingzhi","英制" },
            { "option.gongzhi","公制" },
            { "option.yuyan","语言（Language）" }

        };

        readonly static Lang ZH_TW = new Lang
        {
            { "unit.gaocheng","高程: {0}" },
            { "unit.gao","高: {0}" },
            { "unit.ge_mi","{0:#}格 ({1:#}米)" },
            { "unit.ge","{0:#}格" },
            { "unit.mi","{0:#}米" },
            { "unit.ma","{0:#}碼" },
            { "unit.yinchi","{0:#}英尺" },
            { "unit.ma_yinchi","{0:#}碼  {1:#}英尺"},
            { "option.zitidaxiao","字體大小" },
            { "option.changui","一般" },
            { "option.da","大" },
            { "option.teda","特大" },
            { "option.jiliangdanwei","計量單位"},
            { "option.yingzhi","英制" },
            { "option.gongzhi","公制" },
            { "option.yuyan","語言（Language）" }

        };

        readonly static Lang ZH_HK = new Lang
        {
            { "unit.gaocheng","高程: {0}" },
            { "unit.gao","高: {0}" },
            { "unit.ge_mi","{0:#}格 ({1:#}米)" },
            { "unit.ge","{0:#}格" },
            { "unit.mi","{0:#}米" },
            { "unit.ma","{0:#}碼" },
            { "unit.yinchi","{0:#}英尺" },
            { "unit.ma_yinchi","{0:#}碼  {1:#}英尺"},
            { "option.zitidaxiao","字體大小" },
            { "option.changui","常规" },
            { "option.da","大" },
            { "option.teda","特大" },
            { "option.jiliangdanwei","計量單位"},
            { "option.yingzhi","英制" },
            { "option.gongzhi","公制" },
            { "option.yuyan","語言（Language）" }
        };

        readonly static Lang EN_US = new Lang
        {
            { "unit.gaocheng","Elevation: {0}" },
            { "unit.gao","H: {0}" },
            { "unit.ge_mi","{0:#}u ({1:#} meter)" },
            { "unit.ge","{0:#}u" },
            { "unit.mi","{0:#} meter" },
            { "unit.ma","{0:#} yard" },
            { "unit.yinchi","{0:#} foot" },
            { "unit.ma_yinchi","{0:#} yard  {1:#} foot"},
            { "option.zitidaxiao","Font Size" },
            { "option.changui","General" },
            { "option.da","Large" },
            { "option.teda","Extra Large" },
            { "option.jiliangdanwei","Unit"},
            { "option.yingzhi","English" },
            { "option.gongzhi","Metric" },
            { "option.yuyan","Language" }
        };

        readonly static Dictionary<ModSettings.Languages, Dictionary<string, string>> LANGUAGE = new Dictionary<ModSettings.Languages, Dictionary<string, string>>
        {
            {ModSettings.Languages.en_US,EN_US },
            {ModSettings.Languages.zh_CN,ZH_CN },
            {ModSettings.Languages.zh_TW,ZH_TW },
            {ModSettings.Languages.zh_HK,ZH_HK }
        };

        public static Dictionary<string,string> getLanguage(ModSettings.Languages lanCode)
        {
            if (LANGUAGE.ContainsKey(lanCode))
            {
                return LANGUAGE[lanCode]; 
            }
            return LANGUAGE[ModSettings.Languages.en_US];
        }
    }
}
