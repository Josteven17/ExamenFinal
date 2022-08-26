using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ExamenFinalJosephOvarez
{
    public class ClaseArticulos
    {
        private static String Descripcion;
        private static int CodigoTipo;
        private static int Cantidad;
        private static int CodigoArticulo;
        private static float PrecioArticulo;
        private static float CostoArticulo;

        public ClaseArticulos()
        {

            Descripcion = "";
            CodigoTipo = 0;
            Cantidad = 0;
            CodigoArticulo = 0;
            PrecioArticulo = 0;
            CostoArticulo = 0;
        }

        public static void SetDescripcion(String descripcion) { Descripcion = descripcion; }
        public static String GetDescripcion() { return Descripcion; }   
        public static void SetCodigoTipo(int codigo) { CodigoTipo = codigo; }    
        public static int GetCodigoTipo() { return CodigoTipo; }
        public static void SetCodigoArticulo(int codigo) { CodigoArticulo = codigo; }
        public static int GetCodigoArticulo() { return CodigoArticulo; }
        public static void setCantidad(int cantidad) { Cantidad = cantidad; }
        public static int GetCantidad() { return Cantidad; }
        public static void SetPrecioArticulo(float precioArticulo) { PrecioArticulo = precioArticulo; }

        public static float GetPrecioArticulo() { return PrecioArticulo; }  

        public static void SetCostoArticulo(float costoArticulo) { CostoArticulo = costoArticulo; }
        public static float GetCostoArticulo() { return CostoArticulo; }

        public static void AgregarArticulo()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("AgregarArticulo", con);
            command.Parameters.Add(new SqlParameter("@descripcion", Descripcion));
            command.Parameters.Add(new SqlParameter("@codigotipo", CodigoTipo));
            command.Parameters.Add(new SqlParameter("@precioarticulo", PrecioArticulo));
            command.Parameters.Add(new SqlParameter("@costoarticulo", CostoArticulo));
            command.Parameters.Add(new SqlParameter("@cantidad", Cantidad));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }
        public static Boolean BorrarArticulo()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("BorrarArticulo", con);
                command.Parameters.Add(new SqlParameter("@codigo", CodigoArticulo));
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
        public static void ActualizarArticulo()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("ActualizarArticulo", con);
            command.Parameters.Add(new SqlParameter("@codigo", CodigoArticulo));
            command.Parameters.Add(new SqlParameter("@descripcion", Descripcion));
            command.Parameters.Add(new SqlParameter("@codigotipo", CodigoTipo));
            command.Parameters.Add(new SqlParameter("@precioarticulo", PrecioArticulo));
            command.Parameters.Add(new SqlParameter("@costoarticulo", CostoArticulo));
            command.Parameters.Add(new SqlParameter("@cantidad", Cantidad));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }
    }

}