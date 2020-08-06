using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Stockman.Entities;

namespace Stockman.Classes
{
    class attributeMethods
    {
        #region initialize
        string query { get; set; }
        databaseMethods db = new databaseMethods();
        #endregion

        public void createAttribute(string attributeName)
        {
            //does this attribute name already exist?
            ArrayList names = getAttributeNames();
            if (names.Contains(attributeName))
            {
                throw new Exception("Attribute name already exist");
            }

            query = "INSERT INTO attributes (attributeName) VALUES ('" + attributeName + "')";
            try
            {
                db.write(query);
            }
            catch (Exception ee)
            {
                throw new DataException(ee.Message, ee);
            }
        }

        public void deleteFullAttributeSet(AttributePropertyParent attributeSet)
        {
            ArrayList queries = new ArrayList();
            query = "DELETE FROM supplier_attributes WHERE attributeSetID = " + attributeSet.attributeSetID;
            queries.Add(query);
            query = "DELETE FROM attribute_properties WHERE attributeSetID = " + attributeSet.attributeSetID;
            queries.Add(query);

            try
            {
                db.writeTransaction(queries);
            }
            catch (Exception ee)
            {
                throw new Exception("Unable to delete attribute set: " + ee.Message);
            }
        }

        public void deleteChildProperties(AttributeProperty property)
        {            
            query = "DELETE FROM attribute_properties WHERE propertyID = " + property.propertyID;
            db.write(query);
        }

        public ArrayList getAttributeNames()
        {
            query = "SELECT attributeName FROM attributes ORDER BY attributeName";
            DataTable dt = new DataTable();

            try
            {
                dt = db.read(query);
            }
            catch (Exception ee)
            {
                throw new DataException("Unable to retrieve attributes: " + ee.Message, ee);
            }

            ArrayList attrNames = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                attrNames.Add(dt.Rows[i]["attributeName"].ToString());
            }

            return attrNames;
        }

        public void deleteSet(Supplier s, AttributePropertyParent set)
        {
            ArrayList queries = new ArrayList();
            queries.Add("DELETE FROM supplier_attributes WHERE attributeSetID = " + set.attributeSetID);
            queries.Add("DELETE FROM attribute_properties WHERE attributeSetID = " + set.attributeSetID);
            try
            {
                db.writeTransaction(queries);
            }
            catch (Exception ee)
            {
                throw;
            }

        }

        public void saveSet(Supplier s, List<AttributePropertyParent> attributeSets)
        {

            foreach (AttributePropertyParent parent in attributeSets)
            {
                if (parent.attributeSetID == 0)
                {
                    //do an insert
                    //write to database
                    query = "INSERT INTO supplier_attributes (supplierID, attributeName, basePriceColumn, parentPropertyName, parentPropertyCode, parentPropertySKUCode) VALUES (" + s.supplierID + ", '" + parent.attributeSetName + "', '" + parent.basePriceColumn + "', '" + parent.propertyName + "', '" + parent.stockCode + "', '" + parent.skuCode + "') SELECT @@Identity AS myID";
                    string setID = db.writeWithID(query);

                    foreach (AttributeProperty prop in parent.childrenProperties)
                    {
                        query = "INSERT INTO attribute_properties (attributeSetID, stockCode, skuCode, propertyName, position) VALUES (" + setID + ", '" + prop.stockCode + "', '" + prop.skuCode + "', '" + prop.propertyName + "', " + prop.position + " )";
                        db.write(query);
                    }
                }
                else
                {
                    //do an update
                    //write to database
                    query = "UPDATE supplier_attributes SET basePriceColumn = '" + parent.basePriceColumn + "', parentPropertyName = '" + parent.propertyName + "', parentPropertyCode = '" + parent.stockCode + "', parentPropertySKUCode = '" + parent.skuCode + "' WHERE attributeSetID = " + parent.attributeSetID;
                    db.write(query);

                    foreach (AttributeProperty prop in parent.childrenProperties)
                    {
                        if (!string.IsNullOrWhiteSpace(prop.propertyID))
                        {
                            query = "UPDATE attribute_properties SET stockCode = '" + prop.stockCode + "', skuCode = '" + prop.skuCode + "', propertyName = '" + prop.propertyName + "', position = " + prop.position + " WHERE propertyID = " + prop.propertyID;
                        }
                        else
                        {
                            query = "INSERT INTO attribute_properties (attributeSetID, stockCode, skuCode, propertyName, position) VALUES (" + parent.attributeSetID + ", '" + prop.stockCode + "', '" + prop.skuCode + "', '" + prop.propertyName + "', " + prop.position + " )";
                        }
                        db.write(query);
                    }
                }
            }
        }

        public List<AttributePropertyParent> getFullAttributeSet(Supplier s, string attributeName)
        {
            query = "SELECT attributeSetID, attributeName, basePriceColumn, parentPropertyName, parentPropertyCode, parentPropertySKUCode FROM supplier_attributes WHERE attributeName = '" + attributeName + "' AND supplierID = " + s.supplierID;
            DataTable dt = db.read(query);

            List<AttributePropertyParent> parentProperties = new List<AttributePropertyParent>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AttributePropertyParent prop = new AttributePropertyParent();
                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                prop.attributeSetID = int.Parse(dt.Rows[i]["attributeSetID"].ToString());
                prop.attributeSetName = dt.Rows[i]["attributeName"].ToString();
                prop.basePriceColumn = dt.Rows[i]["basePriceColumn"].ToString();
                prop.propertyName = dt.Rows[i]["parentPropertyName"].ToString();
                prop.stockCode = dt.Rows[i]["parentPropertyCode"].ToString();
                prop.skuCode = dt.Rows[i]["parentPropertySKUCode"].ToString();

                query = "SELECT propertyID, stockCode, skuCode, position, propertyName FROM attribute_properties WHERE attributeSetID = " + prop.attributeSetID;
                DataTable dtChildren = db.read(query);

                List<AttributeProperty> childrenProperties = new List<AttributeProperty>();
                for (int ji = 0; ji < dtChildren.Rows.Count; ji++)
                {
                    childrenProperties.Add(bindAttributeSetProperties(dtChildren.Rows[ji]));
                }

                prop.childrenProperties = childrenProperties;
                parentProperties.Add(prop);
            }

            return parentProperties;
        }

        private string getAttributeSetID(Supplier s, string attributeName)
        {
            query = "SELECT attributeSetID FROM supplier_attributes WHERE attributeName = '" + attributeName + "' AND supplierID = " + s.supplierID;
            string attributeSetID = db.readOne(query);

            return attributeSetID;
        }

        //public ArrayList getAttributeSetProperties(string attributeSetID)
        //{
        //    DataTable dt = new DataTable();

        //    query = "SELECT propertyID, stockCode, skuCode, position, propertyName FROM attribute_properties WHERE attributeSetID = " + attributeSetID;
        //    dt = db.read(query);


        //    ArrayList properties = new ArrayList();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        properties.Add(bindAttributeSetProperties(dt.Rows[i]));
        //    }

        //    return properties;
        //}

        public AttributeProperty bindAttributeSetProperties(DataRow dr)
        {
            AttributeProperty prop = new AttributeProperty();
            prop.propertyID = dr["propertyID"].ToString();
            prop.stockCode = dr["stockCode"].ToString();
            prop.skuCode = dr["skuCode"].ToString();
            if (!string.IsNullOrWhiteSpace(dr["position"].ToString()))
            {
                prop.position = int.Parse(dr["position"].ToString());
            }
            else
            {
                prop.position = 0;
            }
            prop.propertyName = dr["propertyName"].ToString();

            return prop;
        }

        public ArrayList getAttributeSetProperties(Supplier s, AttributePropertyParent parent)
        {
            ArrayList properties = new ArrayList();
            query = "SELECT propertyID, stockCode, skuCode, propertyName, position FROM attribute_properties WHERE attributeSetID = " + parent.attributeSetID + " ORDER BY position";
            DataTable dt = db.read(query);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                properties.Add(bindAttributeSetProperties(dt.Rows[i]));
            }

            return properties;
        }

        public ArrayList getSupplierAttributeSets(Supplier s)
        {
            query = "SELECT attributeSetID FROM supplier_attributes WHERE supplierID = " + s.supplierID;
            DataTable dt = db.read(query);

            ArrayList setIDs = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                setIDs.Add(dt.Rows[i]["attributeSetID"].ToString());
            }

            return setIDs;
        }
    }
}
