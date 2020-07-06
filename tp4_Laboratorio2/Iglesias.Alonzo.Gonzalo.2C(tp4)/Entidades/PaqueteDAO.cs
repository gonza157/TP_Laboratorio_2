using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        public static bool Insertar(Paquete p)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source = DESKTOP-CCO3RRS\SQLEXPRESS; Database = correo-sp-2017; Trusted_Connection = true;"))
                {

                    string comando = String.Format("INSERT INTO Paquetes(direccionEntrega,trackingID,alumno)VALUES (@direccionEntrega,@trackingID,'Gonzalo Iglesias Alonzo')");
                    SqlCommand command = new SqlCommand(comando, connection);

                    command.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
                    command.Parameters.AddWithValue("@trackingID", p.TrackingID);
                    connection.Open(); //abre la conexcion con la BD
                    command.ExecuteNonQuery();//ejecuta
                }
            }
            catch (Exception e)
            {
                throw new Exception("no se pudo insertar en la base", e );
            }


            return true;
        }

        static PaqueteDAO()
        {
            //cambiar el Source
            try
            {
                conexion = new SqlConnection(@"Data Source = DESKTOP-CCO3RRS\SQLEXPRESS; Database = correo-sp-2017; Trusted_Connection = true;");
                comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;

            }
            catch (Exception e)
            {
                throw new Exception("crear la coneccion", e);
            }
        }
    }
}
