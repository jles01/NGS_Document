using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGS_DocumentNew.Database;

namespace NGS_DocumentNew.Model
{
    public class RejestrCzynnosci
    {
        public String RejestrCzynnosciGUID { get; set; }
        public String NazwaAdministratoraDanych { get; set; }
        public String WspolAdministratorzy { get; set; }
        public String InsepktorDanychOsobowych { get; set; }
        public String NazwaZbioruDanych { get; set; }
        public String RodzajCzynnosci { get; set; }
        public String TytulCzynnosci { get; set; }
        public String CelPrzetwarzania { get; set; }
        public String OpisKategoriiOsob { get; set; }
        public String KategorieOdbiorcow { get; set; }
        public String KategorieDanychOsobowych { get; set; }
        public String InformarcjeOPrzekazaniuDoPanstwaTrzeciego { get; set; }
        public String PlanowanyTerminUsuniecia { get; set; }
        public String OpisTechniczny { get; set; }
        public String Uwagi { get; set; }
        public String TypRejestruCzynnosci { get; set; }
        public String CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public String LastModifiedBy { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public String CompanyGUID { get; set; }

        public void FillData(String _RejestrCzynnosciGUID
                            , String _NazwaAdministratoraDanych
                            , String _WspolAdministratorzy
                            , String _InsepktorDanychOsobowych
                            , String _NazwaZbioruDanych
                            , String _RodzajCzynnosci
                            , String _TytulCzynnosci
                            , String _CelPrzetwarzania
                            , String _OpisKategoriiOsob
                            , String _KategorieOdbiorcow
                            , String _KategorieDanychOsobowych
                            , String _InformarcjeOPrzekazaniuDoPanstwaTrzeciego
                            , String _PlanowanyTerminUsuniecia
                            , String _OpisTechniczny
                            , String _Uwagi
                            , String _TypRejestruCzynnosci
                            , String _CreatedBy
                            , DateTime _CreatedDateTime
                            , String _LastModifiedBy
                            , DateTime _LastModifiedDateTime
                            , String _CompanyGUID )
        {
            RejestrCzynnosciGUID = _RejestrCzynnosciGUID;
            NazwaAdministratoraDanych = _NazwaAdministratoraDanych;
            WspolAdministratorzy = _WspolAdministratorzy;
            InsepktorDanychOsobowych = _InsepktorDanychOsobowych;
            NazwaZbioruDanych = _NazwaZbioruDanych;
            RodzajCzynnosci = _RodzajCzynnosci;
            TytulCzynnosci = _TytulCzynnosci;
            CelPrzetwarzania = _CelPrzetwarzania;
            OpisKategoriiOsob = _OpisKategoriiOsob;
            KategorieOdbiorcow = _KategorieOdbiorcow;
            KategorieDanychOsobowych = _KategorieDanychOsobowych;
            InformarcjeOPrzekazaniuDoPanstwaTrzeciego = _InformarcjeOPrzekazaniuDoPanstwaTrzeciego;
            PlanowanyTerminUsuniecia = _PlanowanyTerminUsuniecia;
            OpisTechniczny = _OpisTechniczny;
            TypRejestruCzynnosci = _TypRejestruCzynnosci;
            Uwagi = _Uwagi;
            CreatedBy = _CreatedBy;
            CreatedDateTime = _CreatedDateTime;
            LastModifiedBy = _LastModifiedBy;
            LastModifiedDateTime = _LastModifiedDateTime;
            CompanyGUID = _CompanyGUID;
        }

        public void Save()
        {
            string sql = @"INSERT INTO RejestrCzynnosci VALUES( @RejestrCzynnosciGUID,	@NazwaAdministratoraDanych,	@WspolAdministratorzy,	@InsepktorDanychOsobowych,	@NazwaZbioruDanych,	@RodzajCzynnosci,	@TytulCzynnosci,	@CelPrzetwarzania,	@OpisKategoriiOsob,	@KategorieOdbiorcow,	@KategorieDanychOsobowych,	@InformarcjeOPrzekazaniuDoPanstwaTrzeciego,	@PlanowanyTerminUsuniecia,	@OpisTechniczny,	@Uwagi, @TypRejestruCzynnosci,	@CreatedBy,	@CreatedDateTime,	@LastModifiedBy,	@LastModifiedDateTime, @CompanyGUID )";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@RejestrCzynnosciGUID", RejestrCzynnosciGUID));
            paramList.Add(new SQLiteParameter("@NazwaAdministratoraDanych", NazwaAdministratoraDanych));
            paramList.Add(new SQLiteParameter("@WspolAdministratorzy", WspolAdministratorzy));
            paramList.Add(new SQLiteParameter("@InsepktorDanychOsobowych", InsepktorDanychOsobowych));
            paramList.Add(new SQLiteParameter("@NazwaZbioruDanych", NazwaZbioruDanych));
            paramList.Add(new SQLiteParameter("@RodzajCzynnosci", RodzajCzynnosci));
            paramList.Add(new SQLiteParameter("@TytulCzynnosci", TytulCzynnosci));
            paramList.Add(new SQLiteParameter("@CelPrzetwarzania", CelPrzetwarzania));
            paramList.Add(new SQLiteParameter("@OpisKategoriiOsob", OpisKategoriiOsob));
            paramList.Add(new SQLiteParameter("@KategorieOdbiorcow", KategorieOdbiorcow));
            paramList.Add(new SQLiteParameter("@KategorieDanychOsobowych", KategorieDanychOsobowych));
            paramList.Add(new SQLiteParameter("@InformarcjeOPrzekazaniuDoPanstwaTrzeciego", InformarcjeOPrzekazaniuDoPanstwaTrzeciego));
            paramList.Add(new SQLiteParameter("@PlanowanyTerminUsuniecia", PlanowanyTerminUsuniecia));
            paramList.Add(new SQLiteParameter("@OpisTechniczny", OpisTechniczny));
            paramList.Add(new SQLiteParameter("@TypRejestruCzynnosci", TypRejestruCzynnosci));
            paramList.Add(new SQLiteParameter("@Uwagi", Uwagi));
            paramList.Add(new SQLiteParameter("@CreatedBy", CreatedBy));
            paramList.Add(new SQLiteParameter("@CreatedDateTime", CreatedDateTime));
            paramList.Add(new SQLiteParameter("@LastModifiedBy", LastModifiedBy));
            paramList.Add(new SQLiteParameter("@LastModifiedDateTime", LastModifiedDateTime));
            paramList.Add(new SQLiteParameter("@CompanyGUID", CompanyGUID));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            connector = null;
        }

        public void Update()
        {
            string sql = @"UPDATE RejestrCzynnosci SET NazwaAdministratoraDanych = @NazwaAdministratoraDanych,	WspolAdministratorzy = @WspolAdministratorzy,	InsepktorDanychOsobowych = @InsepktorDanychOsobowych,	NazwaZbioruDanych = @NazwaZbioruDanych,	RodzajCzynnosci = @RodzajCzynnosci,	TytulCzynnosci = @TytulCzynnosci,	CelPrzetwarzania = @CelPrzetwarzania,	OpisKategoriiOsob = @OpisKategoriiOsob,	KategorieOdbiorcow = @KategorieOdbiorcow,	KategorieDanychOsobowych = @KategorieDanychOsobowych,	InformarcjeOPrzekazaniuDoPanstwaTrzeciego = @InformarcjeOPrzekazaniuDoPanstwaTrzeciego,	PlanowanyTerminUsuniecia = @PlanowanyTerminUsuniecia,	OpisTechniczny = @OpisTechniczny,	TypRejestruCzynnosci = @TypRejestruCzynnosci, Uwagi = @Uwagi,	CreatedBy = @CreatedBy,	CreatedDateTime = @CreatedDateTime,	LastModifiedBy = @LastModifiedBy,	LastModifiedDateTime = @LastModifiedDateTime WHERE RejestrCzynnosciGUID = @RejestrCzynnosciGUID";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@RejestrCzynnosciGUID", RejestrCzynnosciGUID));
            paramList.Add(new SQLiteParameter("@NazwaAdministratoraDanych", NazwaAdministratoraDanych));
            paramList.Add(new SQLiteParameter("@WspolAdministratorzy", WspolAdministratorzy));
            paramList.Add(new SQLiteParameter("@InsepktorDanychOsobowych", InsepktorDanychOsobowych));
            paramList.Add(new SQLiteParameter("@NazwaZbioruDanych", NazwaZbioruDanych));
            paramList.Add(new SQLiteParameter("@RodzajCzynnosci", RodzajCzynnosci));
            paramList.Add(new SQLiteParameter("@TytulCzynnosci", TytulCzynnosci));
            paramList.Add(new SQLiteParameter("@CelPrzetwarzania", CelPrzetwarzania));
            paramList.Add(new SQLiteParameter("@OpisKategoriiOsob", OpisKategoriiOsob));
            paramList.Add(new SQLiteParameter("@KategorieOdbiorcow", KategorieOdbiorcow));
            paramList.Add(new SQLiteParameter("@KategorieDanychOsobowych", KategorieDanychOsobowych));
            paramList.Add(new SQLiteParameter("@InformarcjeOPrzekazaniuDoPanstwaTrzeciego", InformarcjeOPrzekazaniuDoPanstwaTrzeciego));
            paramList.Add(new SQLiteParameter("@PlanowanyTerminUsuniecia", PlanowanyTerminUsuniecia));
            paramList.Add(new SQLiteParameter("@OpisTechniczny", OpisTechniczny));
            paramList.Add(new SQLiteParameter("@Uwagi", Uwagi));
            paramList.Add(new SQLiteParameter("@TypRejestruCzynnosci", TypRejestruCzynnosci));
            paramList.Add(new SQLiteParameter("@CreatedBy", CreatedBy));
            paramList.Add(new SQLiteParameter("@CreatedDateTime", CreatedDateTime));
            paramList.Add(new SQLiteParameter("@LastModifiedBy", LastModifiedBy));
            paramList.Add(new SQLiteParameter("@LastModifiedDateTime", LastModifiedDateTime));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);

            connector = null;
        }

    }
}
