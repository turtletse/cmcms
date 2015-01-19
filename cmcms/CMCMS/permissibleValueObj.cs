using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCMS
{
    public class PermissibleValueObj
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private String value;

        public String Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public PermissibleValueObj()
        {
            name = "";
            value = "";
        }
        public PermissibleValueObj(String name, String value)
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
