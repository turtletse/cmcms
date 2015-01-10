using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCMS
{
    public class Utilities
    {
        public static String stringDataParse4SQL(String data)
        {
            return data.Replace("'", "''");
        }
    }
}
