
<%@ Page Title=""  Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_DH.Master" AutoEventWireup="true" CodeBehind="listOfPendingReq.aspx.cs" Inherits="Logic_University_Stationary.Mobile.listOfPendingReq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

    <title>List Of Pending Requisition</title>
</head>
<body>

<center><h2>List Of Pending Requisition</h2></center>
    <form id="form1" runat="server" data-ajax="false">
    <div>
        <asp:GridView ID="gvReqList" runat="server" 
            onrowcommand="gvReqList_RowCommand" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnDetail" runat="server">Details</asp:LinkButton>
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
        <asp:Button ID="btnApprove" runat="server" Text="Approve" 
            onclick="btnApprove_Click" data-ajax="false" />
         &nbsp;&nbsp;
        <asp:Button ID="btnAppAll" runat="server" 
            Text="Approve All" onclick="btnAppAll_Click" />
    </div>
    </form>
</body>
</html>
</asp:Content>