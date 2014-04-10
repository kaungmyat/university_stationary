<%@ Page Title="" Language="C#" MasterPageFile="~/RepresentativeMasterPage.Master" AutoEventWireup="true" CodeBehind="DeptRepRequisition.aspx.cs" Inherits="Logic_University_Stationary.DeptRep.DeptRepRequisition" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    
   
    <table >
        <tr>
            <td class="input-medium"></td>
            <td></td>
            <td></td>
            <td style="width: 67px"></td>
            <td style="width: 80px"><asp:Label ID="lblDate" runat="server" Text="" ></asp:Label></td>
            
        </tr>
         <tr>
            <td class="input-medium"></td>
            <td></td>
            <td></td>
            <td style="width: 67px"></td>
            <td style="width: 80px"> &nbsp;</td>
        </tr>
          <tr>
            <td style="height: 36px;" class="input-medium">
                Employee Name</td>
            <td style="height: 36px">
                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
              </td>
            <td style="height: 36px"></td>
        </tr>
          <tr>
            <td colspan="3" style="height: 38px"><b>Select Categories</b></td>
          
        </tr>
          <tr>
            <td style="height: 49px;" class="input-medium">
                Name</td>
            <td style="height: 49px">
                <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="true"
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>Apple</asp:ListItem>
                    <asp:ListItem>Orange</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="height: 49px">Description</td>
            <td style="width: 67px; height: 49px;"><asp:DropDownList ID="DropDownList2" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
           
        </tr>
        <tr>
             <td style="height: 44px;" class="input-medium">Quantity</td>
            <td style="height: 44px"><asp:TextBox ID="txtQuantity" runat="server" width="88px"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td class="input-medium"></td>
        </tr>
        <tr>
            <td class="input-medium"></td>
        </tr>
        <tr>
            <td class="input-medium"></td>
            <td><asp:Button ID="btnAdd" runat="server" text="Add" onclick="btnAdd_Click" class="btn-primary" Width="100px" Height="28px"/>
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
    <br /><br /><br />
    <asp:Button ID="btnSubmit" text="Submit" runat="server" class="btn-primary" Width="100px" Height="28px"
        onclick="btnSubmit_Click"></asp:Button>&nbsp;
    <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn-primary" Width="100px" Height="28px"
        onclick="btnDelete_Click"></asp:Button>&nbsp;
    <asp:Button ID="btnDeleteAll" runat="server" Text="Delete All" class="btn-primary" Width="100px" Height="28px"
        onclick="btnDeleteAll_Click"></asp:Button>&nbsp;
    <asp:Button ID="txtCancel" runat="server" Text="Cancel" class="btn-primary" Width="100px" Height="28px"
        onclick="txtCancel_Click"></asp:Button>&nbsp;
    <br />
    <br />

    </form>
</asp:Content>
