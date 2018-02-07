using NGS_DocumentNew.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Model
{
    public class ListNGSObject
    {
        public List<Company> GetListOfCompany()
        {
            List<Company> companyList = new List<Company>();

            string sql = @"SELECT 
                CompanyGUID
                ,CompanyName
            FROM Company";

            NGSConnector connector = new NGSConnector();
            SQLiteDataReader reader = connector.execSQLWithResult(sql);

            while(reader.Read())
            {
                Company c = new Company();
                c.FillData(reader.GetString(0), reader.GetString(1));
                companyList.Add(c);
            }

            reader.Close();

            return companyList;
        }

        public List<Company> GetCompanyByUser( String UserGUID )
        {
            return null;
        }

        public List<User> GetListOfUsers()
        {
            List<User> listOfUsers = new List<User>();

            string sql = @"SELECT 
                UserGUID, FirstName, LastName, UserName, UserPassword
            FROM User";

            NGSConnector connector = new NGSConnector();
            SQLiteDataReader reader = connector.execSQLWithResult(sql);

            while (reader.Read())
            {
                User u = new User();
                u.FillData(reader.GetString(0)
                    , reader.GetString(1)
                    , reader.GetString(2)
                    , reader.GetString(3)
                    , reader.IsDBNull(4) ? "" : reader.GetString(4)
                    );
                listOfUsers.Add(u);
            }

            reader.Close();

            return listOfUsers;
        }

        public List<DocumentTemplate> GetDocumentTemplateList()
        {
            List<DocumentTemplate> documentList = new List<DocumentTemplate>();

            string sql = @"SELECT 
                DocumentTemplateGUID, DocumentName, DocumentText, DocumentHint, DocumentType, DocumentEndDate
            FROM DocumentTemplate";

            NGSConnector connector = new NGSConnector();
            SQLiteDataReader reader = connector.execSQLWithResult(sql);

            while (reader.Read())
            {
                DocumentTemplate u = new DocumentTemplate();
                u.FillData(reader.GetString(0)
                    , reader.GetString(1)
                    , reader.GetString(2)
                    , reader.IsDBNull(3) ? "" : reader.GetString(3)
                    , reader.IsDBNull(4) ? "D" : reader.GetString(4)
                    , reader.IsDBNull(5) ? "N" : reader.GetString(5)
                    );
                documentList.Add(u);
            }

            reader.Close();

            return documentList;
        }

        public List<DocumentTemplateFlow> GetDocumentTemplateFlowList()
        {
            List<DocumentTemplateFlow> documentList = new List<DocumentTemplateFlow>();

            string sql = @"SELECT 
                DocumentTemplateFlowGUID, DocumentTemplateFlowName, DocumentTemplateFlowType
            FROM DocumentTemplateFlow";

            NGSConnector connector = new NGSConnector();
            SQLiteDataReader reader = connector.execSQLWithResult(sql);

            while (reader.Read())
            {
                DocumentTemplateFlow u = new DocumentTemplateFlow();
                u.FillData(reader.GetString(0)
                    , reader.GetString(1)
                    , reader.GetString(2)
                    );
                documentList.Add(u);
            }

            reader.Close();

            return documentList;
        }

        public List<DocumentTemplateFlowAssignment> GetDocumentTemplateFlowAssignmentList()
        {
            List<DocumentTemplateFlowAssignment> documentList = new List<DocumentTemplateFlowAssignment>();

            string sql = @"SELECT 
                DocumentTemplateFlowAssignmentGUID, DocumentTemplateFlowGUID, DocumentTemplateGUID, DocumentPosition
            FROM DocumentTemplateFlowAssignment";

            NGSConnector connector = new NGSConnector();
            SQLiteDataReader reader = connector.execSQLWithResult(sql);

            while (reader.Read())
            {
                DocumentTemplateFlowAssignment u = new DocumentTemplateFlowAssignment();
                u.FillData(reader.GetString(0)
                    , reader.GetString(1)
                    , reader.GetString(2)
                    , reader.GetInt32(3)
                    );
                documentList.Add(u);
            }

            reader.Close();

            return documentList;
        }

        public List<Document> GetDocumentListBySearchPhrase(String searchTxt)
        {
            List<Document> documentList = new List<Document>();

            string sql = @"          
            select DISTINCT D.*, 'N' as DocumentType from DocumentField DF 
            INNER JOIN Document D ON DF.CompanyGUID = D.CompanyGUID AND DF.DocumentGUID = D.DocumentGUID
            INNER JOIN User U ON U.UserGUID = D.CreatedBy
            INNER JOIN User U1 On U1.UserGUID = D.LastModifiedBy
            WHERE (DF.FieldValue Like @searchTxt
             OR U.FirstName LIKE @searchTxt OR U.LastName LIKE @searchTxt OR U.UserName LIKE @searchTxt
             OR U1.FirstName LIKE @searchTxt OR U1.LastName LIKE @searchTxt OR U1.UserName LIKE @searchTxt
             OR D.DocumentName LIKE @searchTxt OR D.PrintedDateTime LIKE @searchTxt OR D.CreatedDateTime LIKE @searchTxt OR D.LastModifiedDateTime LIKE @searchTxt
            ) AND D.CompanyGUID = @CompanyGUID
            ";

            NGSConnector connector = new NGSConnector();
            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", GlobalVariables.CurrentCompany.CompanyGUID));
            paramList.Add(new SQLiteParameter("@searchTxt", "%" + searchTxt + "%"));
            SQLiteDataReader reader = connector.execSQLWithResult(sql, paramList);

            while (reader.Read())
            {
                Document u = new Document();
                u.FillData(reader.GetString(0)
                    , reader.GetString(1)
                    , reader.GetString(2)
                    , reader.GetString(3)
                    , reader.GetDateTime(4)
                    , reader.GetString(5)
                    , reader.GetDateTime(6)
                    , reader.GetString(7)
                    , reader.GetDateTime(8)
                    , reader.IsDBNull(9) ? (DateTime?)null : reader.GetDateTime(9)
                    );

                documentList.Add(u);
            }

            reader.Close();

            return documentList;
        }

        public List<String> GetDocumentTemplateFlowFieldList(string DocumentFlowGUID)
        {
            List<String> fieldList = new List<String>();

            string sql = @"SELECT 
                FieldName
            FROM DocumentTemplateFlowField
            WHERE DocumentTemplateFlowGUID = @DocumentTemplateFlowGUID";

            NGSConnector connector = new NGSConnector();
            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@DocumentTemplateFlowGUID", DocumentFlowGUID));
            SQLiteDataReader reader = connector.execSQLWithResult(sql, paramList);

            while (reader.Read())
            {
                fieldList.Add(reader.GetString(0));
            }

            reader.Close();

            return fieldList;
        }

        public List<RejestrCzynnosci> GetRejestrCzynnosciList(String searchTxt)
        {
            List<RejestrCzynnosci> rejestrCzynnosciList = new List<RejestrCzynnosci>();
            String sql = @"SELECT 
                            RejestrCzynnosciGUID,
                            NazwaAdministratoraDanych,
                            WspolAdministratorzy,
                            InsepktorDanychOsobowych,
                            NazwaZbioruDanych,
                            RodzajCzynnosci,
                            TytulCzynnosci,
                            CelPrzetwarzania,
                            OpisKategoriiOsob,
                            KategorieOdbiorcow,
                            KategorieDanychOsobowych,
                            InformarcjeOPrzekazaniuDoPanstwaTrzeciego,
                            PlanowanyTerminUsuniecia,
                            OpisTechniczny,
                            Uwagi,
                            TypRejestruCzynnosci,
                            CreatedBy,
                            CreatedDateTime,
                            LastModifiedBy,
                            LastModifiedDateTime,
                            CompanyGUID
                            FROM RejestrCzynnosci D
                                        INNER JOIN User U ON U.UserGUID = D.CreatedBy
                                        INNER JOIN User U1 On U1.UserGUID = D.LastModifiedBy
                            WHERE
                            (NazwaAdministratoraDanych LIKE @searchTxt OR U.FirstName LIKE @searchTxt OR U.LastName LIKE @searchTxt OR
                            WspolAdministratorzy LIKE @searchTxt OR U1.FirstName LIKE @searchTxt OR U1.LastName LIKE @searchTxt OR
                            InsepktorDanychOsobowych LIKE @searchTxt OR
                            NazwaZbioruDanych LIKE @searchTxt OR
                            RodzajCzynnosci LIKE @searchTxt OR
                            TytulCzynnosci LIKE @searchTxt OR
                            CelPrzetwarzania LIKE @searchTxt OR
                            OpisKategoriiOsob LIKE @searchTxt OR
                            KategorieOdbiorcow LIKE @searchTxt OR
                            KategorieDanychOsobowych LIKE @searchTxt OR
                            InformarcjeOPrzekazaniuDoPanstwaTrzeciego LIKE @searchTxt OR
                            PlanowanyTerminUsuniecia LIKE @searchTxt OR
                            OpisTechniczny LIKE @searchTxt OR
                            Uwagi LIKE @searchTxt) AND CompanyGUID = @CompanyGUID ";

            NGSConnector connector = new NGSConnector();
            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", GlobalVariables.CurrentCompany.CompanyGUID));
            paramList.Add(new SQLiteParameter("@searchTxt", "%" + searchTxt + "%"));
            SQLiteDataReader reader = connector.execSQLWithResult(sql, paramList);

            while (reader.Read())
            {
                RejestrCzynnosci u = new RejestrCzynnosci();
                u.FillData(reader.GetString(0)
                    , reader.GetString(1)
                    , reader.GetString(2)
                    , reader.GetString(3)
                    , reader.GetString(4)
                    , reader.GetString(5)
                    , reader.GetString(6)
                    , reader.GetString(7)
                    , reader.GetString(8)
                    , reader.GetString(9)
                    , reader.GetString(10)
                    , reader.GetString(11)
                    , reader.GetString(12)
                    , reader.GetString(13)
                    , reader.GetString(14)
                    , reader.GetString(15)
                    , reader.GetString(16)
                    , reader.GetDateTime(17)
                    , reader.GetString(18)
                    , reader.GetDateTime(19)
                    , reader.GetString(20)
                    );

                rejestrCzynnosciList.Add(u);
            }

            reader.Close();

            return rejestrCzynnosciList;
        }

    }
}
