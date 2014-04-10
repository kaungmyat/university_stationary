<%@ Page Title="" Language="C#" MasterPageFile="ClerkMasterPage.Master" AutoEventWireup="true" CodeBehind="DisbusementListAllDepartment.aspx.cs" Inherits="Logic_University_Stationary.Clerk.DistrubsementListAllDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" >
    <center><h5>Disbursement List for All Departments</h5></center>
    <br />
    <b>Consolidated Disbursement list at </b>
    <asp:Label ID="lblDate" runat="server"></asp:Label>
    &nbsp;<br />
    <br />
    <asp:GridView ID="disburseListGridView" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" onrowcommand="disburseListGridView_RowCommand" 
        AutoGenerateSelectButton="True" 
        onselectedindexchanged="disburseListGridView_SelectedIndexChanged">
    <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField></asp:TemplateField>
        </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
    
</asp:GridView>
</form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
</asp:Content>