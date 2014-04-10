<%@ Page Title="" Language="C#" MasterPageFile="~/ClerkMasterPage.Master" AutoEventWireup="true" CodeBehind="OutstandingRequisitionList.aspx.cs" Inherits="Logic_University_Form.Supervisor.OutstandingRequisitionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server" id="form1">
       <p class="style1">
        <strong>
        <asp:Label ID="Label1" runat="server" CssClass="style2" 
            Text="List Of Outstanding Requisition"></asp:Label>
        </strong>
    </p>
    <p class="style1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Disbursement_ID,Item_Code" 
            DataSourceID="EntityDataSourceOutS" BackColor="White" BorderColor="#CC9966" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="Disbursement_ID" HeaderText="Disbursement_ID" 
                    ReadOnly="True" SortExpression="Disbursement_ID" />
                <asp:BoundField DataField="Item_Code" HeaderText="Item_Code" ReadOnly="True" 
                    SortExpression="Item_Code" />
                <asp:BoundField DataField="OutStand_Qty" HeaderText="OutStand_Qty" 
                    SortExpression="OutStand_Qty" />
            </Columns>
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
        <asp:EntityDataSource ID="EntityDataSourceOutS" runat="server" 
            ConnectionString="name=LOGIC_UniversityEntities" 
            DefaultContainerName="LOGIC_UniversityEntities" EnableFlattening="False" 
            EntitySetName="getOutStandLists">
        </asp:EntityDataSource>
    </p>
    <p class="style1">
        
        <br />

        <asp:Button ID="btnFulfil" runat="server" Text="Fulfill" class="btn-primary" Width="100px" Height="28px"
            onclick="btnFulfil_Click" ondatabinding="btnFulfil_Click" />&nbsp;&nbsp;
        <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn-primary" 
            Width="100px" Height="28px" OnClientClick="javascript:window.print();"/>&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn-primary" Width="100px" Height="28px" />
    </p>
    </form>
</asp:Content>
