<%@ Page Title="" Language="C#" MasterPageFile="~/ClerkMasterPage.Master" AutoEventWireup="true" CodeBehind="ListOfItemsBelowReorderLevel.aspx.cs" Inherits="PL.Clerk.ListOfItemsBelowReorderLevel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <div>
    <h5>List of Items below reorder level</h5>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" BackColor="White" 
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="selChkBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
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
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <br />
        
        
        <asp:Label ID="lblStatus2" runat="server"></asp:Label>
        
        
        <br />
        <asp:Button ID="btnGenereatePO" runat="server" onclick="btnGenereatePO_Click" class="btn-primary"
            Width="211px" height="28px" Text="Generate Purchase Order" />
            <br />
        <asp:Label ID="lblCheck" runat="server"></asp:Label>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
</asp:Content>
