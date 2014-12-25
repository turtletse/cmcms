using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCMS
{
    class permissibleValueObj
    {
        private String name;
        private String value;

        public permissibleValueObj()
        {
            name = "";
            value = "";
        }
        public permissibleValueObj(String name, String value)
        {
            this.name = name;
            this.value = value;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public void setValue(String value)
        {
            this.value = value;
        }
        public String getName()
        {
            return name;
        }
        public String getValue()
        {
            return value;
        }
        public override string ToString()
        {
            return name;
        }

    }
}
