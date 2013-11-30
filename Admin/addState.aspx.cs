using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Admin_addState : System.Web.UI.Page
{
    stateBO StateBO = new stateBO();
    countryBAL CountryBAL = new countryBAL();
    StateBAL stateBAL = new StateBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("OnClick","javascript:return checkdata()");
        if(!IsPostBack)
        {
            dropCountry.Items.Clear();
            dropCountry.DataSource = (DataTable)(CountryBAL.load_country());
            dropCountry.DataTextField = "country";
            dropCountry.DataValueField = "countryId";
            dropCountry.DataBind();
            dropCountry.Items.Insert(0, new ListItem("Select Country", "0"));
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (dropCountry.SelectedIndex != 0)
            {
                StateBO.countryId = int.Parse(dropCountry.SelectedValue.ToString());
                StateBO.noOfConstituency = byte.Parse(txtNoConsti.Text);
                StateBO.state = txtstate.Text;
                bool res = stateBAL.stateInsert(StateBO);
                if (res == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "stateInserted()", true);
                }
                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "stateInsertedFail()", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "selectCountry()", true);
            }
        }
    }
    protected void dropCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}