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
/// Summary description for TransBLWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TransBLWebService : System.Web.Services.WebService {

    DBhelper db = new DBhelper();
    private DataTable dta;

    public TransBLWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataTable vieatran() {
     return   dta = db.ExecuteQuerry("sp_viewtran", null);
    }
    [WebMethod]
    public DataTable get_tran_id() {
        return db.ExecuteQuerry("sp_get_tranid",null);
    }
    [WebMethod]
    public DataTable view_tan_detail(String tranid) {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter para = new SqlParameter("@tranid", SqlDbType.NVarChar);
        para.Value = tranid;
        list.Add(para);
        return dta = db.ExecuteQuerry("sp_view_tran_detail", list);
    }
    [WebMethod]
    public DataTable viewTransByID(string transID)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter para = new SqlParameter("@transid", SqlDbType.NVarChar);
        para.Value = transID;
        list.Add(para);
        return db.ExecuteQuerry("viewTransByID",list);
    }
    [WebMethod]
    public DataTable intsert_tran(String transID,String transPlaceStart,String transPlaceDestination,int transFee,String transStatus ) {
     
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter para1 = new SqlParameter("@transID", SqlDbType.NVarChar);
        SqlParameter para2 = new SqlParameter("@transPlaceStart", SqlDbType.NVarChar);
        SqlParameter para3 = new SqlParameter("@transPlaceDestination", SqlDbType.NVarChar);
        SqlParameter para4 = new SqlParameter("@transFee", SqlDbType.Int);
        SqlParameter para5 = new SqlParameter("@transStatus", SqlDbType.NVarChar);
        para1.Value = transID;
        para2.Value = transPlaceStart;
        para3.Value = transPlaceDestination;
        para4.Value = transFee;
        para5.Value = transStatus;
        list.Add(para1);
        list.Add(para2);
        list.Add(para3);
        list.Add(para4);
        list.Add(para5);

        return db.ExecuteQuerry("sp_insert_tran", list);
    }
    
}

