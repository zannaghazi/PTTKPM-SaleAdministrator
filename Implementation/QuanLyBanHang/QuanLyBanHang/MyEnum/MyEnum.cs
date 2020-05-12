using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.MyEnum
{
    public class MyEnum
    {
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
    }
}
