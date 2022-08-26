<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Catalogos.aspx.cs" Inherits="ExamenFinalJosephOvarez.Catalogos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Catalogos</h2>
    <div class="dropdown">
        <button class="dropbtn">Catalogo de articulos</button>
        <div class="dropdown-content">
            <a href="AgregarArticulo.aspx">Agregar Articulo</a>
            <a href="BorrarArticulo.aspx">Borrar Articulo</a>
            <a href="ActualizarArticulo.aspx">Actualizar Articulo</a>
        </div>
    </div>

    <div class="dropdown">
        <button class="dropbtn">Catalogo Usuarios</button>
        <div class="dropdown-content">
            <a href="AgregarUsuario.aspx">Agregar Usuario</a>
            <a href="BorrarUsuario.aspx">Borrar Usuario</a>
            <a href="ActualizarUsuario.aspx">Actualizar Usuario</a>
        </div>
    </div>

    <div class="dropdown">
        <button class="dropbtn">Catalogo Tipos Articulos</button>
        <div class="dropdown-content">
            <a href="AgregarTipoArticulo.aspx">Agregar Tipo De Articulo</a>
            <a href="BorrarTipoArticulo.aspx">Borrar Tipo De Articulo</a>
            <a href="ActualizarTipoArticulo.aspx">Actualizar Tipo De Articulo</a>
        </div>
    </div>

</asp:Content>
