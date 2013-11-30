using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_viewParty : System.Web.UI.Page
{

    countryBAL CountryBAL = new countryBAL();
    PartyBAL partyBal = new PartyBAL();
    partyBO PartyBO = new partyBO();
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

        PartyBO.countryId = int.Parse(dropCountry.SelectedValue);
        DataTable data = partyBal.getData(PartyBO);
        if (data.Rows.Count > 0)
        {
            grdParty.DataSource = data;
            grdParty.DataBind();
        }
        else
        {
            data.Rows.Add(data.NewRow());
            grdParty.DataSource = data;
            grdParty.DataBind();

            int TotalColumns = grdParty.Rows[0].Cells.Count;
            grdParty.Rows[0].Cells.Clear();
            grdParty.Rows[0].Cells.Add(new TableCell());
            grdParty.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            grdParty.Rows[0].Cells[0].Text = "No Record Found";
        }
    }



    protected void grdParty_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        PartyBO.countryId = int.Parse(dropCountry.SelectedValue);
        DataTable data = partyBal.getData(PartyBO);

        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if ((e.Row.RowState == (DataControlRowState.Edit |DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
            {
                Label lblId = (Label)e.Row.FindControl("lblId");
                if (lblId != null)
                {
                    lblId.Text = (String)data.Rows[e.Row.RowIndex]["partyId"].ToString();
                }

                TextBox txtParty = (TextBox)e.Row.FindControl("txtParty");
                if (txtParty != null)
                {
                    txtParty.Text = (String)data.Rows[e.Row.RowIndex]["partyName"].ToString();
                }

                TextBox txtabb = (TextBox)e.Row.FindControl("txtabb");
                if (txtabb != null)
                {
                    txtabb.Text = (String)data.Rows[e.Row.RowIndex]["Abbreviation"].ToString();
                }

                TextBox txtMem = (TextBox)e.Row.FindControl("txtMem");
                if (txtMem != null)
                {
                    txtMem.Text = (String)data.Rows[e.Row.RowIndex]["totalMember"].ToString();
                }
            }
            else if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                Label lblId = (Label)e.Row.FindControl("lblId");
                if (lblId != null)
                {
                    lblId.Text = (String)data.Rows[e.Row.RowIndex]["partyId"].ToString();
                }

                Label lblParty = (Label)e.Row.FindControl("lblParty");
                if (lblParty != null)
                {
                    lblParty.Text = (String)data.Rows[e.Row.RowIndex]["partyName"].ToString();
                }

                Label lblabb = (Label)e.Row.FindControl("lblabb");
                if (lblabb != null)
                {
                    lblabb.Text = (String)data.Rows[e.Row.RowIndex]["Abbreviation"].ToString();
                }

                Label lblMem = (Label)e.Row.FindControl("lblMem");
                if (lblMem != null)
                {
                    lblMem.Text = (String)data.Rows[e.Row.RowIndex]["totalMember"].ToString();
                }
            }
        }
    }


    protected void grdParty_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Label lblId = (Label)grdParty.Rows[e.RowIndex].FindControl("lblId");
        TextBox txtParty = (TextBox)grdParty.Rows[e.RowIndex].FindControl("txtParty");
        TextBox txtabb = (TextBox)grdParty.Rows[e.RowIndex].FindControl("txtabb");
        TextBox txtMem = (TextBox)grdParty.Rows[e.RowIndex].FindControl("txtMem");
        PartyBO.countryId = int.Parse(dropCountry.SelectedValue);
        PartyBO.partyId = byte.Parse(lblId.Text);
        PartyBO.partyName = txtParty.Text;
        PartyBO.abbreviation = txtabb.Text;
        PartyBO.totalMember = int.Parse(txtMem.Text);
        partyBal.partyUpdate(PartyBO);
        grdParty.EditIndex = -1;
        FillGrid();
    }
    protected void grdParty_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdParty.EditIndex = e.NewEditIndex;
        FillGrid();
    }
    
    protected void grdParty_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdParty.EditIndex = -1;
        FillGrid();
    }
    protected void dropCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
}