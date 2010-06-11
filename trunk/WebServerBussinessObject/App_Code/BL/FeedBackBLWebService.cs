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
/// Summary description for FeedBackBLWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class FeedBackBLWebService : System.Web.Services.WebService {
    DBhelper helper = new DBhelper();
    List<SqlParameter> list;
    public FeedBackBLWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public void InsertFeedBack(string content,string cusID)
    {
        list = new List<SqlParameter>();
        SqlParameter paraContent = new SqlParameter("@feedbackContent",SqlDbType.VarChar);
        SqlParameter paraCusID = new SqlParameter("@cusID",SqlDbType.VarChar);
        paraContent.Value = content;
        paraCusID.Value = cusID;
        list.Add(paraContent);
        list.Add(paraCusID);
        helper.ExecuteQuerry("insertFeedBack",list);
    }
    [WebMethod]
    public DataTable viewFeedBack()
    {
        return helper.ExecuteQuerry("ViewFeedBack",null);
    }
    [WebMethod]
    public DataTable viewFeedBackByID(int feedbackID)
    {
        list = new List<SqlParameter>();
        SqlParameter paraFeedBackID = new SqlParameter("@feedID",SqlDbType.Int);
        paraFeedBackID.Value = feedbackID;
        list.Add(paraFeedBackID);
        return helper.ExecuteQuerry("ViewFeedBackByID",list);
    }
    [WebMethod]
    public void updateFeedBack(int feedbackID)
    {
        list = new List<SqlParameter>();
        SqlParameter paraFeedBackID = new SqlParameter("@feedID", SqlDbType.Int);
        paraFeedBackID.Value = feedbackID;
        list.Add(paraFeedBackID);
        helper.ExecuteQuerry("updateFeedBack",list);
    }
    
}

