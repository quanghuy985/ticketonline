using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
/// <summary>
/// Summary description for RevenueBLWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class RevenueBLWebService : System.Web.Services.WebService {

        
    DBhelper helper = new DBhelper();
	
    
    public RevenueBLWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public DataTable GetStartTime()
    {
        return helper.ExecuteQuerry("getStartTime",null);
    }
    [WebMethod]
    public DataTable SumTicketSold(string transID, string startTime, int startHours)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraTransID = new SqlParameter("@transID",SqlDbType.VarChar);
        SqlParameter paraStartTime = new SqlParameter("@startTime",SqlDbType.VarChar);
        SqlParameter paraStartHours = new SqlParameter("@startHours",SqlDbType.VarChar);
        paraTransID.Value = transID;
        paraStartTime.Value = startTime;
        paraStartHours.Value = startHours;
        list.Add(paraTransID);
        list.Add(paraStartTime);
        list.Add(paraStartHours);
        return helper.ExecuteQuerry("SumTicketSold",list);

    }
    [WebMethod]
    public DataTable SumTicketAvailabe(string transID, string startTime, int startHours)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraTransID = new SqlParameter("@transID", SqlDbType.VarChar);
        SqlParameter paraStartTime = new SqlParameter("@startTime", SqlDbType.VarChar);
        SqlParameter paraStartHours = new SqlParameter("@startHours", SqlDbType.VarChar);
        paraTransID.Value = transID;
        paraStartTime.Value = startTime;
        paraStartHours.Value = startHours;
        list.Add(paraTransID);
        list.Add(paraStartTime);
        list.Add(paraStartHours);
        return helper.ExecuteQuerry("SumTicketAvailable", list);
    }
}

