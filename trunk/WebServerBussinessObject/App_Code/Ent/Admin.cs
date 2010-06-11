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
/// Summary description for Admin
/// </summary>
public class Admin
{
    public Admin()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string adminId;
    public string _adminId
    {
        get { return adminId; }
        set { adminId = value; }
    }

    private string adminPassword;
    public string _adminPassword
    {
        get { return adminPassword; }
        set { adminPassword = value; }
    }
}
