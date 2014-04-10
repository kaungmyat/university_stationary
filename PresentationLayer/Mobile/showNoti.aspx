<%@ Page Title=""  Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_Clerk.Master" AutoEventWireup="true" CodeBehind="showNoti.aspx.cs" Inherits="Logic_University_Stationary.Mobile.showNoti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

    <title></title>
</head>
<body>

    <form id="form1" runat="server" data-ajax="false">
     
   <center>
    <h1><asp:Label ID="Label1" runat="server" Text="Adjustment Voucher Detail"></asp:Label></h1>

    </center>
     <asp:Label ID="lblDate" runat="server" Text="" ></asp:Label>
     <br />
  
    
       <asp:GridView ID="gvAdjVoc" runat="server">
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
            onclick="btnApprove_Click" data-theme="b"/>
        
  
    </form>
</body>
</html>
</asp:Content>