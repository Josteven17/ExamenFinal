using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinalJosephOvarez
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BRegistrarse_Click(object sender, EventArgs e)
        {
            GuardarDatos();
            ClaseUsuario.Registrarse();
            Response.Redirect("Login.aspx");
        }

        public void GuardarDatos()
        {
            ClaseUsuario.SetNombre(TNombre.Text);
            ClaseUsuario.SetClave(TClave.Text);
            ClaseUsuario.SetTipoUsuario(int.Parse(DTipoUsuario.SelectedValue));

        }
    }
}