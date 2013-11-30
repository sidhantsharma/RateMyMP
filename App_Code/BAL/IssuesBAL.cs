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
/// <summary>

/// </summary>
public class IssuesBAL
{
    private IssuesDAL ob = new IssuesDAL();
    public IssuesBAL()
    {
    }
    public string[] getmpname(Int64 issueidval)
    {
        try
        {
            return ob.getmpname(issueidval);
        }
        catch
        {
            throw;
        }
        finally
        {

        }
    }

    public void updateReportAbuseIssue(issuesBO issuesBO)
    {
        try
        {
            ob.updateReportAbuseIssue(issuesBO);
        }
        catch
        {

        }
        finally
        {

        }

    }
    public DataTable fetchAbuseIssueReport()
    {
        try
        {
            return ob.fetchAbuseIssueReport();

        }
        catch
        {
            throw;
        }
        finally
        {

        }
    }
    public DataTable getIssues(Int64 mpId,int number, Int64 filtertype,int sortBy)
    {
        try
        {
            return ob.getIssues(mpId,number,filtertype,sortBy);
        }
        catch
        {
            throw;
        }
        finally
        {
        }
    }
    public DataTable getIssue(Int64 issueId)
    {
        try
        {
            return ob.getIssue(issueId);
        }
        catch
        {
            throw;
        }
        finally
        {
        }
    }
    public DataTable getVoters(Int64 issueId)
    {
        try
        {
            return ob.getVoters(issueId);
        }
        catch
        {
            throw;
        }
        finally
        {
        }
    }
    public void postIssue(issuesBO issuesbo)
    {
        try
        {
            ob.postIssues(issuesbo);
        }
        catch
        {
            throw;
        }
        finally
        {
        }
    }

    public DataTable TypeOfIssue()
    {
        try
        {
            return ob.TypeOfIssue();
        }
        catch
        {
            throw;
        }
        finally
        {
        }
    }

    public DataTable SEARCH_AND_FILTER(string searchquery, int n, int filterDate,Int64 filterType,Int16 filterParty)
    {
        try
        {
            return ob.SEARCH_AND_FILTER(searchquery, n,filterDate,filterType,filterParty);
        }
        catch
        {
            throw;
        }
        finally { }
    }
    public DataTable ONLY_FILTER(int n, int filterDate,Int64 filterType,Int16 filterParty)
    {
        try
        {
            return ob.ONLY_FILTER(n,filterDate,filterType,filterParty);
        }
        catch
        {
            throw;
        }
        finally { }
    }

    public DataTable mpSortDetails(Int64 issueId)
    {
        try
        {
            return ob.mpSortDetails(issueId);
        }
        catch
        {
            throw;
        }
        finally
        {
        }

    }

 }
