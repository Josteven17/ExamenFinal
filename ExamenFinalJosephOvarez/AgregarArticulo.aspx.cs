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
    public partial class AgregarArticulo : System.Web.UI.Page
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
                GuardarDatos();
                ClaseArticulos.AgregarArticulo();
                ConsultarTabla();
            }
            
        }

        public void GuardarDatos()
        {
            ClaseArticulos.SetDescripcion(TDescripcion.Text);
            ClaseArticulos.SetCodigoTipo(int.Parse(DTipoArticulo.SelectedValue));
            ClaseArticulos.SetPrecioArticulo(float.Parse(TPrecio.Text));
            ClaseArticulos.SetCostoArticulo(float.Parse(TCosto.Text));
            ClaseArticulos.setCantidad(int.Parse(TCantidad.Text));
        }
        protected void ConsultarTabla()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ExamenFinalConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("MostrarArticulos", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GAgregarArticulo.DataSource = dt;
            GAgregarArticulo.DataBind();
        }
        private Boolean VerificarEspacios()
        {
            int parsedValue;
            Boolean Verificador = false;
            if (String.IsNullOrEmpty(TDescripcion.Text) || String.IsNullOrEmpty(DTipoArticulo.Text) || String.IsNullOrEmpty(TPrecio.Text)
                || String.IsNullOrEmpty(TCosto.Text) || String.IsNullOrEmpty(TCantidad.Text) || !int.TryParse(TPrecio.Text, out parsedValue))

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