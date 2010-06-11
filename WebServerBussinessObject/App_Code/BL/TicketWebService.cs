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
/// Summary description for TicketWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TicketWebService : System.Web.Services.WebService {


    private DataTable dta;
    DBhelper db = new DBhelper();
    private int seatno;
   
    public TicketWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //public DataTable gettiketid(){
    //    dta = db.ExecuteQuerry("sp_gettiketid", null);
    //    if (dta.Rows.Count != 0)
    //    {
    //        tkid = Convert.ToInt32(dt1.Rows[0].ItemArray[0].ToString()) +1;
    //    }
    //    return tkia;
    //}
    [WebMethod]
    public DataTable getcar()
    {
        dta = db.ExecuteQuerry("sp_getcarID", null);
        return dta;
    }
    [WebMethod]
    public int getseateno(int id)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter para1 = new SqlParameter("@carid", SqlDbType.Int);
        para1.Value = id;
        list.Add(para1);
        dta = db.ExecuteQuerry("sp_car_seatno", list);
        if (dta.Rows.Count != 0)
        {
            seatno = Convert.ToInt32(dta.Rows[0].ItemArray[0].ToString());
        }
        return seatno;
    }
    [WebMethod]
    public DataTable gettranid()
    {
   return dta = db.ExecuteQuerry("sp_gettrans", null);
   
    }
    [WebMethod]
    public DataTable insertticket(String transID, String carID,int starthours, String startTime, String endTime, int seatNo, String ticketStatus) {
        //for (int i = 1; i <=seatno; i++)
        //{
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter para1 = new SqlParameter("@transID", SqlDbType.NVarChar);
            SqlParameter para2 = new SqlParameter("@carID", SqlDbType.NVarChar);
            SqlParameter para3 = new SqlParameter("@starthours", SqlDbType.Int);
            SqlParameter para4 = new SqlParameter("@startTime", SqlDbType.NVarChar);
            SqlParameter para5 = new SqlParameter("@endTime", SqlDbType.NVarChar);
            SqlParameter para6 = new SqlParameter("@seatNo", SqlDbType.Int);
            SqlParameter para7 = new SqlParameter("@ticketStatus", SqlDbType.Char);
            para1.Value = transID;
            para2.Value = carID;
            para3.Value = starthours;
            para4.Value = startTime;
            para5.Value = endTime;
            para6.Value = seatNo;
            para7.Value = ticketStatus;
            list.Add(para1);
            list.Add(para2);
            list.Add(para3);
            list.Add(para4);
            list.Add(para5);
            list.Add(para6);
            list.Add(para7);
           return dta= db.ExecuteQuerry("sp_insert_Ticket", list);
        //}
    }
    [WebMethod]
    public DataTable updatestatus_car(String carid) {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter para1 = new SqlParameter("@carid", SqlDbType.NVarChar);
        para1.Value = carid;
        list.Add(para1);
         return dta= db.ExecuteQuerry("sp_update_status_car", list);
    }
    
}

