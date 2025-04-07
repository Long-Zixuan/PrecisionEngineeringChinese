using System;
using ICities;

namespace PrecisionEngineering
{
    public class Mod : IUserMod
    {
        public string Name
        {
            get { return "精確構建（Precision Engineering）"; }
        }

        public string Description
        {
            get
            {
                return
                    "精確構建。 按住CTRL鍵可啟用角度捕捉，按住SHIFT鍵可顯示更多資訊，按住ALT鍵可捕捉到參攷線。";
            }
        }

        public void OnSettingsUI(UIHelperBase helper)
        {
            var group = helper.AddGroup("UI");
            group.AddDropdown("字體大小", new [] { "一般", "大", "特大"}, ModSettings.FontSize,
                OnFontSizeChanged); 
            
            group.AddDropdown("計量單位", new [] {"公制", "英制"}, (int)ModSettings.Unit,
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
