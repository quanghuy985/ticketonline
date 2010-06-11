using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


/// <summary>
/// Summary description for Employee
/// </summary>
public class Employee
{

    private string empId;
    public string _empId
    {
        get { return empId; }
        set { empId = value; }
    }

    private string empPassword;
    public string _empPassword
    {
        get { return empPassword; }
        set { empPassword = value; }
    }

    private string empAddress;
    public string _empAddress
    {
        get { return empAddress; }
        set { empAddress = value; }
    }

    private string empEmail;
    public string _empEmail
    {
        get { return empEmail; }
        set { empEmail = value; }
    }

    private int empFunction;
    public int _empFunction
    {
        get { return empFunction; }
        set { empFunction = value; }
    }

    private int empIsLogin;
    public int _empIsLogin
    {
        get { return empIsLogin; }
        set { empIsLogin = value; }
    }

    private int empStatus;
    public int _empStatus
    {
        get { return empStatus; }
        set { empStatus = value; }
    }


	public Employee()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    
}
