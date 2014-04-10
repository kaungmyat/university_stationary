<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_Clerk.Master" AutoEventWireup="true" CodeBehind="Mob_UpdateStock.aspx.cs" Inherits="Logic_University_Stationary.Mobile.Mob_UpdateStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="UpdateStocklb" runat="server" Text="Update Stock"></asp:Label>
    <br />
    <asp:DropDownList ID="DropDownListUS" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownListUS_SelectedIndexChanged" 
        DataSourceID="EntityDataSourceStockCard" DataTextField="Item_Code" 
        DataValueField="Item_Code">
    </asp:DropDownList>
    <asp:EntityDataSource ID="EntityDataSourceStockCard" runat="server" 
        ConnectionString="name=LOGIC_UniversityEntities" 
        DefaultContainerName="LOGIC_UniversityEntities" EnableFlattening="False" 
        EntitySetName="Stationary_Catalogue" Select="it.[Item_Code]">
    </asp:EntityDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True">
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Item Detail:"></asp:Label>
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
    </form>
</asp:Content>
