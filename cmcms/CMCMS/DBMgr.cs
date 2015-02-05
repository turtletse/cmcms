using System;
using System.Data;
using System.Data.Odbc;
using MySql.Data.MySqlClient; 
using System.Collections.Generic;

namespace CMCMS
{
    class DBMgr
    {
        MySqlConnection conn = null;
        //OdbcConnection conn = null;

        public DataTable execSelectStmtSP(String SQL)
        {
            DataTable data = new DataTable();
            try
            {
                conn = new MySqlConnection(CMCMS.Properties.Resources.server + CMCMS.Properties.Resources.connectionString);
                MySqlDataAdapter adr = new MySqlDataAdapter(SQL, conn);
                /*conn = new OdbcConnection(CMCMS.Properties.Resources.connectionString);
                OdbcDataAdapter adr = new OdbcDataAdapter(SQL, conn);*/
                adr.SelectCommand.CommandType = CommandType.Text;
                adr.Fill(data);
                return data;
            }
            catch (OdbcException)
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

        public DataTable execSelectStmtSP(String SQL, params MySqlParameter[] parm)
        {
            DataTable data = new DataTable();
            try
            {
                conn = new MySqlConnection(CMCMS.Properties.Resources.server + CMCMS.Properties.Resources.connectionString);
                MySqlDataAdapter adr = new MySqlDataAdapter(SQL, conn);
                /*conn = new OdbcConnection(CMCMS.Properties.Resources.connectionString);
                OdbcDataAdapter adr = new OdbcDataAdapter(SQL, conn);*/
                adr.SelectCommand.CommandType = CommandType.Text;
                adr.Fill(data);
                return data;
            }
            catch (OdbcException)
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
