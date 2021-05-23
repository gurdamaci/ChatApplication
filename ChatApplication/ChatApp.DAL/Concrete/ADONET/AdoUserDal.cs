using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.DAL.Abstract;
using ChatApp.Entities.Concrete;

namespace ChatApp.DAL.Concrete.ADONET
{
    public class AdoUserDal: IUserDal
    {
        #region Veritabanı Bağlantı
        private AdoNetContext veritabani;

        public AdoUserDal()
        {
            veritabani = AdoNetContext.Olustur();
        }
 
        #endregion
        public void AddUser(User user)
        {
            try
            {
                veritabani.BaglantiKur();
                SqlCommand komut = new SqlCommand("[SP_USER_INSERT]", veritabani.BAGLANTI);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@name", user.Name);
                komut.Parameters.AddWithValue("@surname", user.SurName);
                komut.Parameters.AddWithValue("@mail", user.Mail);

                int etikelenen = komut.ExecuteNonQuery();

                veritabani.BaglantiKes();
            }
            catch (Exception ex)
            {
                veritabani.BaglantiKes();
                throw new ArgumentException("VK:USER Ekleme Hata .Orjinal Hata Mesajı:" + ex.Message);
            }
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

    }
}
