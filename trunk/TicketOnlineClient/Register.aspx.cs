using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Register : System.Web.UI.Page
{
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        CustormerBO cust = new CustormerBO();
        dt = cust.getCustomer(txtCustomerID.Text);
        if (dt.Rows.Count != 0)
        {
            lbError.Text = "Xin lỗi! Tài khoản đã được sử dụng vui lòng chọn tài khoản khác";
        }
        else
        {
          cust.InsertCustomer(txtCustomerID.Text, txtCustomerPassword.Text, txCustomerAddress.Text, txtEmail.Text, Convert.ToInt32(txtCustomerAccountBank.Text));
          cust.SendMailForNewCustomer(txtEmail.Text);
          Response.Redirect("Login.aspx");
        }
    }
    protected void btReset_Click(object sender, EventArgs e)
    {
        string txt = "";
        txtCustomerID.Text = txt;
        txtCustomerPassword.Text = txt;
        txCustomerAddress.Text = txt;
        txtCustomerAccountBank.Text = txt;
        txtEmail.Text = txt;
    }
    protected void btBack_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}
