<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="create-user.aspx.cs" Inherits="Logic_University_Stationary.Admin.create_user" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <center><h5>Create New User</h5></center>
    <table class="style1">
    <tr>
        <td>
            Employee ID</td>
        <td>
            <asp:TextBox ID="txtEmpID" runat="server"></asp:TextBox><br /></td>
       <td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmpID" ErrorMessage="Enter in Empxx format" ForeColor="Red" 
                        ValidationExpression="^Emp([0-9]{2})$"></asp:RegularExpressionValidator>     
            </td>
    </tr>
    
    <tr>
        <td>
            Employee Name</td>
        <td>
            <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox></td>
        <td>
            &nbsp;</td>
            <td>    </td>
    </tr>
    <tr>
        <td>
            Department ID</td>
        <td>
            <asp:DropDownList ID="ddlDepId" runat="server">
            </asp:DropDownList></td>
            <td>    </td>
    </tr>
    <tr>
        <td>
            Email</td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        <td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red"
            ErrorMessage="Enter valid Email Id" ControlToValidate="txtEmail" SetFocusOnError="true" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" > </asp:RegularExpressionValidator></td>
            <td>    </td>
    </tr>
    <tr>
        <td>
            Password</td>
        <td>
            <asp:TextBox ID="txtpw" runat="server" TextMode="Password"></asp:TextBox></td>
        <td> 
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red"
            ErrorMessage="Enter at lease 5 character" ControlToValidate="txtpw" SetFocusOnError="true" 
            ValidationExpression="^[a-zA-Z0-9]{5,}$" > </asp:RegularExpressionValidator>
        </td>

            <td>    </td>
    </tr>
    <tr>
        <td>
            Phone</td>
        <td>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
        <td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ErrorMessage="Enter Valid Mobile Number" ControlToValidate="txtPhone" forecolor="Red"
            ValidationExpression="^[89]\d{7}$"></asp:RegularExpressionValidator></td>
            <td>    </td>
    </tr>
    <tr>
        <td>
            Date of Birth</td>
        <td>
            <asp:TextBox ID="txtDoB" runat="server" Height="19px" Width="141px"></asp:TextBox>
            <asp:ImageButton runat="Server" ID="Image1" 
                ImageUrl="~/images/Calendar_scheduleHS.png" 
                AlternateText="Click to show calendar"  Height="16px" Width="18px" />
        </td>
        <td>
             
        <ajaxtoolkit:calendarextender ID="calendarButtonExtender" runat="server" TargetControlID="txtDoB" 
            PopupButtonID="Image1" />
            </td>
           
    </tr>
    <tr>
        <td>
            Role</td>
        <td>
            <asp:DropDownList ID="ddlRole" runat="server">
            </asp:DropDownList>
        
            &nbsp;</td>
            <td>    </td>
    </tr>
        <tr></tr>
        <tr></tr>
   
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnCreate" runat="server" Text="Create" onclick="btnCreate_Click" class="btn-primary"
                    Width="115px" Height="35px" />
            </td>
       
        </tr>
    </table>
        <br />
        <br />
        <br />
        </form>
    </asp:Content>