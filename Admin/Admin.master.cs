﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["adminId"] == null)
        //{
        //    Response.Redirect("../Default.aspx");
        //}
    }
    protected void logout_Click(object sender, EventArgs e)
    {
        if (Session["adminId"] != null)
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");
        }
    }
}
