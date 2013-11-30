using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_view_viewstates : System.Web.UI.Page
{
    countryBAL CountryBAL = new countryBAL();
    mpDetailsBAL mpDetailsBAL = new mpDetailsBAL();
    StateBAL STATEBAL = new StateBAL();
    stateBO StateBO = new stateBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dropCountry.Items.Clear();
            dropCountry.DataSource = (DataTable)(CountryBAL.load_country());
            dropCountry.DataTextField = "country";
            dropCountry.DataValueField = "countryId";
            dropCountry.DataBind();
            dropCountry.Items.Insert(0, new ListItem("Select Country", "0"));
        }
    }
    protected void dropCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillGrid();

    }
    public void fillGrid()
    {
        if (dropCountry.SelectedIndex != 0)
        {
            int countryId = Convert.ToInt32(dropCountry.SelectedValue);
            DataTable dt = mpDetailsBAL.loadState(countryId);
            grdState.DataSource = dt;
            grdState.DataBind();
            grdState.Visible = true;
        }

    }
    protected void grdState_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblId = (Label)grdState.Rows[e.RowIndex].FindControl("lblId");
        TextBox  txtStateName = (TextBox)grdState.Rows[e.RowIndex].FindControl("txtStateName");
        StateBO.state = txtStateName.Text;
        StateBO.stateId = byte.Parse(lblId.Text);
        StateBO.countryId = int.Parse(dropCountry.SelectedValue);
        STATEBAL.updateState(StateBO);
        grdState.EditIndex = -1;
        fillGrid();

    }
    protected void grdState_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdState.EditIndex = e.NewEditIndex;
        fillGrid();


    }


    protected void grdState_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (dropCountry.SelectedIndex != 0)
        {
            int countryId = Convert.ToInt32(dropCountry.SelectedValue);
            DataTable dt = mpDetailsBAL.loadState(countryId);

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.RowState == (DataControlRowState.Edit |DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
                    {
                        Label lblId = (Label)e.Row.FindControl("lblId");
                        if (lblId != null)
                        {
                            lblId.Text = (String)dt.Rows[e.Row.RowIndex]["stateId"].ToString();
                        }
                        TextBox txtStateName = (TextBox)e.Row.FindControl("txtStateName");
                        if (txtStateName != null)
                        {
                            txtStateName.Text = (String)dt.Rows[e.Row.RowIndex]["state"].ToString();
                        }
                    }

                    else if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {

                        Label lblId = (Label)e.Row.FindControl("lblId");
                        if (lblId != null)
                        {
                            lblId.Text = (String)dt.Rows[e.Row.RowIndex]["stateId"].ToString();
                        }
                        Label lblStateName = (Label)e.Row.FindControl("lblStateName");
                        if (lblStateName != null)
                        {
                            lblStateName.Text = (String)dt.Rows[e.Row.RowIndex]["state"].ToString();
                        }
                    }
                }

        }

    }

    protected void grdState_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdState.EditIndex = -1;
        fillGrid();
    }
}




















