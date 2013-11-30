using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;// name space to use the concept of json

public partial class webservices : System.Web.UI.Page
{
    private ConstituencyBAL constituency = new ConstituencyBAL();
    private StateBAL statebal = new StateBAL();
    private mpDetailsBAL mpdetails = new mpDetailsBAL();
    private IssuesBAL issuesbal = new IssuesBAL();
   
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Request.QueryString["Key"] != null)
        {
            if (Request.QueryString["Key"] == "state")
            {
                Response.Write(selectState()); /*  All states */
            }
            else if (Request.QueryString["Key"] == "mp")
            {
                if (Request.QueryString["constituency"] != null)
                {
                    Response.Write(selectmp(Convert.ToInt16(Request.QueryString["constituency"]))); /* mp fetch based on constituency*/
                }
            }
            else if (Request.QueryString["Key"] == "constituency")
            {
                if (Request.QueryString["stateId"] != null)
                {
                    Response.Write(selectConstituency(Convert.ToInt16(Request.QueryString["stateId"].ToString()))); /* fetch constituency based on stateId */
                }
            }
            else if (Request.QueryString["Key"] == "issues")
            {

                if (Request.QueryString["mpId"] != null && Request.QueryString["mode"] != null)
                {

                    Response.Write(getIssues(50, Convert.ToInt16(Request.QueryString["mode"]), Convert.ToInt64(Request.QueryString["mpId"])));  /*  fetch random issues */

                }
                else if (Request.QueryString["mpId"] != null && Request.QueryString["guid"] != null && Request.QueryString["issue"] != null)
                {

                    Response.Write(postIssue(Convert.ToInt64(Request.QueryString["mpId"]), Convert.ToInt64(Request.QueryString["guId"]), Request.QueryString["issue"]));  /*  fetch random issues */

                }
            }
            else if (Request.QueryString["key"] == "supportDeny")
            {
                if (Request.QueryString["issueId"] != null && Request.QueryString["guId"] != null && Request.QueryString["val"] != null)
                {
                    Response.Write(supportDeny(Convert.ToInt64(Request.QueryString["issueId"]), Convert.ToInt64(Request.QueryString["guId"]), Request.QueryString["val"]));
                }
            }
            else if (Request.QueryString["key"] == "comments")
            {
                if (Request.QueryString["issueId"] != null && Request.QueryString["guId"] != null && Request.QueryString["comment"] != null)
                {
                    Response.Write(postComment(Convert.ToInt64(Request.QueryString["issueId"]), Convert.ToInt64(Request.QueryString["guId"]), Request.QueryString["comment"]));
                }
                else if (Request.QueryString["issueId"] != null)
                {
                    Response.Write(getComments(Convert.ToInt64(Request.QueryString["issueId"])));
                }
                
            }
            else if (Request.QueryString["key"] == "likedislike")
            {
                if (Request.QueryString["commentId"] != null && Request.QueryString["guId"] != null && Request.QueryString["val"] != null)
                {
                    Response.Write(likeDislike(Convert.ToInt64(Request.QueryString["commentId"]), Convert.ToInt64(Request.QueryString["guId"]), Request.QueryString["val"]));
                }
            }

        }

    }

    private string selectState()
    {
        DataTable dt = new DataTable();
        dt = (DataTable)statebal.getData();
        return ConvertToJason(dt);
    }
    private string selectConstituency(Int16 stateId)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)constituency.getData(stateId);
        return ConvertToJason(dt);
    }
    private string selectmp(Int16 constituency)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)mpdetails.getData(constituency);
        return ConvertToJason(dt);

    }
    private string getIssues(Int64 number, Int16 mode, Int64 mpId)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)issuesbal.getIssues(mpId,50,0,0);
        if (dt.Rows.Count != 0)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                DataTable idt = (DataTable)issuesbal.getIssue(Convert.ToInt64(dr[0]));
                if (idt.Rows.Count != 0)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in idt.Columns)
                    {
                        row.Add(col.ColumnName.Trim(), idt.Rows[0][col]);
                    }
                    rows.Add(row);
                }
            }
            return js.Serialize(rows);
        }
        return "[]";
    }
    private string postIssue(Int64 mpId ,Int64 guId , string issue)
    {
        if (issue != " ")
        {
            issuesBO issuebo = new issuesBO();
            issuebo.mpId = mpId;
            issuebo.guid = guId;
            issuebo.issueText = issue;
            issuesbal.postIssue(issuebo);
            return "issue posted";
        }
        return "eRRoR";
    }
    private string supportDeny(Int64 issueId, Int64 guId, string val)
    {
        SupportDenyBAL supportdenybal = new SupportDenyBAL();
        supportDenyBO supportdenybo = new supportDenyBO();
        supportdenybo.issueId = issueId;
        supportdenybo.guid = guId;
        supportdenybo.supportDeny = true;
        if (val != "")
        {
            if (val.ToString() == "support")
                supportdenybo.supportDeny = true;
            else if (val.ToString() == "deny")
                supportdenybo.supportDeny = false;

            DataTable dt = (DataTable)supportdenybal.updateData(supportdenybo);
            return ConvertToJason(dt);
        }
        return "Error ";
    }
    private string getComments(Int64 issueId)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)(new CommentBAL()).getComments(issueId);
        return ConvertToJason(dt);
    }
    private string postComment(Int64 issueId, Int64 guid, string comment)
    {
        commentsBO commentbo = new commentsBO();
        commentbo.issueId = issueId;
        commentbo.guid = guid;
        commentbo.comment = comment;
        return " comment posted";
    }
    private string likeDislike(Int64 commentId,Int64 guid,string val)
    {
        likeDislikeBo likedislikebo = new likeDislikeBo();
        likedislikebo.commentId = commentId;
        likedislikebo.guId = guid;
        likedislikebo.likeDislike = true;
        if (val != " ")
        {
            if (val.ToString() == "like") likedislikebo.likeDislike = true;
            else if (val.ToString() == "dislike") likedislikebo.likeDislike = false;
            DataTable dt = new DataTable();
            dt = (DataTable)(new LikeDislikeBAL()).updateData(likedislikebo);
            return ConvertToJason(dt);
        }
        return "eRRoR";
    }
    private string ConvertToJason(DataTable dt)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;

        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName.Trim(), dr[col]);
            }
            rows.Add(row);
        }
        return js.Serialize(rows);

    }
}

