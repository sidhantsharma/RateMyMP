using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportBAL
/// </summary>
public class ReportBAL
{
    private ReportDAL reportdal = new ReportDAL();
	public ReportBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Issue_Report(Int64 issueId)
    {
        reportdal.Issue_Report(issueId);
    }
    public void Comment_Report(Int64 commentId)
    {
        reportdal.Comment_Report(commentId);
    }
}