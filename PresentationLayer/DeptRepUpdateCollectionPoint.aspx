<%@ Page Title="" Language="C#" MasterPageFile="~/RepresentativeMasterPage.Master" AutoEventWireup="true" CodeBehind="DeptRepUpdateCollectionPoint.aspx.cs" Inherits="Logic_University_Stationary.DeptRep.DeptRepUpdateCollectionPoint" %>
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
            <td style="height: 30px; width: 116px;">
                <asp:DropDownList ID="ddlColPoint" runat="server" Height="30px" Width="68px">
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
            <td style="width: 116px">
                &nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td style="width: 116px">
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click1" class="btn-primary" Width="100px" Height="28px" /></td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn-primary" Width="100px" Height="28px"/></td>
        </tr>
    </table>

    <br /><br />
    <asp:label ID="lblstatus" runat="server"></asp:label>
    </form>
</asp:Content>

