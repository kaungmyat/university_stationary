<%@ Page Title="" Language="C#" MasterPageFile="~/HeadMasterPage.Master" AutoEventWireup="true" CodeBehind="HeadTrendReport.aspx.cs" Inherits="PresentationLayer.HeadTrendReport" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <center><h5>Department Head</h5></center>
        <b>
            <asp:Label ID="lblTitle" runat="server" Text="View Department Stationary Trend Report" ></asp:Label>
        </b>
        <br />
        <br />
        <table>
            <tr>
                <td><asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label></td>
                <td><asp:TextBox ID="txtYear" runat="server" Enabled="False">2013</asp:TextBox></td>
              <td>
                <asp:RequiredFieldValidator ID="rfvProfession" runat="server" 
                ErrorMessage="Please select Year :"
                ForeColor="Red" ControlToValidate="txtYear" 
                Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td><asp:Label ID="lblMonth" runat="server" Text="Month"></asp:Label></td>
                <td><asp:DropDownList ID="ddlMonth" runat="server">
                    <asp:ListItem>January</asp:ListItem>
                    <asp:ListItem>February</asp:ListItem>
                    <asp:ListItem>March</asp:ListItem>
                    <asp:ListItem>April</asp:ListItem>
                    <asp:ListItem>May</asp:ListItem>
                    <asp:ListItem>June</asp:ListItem>
                    <asp:ListItem>July</asp:ListItem>
                    <asp:ListItem>August</asp:ListItem>
                    <asp:ListItem>September</asp:ListItem>
                    <asp:ListItem>October</asp:ListItem>
                    <asp:ListItem>November</asp:ListItem>
                    <asp:ListItem>December</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Please select Month :"
                ForeColor="Red" ControlToValidate="ddlMonth" 
                Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
           <tr>
            <td></td>
           </tr>
        </table>
        <br />
        <br />
    <asp:RadioButton ID="compare1Month" runat="server" Text="Compare 1 Month"
            GroupName="rdocompare" Checked="True"/>
    <asp:RadioButton ID="compare2Month" runat="server" Text="Compare 2 Month" 
            GroupName="rdocompare" oncheckedchanged="compare2Month_CheckedChanged" />
    
        <br />     
        <br />
        &nbsp;&nbsp;
    
    <asp:Button ID="btntableFormat" runat="server" Text="Generate" class="btn btn-primary" height="28px" Width="100px"
        onclick="btntableFormat_Click"></asp:Button>&nbsp;
    <asp:Button ID="txtCancel" runat="server" Text="Cancel" class="btn btn-primary" height="28px" Width="100px"
        onclick="txtCancel_Click"></asp:Button>&nbsp;
        &nbsp;&nbsp;
    <br />
    <br />
     <br />
     <br />
     <br />
     <br />
    </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
</asp:Content>
