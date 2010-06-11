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
public partial class meseage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Request.QueryString["msg"];
        if (Session["User"] != null)
        {
            lbtSolution.PostBackUrl = "FeedBack.aspx";
            lbSolution.Text = " để gửi phản hồi";
        }
    }
}
