<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ActualizarUsuario.aspx.cs" Inherits="ExamenFinalJosephOvarez.ActualizarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Actualizar Usuario</h2>

    <div>

        <asp:GridView ID="GActualizarUsuario" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
    <div>
        <label for="email"><b>Usuario</b></label>
        <asp:DropDownList ID="DActualizarUsuario" runat="server" DataSourceID="SqlDataSource1" DataTextField="NombreUsuario" DataValueField="CodigoUsuario"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ExamenFinalConnectionString %>" SelectCommand="SELECT [CodigoUsuario], [NombreUsuario] FROM [Usuarios]"></asp:SqlDataSource>
    </div>
    <div>
        <h3>Actualice los sigueintes datos</h3>
        <label for="email"><b>Nombre</b></label>
        <asp:TextBox ID="TNombre" type="text" placeholder="Nombre" runat="server"></asp:TextBox>
        <label for="psw"><b>Clave</b></label>
        <asp:TextBox ID="TClave" type="text" placeholder="Clave" runat="server"></asp:TextBox>
    </div>
    <div>
                <label for="email"><b>Tipo Usuario</b></label>
        <asp:DropDownList ID="DTipoUsuario" runat="server" DataSourceID="SqlDataSource2" DataTextField="DescripcionTipoUsuario" DataValueField="CodigoTipoUsuario"></asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ExamenFinalConnectionString %>" SelectCommand="SELECT [CodigoTipoUsuario], [DescripcionTipoUsuario] FROM [TiposUsuario]"></asp:SqlDataSource>

    </div>
    <div>
        <asp:Button ID="BActualizar" type="submit" class="btn btn-primary rounded submit" runat="server" Text="Actualizar" OnClick="BActualizar_Click" />
        <asp:Button ID="BRegresar"  class="btn btn-primary rounded submit" runat="server" Text="Regresar" OnClick="BRegresar_Click" />
    </div>
</asp:Content>
