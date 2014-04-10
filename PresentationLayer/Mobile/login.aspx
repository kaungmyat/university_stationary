<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Logic_University_Stationary.Mobile_Pages.mob_Clerk.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.js"></script>

    <script>
        $(function () {
            $(".btnSaveClass").click(function () {
                document.getElementById("msg").innerHTML = "<label fore-color=""red"">Incorrect Password!</label>";
            });
        });
    </script>

 

</head>
<body>
    <form id="frmLogin" runat="server" data-ajax="false">
    <div>
        <div data-role="page">
            <div data-role="header" data-theme="b">
                
                <h1>LOGIC University</h1>
            </div>
            <div data-role="content" align="center">

                <div id="panel"><p id="msg"></p></div>
                
                <label for="txtUserName"style="text-align:left;">User name</label>
                <asp:TextBox ID="txtUserName" runat="server" name="txtUserName" data-clear-btn="true"></asp:TextBox>
                <label for="txtPassword" style="text-align:left;">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" name="txtPassword" 
                    data-clear-btn="true" value="" autocomplete="off" TextMode="Password"></asp:TextBox>

                <br />
                <asp:Button ID="btn_Save" class="btnSaveClass" runat="server" Text="Log in" data-role="button" 
                    data-theme="b" onclick="btn_Save_Click" data-ajax="false" />
                <br />
                <a href="#">Forgot password?</a>
                    
            </div>
        </div>
    </div>
    </form>
</body>
</html>
