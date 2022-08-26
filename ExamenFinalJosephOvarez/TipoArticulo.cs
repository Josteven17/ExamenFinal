using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;

namespace ExamenFinalJosephOvarez
{
    public class TipoArticulo
    {

        private static String Descripcion;
        private static int Codigo;

        public TipoArticulo()
        {
            Descripcion = "";
            Codigo = 0;

        }

        public static void setDescripcion(String descripcion) { Descripcion = descripcion; }
        public static String getDescripcion() { return Descripcion; }
        public static void setCodigo(int codigo) { Codigo = codigo; }   
        public static int getCodigo() { return Codigo;  }

        public static void AgregarTipoArticulo()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("AgregarTipoArticulo", con);
            command.Parameters.Add(new SqlParameter("@descripcion", Descripcion));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }

        public static Boolean BorrarTipoArticulo()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("BorrarTipoArticulo", con);
                command.Parameters.Add(new SqlParameter("@codigo", Codigo));
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                existe = true;
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return existe;
        }
        public static void ActualizarTipoArticulo()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("ActualizarTipoArticulo", con);
            command.Parameters.Add(new SqlParameter("@codigo", Codigo));
            command.Parameters.Add(new SqlParameter("@descripcion", Descripcion));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }
    }
}