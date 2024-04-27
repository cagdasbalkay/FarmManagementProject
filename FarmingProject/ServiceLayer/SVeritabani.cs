
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmingProject
{
    public class SVeritabani
    {

        public SqlConnection baglanti = new SqlConnection("Data Source=CAGDASBALKAY\\SQLEXPRESS;Initial Catalog=ECOCRAFT_FARM;Integrated Security=True");

        public void VeritabaninaBaglan()
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
        }
        public void VeritabaniBaglantisiKapa()
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
        }
        public bool GirisYap(string kullaniciAd, string sifre)
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM Admin WHERE KULLANICI_AD = @kullaniciAd AND SIFRE = @sifre", baglanti);
            komut.Parameters.AddWithValue("kullaniciAd", kullaniciAd);
            komut.Parameters.AddWithValue("sifre", sifre);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                return true;
            }


            else
            {
                dr.Close();
                return false;
            }



        }

        public DataTable HayvanlariListele()
        {
            DataTable dataTableHayvanlar = new DataTable();
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("SELECT * FROM Animals", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.HasRows)
            {
                dataTableHayvanlar.Load(dr);
                dataTableHayvanlar.Columns["Animal_Type"].ColumnName = "Hayvan Tipi";
                dataTableHayvanlar.Columns["Animal_Name"].ColumnName = "Ad";
                dataTableHayvanlar.Columns["Animal_Color"].ColumnName = "Renk";
                dataTableHayvanlar.Columns["Animal_Breed"].ColumnName = "Tür";
                dataTableHayvanlar.Columns["Birth_Date"].ColumnName = "Doğum Tarihi";
                dataTableHayvanlar.Columns["Weight"].ColumnName = "Ağırlık";

            }
            dr.Close();
            return dataTableHayvanlar;
        }

        public void HayvanEkle(int hayvanNo, string hayvanTip, string hayvanAd, string renk, string cins, DateTime dogumTarih, float kilo)
        {
            VeritabaninaBaglan();


            SqlCommand komut = new SqlCommand("INSERT INTO Animals(Animal_No,Animal_Type,Animal_Name,Animal_Color,Animal_Breed,Birth_Date,Weight) VALUES(@animalNo,@animalType,@animalName,@animalColor,@animalBreed,@birthDate,@weight)", baglanti);

            komut.Parameters.AddWithValue("@animalNo", hayvanNo);
            komut.Parameters.AddWithValue("@animalType", hayvanTip);
            komut.Parameters.AddWithValue("@animalName", hayvanAd);
            komut.Parameters.AddWithValue("@animalColor", renk);
            komut.Parameters.AddWithValue("@animalBreed", cins);
            komut.Parameters.AddWithValue("@birthDate", dogumTarih);
            komut.Parameters.AddWithValue("@weight", kilo);


            
            komut.ExecuteNonQuery();

            VeritabaniBaglantisiKapa();
        }

        public void HayvanSil(int hayvanNo)
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("DELETE FROM Animals WHERE Animal_No = @id", baglanti);
            komut.Parameters.AddWithValue("@id", hayvanNo);
            komut.ExecuteNonQuery();
            VeritabaniBaglantisiKapa();
        }

        public bool TablodaEklenmekIstenenHayvanVarMi(int hayvanNo)
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("SELECT * FROM Animals WHERE Animal_No = @hayvanNo", baglanti);
            komut.Parameters.AddWithValue("@hayvanNo", hayvanNo);
            SqlDataReader dataReader = komut.ExecuteReader();
            if (dataReader.HasRows)
            {
                return true;
            }
            VeritabaniBaglantisiKapa();
            return false;
        }

        public void HayvanBilgileriDuzenle(string hayvanTip, string hayvanAd, string renk, string cins, DateTime dogumTarih, float kilo, int hayvanNo)
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("UPDATE Animals SET Animal_Type = @animalType, Animal_Name= @animalName, Animal_Color = @animalColor, Animal_Breed = @animalBreed ,Birth_Date = @birthDate, Weight = @weight WHERE Animal_No = @animalNo",baglanti);
           
            komut.Parameters.AddWithValue("@animalType", hayvanTip);
            komut.Parameters.AddWithValue("@animalName", hayvanAd);
            komut.Parameters.AddWithValue("@animalColor", renk);
            komut.Parameters.AddWithValue("@animalBreed", cins);
            komut.Parameters.AddWithValue("@birthDate", dogumTarih);
            komut.Parameters.AddWithValue("@weight", kilo);
            komut.Parameters.AddWithValue("@animalNo", hayvanNo);
            komut.ExecuteNonQuery();
            VeritabaniBaglantisiKapa();
        }
        public DataTable HayvanNolariGetir()
        {
            DataTable dt = new DataTable();
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("SELECT Animal_No FROM Animals", baglanti);
            SqlDataReader dataReader = komut.ExecuteReader();
            while (dataReader.HasRows)
            {
                dt.Load(dataReader);
                
                return dt;
            }
            return null;


        }

        public void SaglikBilgisiEkle(int hayvanNo, string hayvanAd, string hastalik, string teshis, DateTime teshisTarih, string tedavi, float tedaviUcreti, string veterinerAdi)
        {
            VeritabaninaBaglan();


            SqlCommand komut = new SqlCommand("INSERT INTO Animal_Health(Animal_No,Animal_Name,Event,Diagnosis,Date,Treatment, TreatmentCost,VeterinaryName) VALUES(@animalNo,@animalName,@event,@diagnosis,@date,@treatment, @treatmentCost,@veterinaryName)", baglanti);

            komut.Parameters.AddWithValue("@animalNo", hayvanNo);
            
            komut.Parameters.AddWithValue("@animalName", hayvanAd);
            komut.Parameters.AddWithValue("@event", hastalik);
            komut.Parameters.AddWithValue("@diagnosis", teshis);
            komut.Parameters.AddWithValue("@date", teshisTarih);
            komut.Parameters.AddWithValue("@treatment", tedavi);
            komut.Parameters.AddWithValue("@treatmentCost", tedaviUcreti);
            komut.Parameters.AddWithValue("@veterinaryName", veterinerAdi);
            komut.ExecuteNonQuery();

            VeritabaniBaglantisiKapa();
        }

        public DataTable SaglikBilgileriniListele()
        {
            DataTable dataTableSaglikBilgileri = new DataTable();
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("SELECT * FROM Animal_Health", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.HasRows)
            {
                dataTableSaglikBilgileri.Load(dr);
                dataTableSaglikBilgileri.Columns["Animal_Name"].ColumnName = "Ad";
                dataTableSaglikBilgileri.Columns["Event"].ColumnName = "Hastalık";
                dataTableSaglikBilgileri.Columns["Diagnosis"].ColumnName = "Teşhis";
                dataTableSaglikBilgileri.Columns["Date"].ColumnName = "Teşhis Tarihi";
                dataTableSaglikBilgileri.Columns["TreatmentCost"].ColumnName = "Tedavi Ücreti";
                dataTableSaglikBilgileri.Columns["VeterinaryName"].ColumnName = "Veteriner Adı";

            }
            dr.Close();
            return dataTableSaglikBilgileri;
        }

        public void SaglikBilgisiSil(int hayvanNo)
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("DELETE FROM Animal_Health WHERE Health_No = @id", baglanti);
            komut.Parameters.AddWithValue("@id", hayvanNo);
            komut.ExecuteNonQuery();
            VeritabaniBaglantisiKapa();
        }

        public void SaglikBilgisiGuncelle(int saglikNo, string hastalik, string teshis, DateTime teshisTarih, string tedavi, float tedaviUcreti, string veterinerAdi)
        {
            VeritabaninaBaglan();


            SqlCommand komut = new SqlCommand("UPDATE Animal_Health SET Event =@event,Diagnosis=@diagnosis,Date=@date,Treatment = @treatment, TreatmentCost=@treatmentCost,VeterinaryName=@veterinaryName WHERE Health_No = @healthNo", baglanti);
            
            komut.Parameters.AddWithValue("@event", hastalik);
            komut.Parameters.AddWithValue("@diagnosis", teshis);
            komut.Parameters.AddWithValue("@date", teshisTarih);
            komut.Parameters.AddWithValue("@treatment", tedavi);
            komut.Parameters.AddWithValue("@treatmentCost", tedaviUcreti);
            komut.Parameters.AddWithValue("@veterinaryName", veterinerAdi);
            komut.Parameters.AddWithValue("@healthNo", saglikNo);
            komut.ExecuteNonQuery();

            VeritabaniBaglantisiKapa();
        }

        public string HayvanAdiGetir(int hayvanNo)
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("SELECT Animal_Name FROM Animals WHERE Animal_No = @animalNo",baglanti);
            komut.Parameters.AddWithValue("animalNo", hayvanNo);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {

                string animalName = dr.GetString(0);
                dr.Close();
                return animalName;
            }
               
            else

                return "0";



        }

        public DataTable UretimListele()
        {
            DataTable dataTableUretim = new DataTable();
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("SELECT * FROM Production", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.HasRows)
            {
                dataTableUretim.Load(dr);
                dataTableUretim.Columns["Animal_No"].ColumnName = "Hayvan No";
                dataTableUretim.Columns["Animal_Name"].ColumnName = "Ad";
                dataTableUretim.Columns["Am_Production"].ColumnName = "Sabah Üretim";
                dataTableUretim.Columns["Noon_Production"].ColumnName = "Öğle Üretim";
                dataTableUretim.Columns["Afternoon_Production"].ColumnName = "Ö.S. Üretim";
                dataTableUretim.Columns["Total_Production"].ColumnName = "Toplam Üretim";
                dataTableUretim.Columns["Production_Date"].ColumnName = "Üretim Tarihi";

            }
            dr.Close();
            return dataTableUretim;
        }
        public bool TablodaEklenmekIstenenUretimVarMi(int hayvanNo)
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("SELECT * FROM Production WHERE Animal_No = @hayvanNo", baglanti);
            komut.Parameters.AddWithValue("@hayvanNo", hayvanNo);
            SqlDataReader dataReader = komut.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Close();
                return true;
            }
            dataReader.Close();
            VeritabaniBaglantisiKapa();
            return false;
        }
        public void UretimEkle(int hayvanNo, string hayvanAd, double sabahUretimi, double ogleUretimi, double osUretimi, double toplamUretim, DateTime uretimTarih)
        {
            VeritabaninaBaglan();


            SqlCommand komut = new SqlCommand("INSERT INTO Production  ([Animal_No] ,[Animal_Name],[Am_Production],[Noon_Production],[Afternoon_Production],[Total_Production],[Production_Date]) VALUES(@animalNo,@animalName,@amProduction,@noonProduction,@afternoonProduction,@totalProduction,@production_Date) ", baglanti);

            komut.Parameters.AddWithValue("animalNo", hayvanNo);
            komut.Parameters.AddWithValue("animalName", hayvanAd);
            komut.Parameters.AddWithValue("amProduction", sabahUretimi);
            komut.Parameters.AddWithValue("noonProduction", ogleUretimi);
            komut.Parameters.AddWithValue("afternoonProduction", osUretimi);
            komut.Parameters.AddWithValue("totalProduction", toplamUretim);
            komut.Parameters.AddWithValue("production_Date", uretimTarih);
            komut.ExecuteNonQuery();

            VeritabaniBaglantisiKapa();
        }

        public void UretimSil(int hayvanNo)
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("DELETE FROM Production WHERE Animal_No = @animalNo", baglanti);
            komut.Parameters.AddWithValue("@animalNo", hayvanNo);
            komut.ExecuteNonQuery();
            VeritabaniBaglantisiKapa();
        }

        public void UretimGuncelle(int hayvanNo, string hayvanAd, double sabahUretimi, double ogleUretimi, double osUretimi, double toplamUretim, DateTime uretimTarih)
        {
            VeritabaninaBaglan();


            SqlCommand komut = new SqlCommand("UPDATE Production SET Animal_Name = @animalName,Am_Production = @amProduction,Noon_Production = @noonProduction,Afternoon_Production = @afternoonProduction,Total_Production =@totalProduction,Production_Date= @production_Date", baglanti);

            komut.Parameters.AddWithValue("animalNo", hayvanNo);
            komut.Parameters.AddWithValue("animalName", hayvanAd);
            komut.Parameters.AddWithValue("amProduction", sabahUretimi);
            komut.Parameters.AddWithValue("noonProduction", ogleUretimi);
            komut.Parameters.AddWithValue("afternoonProduction", osUretimi);
            komut.Parameters.AddWithValue("totalProduction", toplamUretim);
            komut.Parameters.AddWithValue("production_Date", uretimTarih);
            komut.ExecuteNonQuery();

            VeritabaniBaglantisiKapa();
        }
        public DataTable SatisListele()
        {
            DataTable dataTableSatis = new DataTable();
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("SELECT * FROM Sales", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.HasRows)
            {
                dataTableSatis.Load(dr);
                dataTableSatis.Columns["Employee"].ColumnName = "Personel";
                dataTableSatis.Columns["Sale_Date"].ColumnName = "Satış Tarihi";
                dataTableSatis.Columns["Product"].ColumnName = "Ürün";
                dataTableSatis.Columns["Price"].ColumnName = "Ücret";
                dataTableSatis.Columns["Customer"].ColumnName = "Müşteri";
                dataTableSatis.Columns["Customer_Phone"].ColumnName = "Müşteri Tel";
                dataTableSatis.Columns["Quantity"].ColumnName = "Miktar";
                dataTableSatis.Columns["Total"].ColumnName = "Toplam";
            }
            dr.Close();
            return dataTableSatis;
        }

        public void SatisEkle(string personel, DateTime satisTarih, string urun, double ucret, string musteri, string musteriTel, double miktar, double toplam)
        {
            VeritabaninaBaglan();

            SqlCommand komut = new SqlCommand("INSERT INTO [dbo].[Sales] " +
                                "([Employee], [Sale_Date], [Product], [Price], [Customer], [Customer_Phone], [Quantity], [Total]) " +
                                "VALUES " +
                                "(@Employee, @Sale_Date, @Product, @Price, @Customer, @Customer_Phone, @Quantity, @Total)", baglanti);

            // Set parameters using AddWithValue
            komut.Parameters.AddWithValue("@Employee", personel);
            komut.Parameters.AddWithValue("@Sale_Date", satisTarih);
            komut.Parameters.AddWithValue("@Product", urun);
            komut.Parameters.AddWithValue("@Price", ucret);
            komut.Parameters.AddWithValue("@Customer", musteri);
            komut.Parameters.AddWithValue("@Customer_Phone", musteriTel);
            komut.Parameters.AddWithValue("@Quantity", miktar);
            komut.Parameters.AddWithValue("@Total", toplam);

            komut.ExecuteNonQuery();
        }


        public void SatisSil(int satisNo)
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("DELETE FROM Sales WHERE Sale_No = @satisNo", baglanti);
            komut.Parameters.AddWithValue("@satisNo", satisNo);
            komut.ExecuteNonQuery();
            VeritabaniBaglantisiKapa();
        }

        public DataTable PersonelGetir()
        {
            VeritabaninaBaglan(); 

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("KULLANICI_AD"); 

            SqlCommand komut = new SqlCommand("SELECT [KULLANICI_AD] FROM [dbo].[Admin]", baglanti);

            using (SqlDataReader dataReader = komut.ExecuteReader())
            {
                // Tüm satırları oku
                while (dataReader.Read())
                {
                    DataRow row = dt2.NewRow();
                    row["KULLANICI_AD"] = dataReader["KULLANICI_AD"];
                    dt2.Rows.Add(row);

                }
            }
           
            baglanti.Close(); 
            return dt2;
        }


        public void SatisGuncelle(string personel, DateTime satisTarih, string urun, double ucret, string musteri, string musteriTel, double miktar, double toplam, int satisNo)
        {
            VeritabaninaBaglan();

            SqlCommand komut = new SqlCommand("UPDATE [dbo].[Sales]\r\n" +
                                               "SET\r\n" +
                                               "    [Employee] = @Employee,\r\n" +
                                               "    [Sale_Date] = @Sale_Date,\r\n" +
                                               "    [Product] = @Product,\r\n" +
                                               "    [Price] = @Price,\r\n" +
                                               "    [Customer] = @Customer,\r\n" +
                                               "    [Customer_Phone] = @Customer_Phone,\r\n" +
                                               "    [Quantity] = @Quantity,\r\n" +
                                               "    [Total] = @Total\r\n" +
                                               "WHERE Sale_No = @satisNo", baglanti);

            komut.Parameters.AddWithValue("@Employee", personel);
            komut.Parameters.AddWithValue("@Sale_Date", satisTarih);
            komut.Parameters.AddWithValue("@Product", urun);
            komut.Parameters.AddWithValue("@Price", ucret);
            komut.Parameters.AddWithValue("@Customer", musteri);
            komut.Parameters.AddWithValue("@Customer_Phone", musteriTel);
            komut.Parameters.AddWithValue("@Quantity", miktar);
            komut.Parameters.AddWithValue("@Total", toplam);
            komut.Parameters.AddWithValue("@satisNo", satisNo);


            komut.ExecuteNonQuery();

            VeritabaniBaglantisiKapa();
        }

        public DataTable GiderListele()
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("SELECT * FROM Expenditures",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            DataTable dataTableGiderler = new DataTable();
            if(dr.HasRows)
            {
                dataTableGiderler.Load(dr);
                
                dataTableGiderler.Columns["ExpDate"].ColumnName = "Tarih";
                dataTableGiderler.Columns["ExpSource"].ColumnName = "Gider Kaynağı";
                dataTableGiderler.Columns["ExpAmount"].ColumnName = "Miktar";
                dataTableGiderler.Columns["Employee"].ColumnName = "Personel";

            }
            dr.Close();
            VeritabaniBaglantisiKapa();
            return dataTableGiderler;
            
        }
        public void GiderEkle(DateTime tarih, string kaynak, float miktar, string personel)
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("INSERT INTO Expenditures(ExpDate,ExpSource,ExpAmount,Employee) VALUES(@date,@source,@amount,@employee)",baglanti);
            komut.Parameters.AddWithValue("date", tarih);
            komut.Parameters.AddWithValue("source", kaynak);
            komut.Parameters.AddWithValue("amount", miktar);
            komut.Parameters.AddWithValue("employee", personel);

            komut.ExecuteNonQuery();
            VeritabaniBaglantisiKapa();
        }

        public DataTable GelirListele()
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("SELECT * FROM Incomes", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            DataTable dataTableGelirler = new DataTable();
            if (dr.HasRows)
            {
                dataTableGelirler.Load(dr);

                dataTableGelirler.Columns["IncDate"].ColumnName = "Tarih";
                dataTableGelirler.Columns["IncSource"].ColumnName = "Gelir Kaynağı";
                dataTableGelirler.Columns["IncAmount"].ColumnName = "Miktar";
                dataTableGelirler.Columns["Employee"].ColumnName = "Personel";

            }
            dr.Close();
            VeritabaniBaglantisiKapa();
            return dataTableGelirler;

        }
        public void GelirEkle(DateTime tarih, string kaynak, float miktar, string personel)
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("INSERT INTO Incomes(IncDate,IncSource,IncAmount,Employee) VALUES(@date,@source,@amount,@employee)", baglanti);
            komut.Parameters.AddWithValue("date", tarih);
            komut.Parameters.AddWithValue("source", kaynak);
            komut.Parameters.AddWithValue("amount", miktar);
            komut.Parameters.AddWithValue("employee", personel);

            komut.ExecuteNonQuery();
            VeritabaniBaglantisiKapa();
        }

        public float GelirGetir()
        {
            VeritabaninaBaglan();
            SqlCommand komut = new SqlCommand("SELECT SUM(IncAmount) AS 'IncAmount' FROM Incomes", baglanti);
            
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                return float.Parse(dr["IncAmount"].ToString());
               
            }
            dr.Close();
            
            VeritabaniBaglantisiKapa();

            return 0;

        }

        public float GiderGetir()
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=CAGDASBALKAY\\SQLEXPRESS;Initial Catalog=ECOCRAFT_FARM;Integrated Security=True")) 
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT SUM(ExpAmount) AS 'ExpAmount' FROM Expenditures", baglanti);

                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        float gider = float.Parse(dr["ExpAmount"].ToString());
                        return gider;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public float HayvanSayisi()
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=CAGDASBALKAY\\SQLEXPRESS;Initial Catalog=ECOCRAFT_FARM;Integrated Security=True"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT COUNT(*) 'Count' FROM Animals", baglanti);

                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        float sayi = float.Parse(dr["Count"].ToString());
                        return sayi;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        public float CalisanSayisi()
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=CAGDASBALKAY\\SQLEXPRESS;Initial Catalog=ECOCRAFT_FARM;Integrated Security=True"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT COUNT(*) 'Count' FROM Admin", baglanti);

                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        float sayi = float.Parse(dr["Count"].ToString());
                        return sayi;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public float EnYuksekSatis()
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=CAGDASBALKAY\\SQLEXPRESS;Initial Catalog=ECOCRAFT_FARM;Integrated Security=True"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT MAX(Total) 'Count' FROM Sales", baglanti);

                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        float sayi = float.Parse(dr["Count"].ToString());
                        return sayi;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public float EnFazlaHarcama()
        {
            using (SqlConnection baglanti = new SqlConnection("Data Source=CAGDASBALKAY\\SQLEXPRESS;Initial Catalog=ECOCRAFT_FARM;Integrated Security=True"))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT MAX(ExpAmount) 'Count' FROM Expenditures", baglanti);

                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        float sayi = float.Parse(dr["Count"].ToString());
                        return sayi;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

    }
}
