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
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtPassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("recoveryPassword.aspx?ID="+txtUserName.Text);
    }
    protected void btCancel_Click(object sender, EventArgs e)
    {

    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        CustormerBO cust = new CustormerBO();
        DataTable dt = new DataTable();
        dt = cust.getCustomer(txtUserName.Text);
        DataTable dt1 = new DataTable();
        if (dt.Rows.Count == 0)
        {
            lbError.Text = "Sai tên đăng nhập! Vui lòng đăng nhập lại hoặc đăng ký tài khoản này";
            
        }
        else
        {
            //int i = Convert.ToInt32(dt.Rows[0].ItemArray[6]);
            dt1 = cust.checkCustomerPassword(txtUserName.Text, txtPassword.Text);
            if (dt1.Rows.Count == 0)
            {
                lbError.Text = "Sai mật khẩu! Hãy ấn vào quên mật khẩu để lấy lại pass";
            }
            else
            {
                if (Convert.ToInt32(dt.Rows[0].ItemArray[6]) == 0)
                {
                    lbError.Text = "Tài khoản của bạn chưa kích hoạt ! Vui lòng kiểm tra lại email or liên hệ người quản trị";
                }
                else
                {
                    cust.UpdateIsLoginCustomer(txtUserName.Text);
                    Session["User"] = txtUserName.Text;
                    Response.Redirect("Home.aspx");
                }
            }
        }
    }
    protected void btRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx?id=" +txtUserName.Text);
    }
}
