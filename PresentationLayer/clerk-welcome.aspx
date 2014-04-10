<%@ Page Title="" Language="C#" MasterPageFile="~/ClerkMasterPage.Master" AutoEventWireup="true" CodeBehind="clerk-welcome.aspx.cs" Inherits="Logic_University_Stationary.Clerk.welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <center><h5>Welcome To Logice University</h5></center>
        <table>
            <tr>
                <td >
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/images/original_00017409.jpg" 
                        Height="221px" Width="269px" 
                        />
                    </td>
                <td style="width: 174px" >
                    <asp:Image ID="Image2" runat="server" 
                        ImageUrl="~/images/original_00017411.jpg" Height="221px" Width="267px" /></td>
                
            </tr>
            <tr>
                <td >
                    <asp:Image ID="Image1"  runat="server" 
                        ImageUrl="~/images/original_00017413.jpg" Height="245px" Width="270px" /></td>
                <td style="width: 174px">
                    <asp:Image ID="Image4" runat="server" 
                        ImageUrl="~/images/original_00017410.jpg" Height="243px" Width="264px" /></td>
                
            </tr>
        </table>
    </form>
</asp:Content>