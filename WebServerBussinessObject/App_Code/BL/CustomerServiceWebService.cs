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
/// Summary description for CustomerServiceWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CustomerServiceWebService : System.Web.Services.WebService {

    public CustomerServiceWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public static void CreateCustomer(Customer cus)
    {
        CustomerDataAccess cusDA = new CustomerDataAccess();
        cusDA.CreateCustomer(cus);
    }
    [WebMethod]
    public static int CheckCustomer(Customer cus)
    {
        CustomerDataAccess cusDa = new CustomerDataAccess();
        Customer _cus = cusDa.GetCustomerByCusID(cus.getCusID());
        if (_cus != null)
            return -1;
        else
        {
            _cus = cusDa.GetCustomerByEmail(cus.getEmail());
            if (_cus != null)
                return 0;
        }
        return 1;
    }
    [WebMethod]
    public static Customer Login(Customer cus)
    {
        CustomerDataAccess cusDa = new CustomerDataAccess();
        Customer _cus = cusDa.GetCustomer(cus.getCusID(), cus.getcusPass());
        return _cus;
    }
    [WebMethod]
    public static void sendEmail(Customer cus)
    {
        MailMessage message = new MailMessage();
        message.From = new MailAddress("TicketOnlineWebMaster@gmail.com");
        message.To.Add(new MailAddress(cus.getEmail()));
        message.Subject = "Thanks you from BooksAmazon";
        message.Body = "To day " + DateTime.Now.ToLongDateString();
        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Send(message);
    }
    
}

