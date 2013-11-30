using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_addCountry : System.Web.UI.Page
{
    countryBAL CountryBAL = new countryBAL();
    countryBO CountryBO = new countryBO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        CountryBO.country = txtCountry.Text;
       bool res= CountryBAL.countryInsert(CountryBO);
       if (res == true)
       {
           ClientScript.RegisterStartupScript(this.GetType(),"myfunction","countryInserted()",true);
       }
       else
       {
           ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "countryInsertionFail()", true);
       }

    }
}