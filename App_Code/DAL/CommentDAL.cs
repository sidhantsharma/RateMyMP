using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CommentDAL
/// </summary>
public class CommentDAL
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter dap;
    string query;

	public CommentDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void updateReportAbuseComment(commentsBO commentsBO)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "updateCommentReportedAsAbuse";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@guid", commentsBO.guid);
            cmd.Parameters.AddWithValue("@commentId", commentsBO.commentId);
            cmd.Parameters.AddWithValue("@enable", commentsBO.enable);
            cmd.Parameters.AddWithValue("@reportabuse", commentsBO.reportAbuseComment);
            cmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
    public DataTable fetchAbuseCommentReport()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "commentReportedAsAbuse";
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            dap.Fill(ds, "temp");
            dap.Dispose();
            return ds.Tables["temp"];
        }
        catch
        {
            throw;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        
    }
    public DataTable getComments(Int64 issueId)
    {
        try
        {

            query = "COMMENT_FETCHING";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@issueId",issueId );
            DataSet ds = new DataSet();
            dap.Fill(ds, "temp");
            con.Close();
            dap.Dispose();
            return ds.Tables["temp"];
        }
        catch
        {
            throw;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }

    public DataTable getComment(Int64 commentId)
    {
        try
        {

            query = "COMMENTONE_FETCHING";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@commentId", commentId);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dap.Dispose();
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }

    public void postComment(commentsBO commentbo)
    {
        try
        {

            query = "COMMENT_INSERTED";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@guid", commentbo.guid);
            cmd.Parameters.AddWithValue("@issueId", commentbo.issueId);
            cmd.Parameters.AddWithValue("@comment", commentbo.comment);
            cmd.Parameters.AddWithValue("@postedOn", DateTime.Now);
            cmd.ExecuteNonQuery();

        }
        catch
        {
            throw;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

    }

}