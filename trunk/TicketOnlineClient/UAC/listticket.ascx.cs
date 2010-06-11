using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

public partial class uwc_listcar : System.Web.UI.UserControl
{
    private DataTable b;
    viewtiket a = new viewtiket();
    ArrayList ticketID;
    int i = 0;
    int str_ticketID;
    string cusID;
    //int hour;
    //string transID;
    //string startDate;
    protected void Page_Load(object sender, EventArgs e)
    {
    bind();
        
    }
    public void bind(){
        if (Session["transID"] == null)
        {
            Response.Redirect("ViewTran.aspx");
        }
        else
        {
           
                b = a.viewtikets(Convert.ToInt32(Session["startHours"].ToString()), Session["startTime"].ToString(), Session["transID"].ToString());

                if (b.Rows.Count == 0)
                {

                    Response.Redirect("meseage.aspx?msg=Xin lỗi hiện tại hành trình này chưa có !Hãy liên hệ với chúng tôi qua phản hồi tiện ích để giúp website thêm hoàn thiện");
                }
                else
                {
                       
        pnlResults.Visible = false;
        pnlNoResults.Visible = true;
        PagedDataSource objPDS = new PagedDataSource();
        objPDS.AllowPaging = true;
        objPDS.PageSize = 16;
        objPDS.DataSource = b.DefaultView;
        if (objPDS.Count > 0)
        {
            pnlResults.Visible = true;
            pnlNoResults.Visible = false;
            objPDS.CurrentPageIndex = CurrentPage;

            lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of "
                                           + objPDS.PageCount.ToString();

         
            lnkPreviousPage.Enabled = !objPDS.IsFirstPage;
            lnkNextPage.Enabled = !objPDS.IsLastPage;

            rpttiket.DataSource = objPDS;      
            rpttiket.DataBind();

        }
                    
                }
        }
}

     public int CurrentPage
    {
        get
        {
           
            object o = this.ViewState["_CurrentPage"];
            if (o == null)
                return 0;
            else
                return (int)o;
        }
        set
        {
            this.ViewState["_CurrentPage"] = value;
        }
    }  
   
    protected void lnkPreviousPage_Click(object sender, EventArgs e)
    { //Set viewstate variable to the previous page
        CurrentPage -= 1;     
        bind();

    }
   
    protected void lnkNextPage_Click(object sender, EventArgs e)
    {
   
        CurrentPage += 1;

        //Reload control
        bind();
    }
    public void addCart(object sender, CommandEventArgs e)
    {
        aas.ticketing bk = new aas.ticketing();
        //string id = e.CommandArgument.ToString();
        bk.tiketids = Convert.ToInt32(e.CommandArgument.ToString());
        aas.tiketbl bbo = new aas.tiketbl();
        aas.tikets b = bbo.gettiketbyid(bk.tiketids);
        bk.trandestination = b.trandestination;
        bk.tranfees = b.tranfees;
        bk.tranplacestarts = b.tranplacestarts;
        ArrayList cart;
        if (Session["ShoppingCart"] != null)
        {
            cart = (ArrayList)Session["ShoppingCart"];
            int n = cart.Count, j = -1;
            for (int i = 0; i < n; i++)
            {
                if (bk.tiketids == ((aas.ticketing)cart[i]).tiketids)
                {
                    j = i;
                }
            }
            if (j > -1)
            {
                // bk.Amount = ((En.caring)cart[j]).Amount + 1;
                Label1.Text = "ban da chon ve nay roi";
                cart.RemoveAt(j);
            }
            cart.Add(bk);
        }
        else
        {
            cart = new ArrayList();
            cart.Add(bk);
        }
        Session["ShoppingCart"] = cart;
        Response.Redirect("Blank.aspx?tranid="+Session["transID"].ToString());
       // LinkButton lbtBooking = (LinkButton)ee.Item.FindControl("lbtBooking");
        
    }


    protected void rpttiket_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      //  LinkButton lbtBooking =(LinkButton) e.Item.FindControl("lbtBooking");
       // lbtBooking.Text = "";
       // lbtBooking.Visible = false;
    }
}
     