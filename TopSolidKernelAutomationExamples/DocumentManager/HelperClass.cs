using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopSolid.Kernel.Automating;

namespace DocumentManager
{
    public static class HelperClass
    {
        public static string GetParameterValue(ElementId param, ParameterType paramType)
        {
            switch (paramType)
            {
                case ParameterType.Real:
                    return TopSolidHost.Parameters.GetRealValue(param).ToString();
                case ParameterType.Integer:
                    return TopSolidHost.Parameters.GetIntegerValue(param).ToString();
                case ParameterType.Boolean:
                    return TopSolidHost.Parameters.GetBooleanValue(param).ToString();
                case ParameterType.Text:
                    return TopSolidHost.Parameters.GetTextValue(param);
                case ParameterType.DateTime:
                    return TopSolidHost.Parameters.GetDateTimeValue(param).ToString();
                case ParameterType.Enumeration:
                    return TopSolidHost.Parameters.GetEnumerationValue(param).ToString();
                case ParameterType.UserEnumeration:
                    return TopSolidHost.Parameters.GetUserEnumerationValue(param).ToString();
                case ParameterType.Color:
                    return TopSolidHost.Parameters.GetColorValue(param).ToString();
                default:
                    return "Unknown Type";
            }
        }

        public static bool IsSystemParameter(ElementId param)
        {
            string paramName = TopSolidHost.Elements.GetName(TopSolidHost.Elements.GetOwner(param));
            return paramName.Contains("System");
        }

        public static bool GetDoubleValue(string textValue,out double outValue)
        {
            outValue = 0;
            return double.TryParse(textValue, out outValue);
        }

        public static bool GetIntValue(string textValue, out int outValue)
        {
            outValue = 0;
            return int.TryParse(textValue, out outValue);
        }

        public static bool GetTextValue(string textValue, out string outValue)
        {
            outValue = textValue;
            return true;
        }
    }
}
