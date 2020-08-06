using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Stockman.Classes
{
    class reportMethods
    {
        databaseMethods db = new databaseMethods();
        public string query = "";

        public enum ReportTables
        {
            SUPPLIERS, STOCKITEMS
        }

        public List<string> tableNames
        {
            get
            {
                List<string> names = new List<string>();
                names.Add("SUPPLIER");
                names.Add("STOCKITEMS");

                return names;
            }
        }

        public DataTable getTableColumns(string tableName)
        {           
            query = @"SELECT COLUMN_NAME, DATA_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = '" + tableName + "' AND TABLE_SCHEMA='dbo' ORDER BY COLUMN_NAME";

            DataTable dt = null;
            try
            {
                dt = db.read(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to retrieve database columns: " + ee.Message, ee);
            }
            return dt;

            return null;
        }
    }
}
