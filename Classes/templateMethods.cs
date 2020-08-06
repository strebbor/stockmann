using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Stockman.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Reflection;

namespace Stockman.Classes
{
    public class templateMethods
    {
        #region initialize
        databaseMethods db = new databaseMethods();
        string query { get; set; }
        #endregion

        #region retrieve templates
        public List<Templates> getSupplierTemplates(string supplierID, string direction, bool showAllSpecialsColumns)
        {
            query = @"
SELECT st.templateID, t.templateName, t.active, t.direction, st.lastFileLocation
FROM supplier_templates st
LEFT JOIN templates t ON st.templateID = t.templateID
WHERE st.supplierID = " + supplierID + " AND t.active = 'True' AND direction = '" + direction + "' ORDER BY t.templateName";
            DataTable dtTemplateMain = null;
            try
            {
                dtTemplateMain = db.read(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to retrieve templates: " + ee.Message, ee);
            }

            List<Templates> retTemplates = new List<Templates>();
            for (int i = 0; i < dtTemplateMain.Rows.Count; i++)
            {
                retTemplates.Add(bindTemplateMain(dtTemplateMain.Rows[i]));
            }

            //load template columns
            for (int i = 0; i < retTemplates.Count; i++)
            {
                try
                {
                    loadTemplateColumns(retTemplates[i]);
                }
                catch (DataException ee)
                {
                    throw;
                }
            }

            //load override template columns
            List<SpecialsOverrideColumns> overrideColumns = new List<SpecialsOverrideColumns>();
            foreach (Templates t in retTemplates)
            {
                try
                {
                    if (overrideColumns.Count < 1)
                    {
                        overrideColumns = getSpecialsOverrideColumns(t.templateID, supplierID, showAllSpecialsColumns);
                    }
                    t.specialsOverrideColumns = overrideColumns;
                }
                catch (DataException ee)
                {
                    throw;
                }
            }

            return retTemplates;
        }

        public void storeLastFileLocation(Templates template, Supplier sup, string location)
        {
            query = "UPDATE supplier_templates SET lastFileLocation = '" + location + "' WHERE templateID = " + template.templateID + " AND supplierID = " + sup.supplierID;
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public enum QueryTypes
        {
            SELECT, UPDATE, INSERT
        }
        private string[] buildQueryStringTemplateColumns(QueryTypes queryType, TemplateColumns itemToUse)
        {
            List<Type> allowedTypes = new List<Type>();
            allowedTypes.Add(typeof(string));
            allowedTypes.Add(typeof(bool));
            allowedTypes.Add(typeof(int));
            allowedTypes.Add(typeof(decimal));
            allowedTypes.Add(typeof(columnCalculationType));
            allowedTypes.Add(typeof(columnTypes));

            List<string> properties = new List<string>();


            Type info = typeof(TemplateColumns);
            foreach (PropertyInfo pi in info.GetProperties())
            {
                if (allowedTypes.Contains(pi.PropertyType))
                {
                    properties.Add(pi.Name);
                }
            }

            string[] returnQuery = new string[2];
            switch (queryType)
            {
                case QueryTypes.SELECT:
                    {
                        foreach (string s in properties)
                        {
                            returnQuery[0] += s + ", ";
                        }
                    } break;
                case QueryTypes.INSERT:
                    {

                    }
                    break;
            }

            returnQuery[0] = returnQuery[0].Substring(0, returnQuery.Length - 2);

            return returnQuery;
        }

        private void loadTemplateColumns(Templates mainTemplateItem)
        {
            if (mainTemplateItem.templateColumns != null)
            {
                mainTemplateItem.templateColumns.Clear();
            }

            //string selectQuery = buildQueryStringTemplateColumns(QueryTypes.SELECT, null)[0];
            //query = "SELECT " + selectQuery + " FROM templateColumns WHERE templateID = " + mainTemplateItem.templateID + " ORDER BY position";

            query = "SELECT templateColumnID, csvHeader, databaseColumn, columnType, calculation, applyRounding, dontOverride, calculationType, position, exportDefault, includeAttributes, specialsOverrideColumns, specialsBasePriceCSVColumn, isSpecialsExportColumn, keepOriginalData FROM templateColumns WHERE templateID = " + mainTemplateItem.templateID + " ORDER BY position";
            DataTable dtColumns = null;
            try
            {
                dtColumns = db.read(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to load template columns: " + ee.Message, ee);
            }

            List<TemplateColumns> templateColumns = new List<TemplateColumns>();

            for (int j = 0; j < dtColumns.Rows.Count; j++)
            {
                templateColumns.Add(bindTemplateColumns(dtColumns.Rows[j]));
            }
            mainTemplateItem.templateColumns = templateColumns;

            //load conditional formatting
            for (int i = 0; i < mainTemplateItem.templateColumns.Count; i++)
            {
                try
                {
                    loadTemplateConditionalFormatting(mainTemplateItem.templateColumns[i]);
                }
                catch (DataException ee)
                {
                    throw;
                }
            }
        }

        public void loadTemplateConditionalFormatting(TemplateColumns col)
        {
            if (col.templateConditionalFormatting != null)
            {
                col.templateConditionalFormatting.Clear();
            }

            query = "SELECT formattingID, op, color, number FROM templateColumn_formatting WHERE templateColumnID = " + col.templateColumnID;
            DataTable dtFormatting = null;
            try
            {
                dtFormatting = db.read(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to load template columns: " + ee.Message, ee);
            }

            List<TemplateConditionalFormatting> formats = new List<TemplateConditionalFormatting>();
            for (int j = 0; j < dtFormatting.Rows.Count; j++)
            {
                formats.Add(bindFormatting(dtFormatting.Rows[j]));
            }

            col.templateConditionalFormatting = formats;
        }
        #endregion

        #region bindings
        private TemplateConditionalFormatting bindFormatting(DataRow dr)
        {
            TemplateConditionalFormatting format = new TemplateConditionalFormatting();
            format.op = dr["op"].ToString();
            format.number = decimal.Parse(dr["number"].ToString());
            //get color parts
            string[] colorParts = dr["color"].ToString().Split(new string[] { "#" }, StringSplitOptions.None);

            format.highlightColor = Color.FromArgb(int.Parse(colorParts[0]), int.Parse(colorParts[1]), int.Parse(colorParts[2]), int.Parse(colorParts[3]));
            format.formattingID = dr["formattingID"].ToString();

            return format;

        }

        private Templates bindTemplateMain(DataRow dr)
        {
            Templates getTemplate = new Templates();
            getTemplate.templateName = dr["templateName"].ToString();
            getTemplate.templateID = dr["templateID"].ToString();
            getTemplate.templateDirection = dr["direction"].ToString();
            getTemplate.lastFileLocation = dr["lastFileLocation"].ToString();
            return getTemplate;
        }

        private TemplateColumns bindTemplateColumns(DataRow dr)
        {
            TemplateColumns tc = new TemplateColumns();
            tc.templateColumnID = dr["templateColumnID"].ToString();
            tc.csvHeader = dr["csvHeader"].ToString();
            tc.databaseColumn = dr["databaseColumn"].ToString();
            switch (dr["calculationType"].ToString())
            {
                case "CALCULATE": { tc.calculationType = columnCalculationType.CALCULATE; } break;
                case "MERGE": { tc.calculationType = columnCalculationType.MERGE; } break;
                case "NONE": { tc.calculationType = columnCalculationType.NONE; } break;
                case "COPY": { tc.calculationType = columnCalculationType.COPY; } break;
                default: { tc.calculationType = columnCalculationType.NONE; } break;
            }

            columnTypes selectedFormat = columnTypes.STRING;
            switch (dr["columnType"].ToString())
            {
                case "STRING": { selectedFormat = columnTypes.STRING; } break;
                case "DECIMAL 0.00": { selectedFormat = columnTypes.DECIMAL_18_2; } break;
                case "DECIMAL 0.000": { selectedFormat = columnTypes.DECIMAL_18_3; } break;
                case "DECIMAL 0.0000": { selectedFormat = columnTypes.DECIMAL_18_4; } break;
                case "DECIMAL 0.00000": { selectedFormat = columnTypes.DECIMAL_18_5; } break;
            }

            tc.columnType = selectedFormat;
            tc.calculation = dr["calculation"].ToString();
            tc.applyRounding = bool.Parse(dr["applyRounding"].ToString());
            tc.dontOverride = bool.Parse(dr["dontOverride"].ToString());
            tc.position = int.Parse(dr["position"].ToString());
            tc.exportDefault = dr["exportDefault"].ToString();
            if (!string.IsNullOrWhiteSpace(dr["includeAttributes"].ToString())) { tc.includeAttributes = bool.Parse(dr["includeAttributes"].ToString()); }
            tc.specialsBasePriceCSVColumn = dr["specialsBasePriceCSVColumn"].ToString();
            if (!string.IsNullOrWhiteSpace(dr["isSpecialsExportColumn"].ToString())) { tc.isSpecialsExportColumn = bool.Parse(dr["isSpecialsExportColumn"].ToString()); }
            if (!string.IsNullOrWhiteSpace(dr["keepOriginalData"].ToString())) { tc.keepOriginalData = bool.Parse(dr["keepOriginalData"].ToString()); } else { tc.keepOriginalData = true; }

            return tc;
        }
        #endregion

        #region template operations
        public string createTemplate(string supplierID, string templateName, string direction)
        {
            //[[to do - add transaction]]

            query = "INSERT INTO templates (templateName, direction) VALUES ('" + templateName + "', '" + direction + "')";
            string templateID = db.writeWithID(query);

            query = "INSERT INTO supplier_templates (supplierID, templateID) VALUES (" + supplierID + ", " + templateID + ")";
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to create template: " + ee.Message, ee);
            }

            return templateID;
        }
        public string copyTemplate(string templateID, string copyToSupplierID)
        {
            SqlTransaction trans = null;
            string newTemplateID = "";

            using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["StockmannConfig"]))
            {
                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();

                    query = @"
INSERT INTO templates 
SELECT 'Copy of ' + templateName, active, direction FROM templates WHERE templateID = " + templateID + " SELECT @@Identity AS myID";

                    newTemplateID = db.writeWithID(query);

                    query = @"            
INSERT INTO supplier_templates (supplierID, templateID) 
VALUES (" + copyToSupplierID + ", " + newTemplateID + ")";
                    db.write(query);

                    query = @"
INSERT INTO templateColumns
SELECT " + newTemplateID + ", csvHeader, databaseColumn, columnType, calculation, conditionalFormatting, applyRounding, dontOverride, calculationType, position, exportDefault, includeAttributes, specialsOverrideColumns, specialsBasePriceCSVColumn, isSpecialsExportColumn, keepOriginalData FROM templateColumns WHERE templateID = " + templateID;
                    db.write(query);

                    trans.Commit();
                }
                catch (Exception ee)
                {
                    trans.Rollback();
                    throw new Exception("Unable to update template: " + ee.Message);
                }

                return newTemplateID;
            }
        }
        public void removeTemplate(Templates templateItem)
        {
            ArrayList queries = new ArrayList();
            queries.Add("DELETE FROM templateColumns WHERE templateID = " + templateItem.templateID);
            queries.Add("DELETE FROM templates WHERE templateID = " + templateItem.templateID);
            queries.Add("DELETE FROM supplier_templates WHERE templateID = " + templateItem.templateID);
            try
            {
                db.writeTransaction(queries);
            }
            catch (Exception ee)
            {
                throw new Exception("Unable to delete template: " + ee.Message);
            }
        }
        public void renameTemplate(Templates templateItem, string newName)
        {
            query = "UPDATE templates SET templateName = '" + newName + "' WHERE templateID = " + templateItem.templateID;
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to rename template: " + ee.Message, ee);
            }
        }

        #endregion

        #region column operations
        public enum ColumnCalculationEntities
        { CALCULATE, MERGE, NONE, COPY }


        public void insertColumn(Templates templateItem, string csvHeader, string databaseColumn, string columnType, string calculation, bool applyRounding, bool dontOverride, ColumnCalculationEntities calcType, string exportDefault, string specialsOverrideColumns, string specialsBasePriceCSVColumn, bool isSpecialsExportColumn, bool keepOriginalData)
        {
            //does the column mapping already exist?
            query = "SELECT csvHeader, databaseColumn FROM templateColumns WHERE templateID = " + templateItem.templateID + " AND csvHeader = '" + csvHeader + "' AND databaseColumn = '" + databaseColumn + "'";
            string exist = "";
            try
            {
                exist = db.readOne(query);
            }
            catch (Exception eE)
            {
                throw new DataException("Unable to insert column (unable to determine existance): " + eE.Message, eE);
            }

            if (!string.IsNullOrWhiteSpace(exist))
            {
                throw new DuplicateNameException("Mapping already exist");
            }

            query = "INSERT INTO templateColumns (templateID, csvHeader, databaseColumn, columnType, calculation, applyRounding, dontOverride, calculationType, position, exportDefault, specialsOverrideColumns, specialsBasePriceCSVColumn, isSpecialsExportColumn, keepOriginalData) VALUES (" + templateItem.templateID + ", '" + csvHeader + "', '" + databaseColumn + "', '" + columnType + "', '" + calculation + "', '" + applyRounding + "', '" + dontOverride + "', '" + calcType + "', " + getNewTemplateColumnPosition(templateItem) + ", '" + exportDefault + "', '" + specialsOverrideColumns + "', '" + specialsBasePriceCSVColumn + "', '" + isSpecialsExportColumn + "', '" + keepOriginalData + "')";
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to insert template: " + ee.Message, ee);
            }

            try
            {
                loadTemplateColumns(templateItem);
            }
            catch (DataException ee)
            {
                throw;
            }
        }

        public void updateColumn(Templates templateItem, string templateColumnID, string csvHeader, string databaseColumn, string columnType, string calculation, bool applyRounding, bool dontOverride, ColumnCalculationEntities calculationType, int position, string exportDefault, bool includeAttributes, string specialsOverrideColumns, string specialsBasePriceCSVColumn, bool isSpecialsExportColumn, bool keepOriginalData)
        {
            query = "UPDATE templateColumns SET csvHeader = '" + csvHeader + "', databaseColumn = '" + databaseColumn + "', columnType = '" + columnType + "', calculation = '" + calculation + "', applyRounding = '" + applyRounding + "', dontOverride = '" + dontOverride + "', calculationType = '" + calculationType + "', position = " + position + ", exportDefault = '" + exportDefault + "', includeAttributes = '" + includeAttributes + "', specialsOverrideColumns = '" + specialsOverrideColumns + "', specialsBasePriceCSVColumn = '" + specialsBasePriceCSVColumn + "', isSpecialsExportColumn = '" + isSpecialsExportColumn + "', keepOriginalData = '" + keepOriginalData + "' WHERE templateColumnID = " + templateColumnID;
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to update column: " + ee.Message, ee);
            }

            try
            {
                loadTemplateColumns(templateItem);
            }
            catch (DataException ee)
            {
                throw;
            }
        }


        public void removeColumn(Templates templateItem, string templateColumnID)
        {
            //gets this column's position and ensures that it is found
            int currentPosition = templateItem.getColumnPosition(templateColumnID);
            if (currentPosition == 0)
            {
                throw new Exception("Unable to determine current column's position");
            }


            ArrayList queries = new ArrayList();
            queries.Add("DELETE FROM templateColumns WHERE templateColumnID = " + templateColumnID); //delete column
            queries.Add("UPDATE templateColumns SET position = position - 1 WHERE templateID = " + templateItem.templateID + " and position > " + currentPosition); //moves all columns up with one

            try
            {
                db.writeTransaction(queries);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to delete column: " + ee.Message, ee);
            }


            try
            {
                loadTemplateColumns(templateItem);
            }
            catch (DataException ee)
            {
                throw;
            }
        }

        public enum DIRECTION
        {
            UP, DOWN
        }
        public void swopColumns(Templates selectedTemplate, TemplateColumns selectedColumn, DIRECTION dir)
        {
            TemplateColumns swopColumn = new TemplateColumns();
            int currentColumnPosition = selectedColumn.position;
            if (dir == DIRECTION.UP)
            {
                //can't move top up
                if (currentColumnPosition == 1)
                {
                    throw new Exception("Unable to move column: This column is already at the top");
                }

                //gets the column position to swop with                
                swopColumn = selectedTemplate.getColumnWithPosition(currentColumnPosition - 1);
                if (swopColumn == null)
                {
                    throw new Exception("Unable to determine swop column");
                }
            }
            else
            {
                //can't move last one down
                if (currentColumnPosition == (getNewTemplateColumnPosition(selectedTemplate) - 1))
                {
                    throw new Exception("Unable to move column: This column is already at the bottom");
                }


                //gets the column position to swop with                
                swopColumn = selectedTemplate.getColumnWithPosition(currentColumnPosition + 1);
                if (swopColumn == null)
                {
                    throw new Exception("Unable to determine swop column");
                }
            }

            ArrayList queries = new ArrayList();
            queries.Add("UPDATE templateColumns SET position = " + swopColumn.position + " WHERE templateColumnID = " + selectedColumn.templateColumnID);
            queries.Add("UPDATE templateColumns SET position = " + currentColumnPosition + " WHERE templateColumnID = " + swopColumn.templateColumnID);
            try
            {
                db.writeTransaction(queries);
            }
            catch (Exception ee)
            {
                throw new Exception("Unable to move column: " + ee.Message);
            }

            try
            {
                loadTemplateColumns(selectedTemplate);
            }
            catch (DataException ee)
            {
                throw;
            }
        }

        public int getNewTemplateColumnPosition(Templates templateItem)
        {
            query = "SELECT MAX(position) + 1 FROM templateColumns WHERE templateID = " + templateItem.templateID;
            string newVal = db.readOne(query);
            int max = 0;
            if (string.IsNullOrEmpty(newVal))
            {
                max = 1;
            }
            else
            {
                max = int.Parse(newVal);
            }

            return max;
        }


        #endregion

        #region formatting operations
        public void insertFormatting(TemplateColumns column, string op, decimal number, Color color)
        {
            string convertToDB = color.A + "#" + color.R + "#" + color.G + "#" + color.B;

            query = "INSERT INTO templateColumn_formatting (templateColumnID, op, color, number) VALUES (" + column.templateColumnID + ", '" + op + "', '" + convertToDB + "', " + number + ")";
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to insert formatting: " + ee.Message, ee);
            }
        }

        public void removeFormatting(string formattingID)
        {
            query = "DELETE FROM templateColumn_formatting WHERE formattingID = " + formattingID;
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to remove formatting: " + ee.Message, ee);
            }
        }
        #endregion

        #region database operations
        public void deleteDBColumn(string columnName)
        {
            ArrayList queries = new ArrayList();

            //remove columns out of templates            
            queries.Add("DELETE FROM templateColumns WHERE databaseColumn = '" + columnName + "'");
            queries.Add("ALTER TABLE stockItems DROP COLUMN " + columnName);
            try
            {
                db.writeTransaction(queries);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to delete database column: " + ee.Message, ee);
            }
        }

        public void createDBColumn(string columnName, columnTypes colType)
        {
            createDBColumnMaster(columnName, colType, TableNames.StockTables.StockItems);
            createDBColumnMaster(columnName, colType, TableNames.StockTables.StockItems_Specials);
        }

        private void createDBColumnMaster(string columnName, columnTypes colType, TableNames.StockTables tableName)
        {
            //format columnName
            columnName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(columnName.ToLower());
            columnName = columnName.Replace(" ", "");

            //determines the column type
            string scolType = "VARCHAR(500)";
            switch (colType)
            {
                case columnTypes.DECIMAL_18_2: { scolType = "DECIMAL(18, 2)"; } break;
                case columnTypes.DECIMAL_18_3: { scolType = "DECIMAL(18, 3)"; } break;
                case columnTypes.DECIMAL_18_4: { scolType = "DECIMAL(18, 4)"; } break;
                case columnTypes.DECIMAL_18_5: { scolType = "DECIMAL(18, 5)"; } break;
            }

            //creates the column
            string query = @"
IF NOT EXISTS (SELECT *
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = '" + tableName + "' AND COLUMN_NAME = '" + columnName + @"')
ALTER TABLE [DBO]." + tableName + " ADD " + columnName + @" " + scolType + @" NULL
";
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to create database column: " + ee.Message, ee);
            }
        }

        public DataTable getDBColumns(string tableName, string dataType)
        {
            string additional = "";
            if (!string.IsNullOrWhiteSpace(dataType))
            {
                additional = " AND DATA_TYPE = '" + dataType + "'";
            }
            query = @"SELECT COLUMN_NAME, DATA_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = '" + tableName + "' AND TABLE_SCHEMA='dbo'" + additional + " ORDER BY COLUMN_NAME";

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
        }
        #endregion

        #region specials operations
        public SpecialsCalculation getSpecialsCalculation(string calculation)
        {
            SpecialsCalculation sc = new SpecialsCalculation();

            string[] parts = calculation.Split(new char[] { '#' });
            string t1 = parts[0].Split(new char[] { ':' })[1];
            switch (t1.ToUpper())
            {
                case "STOCKITEMS": { sc.tableOne = TableNames.StockTables.StockItems; } break;
                case "STOCKITEMS_SPECIALS": { sc.tableOne = TableNames.StockTables.StockItems_Specials; } break;
            }
            sc.tableOneColumn = parts[1].Split(new char[] { ':' })[1];

            sc.operation = parts[2].Split(new char[] { ':' })[1];

            string t2 = parts[3].Split(new char[] { ':' })[1];
            switch (t2.ToUpper())
            {
                case "STOCKITEMS": { sc.tableTwo = TableNames.StockTables.StockItems; } break;
                case "STOCKITEMS_SPECIALS": { sc.tableTwo = TableNames.StockTables.StockItems_Specials; } break;
            }

            sc.tableTwoColumn = parts[4].Split(new char[] { ':' })[1];

            return sc;
        }

        public string doSpecialsCalculation(SpecialsCalculation sc, string keyValue)
        {
            string function = "CalculateSpecialsValueNormalSpecials";
            switch (sc.tableOne)
            {
                case TableNames.StockTables.StockItems:
                    {
                        function = "CalculateSpecialsValueNormalSpecials";
                        query = "EXECUTE " + function + " '" + sc.tableOneColumn + "', '" + sc.tableTwoColumn + "', '" + keyValue + "', '" + sc.operation + "'";
                    } break;
                case TableNames.StockTables.StockItems_Specials:
                    {
                        function = "CalculateSpecialsValueSpecialsNormal";
                        query = "EXECUTE " + function + " '" + sc.tableTwoColumn + "', '" + sc.tableOneColumn + "', '" + keyValue + "', '" + sc.operation + "'";
                    } break;
            }

            string returnValue = db.readOne(query);
            return returnValue;
        }

        private List<SpecialsOverrideColumns> getSpecialsOverrideColumns(string templateID, string supplierID, bool getAll)
        {
            string query = "";
            if (!getAll)
            {
                query = @"SELECT tc.databaseColumn, tc.specialsOverrideColumns   
                              FROM templateColumns tc
                              LEFT JOIN supplier_templates st ON st.templateID = tc.templateID
                              LEFT JOIN templates tt ON st.templateID = tt.templateID
                              WHERE tt.templateID = " + templateID + @" AND tt.direction = 'IMPORT'
                              AND (tc.specialsOverrideColumns != NULL OR tc.specialsOverrideColumns != '')";
            }
            else
            {
                query = @"SELECT tc.databaseColumn, tc.specialsOverrideColumns   
                              FROM templateColumns tc
                              LEFT JOIN supplier_templates st ON st.templateID = tc.templateID
                              LEFT JOIN templates tt ON st.templateID = tt.templateID
                              WHERE st.supplierID = " + supplierID + @" AND tt.direction = 'IMPORT'
                              AND (tc.specialsOverrideColumns != NULL OR tc.specialsOverrideColumns != '')";
            }
            DataTable dt = db.read(query);

            List<SpecialsOverrideColumns> columns = new List<SpecialsOverrideColumns>();
            foreach (DataRow dr in dt.Rows)
            {
                SpecialsOverrideColumns sp = new SpecialsOverrideColumns();
                sp.baseColumn = dr["databaseColumn"].ToString();
                string[] overridesColumns = dr["specialsOverrideColumns"].ToString().Split(new char[] { '#' });
                sp.overridesColumns = new List<string>();
                foreach (string s in overridesColumns)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        sp.overridesColumns.Add(s);
                    }
                }

                columns.Add(sp);
            }

            return columns;
        }
        #endregion
    }
}
