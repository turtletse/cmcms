using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCMS
{
    public class SubDrugObj : PermissibleValueObj
    {
        private bool deleted;

        public bool Deleted
        {
            get { return deleted; }
            private set { deleted = value; }
        }

        public SubDrugObj(String name, String value, bool deleted)
            : base(name, value)
        {
            this.deleted = deleted;
        }
    }
}
