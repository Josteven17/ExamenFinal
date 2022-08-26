<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="ExamenFinalJosephOvarez.Registrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrarse</title>
    <link rel="stylesheet" type="text/css" href="css/EstiloMenu.css" />
    <link rel="stylesheet" type="text/css" href="css/MenuDropDown.css" />
    <link rel="stylesheet" href="css/LoginEstilo.css"/>
    
</head>
<body>
     <form id="form1" runat="server">
        <h2>Complete el formulario para registrase</h2>

        <div>

            <hr />

            <label for="email"><b>Nombre</b></label>
            <asp:TextBox ID="TNombre" type="text" placeholder="Nombre" runat="server"></asp:TextBox>
            <label for="psw"><b>Clave</b></label>
            <asp:TextBox ID="TClave" type="text" placeholder="Clave" runat="server"></asp:TextBox>
            <div>
                <label for="email"><b>Tipo Usuario</b></label>
                <asp:DropDownList ID="DTipoUsuario" runat="server" DataSourceID="SqlTipoUsuario" DataTextField="DescripcionTipoUsuario" DataValueField="CodigoTipoUsuario"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlTipoUsuario" runat="server" ConnectionString="<%$ ConnectionStrings:ExamenFinalConnectionString %>" SelectCommand="SELECT [CodigoTipoUsuario], [DescripcionTipoUsuario] FROM [TiposUsuario]"></asp:SqlDataSource>
            </div>
        </div>

    <div>
        <asp:Button ID="BRegistrarse" type="submit" class="btn btn-primary rounded submit" runat="server" Text="Registrase" OnClick="BRegistrarse_Click" />

    </div>
        
    </form>
</body>
</html>
