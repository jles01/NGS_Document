using NGS_DocumentNew.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGS_DocumentNew.Database
{
    public class NGSConnector
    {
        SQLiteConnection conn = null;

        public void checkIfDBExists(string databaseName)
        {
            string path = GlobalVariables.GetDatabasePath(databaseName);
            if (!File.Exists(path))
            {
                CreateDatabase(GlobalVariables.GetDatabasePath(databaseName));
                //InstallDBScript.executeInstallTblScripts(databaseName);
            }
        }

        public void Connect()
        {
            Connect(GlobalVariables.GetDatabaseName());
        }

        public void Connect(string databaseName)
        {
            if (conn == null)
            {
                checkIfDBExists(GlobalVariables.GetDatabaseName());
                conn = new SQLiteConnection(GlobalVariables.GetConnectionString(databaseName));
            }
        }

        private void CreateDatabase()
        {
            CreateDatabase(GlobalVariables.GetDatabasePath());
        }

        private void CreateDatabase(string databasePath)
        {
            SQLiteConnection.CreateFile(databasePath);
        }

        public void Disconnect()
        {
            if (conn != null)
                conn.Dispose();
        }

        public void execSQL(string sql, List<SQLiteParameter> paramList)
        {
            if (conn == null)
                Connect();

            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            if (paramList != null)
            {
                foreach (SQLiteParameter p in paramList)
                    cmd.Parameters.Add(p);
            }

            cmd.ExecuteNonQuery();
        }

        public SQLiteDataReader execSQLWithResult(string sql, List<SQLiteParameter> paramList)
        {
            if (conn == null)
                Connect();

            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            if (paramList != null)
            {
                foreach (SQLiteParameter p in paramList)
                    cmd.Parameters.Add(p);
            }

            SQLiteDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public void execSQL(string sql)
        {
            execSQL(sql, null);
        }

        public SQLiteDataReader execSQLWithResult(string sql)
        {
            return execSQLWithResult(sql, null);
        }
    }
}
