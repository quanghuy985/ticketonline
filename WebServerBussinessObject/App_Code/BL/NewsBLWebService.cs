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
/// Summary description for NewsBLWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class NewsBLWebService : System.Web.Services.WebService {

    DBhelper helper = new DBhelper();
    public NewsBLWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

   
	[WebMethod]
    public DataTable upDateNews(int newsID,string newsTitle,string newsBrief,string newsContent, string newsImage,int newsStatus)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraNewsID = new SqlParameter("@newsID",SqlDbType.Int);
        SqlParameter paraTitle = new SqlParameter("@newsTitle", SqlDbType.VarChar);
        SqlParameter paraBrief = new SqlParameter("@newsBrief", SqlDbType.VarChar);
        SqlParameter paraContent = new SqlParameter("@newsContent", SqlDbType.VarChar);
        SqlParameter paraImages = new SqlParameter("@newsImage", SqlDbType.VarChar);
        SqlParameter paraNewsStatus = new SqlParameter("@newsStatus",SqlDbType.Int);
        paraNewsID.Value = newsID;
        paraTitle.Value = newsTitle;
        paraBrief.Value = newsBrief;
        paraContent.Value = newsContent;
        paraImages.Value = newsImage;
        paraNewsStatus.Value = newsStatus;
        list.Add(paraNewsID);
        list.Add(paraTitle);
        list.Add(paraBrief);
        list.Add(paraContent);
        list.Add(paraImages);
        list.Add(paraNewsStatus);
        return helper.ExecuteQuerry("upDateNews", list);
    }
    [WebMethod]
    public DataTable updateNewsStatus(int newsID, int status)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraNewsID = new SqlParameter("@newsID", SqlDbType.Int);
        SqlParameter paraStatus = new SqlParameter("@newsStatus", SqlDbType.Int);
        paraNewsID.Value = newsID;
        paraStatus.Value = status;
        list.Add(paraNewsID);
        list.Add(paraStatus);
        return helper.ExecuteQuerry("proc_activeNews",list);
    }
    [WebMethod]
    public DataTable ViewNewsAdmin()
    {
        return helper.ExecuteQuerry("viewAllNews",null);
    }
    [WebMethod]
    public DataTable ViewNews()
    {
        return helper.ExecuteQuerry("viewNews",null);
    }
    [WebMethod]
    public void AddNews(string title,string brief,string content, string images)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraTitle = new SqlParameter("@newsTitle", SqlDbType.VarChar);
        SqlParameter paraBrief = new SqlParameter("@newsBief", SqlDbType.VarChar);
        SqlParameter paraContent = new SqlParameter("@newsContent", SqlDbType.VarChar);
        SqlParameter paraImages = new SqlParameter("@newsImage", SqlDbType.VarChar);
        paraTitle.Value = title;
        paraBrief.Value = brief;
        paraContent.Value = content;
        paraImages.Value = images;
        list.Add(paraTitle);
        list.Add(paraBrief);
        list.Add(paraContent);
        list.Add(paraImages);
        helper.ExecuteQuerry("insertNews", list);
    }
    [WebMethod]
    public DataTable viewNewsDetail(int newsID)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraNewsID = new SqlParameter("@newsID",SqlDbType.Int);
        paraNewsID.Value = newsID;
        list.Add(paraNewsID);
        return helper.ExecuteQuerry("viewNewsByID", list);
    }
}

