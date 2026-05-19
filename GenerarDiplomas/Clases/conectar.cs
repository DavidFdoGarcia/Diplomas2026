using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static GenerarDiplomas.Clases.ini;

namespace GenerarDiplomas.Clases
{
        class Conexion
        {
            public static SqlConnection Conectar()
            {
                string ruta = @"C:\SistemaDiplomas\config.ini";

                Ini ini = new Ini(ruta);

                string server = ini.Leer("database", "server");
                string database = ini.Leer("database", "database");
                string user = ini.Leer("database", "user");
                string password = ini.Leer("database", "password");

                string cadena = $"Server={server};Database={database};Integrated Security=True;TrustServerCertificate=True;";


                SqlConnection cn = new SqlConnection(cadena);

                cn.Open();

                return cn;
            }
        }
    
}
