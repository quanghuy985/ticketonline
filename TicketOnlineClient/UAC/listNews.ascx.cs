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
public partial class UAC_listNews : System.Web.UI.UserControl
{
    private DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

        bind();
    }

    public void bind()
    {
     

            NewsBL news = new NewsBL();
            dt = news.ViewNews();

            if (dt.Rows.Count == 0)
            {

                Response.Redirect("meseage.aspx?msg=Hien chua co tin tuc nao.quay lai sao nhe cu");
            }
            else
            {

                pnlResults.Visible = false;
                pnlNoResults.Visible = true;
                PagedDataSource objPDS = new PagedDataSource();
                objPDS.AllowPaging = true;
                objPDS.PageSize = 16;
                objPDS.DataSource = dt.DefaultView;
                if (objPDS.Count > 0)
                {
                    pnlResults.Visible = true;
                    pnlNoResults.Visible = false;
                    objPDS.CurrentPageIndex = CurrentPage;

                    lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of "
                                                   + objPDS.PageCount.ToString();


                    lnkPreviousPage.Enabled = !objPDS.IsFirstPage;
                    lnkNextPage.Enabled = !objPDS.IsLastPage;

                    rptNews.DataSource = objPDS;
                    rptNews.DataBind();

                }

            }
        
    }

    public int CurrentPage
    {
        get
        {

            object o = this.ViewState["_CurrentPage"];
            if (o == null)
                return 0;
            else
                return (int)o;
        }
        set
        {
            this.ViewState["_CurrentPage"] = value;
        }
    }

    protected void lnkPreviousPage_Click(object sender, EventArgs e)
    { //Set viewstate variable to the previous page
        CurrentPage -= 1;
        bind();

    }

    protected void lnkNextPage_Click(object sender, EventArgs e)
    {

        CurrentPage += 1;

        //Reload control
        bind();
    }

    public void More(object sender, CommandEventArgs e)
    {
        Response.Redirect("NewsDetail.aspx?newsID=" +e.CommandArgument.ToString());
    }


 
}
