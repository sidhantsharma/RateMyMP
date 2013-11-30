using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CommentBAL
/// </summary>
public class CommentBAL
{
    private CommentDAL commentdal = new CommentDAL();
	public CommentBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void updateReportAbuseComment(commentsBO commmentsBO)
    {
        try
        {
            commentdal.updateReportAbuseComment(commmentsBO);
        }
        catch
        {

        }
        finally
        {

        }

    }
    public DataTable fetchAbuseCommentReport()
    {
        try
        {
            return commentdal.fetchAbuseCommentReport();
        }
        catch
        {
            throw;
        }
        finally
        {

        }
    }
    public DataTable getComments(Int64 issueId)
    {
        try
        {
            return commentdal.getComments(issueId);
        }
        catch
        {
            throw;
        }
        finally
        {

        }
    }
    public DataTable getComment(Int64 commentId)
    {
        try
        {
            return commentdal.getComment(commentId);
        }
        catch
        {
            throw;
        }
        finally
        {

        }
    }
   
    public void postComment(commentsBO commentbo)
    {
        commentdal.postComment(commentbo);
    }
}