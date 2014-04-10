<%@ Page Title="" Language="C#" MasterPageFile="~/HeadMasterPage.Master" AutoEventWireup="true" CodeBehind="RequisitionDetail.aspx.cs" Inherits="Logic_University_Stationary.Head.RequisitionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <center><h5>Department Head</h5></center>
        <b><asp:Label runat="server" ID="lblTitle"><b>Requisition Detail Form</b></asp:Label></b>
        <br />
        <br />
        <table>
            <tr>
                <td>Requistion Form No :</td>
                <td>
                    <asp:Label ID="lblReqNo" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>Employee Name :</td>
                <td>
                    <asp:Label ID="lblEmpno" runat="server" ></asp:Label></td>
            </tr>
        </table>
    <asp:GridView ID="gvRequisitionDetails" runat="server" AllowPaging="True" 
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
    <asp:Button ID="btnOk" runat="server" Text="OK" class="btn-primary"  Width="100px" height="28px"
            onclick="btnOk_Click" />
    </form>
</asp:Content>