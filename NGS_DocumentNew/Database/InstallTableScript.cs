using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Database
{
    public static class InstallTableScript
    {
        public static String UserTable = @"
            CREATE TABLE IF NOT EXISTS User ( 
                UserGUID NVARCHAR(36)
                ,FirstName NVARCHAR(50)
                ,LastName NVARCHAR(50)
                ,UserName NVARCHAR(50)
                ,UserPassword NVARCHAR(50)
            );
        ";

        public static String CompanyTable = @"
            CREATE TABLE IF NOT EXISTS Company ( 
                CompanyGUID NVARCHAR(36)
                ,CompanyName NVARCHAR(100)
            );
        ";

        public static String UserCompanyTable = @"
            CREATE TABLE IF NOT EXISTS CompanyUser ( 
                UserCompanyGUID NVARCHAR(36)
                ,CompanyGUID NVARCHAR(36)
                ,UserGUID NVARCHAR(36)
            );
        ";

        public static string CreateSettingsTbl = @"CREATE TABLE IF NOT EXISTS Settings(
                                            CompanyGUID NVARCHAR(36)
                                            ,SettingName NVARCHAR(250)
                                            ,SettingValue NVARCHAR(1000)
                                        );";

        public static string CreateDocumentTemplateTbl = @"CREATE TABLE IF NOT EXISTS DocumentTemplate (
                                            DocumentTemplateGUID NVARCHAR(36)
                                            ,DocumentName NVARCHAR(200)
                                            ,DocumentText NTEXT
                                            )";

        public static string CreateDocumentTemplateFlowAssignmentTbl = @"CREATE TABLE IF NOT EXISTS DocumentTemplateFlowAssignment (
                                            DocumentTemplateFlowAssignmentGUID NVARCHAR(36)
                                            ,DocumentTemplateFlowGUID NVARCHAR(36)
                                            ,DocumentTemplateGUID NVARCHAR(36)
                                            ,DocumentPosition INT
                                            )";

        public static string CreateDocumentTemplateFlowTbl = @"CREATE TABLE IF NOT EXISTS DocumentTemplateFlow (
                                            DocumentTemplateFlowGUID NVARCHAR(36)
                                            ,DocumentTemplateFlowName NVARCHAR(100)
                                            )";

        public static String DocumentsTable = @"
                CREATE TABLE IF NOT EXISTS Document(
                                            CompanyGUID NVARCHAR(36)
                                            ,DocumentGUID NVARCHAR(36)
                                            ,DocumentName NVARCHAR(200)
                                            ,DocumentText NTEXT
                                            ,DocumentTemplateGUID NVARCHAR(36)
                                            ,Version NVARCHAR(20)
                                            ,CreatedDateTime DATETIME
                                            ,LastModifiedDateTime DATETIME );
        ";

        public static String InsertAdminUser = @"
            INSERT INTO User VALUES( '803d7dc3-1c2b-4589-aaaa-6dc2fc423006', 'Admin', 'Admin', 'Admin', '21232F297A57A5A743894A0E4A801FC3');
        ";


        public static string insertDocument1 = "INSERT INTO DocumentTemplate VALUES(	'935E4B7F-7E06-0E52-55DE-A6AD929B311C', 'Oswiadczenie_IZIS', @DocumentText)";
        public static string insertDocument2 = "INSERT INTO DocumentTemplate VALUES(	'89A6F241-2337-6D33-1509-2BBD58674824', 'Oswiadczenie_odpowiedzialnosc_za_wyposazenie',  @DocumentText)";
        public static string insertDocument3 = "INSERT INTO DocumentTemplate VALUES(	'FBACF7D7-8111-967C-281E-9AA7153D9989', 'Oswiadczenie_Polityka_Bezpieczenstwa',  @DocumentText)";
        public static string insertDocument4 = "INSERT INTO DocumentTemplate VALUES(	'04DC085F-3112-7901-4366-AD87791F96A2', 'Oswiadczenie_Polityka_i_IZIS',  @DocumentText)";
        public static string insertDocument5 = "INSERT INTO DocumentTemplate VALUES(	'FAA06922-90C3-56EF-9977-257843E45316', 'Oswiadczenie_procedury',  @DocumentText)";
        public static string insertDocument6 = "INSERT INTO DocumentTemplate VALUES(	'BA4A751C-9BB4-1BA9-5DE9-601A14186A88', 'Oswiadczenie_zachowanie_tajemnicy_DO_i_informacji_o_zabezpieczeniu',  @DocumentText)";
        public static string insertDocument7 = "INSERT INTO DocumentTemplate VALUES(	'1B900FBF-2398-6BD3-71D2-46904A62A1B1', 'Powierzenie_komputer',  @DocumentText)";
        public static string insertDocument8 = "INSERT INTO DocumentTemplate VALUES(	'7FC5070E-8EF4-5CB5-6AB8-4CDF36194AA5', 'Protokol_szyfrowana_pamiec',  @DocumentText)";
        public static string insertDocument9 = "INSERT INTO DocumentTemplate VALUES(	'35DE8873-72B0-9596-A2D6-32A4FF2D3BBF', 'Protokol_telefon',  @DocumentText)";
        public static string insertDocument10 = "INSERT INTO DocumentTemplate VALUES(	'2D849532-55C9-715C-4E81-37E844533301', 'zgoda_dziecko',  @DocumentText)";
        public static string insertDocument11 = "INSERT INTO DocumentTemplate VALUES(	'2D849532-55C9-715C-4E81-37E844533302', 'zgoda_na_wizerunek',  @DocumentText)";

        public static string insertDocumentFlow = "INSERT INTO DocumentTemplateFlow VALUES( '2D849532-55C9-715C-4E81-37E844533303', 'NOWY PRACOWNIK');";

        public static string insertDocumentFlowAssignment1 = "INSERT INTO DocumentTemplateFlowAssignment VALUES( 	'AD3116CF-77E3-40EB-29F8-91A572227E66','2D849532-55C9-715C-4E81-37E844533303', '935E4B7F-7E06-0E52-55DE-A6AD929B311C', '1')";
        public static string insertDocumentFlowAssignment2 = "INSERT INTO DocumentTemplateFlowAssignment VALUES( 	'9B300300-3E44-3ECB-86F8-09ED9F301797','2D849532-55C9-715C-4E81-37E844533303', '89A6F241-2337-6D33-1509-2BBD58674824', '2')";
        public static string insertDocumentFlowAssignment3 = "INSERT INTO DocumentTemplateFlowAssignment VALUES( 	'9955491C-448C-7286-6E3E-F4CAB06541E2','2D849532-55C9-715C-4E81-37E844533303', 'FBACF7D7-8111-967C-281E-9AA7153D9989', '3')";
        public static string insertDocumentFlowAssignment4 = "INSERT INTO DocumentTemplateFlowAssignment VALUES( 	'7B79ABAB-6023-84B8-7F2C-B7DECC1C4A17','2D849532-55C9-715C-4E81-37E844533303', '04DC085F-3112-7901-4366-AD87791F96A2', '4')";
        public static string insertDocumentFlowAssignment5 = "INSERT INTO DocumentTemplateFlowAssignment VALUES( 	'63B96E33-0685-33E8-33EB-A485601626A8','2D849532-55C9-715C-4E81-37E844533303', 'FAA06922-90C3-56EF-9977-257843E45316', '5')";
        public static string insertDocumentFlowAssignment6 = "INSERT INTO DocumentTemplateFlowAssignment VALUES( 	'3C1F8971-38F9-4175-761B-4650256B6F43','2D849532-55C9-715C-4E81-37E844533303', 'BA4A751C-9BB4-1BA9-5DE9-601A14186A88', '6')";
        public static string insertDocumentFlowAssignment7 = "INSERT INTO DocumentTemplateFlowAssignment VALUES( 	'DA14F8A2-354E-5E5E-2669-AE36A0754E40','2D849532-55C9-715C-4E81-37E844533303', '1B900FBF-2398-6BD3-71D2-46904A62A1B1', '7')";
        public static string insertDocumentFlowAssignment8 = "INSERT INTO DocumentTemplateFlowAssignment VALUES( 	'E1FEAC4B-4732-9077-336A-9E62584270D1','2D849532-55C9-715C-4E81-37E844533303', '7FC5070E-8EF4-5CB5-6AB8-4CDF36194AA5', '8')";
        public static string insertDocumentFlowAssignment9 = "INSERT INTO DocumentTemplateFlowAssignment VALUES( 	'20EF85F1-89DB-7D1E-7684-6BF5F82E83DE','2D849532-55C9-715C-4E81-37E844533303', '35DE8873-72B0-9596-A2D6-32A4FF2D3BBF', '9')";
        public static string insertDocumentFlowAssignment10 = "INSERT INTO DocumentTemplateFlowAssignment VALUES( 	'76D0299D-1CAE-12CE-A02A-F2DE155B82C1','2D849532-55C9-715C-4E81-37E844533303', '2D849532-55C9-715C-4E81-37E844533301', '10')";
        public static string insertDocumentFlowAssignment11 = "INSERT INTO DocumentTemplateFlowAssignment VALUES( 	'76D0299D-1CAE-12CE-A02A-F2DE155B82C2','2D849532-55C9-715C-4E81-37E844533303', '2D849532-55C9-715C-4E81-37E844533302', '11')";


        public static void CreateTables()
        {
            NGSConnector connector = new NGSConnector();
            connector.execSQL(UserTable);
            connector.execSQL(CompanyTable);
            connector.execSQL(UserCompanyTable);
            connector.execSQL(InsertAdminUser);
            connector.execSQL(CreateSettingsTbl);

            connector = null;
        }

        public static string GetDocumentString(string path)
        {
            StreamReader reader = new StreamReader(path);
            string txt = reader.ReadToEnd();

            reader.Close();

            return txt;
        }

        public static void InsertTemplates()
        {
            NGSConnector connector = new NGSConnector();

            connector.Connect();

            connector.execSQL(insertDocumentFlow);

            connector.execSQL(insertDocumentFlowAssignment1);
            connector.execSQL(insertDocumentFlowAssignment2);
            connector.execSQL(insertDocumentFlowAssignment3);
            connector.execSQL(insertDocumentFlowAssignment4);
            connector.execSQL(insertDocumentFlowAssignment5);
            connector.execSQL(insertDocumentFlowAssignment6);
            connector.execSQL(insertDocumentFlowAssignment7);
            connector.execSQL(insertDocumentFlowAssignment8);
            connector.execSQL(insertDocumentFlowAssignment9);
            connector.execSQL(insertDocumentFlowAssignment10);
            connector.execSQL(insertDocumentFlowAssignment11);


            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new System.Data.SQLite.SQLiteParameter("@DocumentText", GetDocumentString(@"C:/Pfizer/NGS_Document/Dokuemnty/Word/NewHtml/Oswiadczenie_IZIS.htm")));
            connector.execSQL(insertDocument1, paramList);

            paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new System.Data.SQLite.SQLiteParameter("@DocumentText", GetDocumentString(@"C:/Pfizer/NGS_Document/Dokuemnty/Word/NewHtml/Oswiadczenie_odpowiedzialnosc_za_wyposazenie.htm")));
            connector.execSQL(insertDocument2, paramList);

            paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new System.Data.SQLite.SQLiteParameter("@DocumentText", GetDocumentString(@"C:/Pfizer/NGS_Document/Dokuemnty/Word/NewHtml/Oswiadczenie_Polityka_Bezpieczenstwa.htm")));
            connector.execSQL(insertDocument3, paramList);

            paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new System.Data.SQLite.SQLiteParameter("@DocumentText", GetDocumentString(@"C:/Pfizer/NGS_Document/Dokuemnty/Word/NewHtml/Oswiadczenie_Polityka_i_IZIS.htm")));
            connector.execSQL(insertDocument4, paramList);

            paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new System.Data.SQLite.SQLiteParameter("@DocumentText", GetDocumentString(@"C:/Pfizer/NGS_Document/Dokuemnty/Word/NewHtml/Oswiadczenie_procedury.htm")));
            connector.execSQL(insertDocument5, paramList);

            paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new System.Data.SQLite.SQLiteParameter("@DocumentText", GetDocumentString(@"C:/Pfizer/NGS_Document/Dokuemnty/Word/NewHtml/Oswiadczenie_zachowanie_tajemnicy_DO_i_informacji_o_zabezpieczeniu.htm")));
            connector.execSQL(insertDocument6, paramList);

            paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new System.Data.SQLite.SQLiteParameter("@DocumentText", GetDocumentString(@"C:/Pfizer/NGS_Document/Dokuemnty/Word/NewHtml/Powierzenie_komputer.htm")));
            connector.execSQL(insertDocument7, paramList);

            paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new System.Data.SQLite.SQLiteParameter("@DocumentText", GetDocumentString(@"C:/Pfizer/NGS_Document/Dokuemnty/Word/NewHtml/Protokol_szyfrowana_pamiec.htm")));
            connector.execSQL(insertDocument8, paramList);

            paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new System.Data.SQLite.SQLiteParameter("@DocumentText", GetDocumentString(@"C:/Pfizer/NGS_Document/Dokuemnty/Word/NewHtml/Protokol_telefon.htm")));
            connector.execSQL(insertDocument9, paramList);

            paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new System.Data.SQLite.SQLiteParameter("@DocumentText", GetDocumentString(@"C:/Pfizer/NGS_Document/Dokuemnty/Word/NewHtml/zgoda_dziecko.htm")));
            connector.execSQL(insertDocument10, paramList);

            paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new System.Data.SQLite.SQLiteParameter("@DocumentText", GetDocumentString(@"C:/Pfizer/NGS_Document/Dokuemnty/Word/NewHtml/zgoda_na_wizerunek.htm")));
            connector.execSQL(insertDocument11, paramList);
        }
    }
}
