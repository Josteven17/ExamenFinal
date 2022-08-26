using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinalJosephOvarez
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BIniciar_Click(object sender, EventArgs e)
        {
            ClaseUsuario.SetNombre(Tnombre.Text);
            ClaseUsuario.SetClave(TClave.Text);
            Registrarse();
        }

        public void Registrarse()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("Inicio", con);
                command.Parameters.Add(new SqlParameter("@nombre", ClaseUsuario.GetNombre()));
                command.Parameters.Add(new SqlParameter("@clave", ClaseUsuario.GetClave()));
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader registro = command.ExecuteReader();
                if (registro.Read())
                {
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Usuario no existe');", true);
                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Revisar la conexion');", true);
            }
            finally
            {
                con.Close();
            }
           
            }

        
    }
}