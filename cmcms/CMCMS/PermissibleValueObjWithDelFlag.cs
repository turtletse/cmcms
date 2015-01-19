using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCMS
{
    public class PermissibleValueObjWithDelFlag : PermissibleValueObj
    {
        private bool deleted;

        public bool Deleted
        {
            get { return deleted; }
            private set { deleted = value; }
        }

        public PermissibleValueObjWithDelFlag(String name, String value, bool deleted)
            : base(name, value)
        {
            this.deleted = deleted;
        }
    }
}
