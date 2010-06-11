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
/// Summary description for bEmployeeWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class bEmployeeWebService : System.Web.Services.WebService {

    DataSet ds = new DataSet();
    DataAccess da = new DataAccess();
    public bEmployeeWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public DataSet ShowAllEmployee()
    {
        DBhelper helper = new DBhelper();
        return helper.ExecuteDataSet("ShowAllEmployee", CommandType.StoredProcedure);

    }
    [WebMethod]
    public int AddEmployee(string id, string pass, string address, string email, int function)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter p = new SqlParameter();
        DBhelper helper = new DBhelper();
        p = new SqlParameter("@empId", SqlDbType.VarChar);
        p.Value = id.ToString();
        list.Add(p);
        p = new SqlParameter("@empPassword", SqlDbType.VarChar);
        p.Value = pass.ToString();
        list.Add(p);
        p = new SqlParameter("@empAddress", SqlDbType.VarChar);
        p.Value = address.ToString();
        list.Add(p);
        p = new SqlParameter("@empEmail", SqlDbType.VarChar);
        p.Value = email.ToString();
        list.Add(p);
        p = new SqlParameter("@empFunction", SqlDbType.Int);
        p.Value = function;
        list.Add(p);
        return helper.ExecuteQuery("AddEmployee", CommandType.StoredProcedure, list);

    }

    [WebMethod]
    public int UpdateEmployee(string id, string pass, string address, string email, int function)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter p = new SqlParameter();
        DBhelper helper = new DBhelper();
        p = new SqlParameter("@empId", SqlDbType.VarChar);
        p.Value = id.ToString();
        list.Add(p);
        p = new SqlParameter("@empPassword", SqlDbType.VarChar);
        p.Value = pass.ToString();
        list.Add(p);
        p = new SqlParameter("@empAddress", SqlDbType.VarChar);
        p.Value = address.ToString();
        list.Add(p);
        p = new SqlParameter("@empEmail", SqlDbType.VarChar);
        p.Value = email.ToString();
        list.Add(p);
        p = new SqlParameter("@empFunction", SqlDbType.Int);
        p.Value = function;
        list.Add(p);
        return helper.ExecuteQuery("UpdateEmployee", CommandType.StoredProcedure, list);
    }
    [WebMethod]
    public int UpdateIsLogin(string id, int stt)
    {
        DBhelper helper = new DBhelper();
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter p = new SqlParameter();
        p = new SqlParameter("@empId", SqlDbType.VarChar);
        p.Value = id.ToString();
        list.Add(p);
        p = new SqlParameter("@empIsLogin", SqlDbType.Bit);
        p.Value = Convert.ToInt32(stt);
        list.Add(p);

        return helper.ExecuteQuery("UpdateIsLogin", CommandType.StoredProcedure, list);
    }
    [WebMethod]
    public int UpdateStatusEmpOn(string id)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter p = new SqlParameter();
        DBhelper helper = new DBhelper();
        p = new SqlParameter("@empId", SqlDbType.VarChar);
        p.Value = id.ToString();

        return helper.ExecuteQuery("UpdateStatusON", CommandType.StoredProcedure, p);
    }
    [WebMethod]
    public int UpdateStatusEmpOff(string id)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter p = new SqlParameter();
        DBhelper helper = new DBhelper();
        p = new SqlParameter("@empId", SqlDbType.VarChar);
        p.Value = id.ToString();

        return helper.ExecuteQuery("UpdateStatusOff", CommandType.StoredProcedure, p);
    }
    [WebMethod]
    public DataSet ShowEmployeeById(string id)
    {
        DBhelper helper = new DBhelper();
        SqlParameter p = new SqlParameter("@empId", SqlDbType.VarChar);
        p.Value = id.ToString();
        return helper.ExecuteDataSet("ShowEmployeeById", CommandType.StoredProcedure, p);
    }
    [WebMethod]
    public int ActiveStatusEmp(string id, int status)
    {
        DBhelper helper = new DBhelper();
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter p = new SqlParameter();
        p = new SqlParameter("@empId", SqlDbType.VarChar);
        p.Value = id.ToString();
        list.Add(p);
        p = new SqlParameter("@empStatus", SqlDbType.Int);
        p.Value = Convert.ToInt32(status);
        list.Add(p);
        return helper.ExecuteQuery("UpdateStatus", CommandType.StoredProcedure, list);
    }
    [WebMethod]
    public int DeactiveStatusEmp(string id, int status)
    {
        DBhelper helper = new DBhelper();
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter p = new SqlParameter();
        p = new SqlParameter("@empId", SqlDbType.VarChar);
        p.Value = id.ToString();
        list.Add(p);
        p = new SqlParameter("@empStatus", SqlDbType.Int);
        p.Value = Convert.ToInt32(status);
        list.Add(p);
        return helper.ExecuteQuery("DeactiveStatusEmp", CommandType.StoredProcedure, list);
    }
    [WebMethod]
    public Employee CheckExistEmpId(string id)
    {
        DBhelper helper = new DBhelper();
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter p = new SqlParameter("@empId", SqlDbType.VarChar);
        p.Value = id.ToString();
        list.Add(p);
        SqlDataReader dr = helper.ExecuteReader("CheckEmpId", CommandType.StoredProcedure, list);
        if (dr.Read())
        {
            Employee emp = new Employee();
            emp._empId = dr[0].ToString();
            return emp;
        }
        return null;
    }
    [WebMethod]
    public DataSet CheckStatus(string id)
    {
        DBhelper helper = new DBhelper();
        SqlParameter p = new SqlParameter("@empId", SqlDbType.VarChar);
        p.Value = id.ToString();
        return helper.ExecuteDataSet("CheckStatus", CommandType.StoredProcedure, p);
    }
    [WebMethod]
    public DataSet getAllBookingByID()
    {
        return da.ExecuteQueryDataSet("spGetBookingStatus", CommandType.StoredProcedure, null);
    }
    [WebMethod]
    public DataSet getAllbyCUSID(String abcd)
    {
        DBhelper helper = new DBhelper();
        SqlParameter p = new SqlParameter("@CusID", SqlDbType.VarChar);
        p.Value = abcd;
        return helper.ExecuteDataSet("spGetBookingStatusbyCusID", CommandType.StoredProcedure, p);
    }
    [WebMethod]
    public DataSet getAllBookingByCusID()
    {
        return da.ExecuteQueryDataSet("spGetBookingByCusID", CommandType.StoredProcedure, null);
    }
    [WebMethod]
    public int UpdateBookingStatus(int id, String empID)
    {
        DBhelper helper = new DBhelper();
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter p = new SqlParameter();
        p = new SqlParameter("@bookingID", SqlDbType.Int);
        p.Value = id;
        list.Add(p);
        p = new SqlParameter("@empID", SqlDbType.VarChar);
        p.Value = empID;
        list.Add(p);
        List<SqlParameter> list1 = new List<SqlParameter>();
        SqlParameter p1 = new SqlParameter();
        p1 = new SqlParameter("@bookingID", SqlDbType.Int);
        p1.Value = id;
        list1.Add(p1);
        int a1 = helper.ExecuteQuery("updateBookingStatus", CommandType.StoredProcedure, list1);
        int a2 = helper.ExecuteQuery("uempIDBookingStatus", CommandType.StoredProcedure, list);
        return a1 + a2;
    }
    [WebMethod]
    public void UpdateBookingStatusbyCusID(String id, String empID)
    {
        DBhelper helper = new DBhelper();
        SqlParameter p = new SqlParameter("@cusID", SqlDbType.VarChar);
        p.Value = id;
        List<SqlParameter> list = new List<SqlParameter>();
        list.Add(p);
        ds = helper.ExecuteQuerryReturnDataSet("getbookingbycusid", list);
        int dem = ds.Tables[0].Rows.Count;
        for (int i = 0; i < dem; i++)
        {
            this.UpdateBookingStatus(Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString()), empID);
        }
    }
    [WebMethod]
    public DataTable getallviewtblTransSchedule()
    {
        DBhelper helper = new DBhelper();
        return helper.ExecuteQuerry("viewtblTransSchedule", null);
    }
    [WebMethod]
    public int updatranschedutestatus(bool status, String transid)
    {
        DBhelper helper = new DBhelper();
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter p = new SqlParameter();
        p = new SqlParameter("@transID", SqlDbType.VarChar);
        p.Value = transid;
        list.Add(p);
        p = new SqlParameter("@transStatus", SqlDbType.Bit);
        p.Value = status;
        list.Add(p);
        return helper.ExecuteQuery("sp_updatestatusSchedule", CommandType.StoredProcedure, list);
    }
}

