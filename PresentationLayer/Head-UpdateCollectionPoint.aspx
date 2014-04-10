<%@ Page Title="" Language="C#" MasterPageFile="~/HeadMasterPage.Master" AutoEventWireup="true" CodeBehind="Head-UpdateCollectionPoint.aspx.cs" Inherits="Logic_University_Stationary.Head_UpdateCollectionPoint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <center><h6><asp:Label ID="lblTitle" runat="server" Text="Department Representative"></asp:Label></h6></center>
    <br /><b>
    <asp:Label ID="lblSmallTitle" runat="server" Text="Update Collection point"></asp:Label></b>
    <br />
    <br />
    <table>
        <tr>
            <td style="height: 30px">Collection Point:</td>
            <td style="height: 30px; width: 94px;">
                <asp:DropDownList ID="ddlColPoint" runat="server">
                      <asp:ListItem>Point-1</asp:ListItem>
                        <asp:ListItem>Point-2</asp:ListItem>
                        <asp:ListItem>Point-3</asp:ListItem>
                        <asp:ListItem>Point-4</asp:ListItem>
                        <asp:ListItem>Point-5</asp:ListItem>
                        <asp:ListItem>Point-6</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td  style="height: 30px">&nbsp;</td>
            <td style="width: 74px">
                &nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td style="width: 94px">
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click1" class="btn-primary"  Width="100px" height="28px"/></td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn-primary"  Width="100px" height="28px" /></td>
        </tr>
    </table>
    </form>
</asp:Content>

