using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Default : System.Web.UI.Page
{
    adminLoginBO adminLoginBO = new adminLoginBO();
    adminLoginBAL adminLoginBAL = new adminLoginBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnLogin.Attributes.Add("OnClick", "javascript: return loginValueCheck()");
        btnCancel.Attributes.Add("OnClick", "javascript: return loginCancel()");
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        adminLoginBO.adminId = txtUserName.Text;
        adminLoginBO.password = txtPassword.Text;
        bool res = adminLoginBAL.adminLoginCheck(adminLoginBO);
        if (res == true)
        {
            Session["adminId"] = adminLoginBO.adminId;
            Response.Redirect("Welcome.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(),"myfunction","wrongcredential()",true);
        }
    }
}