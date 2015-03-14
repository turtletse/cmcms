using System;
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
            return Regex.IsMatch(s, @"^[0-9]+$", RegexOptions.Compiled);
        }

        public static bool isDecimal(String s)
        {
            return Regex.IsMatch(s, @"^[0-9]{0,4}([.][0-9]{0,4})?$", RegexOptions.Compiled);
        }

        public static bool isCJKCharacters(String s)
        {
            Regex cjkCharRegex = new Regex(@"\p{IsCJKUnifiedIdeographs}");
            return s.All(c=>cjkCharRegex.IsMatch(c.ToString()));
        }

        public static bool isAlphaOnly(String s)
        {
            return Regex.IsMatch(s, @"^[a-zA-Z]*$", RegexOptions.Compiled);
        }

        public static bool isAlphaSpace(String s)
        {
            return Regex.IsMatch(s, @"^[a-zA-Z\s]*$", RegexOptions.Compiled);
        }

        public static bool isAlphaNumericOnly(String s)
        {
            return Regex.IsMatch(s, @"^[a-zA-Z0-9]*$", RegexOptions.Compiled);
        }

        public static bool isAlphaNumericCommonPunctuation(String s)
        {
            return Regex.IsMatch(s, @"^[a-zA-Z0-9\s,\.'\(\)&]*$", RegexOptions.Compiled);
        }

        public static bool isAlphaNumericParentheses(String s)
        {
            return Regex.IsMatch(s, @"^[a-zA-Z0-9\(\)]*$", RegexOptions.Compiled);
        }

        public static bool isAlphaNumericSpaceComma(String s)
        {
            return Regex.IsMatch(s, @"^[a-zA-Z0-9\s,]*$", RegexOptions.Compiled);
        }

        public static bool isphoneNoMax3Set(String s)
        {
            return Regex.IsMatch(s, @"^[0-9]{8}( ,[0-9]{8}){0,2}$", RegexOptions.Compiled);
        }

        public static bool isphoneNo(String s)
        {
            return Regex.IsMatch(s, @"^[0-9]{8}$", RegexOptions.Compiled);
        }

        public static bool isValidHKID(String s)
        {
            if (Regex.IsMatch(s, @"^([A-Z]){1,2}[0-9]{6}\([0-9A]\)$", RegexOptions.Compiled))
            {
                String id = s.Replace("(", "").Replace(")", "").ToUpper();
                int chksum = 0;
                if (id.Length == 8)
                {
                    chksum = 36 * 9;
                }
                for (int i = 0; i < id.Length - 1; i++)
                {
                    if (id[i] >= 'A' && id[i] <= 'Z')
                    {
                        chksum += (id[i] - 55) * (id.Length - i);
                    }
                    else
                    {
                        chksum += int.Parse(id.Substring(i, 1)) * (id.Length - i);
                    }
                }
                char chkdigit;
                switch (11 - (chksum % 11))
                {
                    case 11:
                        chkdigit = '0';
                        break;
                    case 10:
                        chkdigit = 'A';
                        break;
                    default:
                        chkdigit = (char)(11 - (chksum % 11) + 48);
                        break;
                }
                return (chkdigit == id[id.Length - 1]);
            }
            else
            {
                return false;
            }
        }
    }
}
