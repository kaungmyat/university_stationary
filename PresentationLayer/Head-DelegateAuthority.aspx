<%@ Page Title="" Language="C#" MasterPageFile="~/HeadMasterPage.Master" AutoEventWireup="true" CodeBehind="Head-DelegateAuthority.aspx.cs" Inherits="Logic_University_Stationary.Head_DelegateAuthority" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
   <ajaxToolkit:ToolkitScriptManager runat="server" ID="ToolkitScriptManager1" ></ajaxToolkit:ToolkitScriptManager>
    
       <br />
    <center><h5>Delegate Authority</h5></center>
   
    <table>
        <tr>
            <td style="height: 42px; width: 139px;">&nbsp;</td>
            <td style="height: 42px; width: 173px;">
                &nbsp;</td>
        </tr>

        <tr>
            <td style="height: 42px; width: 139px;">Employee Name:</td>
            <td style="width: 173px">
                <asp:DropDownList ID="ddlEmpName" runat="server"> 
                   
                </asp:DropDownList>
            </td>
            <td></td>
            <td></td>
        </tr>

         <tr>
            <td style="height: 42px; width: 139px;">Department Name:</td>
            <td style="width: 173px">&nbsp;<asp:Label ID="lblDeptName" runat="server"></asp:Label>
        </td>
        <td></td>
       </tr>

         <tr>
            <td>
                &nbsp;</td>
        </tr>
        </table>
        <table>
        <tr>
            <td style="width: 215px;" class="input-large">From Date :
                <asp:TextBox ID="txtFromdate" runat="server" Height="19px" Width="73px"></asp:TextBox>&nbsp;
                <asp:ImageButton runat="Server" ID="Image2" 
                    ImageUrl="~/images/Calendar_scheduleHS.png" 
                    AlternateText="Click to show calendar" onclick="Image2_Click" 
                    Width="16px"/><br />
            </td>
            <td style="width: 19px">
            
                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender2" runat="server" TargetControlID="txtFromdate" 
                 PopupButtonID="Image2" />
            </td>
          
            <td style="width: 195px">To Date :
                <asp:TextBox ID="txtTodate" runat="server" Height="19px" Width="73px"></asp:TextBox>&nbsp;
                <asp:ImageButton runat="Server" ID="Image3" 
                    ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px"
                    AlternateText="Click to show calendar" onclick="Image3_Click" /><br />
            </td>
            <td>
                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender3" runat="server" TargetControlID="txtTodate"
                PopupButtonID="Image3" />
                
            </td>
        </tr>
       
    </table>
    <br />
    <br />
          <div style="margin-left: 160px">
              <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" class="btn-primary" Width="100px" height="28px"/>&nbsp;&nbsp;
              <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn-primary" 
                  Width="100px" height="28px" onclick="btnCancel_Click" />
              
    </div>
     <br />
     <br />
    
    </form>
</asp:Content>

