using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RestSharpNetCoreTemplate.Helpers
{
    public class DataBaseHelpers
    {
        private static SqlConnection GetDBConnection()
        {
            string connectionString = "Data Source=" + JsonBuilder.ReturnParameterAppSettings("DB_URL") + "," + JsonBuilder.ReturnParameterAppSettings("DB_PORT") + ";" +
                                      "Initial Catalog=" + JsonBuilder.ReturnParameterAppSettings("DB_NAME") + ";" +
                                      "User ID=" + JsonBuilder.ReturnParameterAppSettings("DB_USER") + "; " +
                                      "Password=" + JsonBuilder.ReturnParameterAppSettings("DB_PASSWORD") + ";";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public static MySqlConnection GetDBMYConnection()
        {
            string connectionString = "Data Source=" + JsonBuilder.ReturnParameterAppSettings("DB_URL") + "," + JsonBuilder.ReturnParameterAppSettings("DB_PORT") + ";" +
                                                  "Initial Catalog=" + JsonBuilder.ReturnParameterAppSettings("DB_NAME") + ";" +
                                                  "User ID=" + JsonBuilder.ReturnParameterAppSettings("DB_USER") + "; " +
                                                  "Password=" + JsonBuilder.ReturnParameterAppSettings("DB_PASSWORD") + ";";
            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }


        public static void ExecuteQuery(string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, GetDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(JsonBuilder.ReturnParameterAppSettings("DB_CONNECTION_TIMEOUT"));
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }


        public void ExecuteMyQuery(string query)
        {


            using (MySqlCommand cmd = new MySqlCommand(query, GetDBMYConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(JsonBuilder.ReturnParameterAppSettings("DB_CONNECTION_TIMEOUT"));
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }


        }

        public static List<string> RetornaDadosQuery(string query)
        {
            DataSet ds = new DataSet();
            List<string> lista = new List<string>();

            using (SqlCommand cmd = new SqlCommand(query, GetDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(JsonBuilder.ReturnParameterAppSettings("DB_CONNECTION_TIMEOUT"));
                cmd.Connection.Open();

                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);

                cmd.Connection.Close();
            }

            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        lista.Add(ds.Tables[0].Rows[i][j].ToString());
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return lista;
        }


        public static List<string> RetornaDadosMyQuery(string query)
        {
            DataSet ds = new DataSet();
            List<string> lista = new List<string>();

            using (MySqlCommand cmd = new MySqlCommand(query, GetDBMYConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(JsonBuilder.ReturnParameterAppSettings("DB_CONNECTION_TIMEOUT"));
                cmd.Connection.Open();

                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);

                cmd.Connection.Close();
            }

            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        lista.Add(ds.Tables[0].Rows[i][j].ToString());
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return lista;
        }

    }
}
