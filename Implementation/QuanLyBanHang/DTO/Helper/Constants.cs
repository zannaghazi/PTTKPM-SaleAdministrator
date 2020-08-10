﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Helper
{
    public class Constants
    {
        // USER TYPE
        public static int USERTYPE_MANAGER = 0; // Quản lý
        public static int USERTYPE_SALE = 1; // Người bán hàng
        public static int USERTYPE_SHIPPER = 2; // Người giao hàng
        public static int USERTYPE_ADVERTISER = 3; // Người đăng tin
        public static int USERTYPE_TREASURER = 4; // Thủ quỹ

        // LOGIN STATUS
        public static int LOGINSTAT_NONE = 0;
        public static int LOGINSTAT_LOGGED = 1;
    }
}
