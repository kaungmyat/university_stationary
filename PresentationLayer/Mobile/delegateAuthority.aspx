<%--@ Page Language="C#" AutoEventWireup="true" CodeBehind="delegateAuthority.aspx.cs" Inherits="Logic_University_Stationary.Mobile.delegateAuthority" --%>

<%@ Page Title=""  Language="C#" MasterPageFile="~/Mobile/mob_MasterPages/Mob_Master_DH.Master" AutoEventWireup="true" CodeBehind="delegateAuthority.aspx.cs" Inherits="Logic_University_Stationary.Mobile.delegateAuthority" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script>
    $(function () {
        $('.btnDelegate').click(function () {


            $('#ContentPlaceHolder1_hiddenFDate').val($('#date1').val());
            $('#ContentPlaceHolder1_hiddenTDate').val($('#date2').val());


        });
    });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
    <center><h3>Delegate Authority</h3>

   <b><asp:Label ID="lblDeptName" runat="server" Text=""></asp:Label></b> </center>
    <asp:LinkButton ID="lbtMail" runat="server" onclick="lbtMail_Click" data-ajax="false">Approve Adjustment Voucher</asp:LinkButton> 
    <asp:Label ID="lblAuthDate" runat="server"></asp:Label>
        <table>
         
            <tr>
                <td>Emp Name :</td>
                <td>
                    <asp:DropDownList ID="ddlEmpName" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>From :</td>
                <td>
                    <asp:HiddenField ID="hiddenFDate" runat="server" Value="" />
                  
                     <input data-clear-btn="true" name="date1" id="date1" value="" type="date">
                </td>
            </tr>
            <tr>
                <td>To :</td>
                <td>
                    <asp:HiddenField ID="hiddenTDate" runat="server" Value="" />
                    
                    <input data-clear-btn="true" name="date2" id="date2" value="" type="date">
                </td>

            </tr>
        </table>
         <asp:Button class="btnDelegate" ID="btnDelegate" runat="server" Text="Delegate" data-theme="b" data-role="button" OnClick="btnDelegate_Click"/>
         <br />
         <asp:Button ID="btnCancel" runat="server" Text="Cancel" data-theme="b" data-role="button"/>
    <asp:Label ID="lblalert" runat="server" Text=""></asp:Label>
    </form>
</asp:Content>