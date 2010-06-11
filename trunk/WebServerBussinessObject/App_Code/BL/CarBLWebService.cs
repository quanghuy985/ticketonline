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
/// Summary description for CarBLWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CarBLWebService : System.Web.Services.WebService {


    private DataTable dta;
    DBhelper db = new DBhelper();
    public CarBLWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

	[WebMethod]
    public DataTable getcar() {
        return dta = db.ExecuteQuerry("sp_view_car", null);
    }
    [WebMethod]
    public DataTable getcar_byid() {
       
        return dta = db.ExecuteQuerry("sp_getcarID", null);
    }
    [WebMethod]
    public DataTable getAllCar_ByID(string carID)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter para1 = new SqlParameter("@carID", SqlDbType.NVarChar);
        para1.Value = carID;
        list.Add(para1);
        return dta = db.ExecuteQuerry("getAllCar_byID",list);
    }
    [WebMethod]
    public DataTable updatecar(String carID,int carSeatNo,String carDescription,int carStatus) {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter para1 = new SqlParameter("@carID", SqlDbType.NVarChar);
        SqlParameter para2 = new SqlParameter("@carSeatNo", SqlDbType.Int);
        SqlParameter para3 = new SqlParameter("@carDescription", SqlDbType.NVarChar);
        SqlParameter para4 = new SqlParameter("@carStatus", SqlDbType.Int);
        para1.Value = carID;
        para2.Value = carSeatNo;
        para3.Value = carDescription;
        para4.Value = carStatus;
        list.Add(para1);
        list.Add(para2);
        list.Add(para3);
        list.Add(para4);
       return dta = db.ExecuteQuerry("sp_update_car", list);
    }
    [WebMethod]
    public DataTable addnewcar(String carID, int carSeatNo, String carDescription, String carStatus)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter para1 = new SqlParameter("@carID", SqlDbType.NVarChar);
        SqlParameter para2 = new SqlParameter("@carSeatNo", SqlDbType.Int);
        SqlParameter para3 = new SqlParameter("@carDescription", SqlDbType.NVarChar);
        SqlParameter para4 = new SqlParameter("@carStatus", SqlDbType.NVarChar);
        para1.Value = carID;
        para2.Value = carSeatNo;
        para3.Value = carDescription;
        para4.Value = carStatus;
        list.Add(para1);
        list.Add(para2);
        list.Add(para3);
        list.Add(para4);
        return dta = db.ExecuteQuerry("sp_create_car", list);
    }
}

