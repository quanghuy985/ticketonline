using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Collections;
/// <summary>
/// Summary description for CustomerBoService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CustomerBoService : System.Web.Services.WebService {

    private DataTable dt;
    private int bookingID = 0;
    DBhelper helper = new DBhelper();
    private DataTable dt1;

    public CustomerBoService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    
    [WebMethod]
    public int setBookingID(string cusID)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter para = new SqlParameter("@_cusID",SqlDbType.VarChar);
        para.Value = cusID;
        list.Add(para);
        dt = helper.ExecuteQuerry("insertBooking",list);
        dt1 = helper.ExecuteQuerry("getBookingID",null);//Nho' goi bookingID max;
        if (dt1.Rows.Count != 0)
        {
            bookingID = Convert.ToInt32(dt1.Rows[0].ItemArray[0].ToString());
        }
        return bookingID;
    }
    [WebMethod]
    public int InsertBookingDetail(string cusID,ArrayList ticket,int quantity)
    {
        aas.ticketing[] ticketObject = new aas.ticketing[ticket.Count];
        
       int _bookingID = this.setBookingID(cusID);
        for (int i = 0; i < ticket.Count; i++)
        {
            ticketObject[i] = (aas.ticketing)ticket[i];
            int ticketID = ticketObject[i].tiketids;
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter paraBookingID = new SqlParameter("@_bookingID",SqlDbType.Int);
            SqlParameter paraTicket = new SqlParameter("@_ticket",SqlDbType.Int);
            SqlParameter paraQuantity = new SqlParameter("@_quantity",SqlDbType.Int);
            paraBookingID.Value = _bookingID;
            paraTicket.Value = ticketID;
            paraQuantity.Value = quantity;
            list.Add(paraBookingID);
            list.Add(paraTicket);
            list.Add(paraQuantity);
           dt= helper.ExecuteQuerry("insertBookingDetail",list);
        }
        return _bookingID;
    }
    [WebMethod]
    public void UpdateTicket(ArrayList ticket)
    {
        aas.ticketing[] ticketObject = new aas.ticketing[ticket.Count];
        for (int i = 0; i < ticket.Count; i++)
        {

            ticketObject[i] = (aas.ticketing)ticket[i];
            int ticketID = ticketObject[i].tiketids;

            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter paraTicket = new SqlParameter("@_ticket",SqlDbType.Int);
            paraTicket.Value = ticketID;
            list.Add(paraTicket);
            dt = helper.ExecuteQuerry("updateStatusTicket",list);
        }
        
    }
    [WebMethod]
    public int checkOut(string cusID,ArrayList ticket,int quantity)
    {
       int _bookingID = this.InsertBookingDetail(cusID, ticket, quantity);
        this.UpdateTicket(ticket);
        return _bookingID;
    }
    [WebMethod]
    public DataTable getCustomer(string cusID)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraCusID = new SqlParameter("@_cusID",SqlDbType.VarChar);
        paraCusID.Value = cusID;
        list.Add(paraCusID);
        return helper.ExecuteQuerry("getCustomerByCusID",list);
    }
    [WebMethod]
    public DataTable checkCustomerPassword(string cusID, string cusPassword)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paracusID = new SqlParameter("@cusID",SqlDbType.VarChar);
        SqlParameter paracusPassword = new SqlParameter("@cusPassword", SqlDbType.VarChar);
        paracusID.Value = cusID;
        paracusPassword.Value = cusPassword;
        list.Add(paracusID);
        list.Add(paracusPassword);
        return helper.ExecuteQuerry("checkCustomerPassword",list);
    }
    [WebMethod]
    public void UpdateIsLoginCustomer(string cusID)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraCusID = new SqlParameter("@_cusID", SqlDbType.VarChar);
        paraCusID.Value = cusID;
        list.Add(paraCusID);
        helper.ExecuteQuerry("updateIsLoginCustomer", list);
    }
    [WebMethod]
    public DataTable showAllCustomer()
    {
        return helper.ExecuteQuerry("showAllCustomer", null);
    }
    [WebMethod]
    public DataTable deleteCustomer(string cusID,bool fix)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraCusId = new SqlParameter("@cusID", SqlDbType.VarChar);
        SqlParameter paraCusStatus = new SqlParameter("@cusStatus", SqlDbType.Bit);
        paraCusId.Value = cusID;
        paraCusStatus.Value = fix;
        list.Add(paraCusId);
        list.Add(paraCusStatus);
        return helper.ExecuteQuerry("deleteCustomer",list);
    }
    [WebMethod]
    public DataTable DeActiveCustomer(string cusID, int status)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraCusId = new SqlParameter("@cusID", SqlDbType.VarChar);
        SqlParameter paraCusStatus = new SqlParameter("@cusStatus", SqlDbType.Int);
        paraCusId.Value = cusID;
        paraCusStatus.Value = status;
        list.Add(paraCusId);
        list.Add(paraCusStatus);
        return helper.ExecuteQuerry("UpdateStatusCustomer", list);
    }
    [WebMethod]
    public DataTable updateCustomer(string cusID, string cusPassword, string cusAddress, string cusEmail, int cusBankAccount, bool cusIsLogin, bool cusStatus)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraCusId = new SqlParameter("@cusID", SqlDbType.VarChar);
        SqlParameter paraCusPassword = new SqlParameter("@cusPassword", SqlDbType.VarChar);
        SqlParameter paraCusAddress = new SqlParameter("@cusAddress", SqlDbType.VarChar);
        SqlParameter paraCusEmail = new SqlParameter("@cusEmail", SqlDbType.VarChar);
        SqlParameter paraCusBankAccount = new SqlParameter("@cusBankAccount", SqlDbType.Int);
        SqlParameter paraCusIsLogin = new SqlParameter("@cusIsLogin", SqlDbType.Bit);
        SqlParameter paraCusStatus = new SqlParameter("@cusStatus", SqlDbType.Bit);
         paraCusId.Value = cusID;
         paraCusPassword.Value = cusPassword;
         paraCusAddress.Value = cusAddress;
         paraCusEmail.Value = cusEmail;
         paraCusBankAccount.Value = cusBankAccount;
         paraCusIsLogin.Value = cusIsLogin;
         paraCusStatus.Value = cusStatus;
         list.Add(paraCusId);
         list.Add(paraCusPassword);
         list.Add(paraCusAddress);
         list.Add(paraCusEmail);
         list.Add(paraCusBankAccount);
         list.Add(paraCusIsLogin);
         list.Add(paraCusStatus);
         return helper.ExecuteQuerry("updateCustomer",list);
 
    }
    //public void sendEmail(string cusEmail,string subject,string Body)
    //{
    //    MailMessage message = new MailMessage();
    //    message.From = new MailAddress("TicketOnlineWebMaster@gmail.com");
    //    message.To.Add(new MailAddress(cusEmail));
    //    message.Subject = subject;
    //    message.Body = "To day : " + DateTime.Now.ToLongDateString() +Body;
    //    SmtpClient client = new SmtpClient();
    //    client.EnableSsl = true;
    //    client.Send(message);
    //}
    [WebMethod]
    public void sendEmail(string cusEmail, string subject, string Body)
    {
        MailMessage message = new MailMessage();
        message.From = new MailAddress("TicketOnlineWebMaster@gmail.com");
        message.To.Add(new MailAddress(cusEmail));
        message.Subject = subject;
        message.Body = "To day : " + DateTime.Now.ToLongDateString() +Body;
        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Send(message);
    }  
    [WebMethod]
    public DataTable InsertCustomer(string cusID, string cusPassword, string cusAddress, string cusEmail, int cusBankAccount)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraCusId = new SqlParameter("@cusID", SqlDbType.VarChar);
        SqlParameter paraCusPassword = new SqlParameter("@cusPassword", SqlDbType.VarChar);
        SqlParameter paraCusAddress = new SqlParameter("@cusAddress", SqlDbType.VarChar);
        SqlParameter paraCusEmail = new SqlParameter("@cusEmail", SqlDbType.VarChar);
        SqlParameter paraCusBankAccount = new SqlParameter("@cusBankAccount", SqlDbType.Int);
        paraCusId.Value = cusID;
        paraCusPassword.Value = cusPassword;
        paraCusAddress.Value = cusAddress;
        paraCusEmail.Value = cusEmail;
        paraCusBankAccount.Value = cusBankAccount;
        list.Add(paraCusId);
        list.Add(paraCusPassword);
        list.Add(paraCusAddress);
        list.Add(paraCusEmail);
        list.Add(paraCusBankAccount);
        return helper.ExecuteQuerry("InsertCustomer", list);
    }
    [WebMethod]
    public DataTable ViewOrderByBookingID(int id)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraBookingID = new SqlParameter("@bookingID", SqlDbType.Int);
        paraBookingID.Value = id;
        list.Add(paraBookingID);
        return helper.ExecuteQuerry("ViewOrderByBookingID", list);
    }
    [WebMethod]
    public DataTable getCustomerByActivePass(int activePass)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        SqlParameter paraActivePass = new SqlParameter("@activePass", SqlDbType.Int);
        paraActivePass.Value = activePass;
        list.Add(paraActivePass);
        return helper.ExecuteQuerry("getCustomerByActivePass", list);
    }
    
}

