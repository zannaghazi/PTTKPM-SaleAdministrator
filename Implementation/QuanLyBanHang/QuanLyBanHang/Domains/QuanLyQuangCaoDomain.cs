using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;

namespace QuanLyBanHang.Domains
{

    public class QuanLyQuangCaoDomain
    {
        public List<Models.Partner> listPartner = new List<Models.Partner>();
        public List<Models.QangCaoSDT> listQCSDT = new List<Models.QangCaoSDT>();

        public Domains.QuanLyKhachHangDomain quanLyKhachHangDomain = new Domains.QuanLyKhachHangDomain();
        public QuanLyQuangCaoDomain()
        {

        }

        public void LoadPartner(Repository.Repository repository)
        {
            this.listPartner = new List<Models.Partner>();

            string queryString = "select* from qcpartner where isDeleted = false";
            repository.cmd.CommandText = queryString;

            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    MessageBox.Show(
                        "Data chưa có dữ liệu",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    while (reader.Read())
                    {
                        Models.Partner temp = new Models.Partner(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDateTime(2),
                             reader.GetDateTime(3),
                            reader.GetString(4));
                        this.listPartner.Add(temp);
                    }

                }
            }
        }

        public Models.Partner GetPartnerByID(Repository.Repository repository, int id)
        {
            string queryString = "select* from Partner where id=" + id;
            repository.cmd.CommandText = queryString;

            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return new Models.Partner();
                }
                else
                {
                    Models.Partner temp = new Models.Partner();
                    while (reader.Read())
                    {
                        temp = new Models.Partner(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDateTime(2),
                             reader.GetDateTime(3),
                            reader.GetString(4));
                        break;
                    }
                    return temp;
                }
            }
        }

        public void AddPartner(Repository.Repository repository, Models.Partner sp)
        {
            DateTime serverTime = DateTime.Now;
           
            string queryString = "INSERT INTO qcpartner(`partner_name`, `date`, `deadline`, `infopost`, `isDeleted`)" +
                "values('" + sp.partner_name +
                "', '" + sp.begindate.ToString("yyyy-MM-dd H:mm:ss") +
                "', '" + sp.deadline.ToString("yyyy-MM-dd H:mm:ss") +
                "', '" + sp.infopost + "',  false)";
            repository.cmd.CommandText = queryString;
            try
            {
                repository.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình thêm dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            queryString = "select* from qcpartner order by id desc limit 1";
            repository.cmd.CommandText = queryString;
            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    MessageBox.Show(
                        "Data chưa có dữ liệu",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    while (reader.Read())
                    {
                        Models.Partner temp = new Models.Partner(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDateTime(2),
                             reader.GetDateTime(3),
                            reader.GetString(4));
                        this.listPartner.Add(temp);
                    }
                }
            }
        }

        public void UpdatePartner(Repository.Repository repository, Models.Partner pr)
        {
            string queryString = "update qcpartner set deadline='" + pr.deadline.ToString("yyyy-MM-dd H:mm:ss") + "' where id=" + pr.ID;
            repository.cmd.CommandText = queryString;
            try
            {
                repository.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            this.LoadPartner(repository);
        }


        public void LoadQCSDT(Repository.Repository repository)
        {
            this.listQCSDT = new List<Models.QangCaoSDT>();
            string queryString = "SELECT qc.id,cs.id, cs.sdt,qc.id_item,qc.dateqc  FROM quangcaosdt as qc, customer as cs where qc.id_customer = cs.id ";
            repository.cmd.CommandText = queryString;

            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    MessageBox.Show(
                        "Data chưa có dữ liệu",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    while (reader.Read())
                    {
                        Models.QangCaoSDT temp = new Models.QangCaoSDT(
                            reader.GetInt32(0),
                             reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetDateTime(4));
                        this.listQCSDT.Add(temp);
                    }

                }
            }
           
        }
        public void AddQCmobile(Repository.Repository repository, List<Models.Customer> cs,int  idSP, InitPage parent)
        {
            DateTime serverTime = DateTime.Now;
          

            for(int i = 0;i < cs.Count; i++)
            {
                string queryString = "INSERT INTO quangcaosdt(`id_customer`, `id_item`, `dateqc`)" +
                "values('" + cs[i].ID +
                "', '" + idSP +
                "', '" + serverTime.ToString("yyyy-MM-dd H:mm:ss") +"')";
                repository.cmd.CommandText = queryString;
                try
                {
                    repository.cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Có lỗi xảy ra trong quá trình thêm dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                queryString = "SELECT qc.id,cs.id, cs.sdt,qc.id_item,qc.dateqc  FROM quangcaosdt as qc, customer as cs where qc.id_customer = cs.id order by id desc limit 1";
                repository.cmd.CommandText = queryString;
                using (DbDataReader reader = repository.cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show(
                            "Data chưa có dữ liệu",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Models.QangCaoSDT temp = new Models.QangCaoSDT(
                             reader.GetInt32(0),
                             reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetDateTime(4));
                            this.listQCSDT.Add(temp);
                        }
                    }
                }
            }
           
        }

    }
}
