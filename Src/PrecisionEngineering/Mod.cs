using System;
using ICities;

namespace PrecisionEngineering
{
    public class Mod : IUserMod
    {
        public string Name
        {
            get { return "精确构建（Precision Engineering）"; }
        }

        public string Description
        {
            get
            {
                return
                    "精确构建。按住CTRL键可启用角度捕捉，按住SHIFT键可显示更多信息，按住ALT键可捕捉到参考线。";
            }
        }

        public void OnSettingsUI(UIHelperBase helper)
        {
            var group = helper.AddGroup("UI");
            var opt1 = new[] { I18N.I18N.Trans("option.changui"), I18N.I18N.Trans("option.da"), I18N.I18N.Trans("option.teda") };
            group.AddDropdown(I18N.I18N.Trans("option.zitidaxiao"), opt1, ModSettings.FontSize,
                OnFontSizeChanged); 
            var opt2 = new[] { I18N.I18N.Trans("option.gongzhi"), I18N.I18N.Trans("option.yingzhi") };
            group.AddDropdown(I18N.I18N.Trans("option.jiliangdanwei"), opt2, (int)ModSettings.Unit,
                OnMeasurementUnitChanged);

            group.AddDropdown("🌐", languages, (int)ModSettings.LanguageCode, OnLanguageChanged);
        }

        private void OnMeasurementUnitChanged(int sel)
        {
            ModSettings.Unit = (ModSettings.Units) sel;
        }

        private void OnFontSizeChanged(int val)
        {
            ModSettings.FontSize = val;
        }

        private readonly string[] languages = { "简体中文(中国大陆)", "繁體中文(台湾地区)", "繁體中文(香港特区)", "English(US)" };

        private void OnLanguageChanged(int val)
        {
            ModSettings.LanguageCode = (ModSettings.Languages)val;
            I18N.I18N.SetLanguage(ModSettings.LanguageCode);
        }
    }
}
