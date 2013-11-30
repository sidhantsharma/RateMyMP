using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_viewConstituencies : System.Web.UI.Page
{
    countryBAL CountryBal = new countryBAL();
    ConstituencyBAL constituencyBal = new ConstituencyBAL();
    constituencyBO ConstituencyBO = new constituencyBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dropCountry.Items.Clear();                       
            dropCountry.DataSource=CountryBal.load_country();
            dropCountry.DataTextField="country";
            dropCountry.DataValueField = "countryId";            
            dropCountry.DataBind();
            dropCountry.Items.Insert(0, new ListItem("Select Country", "0"));
            dropCountry.SelectedIndex = 0;
            
        }
    }
    protected void dropCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        StateBAL StateBal=new StateBAL();
        dropState.DataSource = StateBal.getData();
        dropState.DataTextField = "State";
        dropState.DataValueField = "stateId";
        dropState.DataBind();
        dropState.Items.Insert(0,new ListItem("Select State","0"));
        dropState.SelectedIndex = 0;

    }
    protected void dropState_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }


    public void FillGrid()
    {
        DataTable dt = constituencyBal.getData(short.Parse(dropState.SelectedValue.ToString()));
        if (dt.Rows.Count > 0)
        {
            grdConstituency.DataSource = dt;
            grdConstituency.DataBind();
        }
        else
        {
            dt.Rows.Add(dt.NewRow());
            grdConstituency.DataSource = dt;
            grdConstituency.DataBind();

            int TotalColumns = grdConstituency.Rows[0].Cells.Count;
            grdConstituency.Rows[0].Cells.Clear();
            grdConstituency.Rows[0].Cells.Add(new TableCell());
            grdConstituency.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            grdConstituency.Rows[0].Cells[0].Text = "No Record Found";
        }
    }




    protected void grdConstituency_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable dt = constituencyBal.getData(short.Parse(dropState.SelectedValue.ToString()));
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState == (DataControlRowState.Edit |DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
            {
                Label lblId = (Label)e.Row.FindControl("lblId");
                if (lblId != null)
                {
                    lblId.Text = dt.Rows[e.Row.RowIndex][0].ToString();
                }

                TextBox txtConstituency = (TextBox)e.Row.FindControl("txtConstituency");
                if (txtConstituency != null)
                {
                    txtConstituency.Text = dt.Rows[e.Row.RowIndex][1].ToString();
                }
            }
            else if (e.Row.RowState ==DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                Label lblId = (Label)e.Row.FindControl("lblId");
                if (lblId != null)
                {
                    lblId.Text = dt.Rows[e.Row.RowIndex][0].ToString();
                }
                Label lblConstituency = (Label)e.Row.FindControl("lblConstituency");
                if (lblConstituency != null)
                {
                    lblConstituency.Text = dt.Rows[e.Row.RowIndex][1].ToString();
                }
            }
        }
    }
    protected void grdConstituency_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdConstituency.EditIndex = -1;
        FillGrid();
    }
    protected void grdConstituency_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdConstituency.EditIndex = e.NewEditIndex;
        FillGrid();
    }
    protected void grdConstituency_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblId = (Label)grdConstituency.Rows[e.RowIndex].FindControl("lblId");
        TextBox txtConstituency = (TextBox)grdConstituency.Rows[e.RowIndex].FindControl("txtConstituency");
        ConstituencyBO.StateId = byte.Parse(dropState.SelectedValue);
        ConstituencyBO.constituencyId = Int16.Parse(lblId.Text);
        ConstituencyBO.constituency = txtConstituency.Text;
        constituencyBal.updateConstituency(ConstituencyBO);
        grdConstituency.EditIndex = -1;
        FillGrid();
    }
}