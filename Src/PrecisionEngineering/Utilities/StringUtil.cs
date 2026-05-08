using System;
using ColossalFramework.UI;
using UnityEngine;
//using I18n = PrecisionEngineering.I18N.I18n;
using PrecisionEngineering.I18N;

namespace PrecisionEngineering.Utilities
{
    //using PrecisionEngineering.I18n;
    internal static class StringUtil
    {
        public static string ToString(NetTool.ControlPoint pt)
        {
            return string.Format("  Position: {0}, Direction: {1}\n\t, Node: {2}, Segment: {3}, Elevation: {4}",
                pt.m_position,
                pt.m_direction, pt.m_node, pt.m_segment, pt.m_elevation);
        }

        public static string ToString(NetTool.NodePosition pt)
        {
            return string.Format("  Position: {0}, Direction: {1}", pt.m_position, pt.m_direction);
        }

        public static string GetDistanceMeasurementString(float distance, bool highPrecision = false)
        {
           int u = (int)(distance / 8f).RoundToNearest(1);

            if (!highPrecision)
            {
                return string.Format(I18n.Trans("unit.ge"), u);
                //return $"{u:#}格";
            }

            switch (ModSettings.Unit)
            {
                case ModSettings.Units.Metric:
                    return string.Format(I18n.Trans("unit.ge_mi"), u, (int) distance.RoundToNearest(1));
                    //return $"{u:#}格 ({(int) distance.RoundToNearest(1):#}米)";
                case ModSettings.Units.Imperial:
                    return string.Format(I18n.Trans("unit.ge"),u) + $" ({GetImperial(distance, false)})";
                    //return $"{u:#}格 ({GetImperial(distance, false)})";
            }

            throw new NotImplementedException("Unknown unit");
        }

        public static string GetHeightMeasurementString(float height)
        {
            switch (ModSettings.Unit)
            {
                case ModSettings.Units.Metric:
                    return string.Format(I18n.Trans("unit.mi"), (int)height.RoundToNearest(1));
                    //return $"{(int) height.RoundToNearest(1):#}米";
                case ModSettings.Units.Imperial:
                    return $"{GetImperial(height, true)}";
            }

            throw new NotImplementedException("Unknown unit");
        }

        /// <summary>
        /// lets just ignore the irony of using imperial units for 'precision engineering'...
        /// </summary>
        /// <param name="meterDistance">Distance in meters</param>
        /// <param name="isHeight">Is this a height measurement? (force feet instead of yards)</param>
        /// <returns>A string of yards/feet (e.g. 2 yards 1ft</returns>
        public static string GetImperial(float meterDistance, bool isHeight)
        {
            if (isHeight)
            {
                // force ft
                return string.Format(I18n.Trans("unit.yinchi"), (meterDistance * 3.28084f).RoundToNearest(1));
                //return $"{(meterDistance * 3.28084f).RoundToNearest(1)}英尺";
            }

            float yardsExact = meterDistance * 1.09361f;
            int yards = Mathf.FloorToInt(yardsExact);
            float remainder = yards - yardsExact;

            int feet = Mathf.FloorToInt(remainder / 3f);

            if (feet > 0)
            {
                return string.Format(I18n.Trans("unit.ma_yinchi"), yards, feet);
                //return $"{yards}码 {feet}英尺";
            }
            return string.Format(I18n.Trans("unit.ma"), yards);
            //return $"{yards}码";
        }
    }
}
