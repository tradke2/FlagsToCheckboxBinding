using System;
using System.Globalization;
using System.Windows.Data;

namespace FlagsToCheckboxBinding
{
    /// <summary>
    /// 
    /// </summary>
    public class FlagsToBoolConverter : IMultiValueConverter
    {
        private FlagDescription iFlagDescription = FlagDescription.FlagOne;
        private int iVerwendung = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2)
                return false;

            int? verwendungValue = values[0] as int?;
            FlagDescription appDomainInfo = values[1] as FlagDescription;
            if (appDomainInfo == null)
                return false;

            iFlagDescription = appDomainInfo;
            iVerwendung = verwendungValue.GetValueOrDefault(0);

            bool result = (iVerwendung & appDomainInfo.Value) != 0;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            bool? incomingFlag = value as bool?;

            if (incomingFlag.HasValue)
            {
                bool flag = incomingFlag.Value;
                if (flag == true)
                    iVerwendung |= iFlagDescription.Value;
                else
                    iVerwendung &= ~iFlagDescription.Value;
            }

            object[] result = new object[] { iVerwendung, iFlagDescription };
            return result;
        }
    }
}
