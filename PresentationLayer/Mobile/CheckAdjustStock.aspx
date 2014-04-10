<%@ Page Title=""  Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckAdjustStock.aspx.cs" Inherits="Logic_University_Stationary.Mobile.CheckAdjustStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1><center><asp:Label ID="Label8" runat="server" Text="Check Existing Stock And Adjust Stock Items"></asp:Label></center></h1>
        <form id="frm_Search" runat=server>
        <div id="Search_Name" runat=server>
             
                <label for="cbo_Cat"><b>Category</b> </label>
               
                 <asp:DropDownList ID="cbo_Cat" runat="server"  AutoPostBack="True" 
                    onselectedindexchanged="cbo_Cat_SelectedIndexChanged">
                </asp:DropDownList>
                    
              

                <label for="cbo_Item"><b>Item Name</b></label>
                
              
                <asp:DropDownList ID="cbo_Item" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="cbo_Item_SelectedIndexChanged"  >
                </asp:DropDownList>
                 
        </div>
        <br />
               
                <label for="lblQty"><b>Balance Qty</b></label><br />
                
                <asp:Label ID="lblQty" BorderStyle=Groove runat="server">Balance Qty</asp:Label>
               <br />
               <br />
                 <label for="lbldate"><b>Date Issue</b></label><br />
                
                <asp:Label ID="lbldate" BorderStyle=Groove runat="server"></asp:Label>
               <br />
               <br />
            <label for="slider_Qty"><b>Adjust Item Qty</b></label>
                <input type="range" 
                data-bind="value: currentLineWidth, slider: currentLineWidth"
                name="slider_Qty" id="slider_Qty" value="1" min="0" max="1000" step="1" data-highlight="true">
        <br />
      
      
   <asp:RadioButton id="radioPlus" GroupName="radioGroup"
             Text="Plus Item Qty" BackColor="Pink" runat="server"/>
    <asp:RadioButton id="radioMinus" GroupName="radioGroup"
             Text="Minus Item Qty" BackColor="Pink" runat="server"/>

   
     
    <label for="txtComment"><b>Write Comment</b> </label>
   
<asp:TextBox ID="txtComment" runat="server" Text=" "  TextMode="multiline"></asp:TextBox>

   <asp:Button id="btnSendNoti" runat="server" Text="Send Notification" data-theme="b" 
            onclick="btnSendNoti_Click" />
 
    </form>

</asp:Content>