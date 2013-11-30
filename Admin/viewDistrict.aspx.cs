using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_viewDistrict : System.Web.UI.Page
{

    countryBAL CountryBAL = new countryBAL();
    mpDetailsBAL mpDetailsBAL = new mpDetailsBAL();
    countryBO COuntryBO = new countryBO();
    districtBO DistrictBO = new districtBO();
    districtBAL districtBAL = new districtBAL();
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
    public void FillGrid()
    {
        DataTable data = mpDetailsBAL.loadDistrict(byte.Parse(dropState.SelectedValue));
        if (data.Rows.Count > 0)
        {
            grdDistrict.DataSource = data;
            grdDistrict.DataBind();
        }
        else
        {
            data.Rows.Add(data.NewRow());
            grdDistrict.DataSource = data;
            grdDistrict.DataBind();

            int TotalColumns = grdDistrict.Rows[0].Cells.Count;
            grdDistrict.Rows[0].Cells.Clear();
            grdDistrict.Rows[0].Cells.Add(new TableCell());
            grdDistrict.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            grdDistrict.Rows[0].Cells[0].Text = "No Record Found";
        }
    }



    protected void grdDistrict_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable data = mpDetailsBAL.loadDistrict(byte.Parse(dropState.SelectedValue));

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if ((e.Row.RowState == (DataControlRowState.Edit |DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
            {
                Label lblId = (Label)e.Row.FindControl("lblId");
                if (lblId != null)
                {
                    lblId.Text = (String)data.Rows[e.Row.RowIndex]["districtId"].ToString();
                }

                TextBox txtDistrict = (TextBox)e.Row.FindControl("txtDistrict");
                if (txtDistrict != null)
                {
                    txtDistrict.Text = (String)data.Rows[e.Row.RowIndex]["districtName"].ToString();
                }
            }
            else if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                Label lblId = (Label)e.Row.FindControl("lblId");
                if (lblId != null)
                {
                    lblId.Text = (String)data.Rows[e.Row.RowIndex]["districtId"].ToString();
                }

                Label lblDistrict = (Label)e.Row.FindControl("lblDistrict");
                if (lblDistrict != null)
                {
                    lblDistrict.Text = (String)data.Rows[e.Row.RowIndex]["districtName"].ToString();
                }
            }
        }
    }


    protected void grdDistrict_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Label lblId = (Label)grdDistrict.Rows[e.RowIndex].FindControl("lblId");
        TextBox txtDistrict = (TextBox)grdDistrict.Rows[e.RowIndex].FindControl("txtDistrict");
        DistrictBO.stateId = byte.Parse(dropState.SelectedValue);
        DistrictBO.districtId = byte.Parse(lblId.Text);
        DistrictBO.districtName = txtDistrict.Text;
        districtBAL.districtUpdate(DistrictBO);
        grdDistrict.EditIndex = -1;
        FillGrid();
    }
    protected void grdDistrict_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdDistrict.EditIndex = e.NewEditIndex;
        FillGrid();
    }

    protected void grdDistrict_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdDistrict.EditIndex = -1;
        FillGrid();
    }
    protected void dropCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropCountry.SelectedIndex != 0)
        {
            dropState.Items.Clear();
            int conutryId = Convert.ToInt32(dropCountry.SelectedValue);
            dropState.DataSource = (DataTable)(mpDetailsBAL.loadState(conutryId));
            dropState.DataTextField = "state";
            dropState.DataValueField = "stateId";
            dropState.DataBind();
            dropState.Items.Insert(0, new ListItem("Select State", "0"));
        }
    }
    protected void dropState_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }


    protected void grdDistrict_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        FillGrid();
    }
}