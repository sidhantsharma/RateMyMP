using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Forms_howtouse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void homeRedirect_Click(object sender, EventArgs e)
    {
        if (Session["userEmail"] != null)
        {
            Response.Redirect("Homepage.aspx");
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }
}