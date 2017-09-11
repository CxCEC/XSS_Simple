using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XSS_Demo
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String s1 = "", s2 = "";
            try
            {
                s1 = Request.QueryString[0]; // unsafe
				s1 = MyClass.Sanitize(s1);
            }
            catch { }

            try
            {
                s2 = Request.QueryString[1];
            }
            catch { }

            Response.Write(s1 + "<br/>" + System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(s2, true));

        }
    }
}