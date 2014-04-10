<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_Clerk.Master" AutoEventWireup="true" CodeBehind="Mob_Outstanding.aspx.cs" Inherits="Logic_University_Stationary.Mobile.Mob_Outstanding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style2
        {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <strong>
        <asp:Label ID="Label1" runat="server" CssClass="style2" 
            Text="List Of Outstanding Requisition"></asp:Label>
        <br />
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Disbursement_ID,Item_Code" DataSourceID="EntityDataSourceOutS">
            <Columns>
                <asp:BoundField DataField="Disbursement_ID" HeaderText="Disbursement_ID" 
                    ReadOnly="True" SortExpression="Disbursement_ID" />
                <asp:BoundField DataField="Item_Code" HeaderText="Item_Code" ReadOnly="True" 
                    SortExpression="Item_Code" />
                <asp:BoundField DataField="OutStand_Qty" HeaderText="OutStand_Qty" 
                    SortExpression="OutStand_Qty" />
            </Columns>
        </asp:GridView>
        <asp:EntityDataSource ID="EntityDataSourceOutS" runat="server" 
            ConnectionString="name=LOGIC_UniversityEntities" 
            DefaultContainerName="LOGIC_UniversityEntities" EnableFlattening="False" 
            EnableUpdate="True" EntitySetName="getOutStandLists">
        </asp:EntityDataSource>
    <br />

        <asp:Button ID="btnFulfil" runat="server" Text="Fulfill" 
            onclick="btnFulfil_Click" ondatabinding="btnFulfil_Click" />
        </strong>
    </form>
</asp:Content>
