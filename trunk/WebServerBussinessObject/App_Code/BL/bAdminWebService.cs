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
/// Summary description for bAdminWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class bAdminWebService : System.Web.Services.WebService {

    DBhelper helper;

    public bAdminWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public bool LoginByAdmin(string id, string pass)
    {
        List<SqlParameter> list=new List<SqlParameter>();
        SqlParameter p=new SqlParameter();
        helper = new DBhelper();
        p=new SqlParameter("@adminId",SqlDbType.VarChar);
        p.Value=id.ToString();
        list.Add(p);
        p=new SqlParameter("@adminPassword",SqlDbType.VarChar);
        p.Value=pass.ToString();
        list.Add(p);
        DataTable dt = helper.ExecuteQuerry("ShowAdmin", list);
        if (dt.Rows.Count !=0)
        {
            return true;
        }
        return false;
    }
    [WebMethod]
    public bool LoginByEmployee(string id, string pass)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter p = new SqlParameter();
        helper = new DBhelper();
        p = new SqlParameter("@empId", SqlDbType.VarChar);
        p.Value = id.ToString().Trim();
        list.Add(p);
        p = new SqlParameter("@empPassword", SqlDbType.VarChar);
        p.Value = pass.ToString().Trim();
        list.Add(p);
        DataTable dt = helper.ExecuteQuerry("ShowEmployee", list);
        if (dt.Rows.Count != 0)
        {
            return true;
        }
        return false;
    }
}

