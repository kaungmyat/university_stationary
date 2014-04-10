using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Logic_University_Stationary.Mobile
{
    //Author - ZhangNa
    public partial class Mob_UpdateStock : System.Web.UI.Page
    {
        EntityBrokerClerk eb = new EntityBrokerClerk();
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
    }
}