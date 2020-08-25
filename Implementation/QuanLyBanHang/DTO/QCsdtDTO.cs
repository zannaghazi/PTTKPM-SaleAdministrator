using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class QCsdtDTO
    {
        public int ID;
        public int IDBaiQC;
        public string name;
        public string sdt;
        public string dateqc;

        public QCsdtDTO()
        {
            this.ID = -1;
            this.IDBaiQC = -1;
            this.name = null;
            this.sdt = null;
            this.dateqc = null;
        }
        public QCsdtDTO(string name,string sdt,string dateqc)
        {
            this.name = name;
            this.sdt = sdt;
            this.dateqc = dateqc;
        }
        public QCsdtDTO(string name, string sdt, string dateqc, int IDBaiQC)
        {
            this.IDBaiQC = IDBaiQC;
            this.name = name;
            this.sdt = sdt;
            this.dateqc = dateqc;
        }
        public QCsdtDTO(string name, string sdt)
        {
            this.name = name;
            this.sdt = sdt;
            this.dateqc = null;
            this.IDBaiQC = -1;
        }

        public QCsdtDTO(int IDBaiQC,string sdt, string dateqc)
        {
            this.IDBaiQC = IDBaiQC;
            this.sdt = sdt;
            this.dateqc = dateqc;
        }
    }
}
