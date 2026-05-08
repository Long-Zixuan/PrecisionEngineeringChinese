using System;
using UnityEngine;

namespace PrecisionEngineering
{
    internal static class ModSettings
    {
        public enum Units
        {
            Metric,
            Imperial
        }

        public static int FontSize
        {
            get
            {
                if (!_fontSize.HasValue)
                {
                    _fontSize = PlayerPrefs.GetInt("PE_FONT_SIZE", 0);
                }

                return _fontSize.Value;
            }
            set
            {
                if(value > 2)
                    throw new ArgumentOutOfRangeException();

                if (value == _fontSize)
                {
                    return;
                }
                PlayerPrefs.SetInt("PE_FONT_SIZE", value);
                _fontSize = value;
            }
        }

        public static Units Unit
        {
            get
            {
                if (!_unit.HasValue)
                {
                    _unit = (Units)PlayerPrefs.GetInt("PE_UNIT", 0);
                }

                return _unit.Value;
            }
            set
            {
                if (value == _unit)
                {
                    return;
                }
                PlayerPrefs.SetInt("PE_UNIT", (int)value);
                _unit = value;
            }
        }

        public enum Languages
        {
            zh_CN,
            zh_TW,
            zh_HK,
            en_US,
        }

        public static Languages LanguageCode
        {
            get
            {
                if(!_languageCode.HasValue)
                {
                    _languageCode = (Languages)PlayerPrefs.GetInt("PE_LANGUAGE_CODE", 0);
                }
                return _languageCode.Value;
            }
            set
            {
                if(value == _languageCode)
                {
                    return;
                }
                _languageCode = value;
                PlayerPrefs.SetInt("PE_LANGUAGE_CODE", (int)value);
            }
        }

        private static Units? _unit;
        private static int? _fontSize;
        private static Languages? _languageCode;
    }
}