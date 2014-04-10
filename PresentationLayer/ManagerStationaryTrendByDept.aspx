<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerMaster.Master" AutoEventWireup="true" CodeBehind="ManagerStationaryTrendByDept.aspx.cs" Inherits="PresentationLayer.ManagerStationaryTrendByDept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <center><h5>Store Manager</h5></center>
    <asp:Label ID="lbltitle" runat="server" Font-Size="16px" Font-Bold="true">Stantionary Trend by Department</asp:Label>
    <br />
    <br />
    <asp:Label ID="lblDeptID" runat="server" Text="DeptID:"></asp:Label>&nbsp;
    <asp:DropDownList ID="ddldeptID" runat="server">
        <asp:ListItem>COM</asp:ListItem>
        <asp:ListItem>ENG</asp:ListItem>
        <asp:ListItem>PSC</asp:ListItem>
        <asp:ListItem>REG</asp:ListItem>
        <asp:ListItem>STO</asp:ListItem>
        <asp:ListItem>ZOL</asp:ListItem>
    </asp:DropDownList><br />

    <asp:Label ID="lblMOnth" runat="server" Text="Month:"></asp:Label>&nbsp;
    <asp:DropDownList ID="ddlmonth" runat="server">
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
    </asp:DropDownList><br />

     <asp:RadioButton ID="compare1Month" runat="server" Text="Compare 1 Month" 
            GroupName="rdocompare" Checked="True"/>
    <asp:RadioButton ID="compare2Month" runat="server" Text="Compare 2 Month" 
            GroupName="rdocompare" oncheckedchanged="compare2Month_CheckedChanged"/><br />
    <br />
    <asp:Button ID="btngenerate" runat="server" Text="Generate" height="28px" Width="100px" class="btn-primary"
        onclick="btngenerate_Click"/>&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" height="28px" Width="100px" class="btn-primary"
        onclick="btnCancel_Click"/>
        <br /><br /><br />
  </form>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
</asp:Content>
