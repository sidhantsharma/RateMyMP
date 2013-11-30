using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_addParty : System.Web.UI.Page
{
    countryBAL CountryBAL = new countryBAL();
    PartyBAL partyBAL = new PartyBAL();
    partyBO PartyBO = new partyBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("OnClick","javascript:return partyValidate()");
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
        if(Page.IsValid)
        {
            PartyBO.partyName = txtParty.Text;
            PartyBO.totalMember = int.Parse(txtTotMembers.Text);
            PartyBO.abbreviation = txtabbr.Text;
            PartyBO.countryId = int.Parse(dropCountry.SelectedValue.ToString());
            bool res= partyBAL.partyInsert(PartyBO);
            if (res == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "partyInserted()", true);
                txtParty.Text = "";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "partyInsertedFail()", true);
            }
        }
        
    }
}