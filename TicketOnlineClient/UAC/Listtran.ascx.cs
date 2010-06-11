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
public partial class UAC_Listtran : System.Web.UI.UserControl
{
    private DataTable dta;
    tranbl tran = new tranbl();
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }
    public void bind() {
        dta = tran.vieatran();
        rpttran.DataSource = dta;
        rpttran.DataBind();
    }
    public void datve(object sender, CommandEventArgs e) {
        Response.Redirect("trandetail.aspx?tranid=" + e.CommandArgument.ToString());
    }
}
