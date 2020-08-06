using System.Collections.Generic;
using System.Drawing;

namespace Stockman.Entities
{
    public class Templates
    {
        public string templateID { get; set; }
        public string templateName { get; set; }
        public bool active;
        public string lastFileLocation { get; set; }
        public List<TemplateColumns> templateColumns { get; set; }
        public string templateDirection { get; set; }

        public bool containsDbColumn(string databaseColumn)
        {
            foreach (TemplateColumns tc in this.templateColumns)
            {
                if (tc.databaseColumn.ToUpper() == databaseColumn.ToUpper())
                {
                    return true;
                }
            }

            return false;
        }
        public int getColumnPosition(string templateColumnID)
        {
            foreach (TemplateColumns tc in this.templateColumns)
            {
                if (tc.templateColumnID == templateColumnID)
                {
                    return tc.position;
                }
            }

            return 0;
        }

        public TemplateColumns getColumnWithPosition(int position)
        {
            foreach (TemplateColumns tc in this.templateColumns)
            {
                if (tc.position == position)
                {
                    return tc;
                }
            }

            return null;
        }

        public List<SpecialsOverrideColumns> specialsOverrideColumns { get; set; }
    }

    public enum columnTypes { STRING, DECIMAL_18_2, DECIMAL_18_3, DECIMAL_18_4, DECIMAL_18_5 }
    public enum columnCalculationType { CALCULATE, MERGE, NONE, COPY }
    public class TemplateColumns
    {
        public string csvHeader { get; set; }
        public string databaseColumn { get; set; }
        public columnTypes columnType { get; set; }
        public string templateColumnID { get; set; }
        public string calculation { get; set; }
        public List<TemplateConditionalFormatting> templateConditionalFormatting { get; set; }
        public bool applyRounding { get; set; }
        public bool dontOverride { get; set; }
        public columnCalculationType calculationType { get; set; }
        public int position { get; set; }
        public string exportDefault { get; set; }
        public bool includeAttributes { get; set; }
        public string specialsBasePriceCSVColumn { get; set; }
        public bool isSpecialsExportColumn { get; set; }
        public bool keepOriginalData { get; set; }
    }

    public class TemplateConditionalFormatting
    {
        public string formattingID { get; set; }
        public Color highlightColor { get; set; }
        public decimal number { get; set; }
        public string op { get; set; }
    }

    public class SpecialsCalculation
    {
        public TableNames.StockTables tableOne { get; set; }
        public TableNames.StockTables tableTwo { get; set; }
        public string tableOneColumn { get; set; }
        public string tableTwoColumn { get; set; }
        public string operation { get; set; }
    }
}
