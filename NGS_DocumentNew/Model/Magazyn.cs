using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGS_DocumentNew.Database;

namespace NGS_DocumentNew.Model
{
    public class Magazyn
    {

        public String KopertaGUID { get; set; }
        public String NrKoperty { get; set; }
        public String NrPlomby { get; set; }
        public String DataOdbioru { get; set; }
        public String GodzinaOdbioru { get; set; }
        public String DataKopii { get; set; }
        public String KopertaNrPro { get; set; }
        public String Przekazal { get; set; }
        public String Zwrocil { get; set; }
        public String NazwaKlienta { get; set; }
        public String NIP { get; set; }
        public String AdresKlienta { get; set; }
        public String KodPocztowy { get; set; }
        public String Miasto { get; set; }
        public String KonwojentImie { get; set; }
        public String KonwojentNazwisko { get; set; }
        public String DataZwrotu { get; set; }
        public String CompanyGUID { get; set; }

        public void Delete()
        {
            string sql = @"DELETE FROM Magazyn WHERE CompanyGUID = @CompanyGUID";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", GlobalVariables.CurrentCompany.CompanyGUID));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            connector = null;
        }

        public void Save()
        {
            string sql = @"INSERT INTO Magazyn VALUES(@KopertaGUID,
                            @NrKoperty,
                            @NrPlomby,
                            @DataOdbioru,
                            @GodzinaOdbioru,
                            @DataKopii,
                            @KopertaNrPro,
                            @Przekazal,
                            @Zwrocil,
                            @NazwaKlienta,
                            @NIP,
                            @AdresKlienta,
                            @KodPocztowy,
                            @Miasto,
                            @KonwojentImie,
                            @KonwojentNazwisko,
                            @DataZwrotu,
                            @CompanyGUID
                            )";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@KopertaGUID", KopertaGUID));
            paramList.Add(new SQLiteParameter("@NrKoperty", NrKoperty));
            paramList.Add(new SQLiteParameter("@NrPlomby", NrPlomby));
            paramList.Add(new SQLiteParameter("@DataOdbioru", DataOdbioru));
            paramList.Add(new SQLiteParameter("@GodzinaOdbioru", GodzinaOdbioru));
            paramList.Add(new SQLiteParameter("@DataKopii", DataKopii));
            paramList.Add(new SQLiteParameter("@KopertaNrPro", KopertaNrPro));
            paramList.Add(new SQLiteParameter("@Przekazal", Przekazal));
            paramList.Add(new SQLiteParameter("@Zwrocil", Zwrocil));
            paramList.Add(new SQLiteParameter("@NazwaKlienta", NazwaKlienta));
            paramList.Add(new SQLiteParameter("@NIP", NIP));
            paramList.Add(new SQLiteParameter("@AdresKlienta", AdresKlienta));
            paramList.Add(new SQLiteParameter("@KodPocztowy", KodPocztowy));
            paramList.Add(new SQLiteParameter("@Miasto", Miasto));
            paramList.Add(new SQLiteParameter("@KonwojentImie", KonwojentImie));
            paramList.Add(new SQLiteParameter("@KonwojentNazwisko", KonwojentNazwisko));
            paramList.Add(new SQLiteParameter("@DataZwrotu", DataZwrotu));
            paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));


            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            connector = null;
        }

        public void FillData(String _KopertaGUID,
                    String _NrKoperty,
                    String _NrPlomby,
                    String _DataOdbioru,
                    String _GodzinaOdbioru,
                    String _DataKopii,
                    String _KopertaNrPro,
                    String _Przekazal,
                    String _Zwrocil,
                    String _NazwaKlienta,
                    String _NIP,
                    String _AdresKlienta,
                    String _KodPocztowy,
                    String _Miasto,
                    String _KonwojentImie,
                    String _KonwojentNazwisko,
                    String _DataZwrotu,
                    String _CompanyGUID)
        {

            KopertaGUID = _KopertaGUID;
            NrKoperty = _NrKoperty;
            NrPlomby = _NrPlomby;
            DataOdbioru = _DataOdbioru;
            GodzinaOdbioru = _GodzinaOdbioru;
            DataKopii = _DataKopii;
            KopertaNrPro = _KopertaNrPro;
            Przekazal = _Przekazal;
            Zwrocil = _Zwrocil;
            NazwaKlienta = _NazwaKlienta;
            NIP = _NIP;
            AdresKlienta = _AdresKlienta;
            KodPocztowy = _KodPocztowy;
            Miasto = _Miasto;
            KonwojentImie = _KonwojentImie;
            KonwojentNazwisko = _KonwojentNazwisko;
            DataZwrotu = _DataZwrotu;
            CompanyGUID = _CompanyGUID;

        }

        public List<Magazyn> GetSearchMagazyn( String searchTxt )
        {
            string sql = @"SELECT KopertaGUID,
                       NrKoperty,
                       NrPlomby,
                       DataOdbioru,
                       GodzinaOdbioru,
                       DataKopii,
                       KopertaNrPro,
                       Przekazal,
                       Zwrocil,
                       NazwaKlienta,
                       NIP,
                       AdresKlienta,
                       KodPocztowy,
                       Miasto,
                       KonwojentImie,
                       KonwojentNazwisko,
                       DataZwrotu,
                       CompanyGUID
                  FROM Magazyn
                  WHERE CompanyGUID = @CompanyGUID
                      AND
                    (NrKoperty LIKE @searchTxt   OR
                    NrPlomby LIKE @searchTxt OR
                    DataOdbioru LIKE @searchTxt  OR
                    GodzinaOdbioru LIKE @searchTxt   OR
                    DataKopii LIKE @searchTxt    OR
                    KopertaNrPro LIKE @searchTxt OR
                    Przekazal LIKE @searchTxt    OR
                    Zwrocil LIKE @searchTxt  OR
                    NazwaKlienta LIKE @searchTxt OR
                    NIP LIKE @searchTxt  OR
                    AdresKlienta LIKE @searchTxt OR
                    KodPocztowy LIKE @searchTxt  OR
                    Miasto LIKE @searchTxt   OR
                    KonwojentImie LIKE @searchTxt    OR
                    KonwojentNazwisko LIKE @searchTxt OR
                    DataZwrotu LIKE @searchTxt)
                    "
                ;


            List<Magazyn> retList = new List<Magazyn>();

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            
            paramList.Add(new SQLiteParameter("@CompanyGUID", GlobalVariables.CurrentCompany.CompanyGUID));
            paramList.Add(new SQLiteParameter("@searchTxt", "%" + searchTxt + "%"));


            NGSConnector connector = new NGSConnector();
            System.Data.SQLite.SQLiteDataReader reader = connector.execSQLWithResult(sql, paramList);

            while( reader.Read() )
            {
                Magazyn m = new Magazyn();
                m.FillData(
                    reader.IsDBNull(0) ? "" : reader.GetString(0),
                    reader.IsDBNull(1) ? "" : reader.GetString(1),
                    reader.IsDBNull(2) ? "" : reader.GetString(2),
                    reader.IsDBNull(3) ? "" : reader.GetString(3),
                    reader.IsDBNull(4) ? "" : reader.GetString(4),
                    reader.IsDBNull(5) ? "" : reader.GetString(5),
                    reader.IsDBNull(6) ? "" : reader.GetString(6),
                    reader.IsDBNull(7) ? "" : reader.GetString(7),
                    reader.IsDBNull(8) ? "" : reader.GetString(8),
                    reader.IsDBNull(9) ? "" : reader.GetString(9),
                    reader.IsDBNull(10) ? "" : reader.GetString(10),
                    reader.IsDBNull(11) ? "" : reader.GetString(11),
                    reader.IsDBNull(12) ? "" : reader.GetString(12),
                    reader.IsDBNull(13) ? "" : reader.GetString(13),
                    reader.IsDBNull(14) ? "" : reader.GetString(14),
                    reader.IsDBNull(15) ? "" : reader.GetString(15),
                    reader.IsDBNull(16) ? "" : reader.GetString(16),
                    reader.IsDBNull(17) ? "" : reader.GetString(17)
                );

                retList.Add(m);
            }

            reader = null;

            return retList;
        }

    }
}
