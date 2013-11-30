using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


public class IssuesDAL
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter dap;
    string query;

    public string[] getmpname(Int64 issueidval)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           // query = "fetchMpNameBasedOnIssueId";

            dap = new SqlDataAdapter("fetchMpNameBasedOnIssueId", con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@issueId", issueidval);
            DataSet ds = new DataSet();
            dap.Fill(ds, "tblmpdetails");
            dap.Dispose();
            string[] str = new string[2];
            string x = "";
            string y = "";

            if (ds.Tables[0].Rows.Count > 0)
            {
                x = ds.Tables[0].Rows[0][0].ToString() + " " + ds.Tables[0].Rows[0][1].ToString() + " " + ds.Tables[0].Rows[0][2].ToString();
                y = ds.Tables[0].Rows[0][3].ToString();
            }
            str[0] = x;
            str[1] = y;
            return str;
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

    public void updateReportAbuseIssue(issuesBO issuesBO)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "updateIssueReportedAsAbuse";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@guid", issuesBO.guid);
            cmd.Parameters.AddWithValue("@issueId", issuesBO.issueId);
            cmd.Parameters.AddWithValue("@enable", issuesBO.enable);
            cmd.Parameters.AddWithValue("@reportabuse", issuesBO.reportAbuseIssue);
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

    public DataTable fetchAbuseIssueReport()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "issuesReportedAsAbuse";
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


    public DataTable getIssues(Int64 mpId, Int64 NUMBER, Int64 filterType, int sortBy)
    {
        try
        {

            query = "ISSUES_FETCHING_USERCOMMENT";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@mpId", mpId);
            dap.SelectCommand.Parameters.AddWithValue("@number", NUMBER);
            dap.SelectCommand.Parameters.AddWithValue("@filterType", filterType);
            dap.SelectCommand.Parameters.AddWithValue("@sortBy", sortBy);
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

    //public DataTable getIssues(Int64 NUMBER, Int16 TYPE,Int64 mpId)
    //{
    //    try
    //    {

    //        query = "ISSUES_FETCHING";
    //        if (con.State == ConnectionState.Closed)
    //        {
    //            con.Open();
    //        }
    //        dap = new SqlDataAdapter(query, con);
    //        dap.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dap.SelectCommand.Parameters.AddWithValue("@number", NUMBER);
    //        dap.SelectCommand.Parameters.AddWithValue("@type", TYPE);
    //        dap.SelectCommand.Parameters.AddWithValue("@mpId",mpId);

    //        DataSet ds = new DataSet();
    //        dap.Fill(ds, "temp");
    //        dap.Dispose();
    //        return ds.Tables["temp"];
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        if (con.State == ConnectionState.Open)
    //            con.Close();
    //    }
    //}
 
    //public DataTable getIssues()
    //{
    //    try
    //    {
            
    //        query = "ISSUES_FETCHING";
    //        if (con.State == ConnectionState.Closed)
    //        {
    //            con.Open();
    //        }
    //      dap = new SqlDataAdapter(query,con);
    //      dap.SelectCommand.CommandType = CommandType.StoredProcedure;
    //      DataSet ds = new DataSet();
    //       dap.Fill(ds,"temp");
    //       dap.Dispose();
    //        return ds.Tables["temp"]; 
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //    finally
    //    {  if(con.State == ConnectionState.Open)
    //        con.Close();
    //    }
    //}

    //public DataTable getIssues(Int64 issueId)
    //{
    //    try
    //    {

    //        query = "ISSUESONE_FETCHING";
    //        if (con.State == ConnectionState.Closed)
    //        {
    //            con.Open();
    //        }
    //        dap = new SqlDataAdapter(query, con);
    //        dap.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dap.SelectCommand.Parameters.AddWithValue("@issueId", issueId);
    //        DataSet ds = new DataSet();
    //        dap.Fill(ds, "temp");
    //        dap.Dispose();
    //        return ds.Tables["temp"];
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        if (con.State == ConnectionState.Open)
    //            con.Close();
    //    }
    //}

    public DataTable getIssue(Int64 issueId)
    {
        try
        {

            query = "ISSUESONE_FETCHING";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@issueId", issueId);
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

    public void postIssues(issuesBO issuesbo)
    {
        try
        {

            query = "ISSUES_INSERTED";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(query,con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mpId",issuesbo.mpId);
            cmd.Parameters.AddWithValue("@guId",issuesbo.guid);
            cmd.Parameters.AddWithValue("@issueText",issuesbo.issueText);
            cmd.Parameters.AddWithValue("@PostedOn",DateTime.Now);
            cmd.Parameters.AddWithValue("@issuetype",issuesbo.issuetype);
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

    public DataTable getVoters(Int64 issueId)
    {
        try
        {

            query = "VOTERNAMES_FETCH";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@issueId", issueId);
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

    public DataTable mpSortDetails(Int64 issueId)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "MP_SORT_DETAILS";
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@issueId", issueId);
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

    public DataTable TypeOfIssue()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "ISSUE_TYPE_FETCH";
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

    //public DataTable SEARCH_AND_FILTER(string searchquery, int n, int filter1, string filter2)
    //{

    //    try
    //    {
    //        if (con.State == ConnectionState.Closed)
    //        {
    //            con.Open();
    //        }
    //        query = "SAERCH_AND_FILTER";
    //        dap = new SqlDataAdapter(query, con);
    //        dap.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dap.SelectCommand.Parameters.AddWithValue("@search", searchquery);
    //        dap.SelectCommand.Parameters.AddWithValue("@searchqty", n);
    //        dap.SelectCommand.Parameters.AddWithValue("filter1", filter1);
    //        dap.SelectCommand.Parameters.AddWithValue("filter2", filter2);
    //        DataSet ds = new DataSet();
    //        dap.Fill(ds, "temp");
    //        dap.Dispose();
    //        return ds.Tables["temp"];
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        if (con.State == ConnectionState.Open)
    //            con.Close();
    //    }
    //}

    //public DataTable ONLY_FILTER(int n, int filter1, string filter2)
    //{

    //    try
    //    {
    //        if (con.State == ConnectionState.Closed)
    //        {
    //            con.Open();
    //        }
    //        query = "ONLY_FILTER";
    //        dap = new SqlDataAdapter(query, con);
    //        dap.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        dap.SelectCommand.Parameters.AddWithValue("@searchqty", n);
    //        dap.SelectCommand.Parameters.AddWithValue("filter1", filter1);
    //        dap.SelectCommand.Parameters.AddWithValue("filter2", filter2);
    //        DataSet ds = new DataSet();
    //        dap.Fill(ds, "temp");
    //        dap.Dispose();
    //        return ds.Tables["temp"];
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        if (con.State == ConnectionState.Open)
    //            con.Close();
    //    }
    //}


    public DataTable SEARCH_AND_FILTER(string searchquery,int n, int filterDate,Int64 filterType,Int16 filterParty)
    {

        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "SAERCH_AND_FILTER1";
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@search", searchquery);
            dap.SelectCommand.Parameters.AddWithValue("@searchqty", n);
            dap.SelectCommand.Parameters.AddWithValue("@filterDate", filterDate);
            dap.SelectCommand.Parameters.AddWithValue("@filterType", filterType);
            dap.SelectCommand.Parameters.AddWithValue("@filterParty", filterParty);
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

    public DataTable ONLY_FILTER(int n, int filterDate, Int64 filterType, Int16 filterParty)
    {

        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "ONLY_FILTER1";
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@searchqty", n);
            dap.SelectCommand.Parameters.AddWithValue("@filterDate", filterDate);
            dap.SelectCommand.Parameters.AddWithValue("@filterType", filterType);
            dap.SelectCommand.Parameters.AddWithValue("@filterParty", filterParty); 
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
    public DataTable ONLY_FILTER_USERCOMMENT(int n, int filterDate, Int64 filterType, Int16 filterPopularity)
    {

        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "ONLY_FILTER_USERCOMMENT";
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@searchqty", n);
            dap.SelectCommand.Parameters.AddWithValue("@filterDate", filterDate);
            dap.SelectCommand.Parameters.AddWithValue("@filterType", filterType);
            dap.SelectCommand.Parameters.AddWithValue("@filterPopularity", filterPopularity);
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

}

