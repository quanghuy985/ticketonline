using System;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    private string cusID;
    private string cusPass;
    private string Address;
    private string Email;
    private int bankAccount;
    private bool isLogin;
    private bool Status;
    public Customer()
    {
 
    }
    public Customer(string _cusID,string _cusPass,string _Address,string _Email,int _bankAccount,bool _isLogin,bool _Status)
    {

        cusID = _cusID;
        cusPass = _cusPass;
        Address = _Address;
        Email = _Email;
        bankAccount = _bankAccount;
        isLogin = _isLogin;
        Status = _Status;
    }
    public string getCusID()
    {
        return cusID;
    }
    public void setCusID(string _cusID)
    {
        cusID = _cusID;
    }
    public string getcusPass()
    {
        return cusPass;
    }
    public void setcusPass(string _cusPass)
    {
        cusPass = _cusPass;
    }
    public string getAddress()
    {
        return Address;
    }
    public void setAddress(string _Address)
    {
        Address = _Address;
    }
    public string getEmail()
    {
        return Email;
    }
    public void setEmail(string _Email)
    {
        Email = _Email;
    }
    public int getBankAccount()
    {
        return bankAccount;
    }
    public void setBankAccount(int _BankAccount)
    {
        bankAccount = _BankAccount;
    }
    public bool getIsLogin()
    {
        return isLogin;
    }
    public void setIsLogin(bool _isLogin)
    {
        isLogin = _isLogin;
 
    }
    public bool getStatus()
    {
        return Status;
    }
    public void setStatus(bool _Status)
    {
        Status = _Status;
    }

}
