using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stockman.Entities
{
    class AttributeProperty
    {        
        public string propertyID { get; set; }
        public string stockCode { get; set; }
        public string skuCode { get; set; }
        public string propertyName { get; set; }
        public int position { get; set; }
    }

    class AttributePropertyParent : AttributeProperty
    {
        public int attributeSetID { get; set; }
        public string basePriceColumn { get; set; }       
        public string attributeSetName { get; set; }
        public List<AttributeProperty> childrenProperties { get; set; }
    }
}
