<%@ Page Title="" Language="C#" MasterPageFile="~/HeadMasterPage.Master" AutoEventWireup="true" CodeBehind="ListofPending.aspx.cs" Inherits="Logic_University_Stationary.Head.ListofPending" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <center><h5>Department Head</h5></center>
        <b><h6><asp:Label ID="lbltitle" runat="server" Text="List of Pending Requisition Form" ></asp:Label></h6>
        <asp:GridView ID="gvPendingRequisition" runat="server" BackColor="White" 
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            onrowcommand="gvPendingRequisition_RowCommand1">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="selChkBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Details" >Details</asp:LinkButton >
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

        
        </b>

        
    <br />
    <br />
    <asp:Button ID="btnApprove" runat="server" Text="Approve" class="btn-primary" Width="100px" height="28px"
            onclick="btnApprove_Click" />
    &nbsp;&nbsp;
    <asp:Button ID="btnApproveAll" runat="server" Text="ApproveAll" class="btn-primary" Width="100px" height="28px"
            onclick="btnApproveAll_Click" />
    </form>
</asp:Content>