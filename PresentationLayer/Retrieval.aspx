<%@ Page Title="" Language="C#" MasterPageFile="~/ClerkMasterPage.Master" AutoEventWireup="true" CodeBehind="Retrieval.aspx.cs" Inherits="Logic_University_Stationary.Clerk.Retrieval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" style="font-weight: 700" 
        Text="Stationary Retrieval Form"></asp:Label>
    <br />
    <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 393px">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        AutoGenerateSelectButton="True" DataKeyNames="Item_Code" 
        DataSourceID="EntityDataSourceRetriItem" 
        onselectedindexchanged="GridView1_SelectedIndexChanged1" AllowPaging="True" 
                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4">
        <Columns>
            <asp:BoundField DataField="Item_Code" HeaderText="Item_Code" ReadOnly="True" 
                SortExpression="Item_Code" />
            <asp:BoundField DataField="Needed" HeaderText="Needed" 
                SortExpression="Needed" />
            <asp:BoundField DataField="Retrieved" HeaderText="Retrieved" 
                SortExpression="Retrieved" />
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
    <br />
    <br />
    <asp:Label ID="Label2" Font-Bold="true" Font-Size="Medium" runat="server" Text="Detail:"></asp:Label>
    <br />
    <br />
    <asp:EntityDataSource ID="EntityDataSourceRetriItem" runat="server" 
        ConnectionString="name=LOGIC_UniversityEntities" 
        DefaultContainerName="LOGIC_UniversityEntities" EnableFlattening="False" 
        EnableUpdate="True" EntitySetName="Retrieval_Item">
    </asp:EntityDataSource>
            </td>
            <td>
            <br />
            <br />
            <br />
            <br />
    
            </td>
        </tr>
        <tr>
            <td style="width: 393px">
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" DataKeyNames="Item_Code,Req_Form_No" 
                    DataSourceID="EntityDataSourceRetriDept" BackColor="White" 
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="Item_Code" HeaderText="ItemCode" ReadOnly="True" 
                            SortExpression="Item_Code" />
                        <asp:BoundField DataField="Req_Form_No" HeaderText="Dept ID" ReadOnly="True" 
                            SortExpression="Req_Form_No" />
                        <asp:BoundField DataField="Needed" HeaderText="Needed" 
                            SortExpression="Needed" />
                        <asp:BoundField DataField="Retrieved" HeaderText="Retrieved" 
                            SortExpression="Retrieved" />
                        <asp:CheckBoxField DataField="prior" HeaderText="prior" SortExpression="prior" 
                            Visible="False" />
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
                <asp:EntityDataSource ID="EntityDataSourceRetriDept" runat="server" 
                    ConnectionString="name=LOGIC_UniversityEntities" 
                    DefaultContainerName="LOGIC_UniversityEntities" EnableFlattening="False" 
                    EnableInsert="True" EnableUpdate="True" EntitySetName="Retrieval_Dept">
                </asp:EntityDataSource>
            <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
  
    <br />
     <asp:Button ID="BtnSubmit" runat="server" onclick="BtnSubmit_Click" class="btn-primary" Width="100px" Height="28px"
        Text="Submit" />
    </form>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
</asp:Content>
