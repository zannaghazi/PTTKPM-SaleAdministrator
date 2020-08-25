using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class QuangCaoDTO
    {
        public int ID;
        public string TieuDe;
        public string NoiDung;
        public int isDeleted;

        public QuangCaoDTO()
        {
            this.ID = -1;
            this.TieuDe = null;
            this.NoiDung = null;
            this.isDeleted = 0;
        }
        public QuangCaoDTO(int id,string TieuDe, string NoiDung,int isDeleted)
        {
            this.ID = id;
            this.TieuDe = TieuDe;
            this.NoiDung = NoiDung;
            this.isDeleted = isDeleted;
        }
        public QuangCaoDTO(string TieuDe, string NoiDung)
        {
            this.TieuDe = TieuDe;
            this.NoiDung = NoiDung;
            this.isDeleted = 0;
        }

    }
}
