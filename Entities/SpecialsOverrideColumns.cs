using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stockman.Entities
{
    public class SpecialsOverrideColumns
    {
        public string baseColumn { get; set; }  //ex baseProductPrice (baseColumn) overrides Netcost (overridesColumn)
        public List<string> overridesColumns { get; set; }
    }
}
