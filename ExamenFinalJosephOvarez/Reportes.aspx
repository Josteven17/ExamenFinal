<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ExamenFinalJosephOvarez.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Reportes</h2>
    <div>
        <asp:GridView ID="GReporteArticulos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
     <div class="dropdown">
        <button class="dropbtn">Seleccione Reporte</button>
        <div class="dropdown-content">
            
            <asp:Button ID="BCosto" type="submit" class="btn btn-primary rounded submit" runat="server" Text="Costo Inventario" OnClick="BCosto_Click" /> 
            <asp:Button ID="BGanancias" type="submit" class="btn btn-primary rounded submit" runat="server" Text="Proyeccion Ganancias" OnClick="BGanancias_Click"/>
            <asp:Button ID="BBitacora" type="submit" class="btn btn-primary rounded submit" runat="server" Text="Mostrar Bitacora" OnClick="BBitacora_Click"/>
        </div>
    </div>
  
</asp:Content>
