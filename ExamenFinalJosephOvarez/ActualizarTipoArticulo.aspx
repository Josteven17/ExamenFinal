<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ActualizarTipoArticulo.aspx.cs" Inherits="ExamenFinalJosephOvarez.ActualizarTipoArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Actualizar Tipo Articulo</h2>

    <div>
        <asp:GridView ID="GActualizarTipoArticulo" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        <label for="email"><b>Tipo Articulo</b></label>
        <asp:DropDownList ID="DTipoArticulo" runat="server" DataSourceID="SqlDataSource1" DataTextField="DescripcionTipo" DataValueField="CodigoTipo"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ExamenFinalConnectionString %>" SelectCommand="SELECT [CodigoTipo], [DescripcionTipo] FROM [TipoArticulo]"></asp:SqlDataSource>
    </div>
    <h3>Actualice la informacion</h3>
    <label for="email"><b>Descripcion</b></label>
    <asp:TextBox ID="TDescripcion" type="text" placeholder="Descripcion" runat="server"></asp:TextBox>
    <div>
        <asp:Button ID="BActualizar" type="submit" class="btn btn-primary rounded submit" runat="server" Text="Actualizar" OnClick="BActualizar_Click" />
        <asp:Button ID="BRegresar" class="btn btn-primary rounded submit" runat="server" Text="Regresar" OnClick="BRegresar_Click" />

    </div>
</asp:Content>
