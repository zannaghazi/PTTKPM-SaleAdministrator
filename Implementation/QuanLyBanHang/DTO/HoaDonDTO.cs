using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class HoaDonDTO
    {
        public int ID;
        public string TenKhach;
        public string TenNV;
        public DateTime Ngay;
        public string Gia;
        public int TrangThai;

        public HoaDonDTO()
        {
            this.ID = -1;
            this.TenKhach = null;
            this.TenNV = null;
            this.Ngay = DateTime.Now;
            this.Gia = null;
            this.TrangThai = 0;
        }

        public HoaDonDTO(int id, string TenKhach, string TenNV,DateTime Ngay,string Gia, int TrangThai)
        {
            this.ID = id;
            this.TenKhach = TenKhach;
            this.TenNV = TenNV;
            this.Ngay = Ngay;
            this.Gia = Gia;
            this.TrangThai = TrangThai;
        }
        public HoaDonDTO(int id, int TrangThai)
        {
            this.ID = id;
            this.TrangThai = TrangThai;
        }
    }

}
