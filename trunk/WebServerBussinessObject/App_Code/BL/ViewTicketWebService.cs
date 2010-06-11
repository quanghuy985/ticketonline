using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
/// <summary>
/// Summary description for ViewTicketWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ViewTicketWebService : System.Web.Services.WebService {

    private DataTable dta;
    DBhelper db = new DBhelper();
    public ViewTicketWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    
    [WebMethod]
    public DataTable viewtikets(int hour, string startDate,string transID) {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraHour = new SqlParameter("@hour", SqlDbType.Int);
        SqlParameter paraStartDate = new SqlParameter("@startDate",SqlDbType.VarChar);
        SqlParameter paraTransID = new SqlParameter("@transID",SqlDbType.VarChar);
        paraHour.Value = hour;
        paraStartDate.Value = startDate;
        paraTransID.Value = transID;
        list.Add(paraHour);
        list.Add(paraStartDate);
        list.Add(paraTransID);
        return dta = db.ExecuteQuerry("sp_viewticket", list);
    }
}

