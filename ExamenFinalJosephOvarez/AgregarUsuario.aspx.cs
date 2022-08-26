using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinalJosephOvarez
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultarTabla();
        }

        protected void BAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (VerificarEspacios())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Verifique la informacion, intente nuevamente');", true);
            }
            else
            {
                GuardarDatos();
                ClaseUsuario.AgregarUsuario();
                ConsultarTabla();
            }
            
        }

        public void GuardarDatos()
        {
           
                ClaseUsuario.SetNombreUsuario(TNombre.Text);
                ClaseUsuario.SetContra(TClave.Text);
                ClaseUsuario.SetTipoUsuario(int.Parse(DUsuario.SelectedValue));
            
            
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
            GUsuario.DataSource = dt;
            GUsuario.DataBind();
        }
        private Boolean VerificarEspacios()
        {
            Boolean Verificador = false;
            if (String.IsNullOrEmpty(TNombre.Text) || String.IsNullOrEmpty(DUsuario.Text) || String.IsNullOrEmpty(TClave.Text))

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