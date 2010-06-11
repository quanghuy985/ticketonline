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

public partial class recoveryPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUser.Text = Request.QueryString["ID"];

    }
    protected void btSendPass_Click(object sender, EventArgs e)
    {
        CustormerBO cust = new CustormerBO();
        DataTable dt = new DataTable();
        dt = cust.getCustomer(txtUser.Text);
        if (dt.Rows.Count != 0)
        {
            string cusEmail = dt.Rows[0].ItemArray[3].ToString();
            string cusPass = dt.Rows[0].ItemArray[1].ToString();
            string subject = "Lấy lại mật khẩu.";
            string body = " Mật khẩu của bạn là :" + cusPass;
            cust.sendEmail(cusEmail, subject, body);
            lbMessage.Text = "Vui lòng kiểm tra email để lấy lại mật khẩu của bạn";
        }
        else
        {
            lbMessage.Text = "Tài khoản chưa có trong website! Xin mời đăng ký.";
        }
    }
}
