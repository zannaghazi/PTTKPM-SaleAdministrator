using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.MyEnum
{
    /// <summary>
    /// Helper class to handle Enum
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// Get description of enum
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns></returns>
        public static string StringValueOf(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
