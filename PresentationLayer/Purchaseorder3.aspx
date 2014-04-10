<%@ Page Title="" Language="C#" MasterPageFile="~/ClerkMasterPage.Master" AutoEventWireup="true" CodeBehind="Purchaseorder3.aspx.cs" Inherits="PresentationLayer.Purchaseorder3" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
       <br />

        <center><h5>Stationary Purchase Order Form</h5></center>
    <table>
        <tr>
            <td class="input-medium" style="width: 120px; height: 58px;">
                <asp:Label ID="Label2" runat="server" Text="1st Supplier"></asp:Label>
            </td>
            <td class="input-small" style="width: 91px; height: 58px;">
                 <asp:Label ID="lblSupplier1" runat="server"></asp:Label>
            </td>
            <td class="style11" style="height: 58px"><asp:RadioButton ID="RadioButton1" runat="server" GroupName="supplier" 
                        AutoPostBack="true" Checked="True"/></td>
        </tr>
         <tr>
            <td class="input-medium" style="width: 120px; height: 58px;">
                <asp:Label ID="lblSupplier" runat="server" Text="2nd Supplier"></asp:Label>
            </td>
            <td class="input-small" style="width: 91px">
                 <asp:Label ID="lblSupplier2" runat="server"></asp:Label>
            </td>
            <td class="style11"><asp:RadioButton ID="RadioButton2" runat="server" GroupName="supplier" 
                        AutoPostBack="true" Checked="True"/></td>
        </tr>
         <tr>
            <td class="input-medium" style="width: 120px; height: 58px;">
                <asp:Label ID="Label5" runat="server" Text="3rd Supplier"></asp:Label>
            </td>
            <td class="input-small" style="width: 91px">
                 <asp:Label ID="lblSupplier3" runat="server"></asp:Label>
            </td>
            <td class="style11"><asp:RadioButton ID="RadioButton3" runat="server" GroupName="supplier" 
                        AutoPostBack="true" Checked="True"/></td>
        </tr>
        <tr>
            <td class="input-medium" style="width: 120px; height: 58px;"> PO Number:</td>
            <td class="input-small" style="width: 91px">
                 <asp:Label ID="lblPONumber" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            
            <td class="input-medium" style="width: 120px" >
                <asp:Label ID="lblDeliverto" runat="server" Text="Deliver to:"></asp:Label>
            </td>
            <td class="input-small" style="width: 91px" colspan="2">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                 
            </td>
        </tr>
        <tr>
            
            <td class="input-medium" style="width: 120px">
                Attention</td>
            <td>
                <asp:TextBox ID="txtAttn" runat="server" Width="73px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="input-medium" >
                
                    Please supply the following items by:</td>
                    <td colspan="2" class="input-small">      
        <asp:TextBox runat="server" ID="txtAutDate" Width="93px" />&nbsp;

        
        <asp:ImageButton runat="Server" ID="Image1" 
                ImageUrl="../images/Calendar_scheduleHS.png" 
                AlternateText="Click to show calendar"  Height="16px" Width="18px" />
      </td>
      <td>
        <asp:Label ID="lblDate" runat="server"></asp:Label>
        <asp:Label ID="lblDateError" runat="server"></asp:Label>
      </td>
        <td>
        <ajaxtoolkit:calendarextender ID="calendarButtonExtender" runat="server" TargetControlID="txtAutDate" 
            PopupButtonID="Image1" />
            </td>
           
            
        </tr>
       
        </table>

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
        <table>
            <tr>
                <td class="input-small" style="width: 77px" >
                    Total Price:
                </td>
                
                <td style="width: 95px">
                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                </td>
                <td style="width: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="input-small" style="width: 77px">
                    Order By  :
                </td>
                <td style="width: 95px">
                    <asp:Label ID="lblEmpName" runat="server" ></asp:Label>
                </td>
                <td >On  </td>
                <td><asp:Label ID="lblTodayDate" runat="server"></asp:Label></td>
            </tr>
            </table>
             <br />
            <br />
            <br />
            <asp:Button ID="btn_Submit" runat="server" Text="Submit" class="btn-primary" Width="100px" height="28px"
            onclick="btn_Submit_Click" /> &nbsp;&nbsp;
        <asp:Button ID="btn_Print" runat="server" Text="Print" class="btn-primary" Width="100px" height="28px"
           OnClientClick="javascript:window.print();" onclick="btn_Print_Click" /> &nbsp;&nbsp;  <!--onclick="btn_Print_Click" -->
        <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnBack_Click" class="btn-primary" Width="100px" height="28px" />
    <br />
   
     <br />
        <asp:Label ID="lblEmailStatus" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
    <br />
    </form>
    
</asp:Content>