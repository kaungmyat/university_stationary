<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Logic_University_Stationary.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
   
     <div class="row-fluid">
    <div class="dialog">
        <div class="block">
            <p class="block-heading">Sign In</p>
            <div class="block-body">
                
                    <label>Emploee ID</label>
                    

                    <asp:TextBox ID="txtEmp_ID" runat="server" class="span12"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmp_ID" ErrorMessage="Enter in Empxx format" ForeColor="Red" 
                        ValidationExpression="^Emp([0-9]{2})$"></asp:RegularExpressionValidator>

                    <label>Password</label>
                    

                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="span12"></asp:TextBox>
                    <p align="right">
                    <asp:Button ID="btnLogin" runat="server" Text="Sign In" class="btn-primary" Width="100px" height="28px"
                        onclick="btnSignin_Click1" />
                    </p>
                   

                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    <div class="clearfix"></div>
                </form>
            </div>
        </div>
        
    </div>
</div>

   
    </form>
</asp:Content>
