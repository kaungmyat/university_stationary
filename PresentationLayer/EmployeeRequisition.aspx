<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeRequisition.aspx.cs" Inherits="Logic_University_Stationary.Employee.EmployeeRequisition" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    
   
    <table >
        <tr>
            <td style="width: 134px"></td>
            <td></td>
            <td style="width: 89px"></td>
            <td style="width: 67px"></td>
            <td style="width: 80px"><asp:Label ID="lblDate" runat="server" Text="" ></asp:Label></td>
            
        </tr>
         <tr>
            <td style="width: 134px"></td>
            <td></td>
            <td style="width: 89px"></td>
            <td style="width: 67px"></td>
            <td style="width: 80px"> &nbsp;</td>
        </tr>
          <tr>
            <td style="width: 134px; height: 36px;">
                Employee Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="height: 36px">
                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
              </td>
            <td style="height: 36px; width: 89px;"></td>
        </tr>
          <tr>
            <td colspan="3" style="height: 40px"><b>Select Categories</b></td>
          
        </tr>
          <tr>
            <td style="width: 104px">
                Name</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server"  AutoPostBack="true"
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>Apple</asp:ListItem>
                    <asp:ListItem>Orange</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlCategory" ErrorMessage="Select  Category"></asp:RequiredFieldValidator>
            </td>
            <td style="width: 89px">Description </td>
            <td style="width: 67px" colspan="2">
                <asp:DropDownList ID="ddlDescription" runat="server" 
                    AutoPostBack="true" 
                    onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
           
        </tr>
        <tr>
             <td style="width: 104px; height: 50px;">Quantity</td>
            <td style="height: 50px"><asp:TextBox ID="txtQuantity" runat="server" width="75px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtQuantity" ErrorMessage="please enter Quantity"></asp:RequiredFieldValidator>
             </td>
            
        </tr>
        <tr>
            <td style="width: 134px; height: 37px;"></td>
            <td style="height: 37px"><asp:Button ID="btnAdd" runat="server" text="Add" onclick="btnAdd_Click" class="btn-primary" Width="100px" Height="28px"/>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div style="margin-left: 20px">
        <asp:GridView ID="itemDetailsGrid" runat="server" BackColor="White" 
            BorderColor="#CC9966" BorderWidth="1px" CellPadding="4" BorderStyle="None" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="selChkBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" 
                HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" ForeColor="#663399" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
    <br />
    <br />
    
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn-primary" 
        Width="100px" Height="28px"
        onclick="btnSubmit_Click" Enabled="False"></asp:Button>&nbsp;
    <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn-primary" Width="100px" Height="28px"
        onclick="btnDelete_Click"></asp:Button>&nbsp;
    <asp:Button ID="btnDeleteAll" runat="server" Text="Delete All" class="btn-primary" Width="100px" Height="28px"
        onclick="btnDeleteAll_Click"></asp:Button>&nbsp;
    <asp:Button ID="txtCancel" runat="server" Text="Cancel" class="btn-primary" Width="100px" Height="28px"
        onclick="txtCancel_Click"></asp:Button>&nbsp;
    <br />
    <br />

    <asp:Label ID="lblStatus" runat="server"></asp:Label>

    </form>
</asp:Content>
