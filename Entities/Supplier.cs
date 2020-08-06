using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stockman.Entities
{
    public class Supplier
    {
        public string supplierID { get; set; }
        public string supplierName { get; set; }
        private string _supplierCode = "";
        public string supplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value.ToUpper(); }
        }
        private string _uniqueKey = "";
        public string uniqueKey
        {
            get { return _uniqueKey; }
            set { _uniqueKey = value.ToUpper(); }
        }
        public decimal agencyMargin { get; set; }
        public decimal discount { get; set; }
        public decimal grossMargin { get; set; }

        public bool active { get; set; }

        public string supplierNotes { get; set; }
        public string lastImportDate { get; set; }

        public bool specialsActive { get; set; }
        public string specialsImportDate { get; set; }
    }
}
