using System;
using System.Linq;
using System.Data;
using Stockman.Entities;
using System.Collections;

namespace Stockman.Classes
{
    class stockItemMethods
    {
        #region initialize
        string query { get; set; }
        databaseMethods db = new databaseMethods();
        supplierMethods supMethods = new supplierMethods();

        private TableNames.StockTables stockTableName = TableNames.StockTables.StockItems;

        public stockItemMethods()
        {
            stockTableName = TableNames.StockTables.StockItems;
        }
        public stockItemMethods(bool isSpecial)
        {
            if (isSpecial)
            {
                stockTableName = TableNames.StockTables.StockItems_Specials;
            }
            else
            {
                stockTableName = TableNames.StockTables.StockItems;
            }
        }
        #endregion

        #region create
        #endregion

        #region get
        public DataTable getTemplateStockItems(Supplier s, Templates selectedTemplate)
        {
            if (stockTableName == TableNames.StockTables.StockItems_Specials)
            {
                disableAllStockItems(s);
            }

            return getTemplateStockItems(s, selectedTemplate, false);

        }

        //public DataTable getTemplateStockItems(Supplier s, Templates selectedTemplate, bool specialsOverride)
        //{
        //    DataTable dataset = new DataTable();
        //    if (specialsOverride)
        //    {
        //        TableNames.StockTables tempStockTableName = stockTableName;

        //        //get the two datasets
        //        DataTable normalItems = getTemplateStockItemsMaster(s, selectedTemplate);
        //        normalItems.Columns.Add("SpecialOverride");

        //        stockTableName = TableNames.StockTables.StockItems_Specials;
        //        DataTable specialItems = getTemplateStockItemsMaster(s, selectedTemplate);
        //        specialItems.Columns.Add("SpecialOverride");
        //        stockTableName = tempStockTableName;

        //        //specials will override normal items
        //        DataTable combinedItems = normalItems.Clone();

        //        for (int i = 0; i < normalItems.Rows.Count; i++)
        //        {
        //            DataRow matchRow = specialItems.NewRow();
        //            bool foundMatch = false;
        //            string checkNormalItem = normalItems.Rows[i]["productCode_Orig"].ToString();
        //            for (int j = 0; j < specialItems.Rows.Count; j++)
        //            {
        //                if (specialItems.Rows[j]["productCode_Orig"].ToString() == checkNormalItem)
        //                {
        //                    matchRow = specialItems.Rows[j];
        //                    matchRow["SpecialOverride"] = true;
        //                    foundMatch = true;
        //                }
        //            }

        //            if (foundMatch)
        //            {
        //                combinedItems.ImportRow(matchRow);
        //            }
        //            else
        //            {
        //                combinedItems.ImportRow(normalItems.Rows[i]);
        //            }
        //        }

        //        dataset = combinedItems;
        //    }
        //    else
        //    {
        //        dataset = getTemplateStockItemsMaster(s, selectedTemplate);
        //    }

        //    return dataset;
        //}
        public DataTable getTemplateStockItems(Supplier s, Templates selectedTemplate, bool specialsOverride)
        {
            DataTable dataset = new DataTable();
            if (specialsOverride)
            {
                stockTableName = TableNames.StockTables.StockItems_Specials;
            }
            else
            {
                stockTableName = TableNames.StockTables.StockItems;
            }

            dataset = getTemplateStockItemsMaster(s, selectedTemplate);

            return dataset;
        }
        private DataTable getTemplateStockItemsMaster(Supplier s, Templates selectedTemplate)
        {
            //build select
            string columns = "";
            for (int i = 0; i < selectedTemplate.templateColumns.Count; i++)
            {
                TemplateColumns tc = selectedTemplate.templateColumns[i];

                if (string.IsNullOrWhiteSpace(tc.databaseColumn))
                {
                    if (tc.calculationType == columnCalculationType.MERGE)
                    {
                        string[] parts = tc.calculation.Split(new char[] { '+' });
                        for (int p = 0; p < parts.Length; p++)
                        {
                            string valColumn = parts[p].Replace("]", "").Replace("[", "").Trim();
                            if (!valColumn.Contains("space") & valColumn != "")
                            {
                                columns += valColumn + ",";
                            }
                        }
                    }
                }
                else
                {
                    columns += tc.databaseColumn + ",";
                }
            }

            columns += "mustExport, overrideMargins, d_agencyMargin, d_grossMargin, d_discount, shortCode, productCode_Orig, active";

            query = @"SELECT " + columns + @" FROM " + stockTableName + " WHERE supplierID = " + s.supplierID;

            DataTable dt = null;
            try
            {
                dt = db.read(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to retrieve template stock items: " + ee.Message, ee);
            }

            return dt;
        }

        public DataTable findStockItem(string databaseColumnToSearch, string valueToMatch)
        {
            query = "SELECT * FROM " + stockTableName + " WHERE " + databaseColumnToSearch + " = '" + valueToMatch + "'";

            DataTable dt = new DataTable();
            try
            {
                dt = db.read(query);
            }
            catch (Exception ee)
            {
                throw new DataException($"Unable to retrieve stock item: {databaseColumnToSearch} = '{valueToMatch}' " + ee.Message, ee);
            }

            return dt;
        }

        public DataTable getAllStockItems()
        {
            query = "SELECT * FROM " + stockTableName + "";
            DataTable dt = new DataTable();

            try
            {
                dt = db.read(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to retrieve stock items: " + ee.Message, ee);
            }

            return dt;
        }

        public DataTable getAllStockItems(Supplier s)
        {
            query = "SELECT * FROM " + stockTableName + " WHERE supplierID = " + s.supplierID;
            DataTable dt = new DataTable();

            try
            {
                dt = db.read(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to retrieve stock items: " + ee.Message, ee);
            }

            return dt;
        }

        public int getDisabledCount(Supplier s)
        {
            query = "SELECT COUNT(stockID) FROM " + stockTableName + " WHERE supplierID = " + s.supplierID + " AND active = 0";
            int total = 0;
            try
            {
                total = int.Parse(db.readOne(query));
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to disabled count: " + ee.Message, ee);
            }
            return total;
        }

        public ArrayList getColumnOrder(Supplier s)
        {
            DataTable dtOrder = new DataTable();
            query = "SELECT dataProperty, displayIndex, visible FROM meta_columnDisplayOrder WHERE supplierID = " + s.supplierID;
            try
            {
                dtOrder = db.read(query);
            }
            catch (Exception ee)
            {
                throw new Exception("Unable to retrieve column order: " + ee.Message, ee);
            }

            ArrayList columnOrder = new ArrayList();

            for (int i = 0; i < dtOrder.Rows.Count; i++)
            {
                Hashtable hash = new Hashtable();
                hash.Add("property", dtOrder.Rows[i]["dataProperty"].ToString());
                hash.Add("index", dtOrder.Rows[i]["displayIndex"].ToString());
                hash.Add("visible", dtOrder.Rows[i]["visible"].ToString());
                columnOrder.Add(hash);
            }

            return columnOrder;
        }
        #endregion

        #region update
        public void updateAllStockItems(Supplier s, DataTable dtUpdate)
        {
            for (int i = 0; i < dtUpdate.Rows.Count; i++)
            {
                string productCode = "";
                string vals = "";
                foreach (DataColumn dc in dtUpdate.Columns)
                {
                    if (dc.ColumnName.ToUpper() == "PRODUCTCODE")
                    {
                        productCode = dtUpdate.Rows[i]["productCode"].ToString();
                    }

                    string updateValue = dtUpdate.Rows[i][dc.ColumnName].ToString();
                    updateValue = updateValue.Replace("'", "`");
                    vals += dc.ColumnName + " = '" + updateValue + "', ";
                }

                vals = vals.Substring(0, vals.Length - 2);

                query = "UPDATE " + stockTableName + " SET " + vals + " WHERE supplierID = " + s.supplierID + " AND productCode = '" + productCode + "'";
                query = query.Replace("''", "null");
                try
                {
                    db.write(query);
                }
                catch (Exception ee)
                {
                    throw new DataException("Unable to update all stock items: " + ee.Message, ee);
                }
            }
        }

        public void updateStockItem(DataRow drNewData, Templates selectedTemplate, Supplier s)
        {
            //does this item exist?
            string query = "SELECT productCode FROM " + stockTableName + " WHERE productCode = '" + drNewData["productCode"].ToString() + "' AND supplierID = " + s.supplierID;
            string exist = "";
            try
            {
                exist = db.readOne(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to update stock item (unable to determine existance): " + ee.Message, ee);
            }

            if (string.IsNullOrWhiteSpace(exist))
            {
                //builds the unique key
                string supUni = s.uniqueKey + "-" + generateUniqueKey();

                //build the INSERT query
                query = "";
                //build the values and data
                string values = "supplierID, uniqueKey, d_agencyMargin, d_grossMargin, d_discount, lastUpdate, shortCode, skuCode, productCode_orig, ";
                string data = "'" + s.supplierID + "', '" + supUni + "', " + drNewData["d_agencyMargin"].ToString() + ", " + drNewData["d_grossMargin"].ToString() + ", " + drNewData["d_discount"].ToString() + ", '" + DateTime.Now + "', '" + drNewData["shortCode"].ToString() + "', '" + generateSKUCode(drNewData, s) + "', '" + drNewData["productCode_orig"].ToString() + "', ";
                foreach (TemplateColumns tc in selectedTemplate.templateColumns)
                {
                    values += tc.databaseColumn + ", ";

                    string updateValue = drNewData[tc.databaseColumn].ToString();
                    updateValue = updateValue.Replace("'", "`");

                    data += "'" + updateValue + "', ";
                }
                values = values.Substring(0, values.Length - 2);
                data = data.Substring(0, data.Length - 2);

                //put the parts together
                query = "INSERT INTO " + stockTableName + " (" + values + ") VALUES (" + data + ")";
            }
            else
            {
                //build the UPDATE  query
                string skuCodeUpdatePart = " skuCode = '" + generateSKUCode(drNewData, s) + "',";

                query = "";
                foreach (TemplateColumns tc in selectedTemplate.templateColumns)
                {
                    string updateValue = drNewData[tc.databaseColumn].ToString();
                    updateValue = updateValue.Replace("'", "`");

                    if (tc.databaseColumn.ToUpper() == "SKUCODE")
                    {
                        skuCodeUpdatePart = "";
                    }

                    query += tc.databaseColumn + " = '" + updateValue + "', ";
                }
                //remove last comma
                query = query.Substring(0, query.Length - 2);

                //put the query parts together
                query = @"UPDATE " + stockTableName + " SET " + query + ", " +
                    "d_agencyMargin = " + drNewData["d_agencyMargin"].ToString() + ", " +
                    "d_grossMargin = " + drNewData["d_grossMargin"].ToString() + ", " +
                    "d_discount = " + drNewData["d_discount"].ToString() + ", " +
                    "lastUpdate = '" + DateTime.Now + "', active = 1, " +
                    "shortCode = '" + drNewData["shortCode"].ToString() + "', " +
                     skuCodeUpdatePart + 
                    "productCode_orig = '" + drNewData["productCode_Orig"].ToString() + "' " +
                    "WHERE supplierID = " + s.supplierID + " AND productCode = '" + drNewData["productCode"].ToString() + "'";
            }

            //execute query
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to update stock item: " + ee.Message, ee);
            }
        }


        public void deleteAllStockItems(Supplier s)
        {
            query = "DELETE FROM " + stockTableName + " WHERE supplierID = " + s.supplierID;
            db.write(query);
        }

        public void deleteStockItem(DataRow drRowToDelete, Supplier s)
        {
            string query = "DELETE FROM " + stockTableName + " WHERE productCode = '" + drRowToDelete["productCode"].ToString() + "' AND supplierID = " + s.supplierID;
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new Exception("Unable to delete row (" + ee.Message + ")");
            }
        }

        public void updateColumnOrder(Supplier supplier, ArrayList newColumnOrder)
        {
            //first, delete the current column order
            ArrayList qu = new ArrayList();

            string query = "DELETE FROM meta_columnDisplayOrder WHERE supplierID = " + supplier.supplierID;
            qu.Add(query);

            foreach (Hashtable hash in newColumnOrder)
            {
                query = "INSERT INTO meta_columnDisplayOrder (dataProperty, displayIndex, visible, supplierID) VALUES ('" + hash["property"] + "', '" + hash["index"] + "', '" + hash["visible"] + "', " + supplier.supplierID + ")";
                qu.Add(query);
            }

            try
            {
                db.writeTransaction(qu);
            }
            catch (Exception ee)
            {
                throw new Exception("Unable to save column order: " + ee.Message, ee);
            }
        }
        #endregion

        #region remove
        public void disableAllStockItems(Supplier s)
        {
            query = "DELETE FROM " + stockTableName + " WHERE supplierID = " + s.supplierID;
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable disable stock items: " + ee.Message, ee);
            }
        }
        #endregion

        #region helpers
        public string generateUniqueKey()
        {
            //NOTE: Allows for 100 000 000 products
            var chars = "0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 7)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            string key = result;
            bool exist = false;
            query = "SELECT uniqueKey FROM " + stockTableName + " WHERE uniqueKey LIKE '%" + key + "%'";
            string ex = "";
            try
            {
                ex = db.readOne(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to retrieve unique key: " + ee.Message, ee);
            }

            if (!string.IsNullOrWhiteSpace(ex))
            {
                exist = true;
            }

            //does this key exist?
            while (exist)
            {
                query = "SELECT uniqueKey FROM " + stockTableName + " WHERE uniqueKey LIKE '%" + key + "%'";
                try
                {
                    ex = db.readOne(query);
                }
                catch (Exception ee)
                {
                    throw new DataException("Unable to retrieve unique key: " + ee.Message, ee);
                }
                if (!string.IsNullOrWhiteSpace(ex))
                {
                    exist = true;

                    random = new Random();
                    result = new string(
                        Enumerable.Repeat(chars, 7)
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());

                    key = result;
                }
                else
                {
                    exist = false;
                }
            }

            return key;
        }

        public string generateSKUCode(DataRow dr, Supplier selectedSupplier)
        {
            string sku = "";
            sku = dr["shortCode"].ToString() + dr["productCode"].ToString() + selectedSupplier.supplierCode;
            return sku;
        }
        #endregion
    }
}
