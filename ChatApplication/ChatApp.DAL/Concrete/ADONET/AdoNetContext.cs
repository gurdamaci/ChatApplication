using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DAL.Concrete.ADONET
{
    /// <summary>
    ///   // Bağlantı tipinize göre kullanınız.
    /// </summary>
    public class AdoNetContext
    {
        //Tanımlamalar
        static AdoNetContext ornek;
        private string baglantiMetini;
        private SqlConnection baglanti;

        private AdoNetContext()
        {

            baglantiMetini = @" Server = ADILKUDULAPTOP; Database = ChatUygulamasi; Trusted_Connection = True;";
        }
        private AdoNetContext(string baglantiMetini)
        {
            this.baglantiMetini = baglantiMetini;
        }
        public static AdoNetContext Olustur()
        {
            if (ornek == null)
                ornek = new AdoNetContext();

            return ornek;
        }
        public static AdoNetContext Olustur(string baglantiMetini)
        {
            if (ornek == null)
                ornek = new AdoNetContext(baglantiMetini);
            else
                ornek.baglantiMetini = baglantiMetini;
            return ornek;
        }
        public void BaglantiKur()
        {
            try
            {
                if (baglanti == null)
                    baglanti = new SqlConnection(baglantiMetini);
                else
                    baglanti.ConnectionString = baglantiMetini;
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();
            }
            catch (Exception ex)
            {
                if (baglanti.State != ConnectionState.Closed)
                    baglanti.Close();
                throw new ArgumentException("Bağlantı Açılamadı.Orjinal Hata:" + ex.Message);
            }

        }
        public SqlConnection BAGLANTI
        {
            get
            {
                return baglanti;
            }
        }
        public string BaglantiMetini
        {
            get
            {
                return baglantiMetini;
            }
            set
            {
                baglantiMetini = value;
            }
        }
        public void BaglantiKes()
        {
            try
            {
                if (baglanti != null && baglanti.State != ConnectionState.Closed)
                    baglanti.Close();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Bağlantı Kapatılamadı. Orjinal Hata:" + ex.Message);
            }
        }
    }
}

