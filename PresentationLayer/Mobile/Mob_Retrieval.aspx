<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_Clerk.Master" AutoEventWireup="true" CodeBehind="Mob_Retrieval.aspx.cs" Inherits="Logic_University_Stationary.Mobile.Mob_Retrieval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" style="font-weight: 700" 
        Text="Stationary Retrieval Form"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Item_Code" 
        DataSourceID="EntityDataSourceRetriItem_Mob" 
        onselectedindexchanged="GridView1_SelectedIndexChanged1" 
        AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="Item_Code" HeaderText="Item_Code" ReadOnly="True" 
                SortExpression="Item_Code" />
            <asp:BoundField DataField="Needed" HeaderText="Needed" 
                SortExpression="Needed" />
            <asp:BoundField DataField="Retrieved" HeaderText="Retrieved" 
                SortExpression="Retrieved" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:EntityDataSource ID="EntityDataSourceRetriItem_Mob" runat="server" 
        ConnectionString="name=LOGIC_UniversityEntities" 
        DefaultContainerName="LOGIC_UniversityEntities" EnableFlattening="False" 
        EnableUpdate="True" EntitySetName="Retrieval_Item">
    </asp:EntityDataSource>
    <br />
                <asp:Label ID="lbDetail" runat="server" Text="RetrievalDetail:"></asp:Label>
            <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Item_Code,Req_Form_No" DataSourceID="EntityDataSourceRetriDept">
        <Columns>
            <asp:BoundField DataField="Item_Code" HeaderText="Item_Code" ReadOnly="True" 
                SortExpression="Item_Code" />
            <asp:BoundField DataField="Req_Form_No" HeaderText="Req_Form_No" 
                ReadOnly="True" SortExpression="Req_Form_No" />
            <asp:BoundField DataField="Needed" HeaderText="Needed" 
                SortExpression="Needed" />
            <asp:BoundField DataField="Retrieved" HeaderText="Retrieved" 
                SortExpression="Retrieved" />
            <asp:CheckBoxField DataField="prior" HeaderText="prior" SortExpression="prior" 
                Visible="False" />
        </Columns>
    </asp:GridView>
            <asp:EntityDataSource ID="EntityDataSourceRetriDept" runat="server" 
        ConnectionString="name=LOGIC_UniversityEntities" 
        DefaultContainerName="LOGIC_UniversityEntities" EnableFlattening="False" 
        EntitySetName="Retrieval_Dept">
    </asp:EntityDataSource>
            <br />
    <asp:Button ID="BtnSubmit" runat="server" onclick="BtnSubmit_Click" 
        Text="Submit" />
            </form>
</asp:Content>
