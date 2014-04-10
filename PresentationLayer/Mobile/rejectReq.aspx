
<%@ Page Title=""  Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_DH.Master" AutoEventWireup="true" CodeBehind="rejectReq.aspx.cs" Inherits="Logic_University_Stationary.Mobile.mob_MasterPages.rejectReq" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
   <h1><center><asp:Label ID="Label8" runat="server" Text="Rejected Requisition List"></asp:Label></center></h1>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblPageHeader" runat="server" Text=""></asp:Label>
        <asp:GridView ID="gvRejectedRequest" runat="server" BackColor="White" 
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            ViewStateMode="Enabled">
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
        <hr />
        <asp:Label ID="Label1" runat="server" Text="Give Reason"></asp:Label>
        <asp:TextBox ID="txtReasone" runat="server" TextMode="MultiLine" 
            ontextchanged="txtReasone_TextChanged" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtReasone" 
        ErrorMessage="Please Enter the Rejection Comment"></asp:RequiredFieldValidator>
    <br />
        <asp:Button ID="btnOk" runat="server" Text="OK" data-ajax="false" onclick="btnOk_Click" />
    </div>
    </form>

</html>
</asp:Content>