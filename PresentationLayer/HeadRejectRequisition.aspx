<%@ Page Title="" Language="C#" MasterPageFile="~/HeadMasterPage.Master" AutoEventWireup="true" CodeBehind="HeadRejectRequisition.aspx.cs" Inherits="Logic_University_Stationary.HeadRejectRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="lblPageHeader" runat="server" Text="Label"></asp:Label></br>
    <asp:GridView ID="gvRejectedRequest" runat="server" BackColor="White" 
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
    </asp:GridView></br>
    <asp:TextBox ID="txtReasone" runat="server" TextMode="MultiLine" 
        ontextchanged="txtReasone_TextChanged"></asp:TextBox> 
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtReasone" 
        ErrorMessage="Please Enter the Rejection Comment"></asp:RequiredFieldValidator>
    </br>
    <asp:Button ID="btnOk" runat="server" class="btn-primary" Text="OK" onclick="btnOk_Click"  Width="100px" height="28px" />
    </form>
</asp:Content>
