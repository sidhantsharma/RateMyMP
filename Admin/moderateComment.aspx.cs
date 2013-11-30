using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Admin_moderateComment : System.Web.UI.Page
{
    CommentBAL commentBAL = new CommentBAL();
    commentsBO commentsBO = new commentsBO();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData(); 
            // gridviewReportAbuseComment.da
        }

    }
    private void  bindData()
    {
        gridviewReportAbuseComment.DataSource = (DataTable)commentBAL.fetchAbuseCommentReport();
        gridviewReportAbuseComment.DataBind();
    }
   
  
    protected void gridviewReportAbuseComment_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
           
            commentsBO.guid = Int64.Parse(((Label)gridviewReportAbuseComment.Rows[e.RowIndex].FindControl("lblGuid")).Text);
            commentsBO.commentId = Int64.Parse(((Label)gridviewReportAbuseComment.Rows[e.RowIndex].FindControl("lblCommentId")).Text);
            CheckBox var = ((CheckBox)gridviewReportAbuseComment.Rows[e.RowIndex].Cells[3].Controls[1]); // under 
           // CheckBox var = ((CheckBox)gridviewReportAbuseComment.Rows[e.RowIndex].Cells[3].FindControl("chkEnableDisable1"));
            
            if (var.Checked==true)
            {
                commentsBO.enable = true;
            }
            else
            {
                commentsBO.enable = false;
            }
            commentsBO.reportAbuseComment = false;
            commentBAL.updateReportAbuseComment(commentsBO);
            bindData();
            gridviewReportAbuseComment.DataBind();

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