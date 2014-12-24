using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient; 

namespace CMCMS
{
    class DBMgr
    {
        public String testReadData(String SQL)
        {
            String data = "11111";
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(CMCMS.Properties.Resources.connectionString);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                data = Convert.ToString(cmd.ExecuteScalar());
                return data;
            }
            catch (MySqlException ex)
            {
                data = "OTZ";
                return data;

            }
            finally
            {

                if (conn != null)
                {
                    conn.Close();
                }

            }
        }
    }
}
