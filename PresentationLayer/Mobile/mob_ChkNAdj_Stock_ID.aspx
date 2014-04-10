<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="mob_ChkNAdj_Stock_ID.aspx.cs" Inherits="Logic_University_Stationary.Mobile_Pages.mob_Clerk.mob_ChkNAdj_Stock_ID" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<h1><center><asp:Label ID="Label8" runat="server" Text="Check Existing Stock And Adjust Stock Items"></asp:Label></center></h1>
    <form id="frm_Search_ID" runat="server" data-ajax="false" >
        
        <div runat="server">
            
               
                <label for="cbo_Item">Item Code</label>
                <asp:DropDownList ID="cboItemCode" runat="server" AutoPostBack="True" data-ajax="false"
                    onselectedindexchanged="cboItemCode_SelectedIndexChanged" >
                </asp:DropDownList>


                 <label for="lblQty"><b>Balance Qty</b></label><br />
                
                <asp:Label ID="lblQty" BorderStyle=Groove runat="server">Balance Qty</asp:Label>
               <br />
               <br />
                 <label for="lbldate"><b>Date Issue</b></label><br />
                
                <asp:Label ID="lbldate" BorderStyle=Groove runat="server">Date</asp:Label>
               <br />

                <label for="slider_Qty">Slider with fill and step of 50:</label>
                <input type="range" name="slider_Qty" id="slider_Qty" value="1" min="0" max="500" step="1" data-highlight="true">
                <div id="slider_range_qty"></div>
                 <asp:RadioButton id="radioPlus" GroupName="radioGroup"
             Text="Plus Item Qty" BackColor="Pink" runat="server"/>
    <asp:RadioButton id="radioMinus" GroupName="radioGroup"
             Text="Minus Item Qty" BackColor="Pink" runat="server"/>

   
     
    <label for="txtComment"><b>Write Comment</b> </label>
   
<asp:TextBox ID="txtComment" runat="server" Text=" "  TextMode="multiline"></asp:TextBox>


                <asp:Button ID="btnSendNoti" runat="server" Text="Send Notification " 
                    data-theme="b" onclick="btnSendNoti_Click" />

                
        </div>
        
        
    </form>    

</asp:Content>
