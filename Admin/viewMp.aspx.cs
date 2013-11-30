using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
//using rateMyMp.App_Code.BO;

public partial class Admin_viewMp : System.Web.UI.Page
{

    countryBAL CountryBAL = new countryBAL();
    countryBO CountryBO = new countryBO();
    stateBO StateBO = new stateBO();
    constituencyBO ConstituencyBO = new constituencyBO();
    mpDetailsBAL mpDetailsBAL = new mpDetailsBAL();
    StateBAL stateBAL = new StateBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadcountry();
        }

    }
    protected void loadcountry()
    {
        dropCountry.Items.Clear();
        dropCountry.DataSource = mpDetailsBAL.loadCountry();
        dropCountry.DataTextField = "country";
        dropCountry.DataValueField = "countryId";
        dropCountry.DataBind();
        dropCountry.Items.Insert(0, new ListItem("Select Country", "0"));

    }


    protected void dropstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropstate.SelectedIndex != 0)
        {
            byte stateId = byte.Parse(dropstate.SelectedValue);
            dropconstituency.DataSource = mpDetailsBAL.loadConstituency(stateId);
            dropconstituency.DataTextField = "constituency";
            dropconstituency.DataValueField = "constituencyId";
            dropconstituency.DataBind();
            dropconstituency.Items.Insert(0, new ListItem("Select Constituency", "0"));

            // LOAD MP IN GRID
            CountryBO.countryId = int.Parse(dropCountry.SelectedValue.ToString());
            StateBO.stateId = byte.Parse(dropstate.SelectedValue.ToString());
            ConstituencyBO.constituencyId=0;
            grdViewMP.DataSource = (DataTable)(mpDetailsBAL.fetchMPBasedOnStateorConstituency(CountryBO, StateBO,ConstituencyBO));
            grdViewMP.DataBind();
            grdViewMP.Visible = true;


        }
        else
        {
            dropconstituency.Items.Clear();
            dropconstituency.Items.Insert(0, new ListItem("Select Constituency", "0"));
        }
    }
    protected void dropconstituency_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropstate.SelectedIndex != 0)
        {
           
          // LOAD MP IN GRID
            CountryBO.countryId = int.Parse(dropCountry.SelectedValue.ToString());
            StateBO.stateId = byte.Parse(dropstate.SelectedValue.ToString());

           ConstituencyBO.constituencyId = Int16.Parse(dropconstituency.SelectedValue);
           grdViewMP.DataSource = (DataTable)(mpDetailsBAL.fetchMPBasedOnStateorConstituency(CountryBO, StateBO,ConstituencyBO));
           grdViewMP.DataBind();
           grdViewMP.Visible = true;
        }
    }
    protected void dropCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropCountry.SelectedIndex != 0)
        {

            int conutryId = Convert.ToInt32(dropCountry.SelectedValue);
            dropstate.Items.Clear();
            DataTable dt = mpDetailsBAL.loadState(conutryId);
            dropstate.DataSource = dt;
            dropstate.DataTextField = "state";
            dropstate.DataValueField = "stateId";
            dropstate.DataBind();
            dropstate.Items.Insert(0, new ListItem("Select State", "0"));
        }
    }
}