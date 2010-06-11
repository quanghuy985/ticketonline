using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
public partial class Default2 : System.Web.UI.Page
{
    ArrayList cart;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label1.Text = Request.QueryString["id"];
        lbTransID.Text = Session["transID"].ToString();
        lbStartTime.Text = Session["startTime"].ToString();
        lbStartHours.Text = Session["startHours"].ToString();

        
            bindGrid();
        
    }
    private void bindGrid()
    {
        cart = (ArrayList)Session["ShoppingCart"];
        if (cart == null || cart.Count == 0)
        {
            //lblTitle.Text = "Bạn chưa chọn xe nào";
            //Response.Redirect("Home.aspx");
            return;
        }
        int n = cart.Count;
        
        aas.ticketing[] bk = new aas.ticketing[n];
        for (int i = 0; i < n; i++)
        {
            bk[i] = (aas.ticketing)cart[i];
            //sum += bk[i].Amount * bk[i].prices;
        }
        rpttikets.DataSource = bk;
        rpttikets.DataBind();
    }
}
