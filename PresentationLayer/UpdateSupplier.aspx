<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerMaster.Master" AutoEventWireup="true" CodeBehind="UpdateSupplier.aspx.cs" Inherits="Logic_University_Stationary.UpdateSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <form id="form1" runat="server">
        <center><h5>Department Head</h5></center>
        <b><asp:Label runat="server" ID="lblTitle"><b>Update Supplier Information</b></asp:Label></b>
        <br /><br />
        
        <table style="width: 98%">
            <tr>
                <td class="span3" style="width: 130px">
                    <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
                </td>
                <td style="width: 303px">
                    <asp:DropDownList ID="ddlSupplier" runat="server" AutoPostBack="true"
                        onselectedindexchanged="ddlSupplier_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="span3" style="width: 130px">
                    <asp:Label ID="lblName" runat="server" Text="Supplier Name"></asp:Label>
                </td>
                <td style="width: 303px">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="span3" style="width: 130px">
                    <asp:Label ID="Label1" runat="server" Text="Contact Name"></asp:Label>
                </td>
                <td style="width: 303px">
                    <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="span3" style="width: 130px; height: 33px">
                    <asp:Label ID="lblPhone" runat="server" Text="Phone Number"></asp:Label>
                </td>
                <td style="height: 33px; width: 303px;">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="span3" style="width: 130px">
                    <asp:Label ID="lblFax" runat="server" Text="Fax Number"></asp:Label>
                </td>
                <td style="width: 303px">
                    <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="span3" style="width: 130px">
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
                <td style="width: 303px">
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="span3" style="width: 130px">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </td>
                <td style="width: 303px">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
         <div style="margin-left: 200px">
             <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click"  Width="100px" height="28px"
          class="btn-primary" Text="Update" onclientclick="javascript:alert('Data Updated Sucessfully');"/>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="btnCancel" runat="server" Text="Cancel"  Width="100px" height="28px" 
        class="btn-primary" onclick="btnCancel_Click" />  </div>
        </form>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
</asp:Content>
