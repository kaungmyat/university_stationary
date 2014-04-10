<%@ Page Title="" Language="C#" MasterPageFile="~/ClerkMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateStock.aspx.cs" Inherits="Logic_University_Form.Clerk.UpdateStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="UpdateStocklb" runat="server" Text="Update Stock"></asp:Label>
    <br />
    <asp:DropDownList ID="DropDownListUS" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownListUS_SelectedIndexChanged" 
        DataSourceID="EntityDataSourceITEMCODE" DataTextField="Item_Code" 
        DataValueField="Item_Code">
    </asp:DropDownList>
    <asp:EntityDataSource ID="EntityDataSourceITEMCODE" runat="server" 
        ConnectionString="name=LOGIC_UniversityEntities" 
        DefaultContainerName="LOGIC_UniversityEntities" EnableFlattening="False" 
        EntitySetName="Stationary_Catalogue" Select="it.[Item_Code]">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceStockCard" runat="server" 
        ConnectionString="name=LOGIC_UniversityEntities2" 
        DefaultContainerName="LOGIC_UniversityEntities2" EnableFlattening="False" 
        EntitySetName="Stationary_Catalogue" Select="it.[Item_Code]">
    </asp:EntityDataSource>
    <asp:GridView ID="GridView1" runat="server" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" AllowPaging="True" 
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4">
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Stock Details"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" BackColor="White" 
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    </form>
</asp:Content>
