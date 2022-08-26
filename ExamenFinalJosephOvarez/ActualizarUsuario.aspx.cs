using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinalJosephOvarez
{
    public partial class ActualizarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultarTabla();
        }

        protected void BActualizar_Click(object sender, EventArgs e)
        {
            if (VerificarEspacios())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Verifique la informacion, intente nuevamente');", true);
            }
            else
            {
                GuardarDatos();
                ClaseUsuario.ActualizarUsuario();
                ConsultarTabla();
            }
            
            
        }

        public void GuardarDatos()
        {
            ClaseUsuario.SetId(int.Parse(DActualizarUsuario.SelectedValue));
            ClaseUsuario.SetNombreUsuario(TNombre.Text);
            ClaseUsuario.SetContra(TClave.Text);
            ClaseUsuario.SetTipoUsuario(int.Parse(DTipoUsuario.SelectedValue));

        }

        protected void ConsultarTabla()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("MostrarUsuarios", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GActualizarUsuario.DataSource = dt;
            GActualizarUsuario.DataBind();
        }
        private Boolean VerificarEspacios()
        {
            Boolean Verificador = false;
            if (String.IsNullOrEmpty(DActualizarUsuario.Text) || String.IsNullOrEmpty(TNombre.Text) || String.IsNullOrEmpty(TClave.Text)
                || String.IsNullOrEmpty(DTipoUsuario.Text));
            {
                Verificador = true;

            }
            return Verificador;
        }

        protected void BRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogos.aspx");
        }
    }

}