using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_moderateIssues : System.Web.UI.Page
{
    IssuesBAL issueBAL = new IssuesBAL();
    issuesBO issueBO = new issuesBO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bindData();
        }
    }
    private void bindData()
    {
        //girdviewIssueReportedAbuse
        girdviewIssueReportedAbuse.DataSource = (DataTable)issueBAL.fetchAbuseIssueReport();
        girdviewIssueReportedAbuse.DataBind();
    }
    protected void girdviewIssueReportedAbuse_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {

            issueBO.guid = Int64.Parse(((Label)girdviewIssueReportedAbuse.Rows[e.RowIndex].FindControl("lblGuid")).Text);
            issueBO.issueId = Int64.Parse(((Label)girdviewIssueReportedAbuse.Rows[e.RowIndex].FindControl("lblIssueId")).Text);
            CheckBox var = ((CheckBox)girdviewIssueReportedAbuse.Rows[e.RowIndex].Cells[3].Controls[1]); // under 
            // CheckBox var = ((CheckBox)gridviewReportAbuseComment.Rows[e.RowIndex].Cells[3].FindControl("chkEnableDisable1"));

            if (var.Checked == true)
            {
                issueBO.enable = true;
            }
            else
            {
                issueBO.enable = false;
            }
            issueBO.reportAbuseIssue = false;
            issueBAL.updateReportAbuseIssue(issueBO);
            bindData();
            girdviewIssueReportedAbuse.DataBind();

        }
        catch (Exception ex)
        {
            //((Label)(Page.FindControl("lblMessage"))).Text = ex.Message.ToString();
        }
        finally
        {

        }
    }
}