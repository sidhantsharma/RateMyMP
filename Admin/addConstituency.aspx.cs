using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_addConstituency : System.Web.UI.Page
{
    constituencyBO constituencyBO = new constituencyBO();
    ConstituencyBAL constituencyBAL = new ConstituencyBAL();
    mpDetailsBAL mpDetailsBAL = new mpDetailsBAL();
    countryBAL countryBAL = new countryBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("OnClick","javascript:return validateAll()");
        if(!IsPostBack)
        {
            // load the country
            dropCountry.Items.Clear();
            dropCountry.DataSource = (DataTable)(countryBAL.load_country());// load the country
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
            constituencyBO.StateId = byte.Parse(dropState.SelectedValue.ToString());
            constituencyBO.constituency = txtconstituency.Text;
            bool res = constituencyBAL.constituencyInsert(constituencyBO);
            if (res == true)
            {
                dropState.SelectedIndex = 0;
                dropCountry.SelectedIndex = 0;
                txtconstituency.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "constituencyInserted()", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "constituencyInsertedFail()", true);
            }
        }
    }
    protected void dropCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropCountry.SelectedIndex != 0)
        {
            dropState.Items.Clear();
            int conutryId = Convert.ToInt32(dropCountry.SelectedValue);
            dropState.DataSource = (DataTable)(mpDetailsBAL.loadState(conutryId));// load the state
            dropState.DataTextField = "state";
            dropState.DataValueField = "stateId";
            dropState.DataBind();
            dropState.Items.Insert(0, new ListItem("Select State", "0"));
        }
    }
}