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

public partial class UAC_viewNewsDetail : System.Web.UI.UserControl
{
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        NewsBL news = new NewsBL();
        dt = news.viewNewsDetail(Convert.ToInt32(Request.QueryString["newsID"].ToString()));
        rptNewsDetail.DataSource = dt;
        rptNewsDetail.DataBind();
    }
}
