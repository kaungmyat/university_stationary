<%--@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitionStatus.aspx.cs" Inherits="Logic_University_Stationary.Mobile.RequisitionStatus" --%>
<%@ Page Title=""  Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_Emp.Master" AutoEventWireup="true" CodeBehind="RequisitionStatus.aspx.cs" Inherits="Logic_University_Stationary.Mobile.RequisitionStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

    <title>View Requisition Status</title>
</head>


<body>
<h1><center><asp:Label ID="Label8" runat="server" Text="Employee Requisition Status"></asp:Label></center></h1>
<center>
        <h4><asp:Label ID="lbltitle" runat="server" CssClass="style1" 
            Text="Stationary Requisition Status"></asp:Label>
            </h4>
       <b>
        <asp:Label ID="lblEmpName" runat="server" Text="Employee Name:"></asp:Label>
        </b>
</center>
<br /><br />
    <form id="form1" runat="server" >
    <div>
        <asp:GridView ID="gvDisbStatus" style="margin:0; text-align:left;" runat="server" 

        BorderColor="#CC9966" BorderWidth="1px" CellPadding="4" BackColor="White" 
            BorderStyle="None" AutoGenerateColumns="False" 
            onrowcommand="gvDisbStatus_RowCommand" 
            onselectedindexchanged="gvDisbStatus_SelectedIndexChanged">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" 
                HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" ForeColor="#663399" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
           


           <Columns>
                <asp:BoundField DataField="Req_Form_No" HeaderText="Form No">
                    
                </asp:BoundField>

                 <asp:BoundField DataField="Approval_Status" HeaderText="Status">
                    
                </asp:BoundField>


                 <asp:BoundField DataField="Rej_Comment" HeaderText="Reasons">
                    
                </asp:BoundField>
                <asp:TemplateField HeaderText="Details">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" >Details</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>



        </asp:GridView>
        <br />

             <hr noshade size=7> <br />
        <asp:Label ID="lblFrmNo" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvDetails" runat="server"
        BorderColor="#CC9966" BorderWidth="1px" CellPadding="4" BackColor="White" 
            BorderStyle="None" AutoGenerateColumns="False" 
            onrowcommand="gvDisbStatus_RowCommand">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" 
                HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" ForeColor="#663399" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />

             <Columns>
                
               
                 <asp:BoundField DataField="Description" HeaderText="Item Name">
                    
                </asp:BoundField>
                <asp:BoundField DataField="Qty" HeaderText="Quantity">
                    
                </asp:BoundField>

               
            </Columns>
        </asp:GridView>
    </div>
    </form>

   
</body>
</html>
</asp:Content>