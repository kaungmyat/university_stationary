<%@ Page Title="" Language="C#" MasterPageFile="~/ClerkMasterPage.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="PL.Clerk.PurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <div>
    
        <br />
        <table class="style1">
            <tr>
                <td class="span1" style="width: 81px">&nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td style="width: 57px">
                    Select Supplier</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="span1" style="width: 81px">1st Supplier
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="lblSupplier1" runat="server"></asp:Label>
                </td>
                <td style="width: 107px">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="supplier" 
                        AutoPostBack="true" Checked="True"/>
                </td>
                <td class="style2">
                    PO Number:
                    </td>
                <td>
                    <asp:Label ID="lblPONumber" runat="server"></asp:Label>
                </td>
                <td style="width: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="span1" style="width: 81px">
                    2nd Supplier</td>
                <td class="style5">
                    <asp:Label ID="lblSupplier2" runat="server"></asp:Label>
                </td>
                <td style="width: 107px">
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="supplier" AutoPostBack="true"/>
                </td>
                <td class="style2">
                    Deliver to:
                    </td>
                <td>
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
                <td style="width: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="span1" style="width: 81px">
                    3rd Supplier</td>
                <td class="style5">
                    <asp:Label ID="lblSupplier3" runat="server"></asp:Label>
                </td>
                <td style="width: 107px" >
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="supplier" AutoPostBack="true"/>
                </td>
                <td class="style2">
                    Attn:</td>
                <td>
                    <asp:TextBox ID="txtAttn" runat="server" Height="20px" Width="112px"></asp:TextBox>
                </td>
                <td style="width: 19px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtAttn" ErrorMessage="Please fill in the name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
                    Please supply the following items by:</td>
                <td colspan="2">
                    <asp:Calendar ID="Calendar1" runat="server" 
                        onselectionchanged="Calendar1_SelectionChanged" Height="196px" 
                        Width="313px"></asp:Calendar>
                </td>
                <td class="style2">
        <asp:ImageButton runat="Server" ID="Calendar" ImageUrl="../images/Calendar_scheduleHS.png" 
              Height="16px" Width="18px" AlternateText="Click to show calendar" onclick="Calendar_Click" />
                </td>
                <td>
                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                    <asp:Label ID="lblDateError" runat="server"></asp:Label>
                </td>
                <td style="width: 19px">
                    &nbsp;</td>
            </tr>
        </table>
        &nbsp;
        <br />
        <br />
        <asp:GridView ID="PurOrderGridView" runat="server" CellPadding="4" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
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
        <br />
        <br />
        <asp:Label ID="lblTotalPrice" runat="server" Text="Total Price :" 
            style="font-weight: 700"></asp:Label>
&nbsp;<asp:Label ID="lblTotal" runat="server"></asp:Label>
        <br />
        <br />
        Ordered by
        <asp:Label ID="lblEmpName" runat="server"></asp:Label>
&nbsp;on
        <asp:Label ID="lblTodayDate" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        &nbsp;<asp:Button ID="btn_Submit" runat="server" Text="Submit" class="btn-primary" Width="100px"
            onclick="btn_Submit_Click" /> &nbsp;&nbsp;
        <asp:Button ID="btn_Print" runat="server" Text="Print" class="btn-primary" Width="100px"
           OnClientClick="javascript:window.print();"  /> &nbsp;&nbsp;  <!--onclick="btn_Print_Click" -->
        <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnBack_Click" class="btn-primary" Width="100px" />
        <br />
        <asp:Label ID="lblEmailStatus" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
    
    </div>
    </form>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
</asp:Content>
