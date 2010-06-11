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
public partial class uwc_listcar : System.Web.UI.UserControl
{
    private DataTable b;
    decimal sum;
    viewtiket a = new viewtiket();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["transID"] == null)
        {
            Response.Redirect("ViewTran.aspx");
        }
        else
        {
            try
            {
                b = a.viewtikets(Convert.ToInt32(Session["startHours"].ToString()), Session["startTime"].ToString(), Session["transID"].ToString());
                rpttiket.DataSource = b;
                rpttiket.DataBind();
            }
            catch
            {
                Response.Redirect("meseage.aspx?msg=" + "Xin lỗi hiện tại hành trình này chưa có" +"\n" +"Hãy liên hệ với chúng tôi qua phản hồi tiện ích để giúp website thêm hoàn thiện");
            }
        }
        
    }

    public void addCart(object sender, CommandEventArgs e)
    {
        aas.ticketing bk = new aas.ticketing();
        //string id = e.CommandArgument.ToString();
        bk.tiketids = Convert.ToInt32(e.CommandArgument.ToString());
        aas.tiketbl bbo = new aas.tiketbl();
        aas.tikets b = bbo.gettiketbyid(bk.tiketids);
        bk.trandestination = b.trandestination;
        bk.tranfees = b.tranfees;
        bk.tranplacestarts = b.tranplacestarts;
        ArrayList cart;
        if (Session["ShoppingCart"] != null)
        {
            cart = (ArrayList)Session["ShoppingCart"];
            int n = cart.Count, j = -1;
            for (int i = 0; i < n; i++)
            {
                if (bk.tiketids == ((aas.ticketing)cart[i]).tiketids)
                {
                    j = i;
                }
            }
            if (j > -1)
            {
               // bk.Amount = ((En.caring)cart[j]).Amount + 1;
                cart.RemoveAt(j);
            }
            cart.Add(bk);
        }
        else
        {
            cart = new ArrayList();
            cart.Add(bk);
        }
        Session["ShoppingCart"] = cart;

    }
    public void viewDetails(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        Response.Redirect("productdetail.aspx?id=" + id);
    }
   
}
