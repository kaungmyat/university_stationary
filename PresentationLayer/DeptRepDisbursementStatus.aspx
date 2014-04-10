<%@ Page Title="" Language="C#" MasterPageFile="~/RepresentativeMasterPage.Master" AutoEventWireup="true" CodeBehind="DeptRepDisbursementStatus.aspx.cs" Inherits="Logic_University_Stationary.DeptRep.DeptRepDisbursementStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

    <p class="style2">
        <strong>
        <asp:Label ID="lbltitle" runat="server" CssClass="style1" 
            Text="Stationary Requisition/Disbursement Status"></asp:Label>
        </strong>
    </p>
    <p class="style3">
        <strong>
        <asp:Label ID="lblEmpName" runat="server" Text="Employee Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <br />
        <br />
        
        <br />
        <asp:GridView ID="gvDisbStatus" style="margin:0; text-align:left;" runat="server"

        BorderColor="#CC9966" BorderWidth="1px" CellPadding="4" BackColor="White" 
            BorderStyle="None" AutoGenerateColumns="false">
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

                 <asp:BoundField DataField="Approval_Status" HeaderText="Approval Status">
                    
                </asp:BoundField>

                 <asp:BoundField DataField="Request_Date" HeaderText="Request Date">
                    
                </asp:BoundField>

                 <asp:BoundField DataField="Rej_Comment" HeaderText="Reasons">
                    
                </asp:BoundField>
            </Columns>



        </asp:GridView>
        <br />
        
        </strong>
    </p>
    <center>
        <asp:Button ID="btnOK" runat="server" Text="OK" class="btn-primary" 
            Width="100px" Height="28px" onclick="btnOK_Click"/>
    </center>
    <br />
    <br />
    </form>

</asp:Content>
