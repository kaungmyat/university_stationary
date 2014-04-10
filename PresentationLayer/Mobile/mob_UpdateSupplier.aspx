<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_Clerk.Master" AutoEventWireup="true" CodeBehind="mob_UpdateSupplier.aspx.cs" Inherits="Logic_University_Stationary.Mobile.mob_UpdateSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1><center><asp:Label ID="Label8" runat="server" Text="Update Existing Supplier Information"></asp:Label></center></h1>
    <form id="frm_updateSup" runat="server">
        <asp:Label ID="lblSupplier" runat="server" Text="Find Existing Supplier"></asp:Label>
    
    <asp:DropDownList ID="ddlSup" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlSup_SelectedIndexChanged" >

    </asp:DropDownList>

    <div>
        
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
    <asp:Button ID="btnUpdate" runat="server" Text="Update Supplier" data-theme="b" onclick="btnUpdate_Click" 
         />
    </form>


</asp:Content>
