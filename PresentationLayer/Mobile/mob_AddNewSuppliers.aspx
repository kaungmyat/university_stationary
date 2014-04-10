<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_Clerk.Master" AutoEventWireup="true" CodeBehind="mob_AddNewSuppliers.aspx.cs" Inherits="Logic_University_Stationary.Mobile.mob_AddNewSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
   <h1><center><asp:Label ID="Label8" runat="server" Text="Add New Supplier"></asp:Label></center></h1>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Supplier ID"></asp:Label>
        <asp:TextBox ID="txtSupId" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Supplier Name"></asp:Label>
        <asp:TextBox ID="txtSupName" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label3" runat="server" Text="Contact Name"></asp:Label>
        <asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Phone No"></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label5" runat="server" Text="FaxNo"></asp:Label>
        <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="btnAdd" runat="server" Text="Add New Supplier" data-theme="b" 
        onclick="btnAdd_Click" />
    </form>

</asp:Content>
