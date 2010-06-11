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
public partial class _Default : System.Web.UI.Page
{
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        CustormerBO cust = new CustormerBO();
        dt = cust.ViewOrderByBookingID(9);
        rptViewOrder.DataSource = dt;
        rptViewOrder.DataBind();
        lbOutPut.Text = "Nếu có thắc mắc gì! Bạn vui lòng đến đại lý gần nhất của chúng tôi, hoặc gửi Email phản hồi cho chúng tôi qua Phản hồi tiện ích! Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi";
    
    }
}
