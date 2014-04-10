using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace Logic_University_Form.Clerk
{
    //Author - ZhangNa
    public partial class UpdateStock : System.Web.UI.Page
    {
        ClerkE eb = new ClerkE();
        string itemCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = eb.getAllStockCardItem();//----------eb
            GridView1.DataBind();
        }

        protected void DropDownListUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemCode = DropDownListUS.SelectedItem.Text.ToString(); 
           
            GridView1.DataSource = eb.getStockCardItem(itemCode);//--------------eb
            GridView1.DataBind();
            GridView2.DataSource = eb.getStockCardItemRecord(itemCode);//----------------eb
            GridView2.DataBind();
        }


        protected void BtnUSSubmit_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        
    }
}