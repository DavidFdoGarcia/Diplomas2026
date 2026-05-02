using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GenerarDiplomas.Clases
{
    internal class consultas
    {
        public static DataTable Consultar(string query, Dictionary<string, object> parametros = null)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, cn);

                if (parametros != null)
                {
                    foreach (var p in parametros)
                    {
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public static int Ejecutar(string query, Dictionary<string, object> parametros)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, cn);

                foreach (var p in parametros)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                return cmd.ExecuteNonQuery();
            }
        }

        public static object EjecutarEscalar(string query, Dictionary<string, object> parametros)
        {
            using (SqlConnection con = Conexion.Conectar()) // 👈 AQUÍ EL CAMBIO
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    foreach (var p in parametros)
                    {
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }
    }
    class Operador
    {
        public static DataTable ObtenerOperadores()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = Conexion.Conectar())
                {
                    // Consulta para traer id y nombre completo concatenado
                    string query = @"SELECT *
                                     FROM vw_Operadores
                                     ORDER BY NombreOperador asc";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar operadores: " + ex.Message);
            }

            return dt;
        }

        public static DataTable ObtenerCamiones()
        {
            DataTable dt2 = new DataTable();

            try
            {
                using (SqlConnection conn = Conexion.Conectar())
                {
                    // Consulta para traer id y nombre completo concatenado
                    string query = @"select * from camion order by  tipocamion asc";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el camion: " + ex.Message);
            }

            return dt2;
        }
    }
}

