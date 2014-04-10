<%@ Page Title="" Language="C#" MasterPageFile="~/ClerkMasterPage.Master" AutoEventWireup="true" CodeBehind="ConsolidateStationaryRequisition.aspx.cs" Inherits="Logic_University_Form.Clerk.ConsolidateStationaryRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <p class="style2">
        <asp:Label ID="Label1" runat="server" style="font-weight: 700; text-align: right" 
            Text="Consolidate Stationary Requisition" CssClass="style1"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblrequisitionlist" runat="server" Text="Requisition List:"></asp:Label>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Req_Form_No,Item_code" DataSourceID="EntityDataSourceReqlist" 
            AllowPaging="True" BackColor="White" BorderColor="#CC9966" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="Req_Form_No" HeaderText="Req_Form_No" 
                    ReadOnly="True" SortExpression="Req_Form_No" />
                <asp:BoundField DataField="Item_code" HeaderText="Item_code" ReadOnly="True" 
                    SortExpression="Item_code" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    SortExpression="Description" />
                <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                <asp:TemplateField HeaderText="Prior">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckB" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
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
        <asp:EntityDataSource ID="EntityDataSourceReqlist" runat="server" 
            ConnectionString="name=LOGIC_UniversityEntities" 
            DefaultContainerName="LOGIC_UniversityEntities" EnableFlattening="False" 
            EntitySetName="ReqLists">
        </asp:EntityDataSource>
        <asp:EntityDataSource ID="EntityDataSourceReqD" runat="server" 
            ConnectionString="name=LOGIC_UniversityEntities2" 
            DefaultContainerName="LOGIC_UniversityEntities2" EnableFlattening="False" 
            EntitySetName="Requisition_Detail">
        </asp:EntityDataSource>
    </p>
    <p>
            <br />
        <asp:Button ID="lblnextstep" runat="server" Text="Next Step" class="btn-primary" height="28px" Width="100px"
                onclick="lblnextstep_Click" UseSubmitBehavior="False"/>
    </p>
    </form>
</asp:Content>
