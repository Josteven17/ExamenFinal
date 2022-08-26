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
    public partial class AgregarTipoArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultarTabla();
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {
            if (VerificarEspacios())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Verifique la informacion, intente nuevamente');", true);
            }
            else
            {
                TipoArticulo.setDescripcion(TDescripcion.Text);
                TipoArticulo.AgregarTipoArticulo();
                ConsultarTabla();
            }
            
        }

        protected void ConsultarTabla()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("MostrarTipoArticulo", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GTipoArticulo.DataSource = dt;
            GTipoArticulo.DataBind();
        }
        private Boolean VerificarEspacios()
        {
            Boolean Verificador = false;
            if (String.IsNullOrEmpty(TDescripcion.Text))

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