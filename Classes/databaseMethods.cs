using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Collections;

namespace Stockman.Classes
{
    class databaseMethods
    {
        string logPath = "log.txt";

        SqlConnection myConnection;
        private void createConnection()
        {
            TextWriter tw = new StreamWriter(logPath);            
            tw.Close();

            myConnection = new SqlConnection(ConfigurationSettings.AppSettings["StockmannConfig"]);
            try
            {
                myConnection.Open();
            }
            catch (Exception ee)
            {
                tw = new StreamWriter(logPath);
                tw.WriteLine("DB Connection Error: " + ee.Message);
                tw.Close();

                throw;
            }
        }

        private void closeConnection()
        {
            try
            {
                myConnection.Close();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public void write(string query)
        {
            try
            {
                createConnection();
                SqlCommand comm = new SqlCommand(query, myConnection);
                comm.ExecuteNonQuery();
                closeConnection();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public void writeTransaction(ArrayList commands)
        {
            SqlTransaction trans = null;

            using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["StockmannConfig"]))
            {
                try
                {
                    conn.Open();

                    trans = conn.BeginTransaction();                    

                    foreach (string query in commands)
                    {
                        using (SqlCommand com = new SqlCommand(query, conn, trans))
                        {
                            com.ExecuteScalar();
                        }
                    }

                    trans.Commit();
                }
                catch (Exception ee)
                {   
                    trans.Rollback();
                    conn.Close();
                    throw ee;
                }
            }
        }

        public string writeWithID(string query)
        {
            string retID = "";
            try
            {
                query += " SELECT @@Identity AS myID";
                createConnection();
                SqlCommand com = new SqlCommand(query, myConnection);

                retID = com.ExecuteScalar().ToString();

                closeConnection();
            }
            catch (Exception ee)
            {
                throw;
            }
            return retID;
        }

        public DataTable read(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                createConnection();

                SqlDataReader reader = null;
                SqlCommand comm = new SqlCommand(query, myConnection);
                reader = comm.ExecuteReader();
                dt.Load(reader);
                closeConnection();
            }
            catch (Exception ee)
            {
                throw;
            }

            return dt;
        }

        public string readOne(string query)
        {
            string value = "";
            try
            {
                createConnection();
                SqlCommand comm = new SqlCommand(query, myConnection);
                object exValue = null;
                exValue = comm.ExecuteScalar();
                if (exValue != null)
                {
                    value = exValue.ToString();
                }

                closeConnection();
            }
            catch (Exception ee)
            {
                throw;
            }

            return value;
        }

        public void createDatabaseBackup(string savePath)
        {
            createConnection();
            SqlCommand cmd = new SqlCommand(@"backup database StockMann to disk ='" + savePath + ".bak' with init,stats=10", myConnection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to create backup: " + ee.Message, ee);
            }
            closeConnection();
        }

        public bool testConnection(string connectionString)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string readAppSetting(string key)
        {
            try
            {
                return ConfigurationSettings.AppSettings[key];
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public void writeAppSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
