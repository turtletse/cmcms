using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCMS
{
    class SubDrugObj : PermissibleValueObj
    {
        private bool deleted { get; set; }
        public SubDrugObj(String name, String value, bool deleted)
            : base(name, value)
        {
            this.deleted = deleted;
        }
    }
}
