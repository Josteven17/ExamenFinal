<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="BorrarTipoArticulo.aspx.cs" Inherits="ExamenFinalJosephOvarez.BorrarTipoArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Borrar Tipo Articulo</h2>

    <div>
        <asp:GridView ID="GBorrarTipoArticulo" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        <asp:DropDownList ID="DBorrarTipoArticulo" runat="server" DataSourceID="SqlDataSource1" DataTextField="DescripcionTipo" DataValueField="CodigoTipo"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ExamenFinalConnectionString %>" SelectCommand="SELECT [CodigoTipo], [DescripcionTipo] FROM [TipoArticulo]"></asp:SqlDataSource>
    </div>
    <div>
        <asp:Button ID="BBorrar" type="submit" class="btn btn-primary rounded submit" runat="server" Text="Borrar" OnClick="BBorrar_Click" />
        <asp:Button ID="BRegresar" class="btn btn-primary rounded submit" runat="server" Text="Regresar" OnClick="BRegresar_Click" />
    </div>
</asp:Content>
