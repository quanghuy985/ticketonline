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
public partial class trandetail : System.Web.UI.Page
{
    private DataTable dta;
    private DataTable dt;
    tranbl tran = new tranbl();
    ArrayList list;
    protected void Page_Load(object sender, EventArgs e)
    {
        string transID = Request.QueryString["tranid"].ToString();
        
        dta = tran.view_tan_detail(transID);
        //DropDownList2.Items.Add()= dta.Rows[0];
        Label4.Text=dta.Rows[0].ItemArray[1].ToString();
        Label5.Text = dta.Rows[0].ItemArray[2].ToString();
        RevenueBL revenue = new RevenueBL();
        dt = revenue.GetStartTime();
        list = new ArrayList();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list.Add(dt.Rows[i].ItemArray[0].ToString());
        }
        DropDownList2.DataSource = list;
        DropDownList2.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["transID"] = Request.QueryString["tranid"].ToString();
        Session["startHours"] = DropDownList1.SelectedValue;
        Session["startTime"] = DropDownList2.SelectedValue;
        Response.Redirect("Booking.aspx");   
    }
}
