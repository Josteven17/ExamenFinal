using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace ExamenFinalJosephOvarez
{
    public class ClaseUsuario
    {

        private static String Nombre;
        private static string NombreUsuario;
        private static String Contra;
        private static String Clave;
        private static int TipoUsuario;
        private static int Id;

        public ClaseUsuario() {
            Nombre = "";
            NombreUsuario = "";
            Contra = "";
            Clave = "";
            TipoUsuario = 0;
            Id = 0;
        }
        public static void SetNombre(String nombre)
        {

            Nombre = nombre;
        }
        public static String GetNombre()
        {
            return Nombre;
        }
        public static void SetNombreUsuario(String nombre)
        {

            NombreUsuario = nombre;
        }
        public static String GetNombreUsuario()
        {
            return NombreUsuario;
        }
        public static void SetContra(String contra)
        {

            Contra = contra;
        }
        public static String GetContra()
        {
            return Contra;
        }
        public static void SetClave(String clave)
        {
            Clave = clave;

        }

        public static String GetClave() { return Clave; }

        public static void SetTipoUsuario(int tipo) {
            TipoUsuario = tipo;
        }
        public static int GetTipoUsuario() { return TipoUsuario; }
        public static void SetId(int id)
        {
            Id = id;
        }
        public static int GetTId() { return Id; }
        public static void Registrarse()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("Registro", con);
            command.Parameters.Add(new SqlParameter("@nombreusuario", Nombre));
            command.Parameters.Add(new SqlParameter("@claveusuario", Clave));
            command.Parameters.Add(new SqlParameter("@tipousuario", TipoUsuario));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }

        public static void AgregarUsuario()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("AgregarUsuario", con);
            command.Parameters.Add(new SqlParameter("@nombre", NombreUsuario));
            command.Parameters.Add(new SqlParameter("@clave", Contra));
            command.Parameters.Add(new SqlParameter("@tipousuario", TipoUsuario));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }

        public static Boolean BorrarUsuario()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("BorrarUsuario", con);
                command.Parameters.Add(new SqlParameter("@codigo", TipoUsuario));
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
        public static void ActualizarUsuario()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("ActualizarUsuario", con);
            command.Parameters.Add(new SqlParameter("@codigo", Id));
            command.Parameters.Add(new SqlParameter("@nombre", NombreUsuario));
            command.Parameters.Add(new SqlParameter("@clave", Contra));
            command.Parameters.Add(new SqlParameter("@tipousuario", TipoUsuario));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }

    }

}