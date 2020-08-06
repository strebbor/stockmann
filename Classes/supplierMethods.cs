using System;
using System.Linq;
using Stockman.Entities;
using System.Data;
using System.Collections;

namespace Stockman.Classes
{
    class supplierMethods
    {
        #region initialize
        databaseMethods db = new databaseMethods();
        string query { get; set; }

        public enum activeStates { ALL, ACTIVE, DISABLED }
        private activeStates _showActive = activeStates.ALL;
        public activeStates showActive
        {
            get { return _showActive; }
            set { _showActive = value; }
        }
        #endregion

        #region create
        public void createSupplier(Supplier supplier)
        {
            //does the supplier code exist already?
            if (doesSupplierCodeExist(supplier.supplierCode))
            {
                throw new Exception("Supplier code already exist");
            }

            query = "INSERT INTO suppliers (supplierName, uniqueKey, supplierCode, d_agencyMargin, d_discount, d_grossMargin, supplierNotes, specialsActive, specialsImportDate) VALUES ('" + supplier.supplierName + "', '" + supplier.uniqueKey + "', '" + supplier.supplierCode + "', " + supplier.agencyMargin + ", " + supplier.discount + ", " + supplier.grossMargin + ", '" + supplier.supplierNotes + "', '" + supplier.specialsActive + "', '" + supplier.specialsImportDate + "')";
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to create supplier", ee);
            }
        }
        #endregion

        #region update
        public void updateSupplier(Supplier s)
        {
            query = "UPDATE suppliers SET supplierName = '" + s.supplierName + "', active = '" + s.active + "', supplierCode = '" + s.supplierCode + "', uniqueKey = '" + s.uniqueKey + "', d_agencyMargin = " + s.agencyMargin + ", d_discount = " + s.discount + ", d_grossMargin = " + s.grossMargin + ", supplierNotes = '" + s.supplierNotes + "', lastImportDate = '" + s.lastImportDate + "', specialsActive = '" + s.specialsActive +
                "', specialsImportDate = '" + s.specialsImportDate + "'" + " WHERE supplierID = " + s.supplierID;
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to update supplier", ee);
            }
        }
        #endregion

        #region retrieve
        public DataTable getSuppliers()
        {
            string showActiveQueryPart = "";
            switch (showActive)
            {
                case activeStates.ACTIVE: { showActiveQueryPart = " WHERE active = 'TRUE'"; } break;
                case activeStates.DISABLED: { showActiveQueryPart = " WHERE active = 'FALSE'"; } break;
            }

            query = "SELECT supplierID, supplierName, supplierCode, uniqueKey, d_agencyMargin, d_grossMargin, d_discount, active, supplierNotes, lastImportDate, specialsActive, specialsImportDate FROM suppliers" + showActiveQueryPart + " ORDER BY supplierName";

            DataTable dtSuppliers = new DataTable();
            try
            {
                dtSuppliers = db.read(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to retrieve suppliers", ee);
            }

            return dtSuppliers;
        }

        public Supplier getSupplier(string supplierID)
        {
            query = "SELECT supplierID, supplierName, supplierCode, uniqueKey, d_agencyMargin, d_discount, d_grossMargin, active, supplierNotes, lastImportDate, specialsActive, specialsImportDate FROM suppliers WHERE supplierID = " + supplierID;
            DataTable dtSupplier = new DataTable();
            try
            {
                dtSupplier = db.read(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to retrieve supplier", ee);
            }

            Supplier s = new Supplier();
            s = bindSuppliers(dtSupplier);

            return s;
        }

        private bool doesSupplierCodeExist(string supplierCode)
        {
            query = "SELECT supplierCode FROM suppliers WHERE supplierCode = '" + supplierCode + "'";
            string e = "";

            try
            {
                e = db.readOne(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to determine existance: " + ee.Message, ee);
            }

            if (!string.IsNullOrWhiteSpace(e))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region remove
        public void deleteSupplier(string supplierID)
        {
            ArrayList qu = new ArrayList();

            //DELETE stock items
            qu.Add("DELETE FROM stockItems WHERE supplierID = " + supplierID);

            //DELETE the supplier
            qu.Add("DELETE FROM suppliers WHERE supplierID = " + supplierID);

            //DELETE the supplier_templates link
            qu.Add("DELETE FROM supplier_templates WHERE supplierID = " + supplierID);


            //get templates
            query = "SELECT templateID FROM supplier_templates WHERE supplierID = " + supplierID;
            DataTable dtSupplierTemplates = db.read(query);

            for (int i = 0; i < dtSupplierTemplates.Rows.Count; i++)
            {
                //DELETE the templates
                qu.Add("DELETE FROM templates WHERE templateID = " + dtSupplierTemplates.Rows[i]["templateID"].ToString());

                query = "SELECT templateColumnID FROM templateColumns WHERE templateID = " + dtSupplierTemplates.Rows[i]["templateID"].ToString();
                DataTable dtTemplateColumns = db.read(query);

                for (int j = 0; j < dtTemplateColumns.Rows.Count; j++)
                {
                    //DELETE the templateColumns
                    qu.Add("DELETE FROM templateColumns WHERE templateColumnID = " + dtTemplateColumns.Rows[j]["templateColumnID"].ToString());

                    //DELETE the templateColumn_formatting
                    qu.Add("DELETE FROM templateColumn_formatting WHERE templateColumnID = " + dtTemplateColumns.Rows[j]["templateColumnID"].ToString());
                }

            }

            try
            {
                db.writeTransaction(qu);
            }
            catch (Exception ee)
            {
                throw new Exception("Unable to delete supplier (" + ee.Message + ")");
            }

        }
        #endregion

        #region helpers
        public string generateUniqueKey()
        {
            //NOTE: Allows for approx 15,600 suppliers
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 4)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            string key = result;
            bool exist = false;
            query = "SELECT uniqueKey FROM suppliers WHERE uniqueKey = '" + key + "'";
            string e = "";
            try
            {
                e = db.readOne(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to generate unique key: " + ee.Message, ee);
            }

            if (!string.IsNullOrWhiteSpace(e))
            {
                exist = true;
            }

            //does this key exist?
            while (exist)
            {
                query = "SELECT uniqueKey FROM suppliers WHERE uniqueKey = '" + key + "'";
                e = "";
                try
                {
                    e = db.readOne(query);
                }
                catch (Exception ee)
                {
                    throw new DataException("Unable to generate unique key: " + ee.Message, ee);
                }

                if (!string.IsNullOrWhiteSpace(e))
                {
                    exist = true;

                    random = new Random();
                    result = new string(
                        Enumerable.Repeat(chars, 3)
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());

                    key = result;
                }
            }

            return key;
        }

        private Supplier bindSuppliers(DataTable dtSupplier)
        {
            Supplier s = new Supplier();
            try
            {
                s.supplierID = dtSupplier.Rows[0]["supplierID"].ToString();
                s.supplierName = dtSupplier.Rows[0]["supplierName"].ToString();
                s.supplierCode = dtSupplier.Rows[0]["supplierCode"].ToString();
                s.uniqueKey = dtSupplier.Rows[0]["uniqueKey"].ToString();
                s.agencyMargin = decimal.Parse(dtSupplier.Rows[0]["d_agencyMargin"].ToString());
                s.discount = decimal.Parse(dtSupplier.Rows[0]["d_discount"].ToString());
                s.grossMargin = decimal.Parse(dtSupplier.Rows[0]["d_grossMargin"].ToString());
                s.active = bool.Parse(dtSupplier.Rows[0]["active"].ToString());
                s.supplierNotes = dtSupplier.Rows[0]["supplierNotes"].ToString();
                if (string.IsNullOrEmpty(dtSupplier.Rows[0]["lastImportDate"].ToString()))
                {
                    s.lastImportDate = new DateTime().ToString();
                }
                else
                {
                    s.lastImportDate = dtSupplier.Rows[0]["lastImportDate"].ToString();
                }

                s.specialsActive = string.IsNullOrWhiteSpace(dtSupplier.Rows[0]["specialsActive"].ToString()) ? false : bool.Parse(dtSupplier.Rows[0]["specialsActive"].ToString());
                s.specialsImportDate = dtSupplier.Rows[0]["specialsImportDate"].ToString();
                if (string.IsNullOrEmpty(dtSupplier.Rows[0]["specialsImportDate"].ToString()))
                {
                    s.specialsImportDate = new DateTime().ToString();
                }
                else
                {
                    s.specialsImportDate = dtSupplier.Rows[0]["specialsImportDate"].ToString();
                }
            }
            catch (Exception ee)
            {
                throw new FormatException("Unable to bind supplier object", ee);
            }
            return s;
        }
        #endregion

    }
}
