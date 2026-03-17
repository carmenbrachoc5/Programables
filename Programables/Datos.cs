using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.Logging;
using MySqlConnector;
namespace Programables
{
    internal class Datos
    {
        string cadenaConexion= "Server=localhost;Database=programables;Uid=luis;Pwd=joseluis;";

        private MySqlConnection Conexion()
        {
            try {
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool ejecutar(string consulta)
        {
            try {
                MySqlCommand cmd = new MySqlCommand(consulta, Conexion());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
