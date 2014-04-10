<%@ Page Title="" Language="C#" MasterPageFile="~/ClerkMasterPage.Master" AutoEventWireup="true" CodeBehind="DisbursementListDetail.aspx.cs" Inherits="PL.Clerk.DisbursementListDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server" >
    <center><h5>Disbursement list Details</h5></center>
    <strong>Dsibursement number:
    </strong>
    <asp:Label ID="lblDisbursementNum" runat="server"></asp:Label>
    &nbsp;<br />
    <strong>Department Name:</strong>&nbsp;
    <asp:Label ID="lblDept" runat="server"></asp:Label>
    <br /><b>Disbursement Date:&nbsp;</b><asp:Label ID="lblDate" runat="server"></asp:Label>
    &nbsp;<br />
    <strong>Collection Point:</strong>
    <asp:Label ID="lblCollectionPoint" runat="server"></asp:Label>
    <br /><br />
<asp:GridView ID="disburseListDetailGridView" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" onrowediting="disburseListDetailGridView_RowEditing" 
        onrowcommand="disburseListDetailGridView_RowCommand" 
        onrowupdating="disburseListDetailGridView_RowUpdating" 
        AutoGenerateColumns="False">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:TemplateField></asp:TemplateField>
        <asp:CommandField HeaderText="Edit" ShowEditButton="True" CancelText="" 
            DeleteText="" InsertText="" NewText="" SelectText="" />
        <asp:TemplateField HeaderText="Item Code">
            <EditItemTemplate>
                <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Stationary Description">
            <EditItemTemplate>
                <asp:Label ID="lblStationaryDescription" runat="server" 
                    Text='<%# Bind("StationaryDescription") %>'></asp:Label>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblStationaryDescription" runat="server" 
                    Text='<%# Bind("StationaryDescription") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Requested Quantity">
            <EditItemTemplate>
                <asp:Label ID="lblRequestedQuantity" runat="server" 
                    Text='<%# Bind("RequestedQuantity") %>'></asp:Label>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblRequestedQuantity" runat="server" 
                    Text='<%# Bind("RequestedQuantity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Retrieved Quantity">
            <EditItemTemplate>
                <asp:Label ID="lblRetrievedQuantity" runat="server" 
                    Text='<%# Bind("RetrievedQuantity") %>'></asp:Label>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblRetrievedQuantity" runat="server" 
                    Text='<%# Bind("RetrievedQuantity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Disbursed Quantity">
            <EditItemTemplate>
                <asp:TextBox ID="txtDisbursedQuantity" runat="server" 
                    Text='<%# Bind("DisbursedQuantity") %>' Width="91px"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblDisbursedQuantity" runat="server" 
                    Text='<%# Bind("DisbursedQuantity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
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
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
        onclick="btnSubmit_Click" />
    <asp:Button ID="btnPrint" runat="server" Text="Print" 
        OnClientClick="javascript:window.print();" /> <!-- onclick="btnPrint_Click" -->
    <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnBack_Click" />
    <br />
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server"></asp:Label>
</form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
</asp:Content>
