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
            group.AddDropdown("字体大小", new [] {"常规", "大", "特大"}, ModSettings.FontSize,
                OnFontSizeChanged); 
            
            group.AddDropdown("计量单位", new [] {"公制", "英制"}, (int)ModSettings.Unit,
                OnMeasurementUnitChanged);
        }

        private void OnMeasurementUnitChanged(int sel)
        {
            ModSettings.Unit = (ModSettings.Units) sel;
        }

        private void OnFontSizeChanged(int val)
        {
            ModSettings.FontSize = val;
        }
    }
}
