using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ReportDAL
/// </summary>
public class ReportDAL
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter dap;
    string query;
    public ReportDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Issue_Report(Int64 issueId)
    {
        try
        {

            query = "ISSUES_REPORT";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@issueId", issueId);
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
 public void Comment_Report(Int64 commentId)
    {
        try
        {

            query = "COMMENT_REPORT";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@commentId",commentId);
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