using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Helper
{
    /// <summary>
    /// Enum storage
    /// </summary>
    public class MyEnum
    {
        /// <summary>
        /// Enum storage type of comment
        /// </summary>
        public enum TypeComment
        {
            [Description("Chưa phân loại")]
            None,
            [Description("Tốt")]
            Good,
            [Description("Xấu")]
            Bad,
            [Description("Bình thường")]
            Normal
        }

        /// <summary>
        /// Enum storage type handle
        /// </summary>
        public enum HandleType
        {
            [Description("Chưa xử lý")]
            None,
            [Description("Đã cộng điểm")]
            Good,
            [Description("Đã xóa")]
            Bad,
        }
    }
}
