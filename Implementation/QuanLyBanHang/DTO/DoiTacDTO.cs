using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DoiTacDTO
    {
        public int ID;
        public string Ten;
        public DateTime NgayKyHD;
        public DateTime NgayHetHanHD;
        public string ViTriDang;
        public int IDBaiQC;

        public DoiTacDTO()
        {
            this.ID = -1;
            this.Ten = null;
            this.NgayKyHD = DateTime.Now;
            this.NgayHetHanHD = DateTime.Now;
            this.ViTriDang = "";
            this.IDBaiQC = 0;
        }

        public DoiTacDTO(int id,string Ten, DateTime NgayKyHD, DateTime NgayHetHanHD, string ViTriDang,int IDBaiQC)
        {
            this.ID = id;
            this.Ten = Ten;
            this.NgayKyHD = NgayKyHD;
            this.NgayHetHanHD = NgayHetHanHD;
            this.ViTriDang = ViTriDang;
            this.IDBaiQC = IDBaiQC;
        }

        public DoiTacDTO(string Ten, DateTime NgayKyHD,DateTime NgayHetHanHD,string ViTriDang)
        {
            this.Ten = Ten;
            this.NgayKyHD = NgayKyHD;
            this.NgayHetHanHD = NgayHetHanHD;
            this.ViTriDang = ViTriDang;
            //this.isDeleted = 0;
        }
       
    }
}
