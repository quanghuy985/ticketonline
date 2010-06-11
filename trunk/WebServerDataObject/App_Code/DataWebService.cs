using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// Summary description for DataWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DataWebService : System.Web.Services.WebService {


    SqlConnection con;
    SqlCommand cmd = new SqlCommand();
    SqlDataReader dr;
    public DataWebService () {

        InitConnection();
    }

   [WebMethod]
    public void InitConnection()
    {
        if (con == null || con.State == ConnectionState.Closed)
        {
            //String connect = @"Data Source=HIEP-PC\HIEP;Initial Catalog=TransServiceWebsite;User ID=sa;Password=123456";
            con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["callConnection"].ConnectionString);

            con.Open();
        }
    }
   
   [WebMethod]
    public void PrepareCommand( String SPName, List<SqlParameter> paramList)
    {
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = SPName;
        if (paramList != null)
        {
            foreach (SqlParameter param in paramList)
            {
                cmd.Parameters.Add(param);
            }
        }
    }
   [WebMethod]
    public DataTable ExecuteQuerry(String SPName, List<SqlParameter> paramList)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        PrepareCommand( SPName, paramList);
        da.SelectCommand = cmd;
        da.Fill(dt);
        return dt;

    }
   [WebMethod]
    public DataSet ExecuteQuerryReturnDataSet(String SPName, List<SqlParameter> paramList)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        PrepareCommand( SPName, paramList);
        da.SelectCommand = cmd;
        da.Fill(ds);
        return ds;
    }
    //public Student ExecuteQuerryLogin(String SPName, List<SqlParameter> paramList)
    //{
    //    SqlCommand cmd = new SqlCommand();
    //    SqlDataAdapter da = new SqlDataAdapter();
    //    Student st = new Student();
    //    PrepareCommand(cmd, SPName, paramList);
    //    da.SelectCommand = cmd;
    //    da.Fill(st);
    //    return st;

    //}

   [WebMethod]
    public int ExecuteQueryReturnInt(string sql, CommandType type)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.CommandType = type;
        cmd.Connection = con;
        int k = cmd.ExecuteNonQuery();
        return k;
    }
   [WebMethod]
    public int ExecuteQueryReturnInt1(string sql, CommandType type, SqlParameter p)
    {
        int k = 0;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.CommandType = type;
        cmd.Connection = con;

        cmd.Parameters.Add(p);

        try
        {
            k = cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            con.Close();
            throw ex;
        }

        return k;
    }
   [WebMethod]
    public int ExecuteQueryReturnInt2(string sql, CommandType type, List<SqlParameter> list)
    {
        int k = 0;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.CommandType = type;
        cmd.Connection = con;
        foreach (SqlParameter p in list)
        {
            cmd.Parameters.Add(p);
        }
        try
        {
            k = cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            con.Close();
            throw ex;
        }

        return k;
    }
   //[WebMethod]
   //public SqlDataReader ExecuteReader(string sql, CommandType type, List<SqlParameter> list)
   //{
   //    SqlDataReader dr;
   //    SqlCommand cmd = new SqlCommand();
   //    cmd.CommandText = sql;
   //    cmd.CommandType = type;
   //    cmd.Connection = con;
   //    foreach (SqlParameter p in list)
   //    {
   //        cmd.Parameters.Add(p);
   //    }
   //    try
   //    {
   //        dr = cmd.ExecuteReader();
   //    }
   //    catch (SqlException ex)
   //    {
   //        con.Close();
   //        throw ex;
   //    }
   //    return dr;
   //}
   [WebMethod]
    public DataSet ExecuteDataSet(string sql, CommandType type)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.CommandType = type;
        cmd.Connection = con;
        SqlDataAdapter data = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        data.Fill(ds);
        return ds;
    }
   [WebMethod]
    public DataSet ExecuteDataSet1(string sql, CommandType type, SqlParameter p)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.CommandType = type;
        cmd.Connection = con;
        cmd.Parameters.Add(p);

        try
        {
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            data.Fill(ds);
            return ds;
        }
        catch (SqlException ex)
        {
            con.Close();
            throw ex;
        }

    }
    
}

