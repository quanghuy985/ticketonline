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
public partial class Default4 : System.Web.UI.Page
{
    ArrayList cart;
    int sum;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGrid();
        }
    }
    public void deleteCart(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        cart = (ArrayList)Session["ShoppingCart"];
        int n = cart.Count;
        for (int i = 0; i < n; i++)
        {
            if (((aas.ticketing)cart[i]).tiketids == id)
            {
                cart.RemoveAt(i);
                Session["ShoppingCart"] = cart;
                bindGrid();
                break;
            }
        }
    }
    private void bindGrid()
    {
        cart = (ArrayList)Session["ShoppingCart"];
        int n;
        if (cart == null || cart.Count == 0)
        {
           
            Label1.Text = "Bạn chưa đặt vé nào";
            return;
        }
        else
        n = cart.Count;

        aas.ticketing[] bk = new aas.ticketing[n];
        for (int i = 0; i < n; i++)
        {
            bk[i] = (aas.ticketing)cart[i];
            sum +=  bk[i].tranfees;
        }
        rpttikets.DataSource = bk;
        rpttikets.DataBind();
        lblSum.Text = sum.ToString()+ " .VND";
    }
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        cart = (ArrayList)Session["ShoppingCart"];
        if (Session["User"] == null)
        {
            Response.Redirect("meseage.aspx?msg=Vui lòng đăng nhập để thanh toán.");
        }
        CustormerBO cust = new CustormerBO();
        int bookingID = cust.checkOut(Session["User"].ToString(), cart, cart.Count);
        DataTable dt = new DataTable();
        dt = cust.getCustomer(Session["User"].ToString());
        if (dt.Rows.Count != 0)
        {
            string cusEmail = dt.Rows[0].ItemArray[3].ToString();
            string subject = "Cám ơn bạn đã đặt vé của chúng tôi";
            string body = " Bạn đã đặt vé tại Ticket Online! Vui lòng click vào đường dẫn dưới đây để xem chi tiết " + "đường dẫn?bookingID=" + bookingID;
            cust.sendEmail(cusEmail, subject, body);

            cart.Clear();
        }

    }
}
