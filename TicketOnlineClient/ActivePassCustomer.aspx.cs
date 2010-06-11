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
public partial class ActivePassCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CustormerBO cust = new CustormerBO();
        DataTable dt = new DataTable();
        dt = cust.getCustomerByActivePass(Convert.ToInt32(Request.QueryString["cusActivePass"].ToString()));
        if (dt.Rows.Count != 0)
        {
            string cusID = dt.Rows[0].ItemArray[0].ToString();
            LbCusID.Text = cusID;
            cust.DeActiveCustomer(cusID, 1);
        }
    }
}
