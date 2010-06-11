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
/// Summary description for TicketBLWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TicketBLWebService : System.Web.Services.WebService {

    private DataTable dta;
        DBhelper db = new DBhelper();

    public TicketBLWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
        public tikets gettiketbyid(int id) 
        {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter para = new SqlParameter("@id", SqlDbType.Int);
        para.Value = id;
        list.Add(para);
        dta = db.ExecuteQuerry("sp_gettiket_byid", list);
        tikets b = new aas.tikets();
        if (dta.Rows.Count != 0)
        {
            b.tiketids = Convert.ToInt32(dta.Rows[0].ItemArray[0].ToString());
            b.tranplacestarts = dta.Rows[0].ItemArray[2].ToString();
            b.trandestination = dta.Rows[0].ItemArray[3].ToString();
            b.tranfees = Convert.ToInt32(dta.Rows[0].ItemArray[4].ToString());
        }
        else
        {
            return null;
        }

        return b;
         }
    
}

