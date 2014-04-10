<%@ Page Title="" Language="C#" MasterPageFile="~/ClerkMasterPage.Master" AutoEventWireup="true" CodeBehind="AddUpdateStock.aspx.cs" Inherits="PresentationLayer.AddUpdateStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="for1" runat="server">
         <center><h5>Update Stock form </h5></center>
         <table>
            <tr>
                <td>Item Code:</td>
                <td><asp:DropDownList ID="ddlItemCode" runat="server"></asp:DropDownList></td>
                <td></td>
                <td>Supplier ID:</td>
                <td><asp:DropDownList ID="ddlSupID" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Store ID :</td>
                <td><asp:TextBox ID="txtStoreID" runat="server" ReadOnly="true" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>Emp ID :</td>
                <td><asp:TextBox ID="txtempId" runat="server" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Qty :</td>
                <td><asp:TextBox ID="txtqty" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button id="btnSave" runat="server" Text="Save" class="btn-primary" Width="100px" Height="28px" /></td>
                <td><asp:Button id="btnCancel" runat="server" Text="Cancel" class="btn-primary" Width="100px" Height="28px"/></td>
            </tr>
         </table>
    </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
</asp:Content>
