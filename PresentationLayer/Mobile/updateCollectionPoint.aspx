
<%@ Page Title=""  Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_EMP.Master" AutoEventWireup="true" CodeBehind="updateCollectionPoint.aspx.cs" Inherits="Logic_University_Stationary.Mobile.updateCollectionPoint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    <center><h1><asp:Label ID="Label1" runat="server" Text="Update Collection Point"></asp:Label></h1></center>
    <b><asp:Label ID="lblCollectionPoint" runat="server" Text="Selece Collection Point"></asp:Label></b>
    <div>
        <asp:Label ID="lblDeptName" runat="server" Text=""></asp:Label>
        <asp:DropDownList ID="ddlCollectionPoint" runat="server">
         <asp:ListItem>Point-1</asp:ListItem>
                        <asp:ListItem>Point-2</asp:ListItem>
                        <asp:ListItem>Point-3</asp:ListItem>
                        <asp:ListItem>Point-4</asp:ListItem>
                        <asp:ListItem>Point-5</asp:ListItem>
                        <asp:ListItem>Point-6</asp:ListItem>
        </asp:DropDownList>
       
        
        <asp:Button ID="btnUpdate" runat="server" Text="Update" data-theme="b"
            onclick="btnUpdate_Click" />
       
        
    </div>
    </form>
</body>
</html>
</asp:Content>