using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient; 
using System.Data;

namespace CMCMS
{
    class DBMgr
    {
        MySqlConnection conn = null;

        public String testReadData(String SQL)
        {
            String data = "11111";

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

        public DataTable execSelectStmtSP(String SQL)
        {
            DataTable data = new DataTable();
            try
            {
                conn = new MySqlConnection(CMCMS.Properties.Resources.connectionString);
                MySqlDataAdapter adr = new MySqlDataAdapter(SQL, conn);
                adr.SelectCommand.CommandType = CommandType.Text;
                adr.Fill(data);
                return data;
            }
            catch (MySqlException ex)
            {
                //return data;
                return null;
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
