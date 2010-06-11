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
public partial class UAC_ListNewsFooter : System.Web.UI.UserControl
{
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        NewsBL news = new NewsBL();
        dt = news.ViewNews();
        rptNewsFooter.DataSource = dt;
        rptNewsFooter.DataBind();
    }
    public void More(object sender, CommandEventArgs e)
    {
        Response.Redirect("NewsDetail.aspx?newsID=" + e.CommandArgument.ToString());
    }
}
