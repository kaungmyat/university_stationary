<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_Clerk.Master" AutoEventWireup="true" CodeBehind="Mob_ConsolidateStationaryRequisition.aspx.cs" Inherits="Logic_University_Stationary.Mobile.Mob_ConsolidateStationaryRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server" data-ajax="false">
        <asp:Label ID="Label2" runat="server" style="font-weight: 700; text-align: right" 
            Text="Consolidate Stationary Requisition"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Req_Form_No,Item_code" DataSourceID="EntityDataSourceReqMob">
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
        </asp:GridView>

        <asp:EntityDataSource ID="EntityDataSourceReqMob" runat="server" 
            ConnectionString="name=LOGIC_UniversityEntities" 
            DefaultContainerName="LOGIC_UniversityEntities" EnableFlattening="False" 
            EntitySetName="ReqLists">
        </asp:EntityDataSource>
    <br />
    <asp:Button ID="btnNextStep" runat="server" onclick="btnNextStep_Click" 
        Text="Next Step" data-ajax="false" />
    </form>
</asp:Content>
