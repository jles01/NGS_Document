using NGS_DocumentNew.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Model
{
    public class User : NGSObject
    {
        public String UserGUID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String UserPassword { get; set; }


        public void FillData(SQLiteDataReader reader)
        {
            while( reader.Read())
            {
                UserGUID = reader.GetString(0);
                FirstName = reader.GetString(1);
                LastName = reader.GetString(2);
                UserName = reader.GetString(3);
                UserPassword = reader.GetString(4);
            }

            reader.Close();
        }

        public void FillData(String _UserGUID
                            , String _FirstName
                            , String _LastName
                            , String _UserName
                            , String _UserPassword)
        {
            UserGUID = _UserGUID;
            FirstName = _FirstName;
            LastName = _LastName;
            UserName = _UserName;
            UserPassword = _UserPassword;
        }

        public bool LoginUser( String userName, String userPassword )
        {
            bool ret = false;

            string sql = @"SELECT 
                            UserGUID  
                            ,FirstName
                            ,LastName
                            ,UserName
                            ,UserPassword
                         FROM User
                         WHERE UserName = @UserName AND UserPassword = @UserPassword";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@UserName", userName));
            paramList.Add(new SQLiteParameter("@UserPassword", GlobalVariables.GetMD5(userPassword)));

            NGSConnector connector = new NGSConnector();
            SQLiteDataReader reader = connector.execSQLWithResult(sql, paramList);

            if( reader.HasRows )
            {
                ret = true;
                FillData(reader);
            }

            return ret;
        }


        public List<Company> GetUserCompany()
        {
            List<Company> companyList = new List<Company>();

            string sql = @"SELECT 
                            C.CompanyGUID
                            ,C.CompanyName
                         FROM Company C INNER JOIN CompanyUser CU
                            ON C.CompanyGUID = CU.CompanyGUID
                         WHERE CU.UserGUID = @UserGUID";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@UserGUID", UserGUID));

            NGSConnector connector = new NGSConnector();
            SQLiteDataReader reader = connector.execSQLWithResult(sql, paramList);

            while (reader.Read())
            {
                Company company = new Company();
                company.FillData(reader.GetString(0), reader.GetString(1));
                companyList.Add(company);
            }

            reader.Close();

            return companyList;
        }

        public void AssignCompany(string companyGUID)
        {
            RemoveAssignCompany(companyGUID);
            string sql = @"INSERT INTO CompanyUser VALUES( @CompanyUserGUID, @CompanyGUID, @UserGUID)";

            List<System.Data.SQLite.SQLiteParameter>  paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", companyGUID));
            paramList.Add(new SQLiteParameter("@UserGUID", UserGUID));
            paramList.Add(new SQLiteParameter("@CompanyUserGUID", GlobalVariables.GetNewGUID()));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);
            connector = null;
        }

        public void RemoveAssignCompany(string companyGUID)
        {
            string sql = @"DELETE FROM CompanyUser WHERE CompanyGUID = @CompanyGUID AND UserGUID = @UserGUID";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@CompanyGUID", companyGUID));
            paramList.Add(new SQLiteParameter("@UserGUID", UserGUID));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);
            connector = null;
        }

        public void SavePassword( string userGUID, string userPassword )
        {
            string sql = @"UPDATE User 
                            SET UserPassword = @UserPassword
                         WHERE UserGUID = @UserGUID";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@UserGUID", userGUID));
            paramList.Add(new SQLiteParameter("@UserPassword", GlobalVariables.GetMD5(userPassword)));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);
        }

        public void SaveUser( string userGUID, string userName, string firstName, string lastName)
        {
            string sql = @"INSERT INTO User( UserGUID, UserName, FirstName, LastName ) 
                           Values( @UserGUID, @UserName, @FirstName, @LastName )";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@UserGUID", userGUID));
            paramList.Add(new SQLiteParameter("@UserName", userName));
            paramList.Add(new SQLiteParameter("@FirstName", firstName));
            paramList.Add(new SQLiteParameter("@LastName", lastName));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);
        }

        public void UpdateUser(string userGUID, string firstName, string lastName)
        {
            string sql = @"UPDATE User
                            SET FirstName = @FirstName,
                                LastName = @LastName
                            WHERE UserGUID = @UserGUID";

            List<System.Data.SQLite.SQLiteParameter> paramList = new List<System.Data.SQLite.SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@UserGUID", userGUID));
            paramList.Add(new SQLiteParameter("@FirstName", firstName));
            paramList.Add(new SQLiteParameter("@LastName", lastName));

            NGSConnector connector = new NGSConnector();
            connector.execSQL(sql, paramList);
        }
    }
}
