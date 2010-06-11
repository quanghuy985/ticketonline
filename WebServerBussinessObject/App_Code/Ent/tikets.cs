using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace aas
{
    public class tikets
    {
        private int tiketid;
        private int tranfee;
        private string tranplacestart;
        private string tranplacedestination;

        public int tiketids
        {
            get { return tiketid; }
            set { tiketid = value; }
        }
        public int tranfees
        {
            get { return tranfee; }
            set { tranfee = value; }
        }
        public string tranplacestarts
        {
            get { return tranplacestart; }
            set { tranplacestart = value; }
        }
        public string trandestination
        {
            get { return tranplacedestination; }
            set { tranplacedestination = value; }
        }
        public void tiket()
        {
            tiketid = 0;
            tranfee = 0;
            tranplacestart = "";
            tranplacedestination = "";
        }
    }
}