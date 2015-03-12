﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CMCMS
{
    public class Utilities
    {
        public static String stringDataParse4SQL(String data)
        {
            return data.Replace("'", "''");
        }

        public static void SelectItemByValue(System.Windows.Forms.ComboBox cb, string value)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                String permissibleValue = ((PermissibleValueObj)(cb.Items[i])).Value;
                if (permissibleValue != null && permissibleValue == value)
                {
                    cb.SelectedIndex = i;
                    break;
                }
            }
        }

        public static bool isInteger(String s)
        {
            return Regex.IsMatch(s, "^[0-9]+$", RegexOptions.Compiled);
        }
    }
}
