using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Web_Forms_usercomment : System.Web.UI.Page
{
    private mpDetailsBAL mpdetailsbal = new mpDetailsBAL();
    private IssuesBAL issuesbal = new IssuesBAL();
    private SupportDenyBAL supportdenybal = new SupportDenyBAL();
    private LikeDislikeBAL likedislikebal = new LikeDislikeBAL();
    private CommentBAL commentbal = new CommentBAL();
    private ratingBAL ratingbal = new ratingBAL();
    private ReportBAL reportbal = new ReportBAL();

    private static Int64 mpidval=1;
    private static Int16 conId=1;
    private Int64 guId = 1; 
    protected void Page_Load(object sender, EventArgs e)
    {
      
       // BTNissuePost.Attributes.Add("OnClick", "javascript: return validatePostContent()");
        if (!Page.IsPostBack)
        {
            userCreateAndSession();

            //dropDownIssueFilter.Items.Insert(0, new ListItem("Categorised as ", "0"));
            //dropDownIssueFilter.Items.Insert(1, new ListItem("Praise", "1"));
            //dropDownIssueFilter.Items.Insert(2, new ListItem("Recommendation", "2"));
            //dropDownIssueFilter.Items.Insert(3, new ListItem("complaint", "3"));
            //dropDownIssueFilter.Items.Insert(4, new ListItem("Miscellaneous", "4"));
            //conId =Int16.Parse( Request["cid"].ToString());
            getMpdata(conId);
            //loadRating();
        }
        if (Session["userEmail"] != null)
        {
            LBLuserName.Text = "Hi" + ", "+ Session["fName"].ToString() +" !";
        }
    
    }
    private void userCreateAndSession()
    {
        if (Session["userEmail"] == null)
        {
            Response.Redirect("../Default.aspx");
        }
        else if (Session["userEmail"] != null)
        {
            if (int.Parse(Session["socialOrNot"].ToString()) == 1)
            {
                if (Session["socialType"].ToString() == "GOOGLE")
                {
                    // for google login
                    googleLogout.Visible = true;
                    facebookLogout.Visible = false;
                }
                else if (Session["socialType"].ToString() == "FACEBOOK")
                {
                    facebookLogout.Visible = true;
                }
            }
            else
            {
                // for local userlogin
                localLogout.Visible = true;
                facebookLogout.Visible = false;
            }
        }
    }

    public void getMpdata(Int16 constituencyId)
    {
        try
        {
            DataTable dt = new DataTable();

            guId = int.Parse(Session["guid"].ToString());
            dt = mpdetailsbal.getData(constituencyId); /** empid fetch throw ***/
            if (dt.Rows.Count != 0)
            {
                string destPicFolder = "../images/mp/";
                if (dt.Rows[0]["profilePic"].ToString() != "")
                {
                    //if (File.Exists(destPicFolder + dt.Rows[0]["profilePic"]))
                    //{
                        imgMpProfile.ImageUrl = destPicFolder + dt.Rows[0]["profilePic"].ToString();
                    //}
                    //else
                    //{
                    //    imgMpProfile.ImageUrl = destPicFolder + "dummy.jpg";
                    //}
                }
                else
                {
                    imgMpProfile.ImageUrl = destPicFolder + "dummy.jpg";
                }

                lblname.Text = dt.Rows[0]["firstName"].ToString() + "  " + dt.Rows[0]["middleName"].ToString() + " " + dt.Rows[0]["lastName"].ToString();
                lblconstituency.Text = dt.Rows[0]["constituency"].ToString();
                lblparty.Text = dt.Rows[0]["partyName"].ToString() + "(" + dt.Rows[0]["Abbreviation"].ToString() + ")";
                lblmail.Text = dt.Rows[0]["email"].ToString();
                lblcntct.Text = dt.Rows[0]["mobile"].ToString();
                lbleducational_q.Text = dt.Rows[0]["qualification"].ToString();
                lblprofession.Text = dt.Rows[0]["profession"].ToString();
                lblp_address.Text = dt.Rows[0]["permanentAddress"].ToString() + ", " + dt.Rows[0][13].ToString() + ", " + dt.Rows[0][14].ToString();
                lblpresent_address.Text = dt.Rows[0]["currentAddress"].ToString() + ", " + dt.Rows[0][16].ToString() + ", " + dt.Rows[0][17].ToString();
                mpidval = Int64.Parse(dt.Rows[0]["mpId"].ToString());
                //DataTable numDt = new DataTable();
                //numDt = issuesbal.Issues_Numbers(Convert.ToInt64(dt.Rows[0]["mpId"]));
                //lblissuesno.Text = numDt.Rows[0][0].ToString();
                //lblsolvedissuesno.Text = numDt.Rows[0][1].ToString();
                loadlist(50, 0, mpidval);
            }
            else lblname.Text = "NO record found !"; /** **/
        }
        catch
        {
            throw;
        }
        finally
        {
        }
    }
    private void loadlist(Int64 number, Int16 type ,Int64 mpId)
    {
        ListIssues.DataSource = (DataTable)issuesbal.getIssues(mpId,50,0,0); /* type 0,1,2 */
        ListIssues.DataBind();
    }
    protected void ListIssues_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            HiddenField issueId = (HiddenField)e.Item.FindControl("HFIssueId");
            DataTable dt = (DataTable)issuesbal.getIssue(Convert.ToInt64(issueId.Value));
            DataTable voterDt = (DataTable)issuesbal.getVoters(Convert.ToInt64(issueId.Value));
            /****Issues***/
            //((Image)e.Item.FindControl("IMGprofilePic")).ImageUrl = dt.Rows[0]["profilePic"].ToString();
            if (dt.Rows[0]["profilePic"].ToString() != "" && dt.Rows[0]["profilePic"].ToString() != "undefined")
            {
                ((Image)e.Item.FindControl("IMGprofilePic")).ImageUrl = dt.Rows[0]["profilePic"].ToString();
            }
            else if (dt.Rows[0]["profilePic"].ToString() == "" || dt.Rows[0]["profilePic"].ToString() == "undefined")
            {
                string destPicFolder = "../images/mp/";
                ((Image)e.Item.FindControl("IMGprofilePic")).ImageUrl = destPicFolder + "dummy.jpg";
            }
            ((Label)e.Item.FindControl("LBLpostedBy")).Text = dt.Rows[0]["firstName"].ToString() + " " + dt.Rows[0]["lastName"].ToString();
           // ((Label)e.Item.FindControl("LBLpstate")).Text = "Andheri East(Mumbai)";
            ((Label)e.Item.FindControl("LBLdt")).Text = ((DateTime)(dt.Rows[0]["postedOn"])).ToString("d-MMM-yyyy hh:mm tt");
            
            /*** voters names ***/
            //if (voterDt.Rows.Count == 2)
            //{
            //    //((Label)e.Item.FindControl("LBLfpname")).Text = voterDt.Rows[0]["firstName"].ToString() + " " + voterDt.Rows[0]["lastName"].ToString() + ",";
            //    //((Label)e.Item.FindControl("LBLspname")).Text = voterDt.Rows[1]["firstName"].ToString() + " " + voterDt.Rows[1]["lastName"].ToString();
            //}
            //else if (voterDt.Rows.Count == 1)
            //{
            //    //((Label)e.Item.FindControl("LBLfpname")).Text = voterDt.Rows[0]["firstName"].ToString() + " " + voterDt.Rows[0]["lastName"].ToString();
            //}
            //else if (voterDt.Rows.Count > 2)
            //{
            //    //((Label)e.Item.FindControl("LBLfpname")).Text = voterDt.Rows[0]["firstName"].ToString() + " " + voterDt.Rows[0]["lastName"].ToString() + ",";
            //    //((Label)e.Item.FindControl("LBLspname")).Text = voterDt.Rows[1]["firstName"].ToString() + " " + voterDt.Rows[1]["lastName"].ToString() + " and ";
            //    ((LinkButton)e.Item.FindControl("LBmore")).Visible = true;
            //    ((LinkButton)e.Item.FindControl("LBmore")).Text = (Convert.ToUInt64(dt.Rows[0]["voteCount"]) - 2).ToString() + " " + "more..";
            //    ((Panel)e.Item.FindControl("PopupMenu")).Visible = true;
            //    Label lblvotersName = (Label)e.Item.FindControl("votersName");
            //    lblvotersName.Text = "";
            //    voterDt.Rows.RemoveAt(0);
            //    voterDt.Rows.RemoveAt(0);
            //    foreach (DataRow dr in voterDt.Rows)
            //    {
            //        lblvotersName.Text += dr["firstName"].ToString() + " " + dr["lastName"].ToString() + "<br/>";
            //    }


            //}
            //else
            //{
            //    //((Label)e.Item.FindControl("LBLfpname")).Text = "(None) Be first to vote it";
            //}


            //((Label)e.Item.FindControl("LBLIssue")).Text = dt.Rows[0]["issueText"].ToString();

            ///***** LinkButtonS *****/
            ((LinkButton)e.Item.FindControl("LBsupport")).CommandArgument = issueId.Value;
            ((LinkButton)e.Item.FindControl("LBdeny")).CommandArgument = issueId.Value;
            ((LinkButton)e.Item.FindControl("LBcomment")).CommandArgument = issueId.Value;
            ((Button)e.Item.FindControl("btnPost")).CommandArgument = issueId.Value;
            ((LinkButton)e.Item.FindControl("Report_Abuse")).CommandArgument = issueId.Value;
            ((LinkButton)e.Item.FindControl("LBmore")).Enabled = false;

            
            ///***** Counts values *****/
            //((Label)e.Item.FindControl("LBLvoteCount")).Text = dt.Rows[0]["voteCount"].ToString();
            ((Label)e.Item.FindControl("LBLsupportCount")).Text = dt.Rows[0]["supportCount"].ToString();
            ((Label)e.Item.FindControl("LBLdenyCount")).Text = dt.Rows[0]["denyCount"].ToString();
            ((Label)e.Item.FindControl("LBLcommentCount")).Text = dt.Rows[0]["commentCount"].ToString();
           
            ///***** Report check ****/
            if (Convert.ToBoolean(dt.Rows[0]["reportAbuse"]) == false)
                ((Image)e.Item.FindControl("IMG_Report")).ImageUrl = "../images/flag-black.png";
            else
            {
                ((Image)e.Item.FindControl("IMG_Report")).ImageUrl = "../images/flag-red.png";
                ((LinkButton)e.Item.FindControl("Report_Abuse")).Enabled = false;
            }
            ///*** post link button ***/
            //((LinkButton)e.Item.FindControl("btnpost")).CommandArgument = issueId.Value;
            ((Repeater)e.Item.FindControl("ListComments")).DataSource = (DataTable)commentbal.getComments(Convert.ToInt64(issueId.Value));
            ((Repeater)e.Item.FindControl("ListComments")).DataBind();

        }
        catch
        {
            throw;
        }
        finally
        {
        }
    }
    protected void ListIssues_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        supportDenyBO supportdenybo = new supportDenyBO();
        Int64 issueId ;
        string btncmdname;
        try
        {
            issueId = Convert.ToInt64(e.CommandArgument);
            btncmdname = e.CommandName.ToString();
            if (btncmdname == "comment")
            {
                //    ((Repeater)e.Item.FindControl("ListComments")).DataSource = (DataTable)commentbal.getComments(Convert.ToInt64(issueId));
                //    ((Repeater)e.Item.FindControl("ListComments")).DataBind();
            }
            else if (btncmdname == "support")
            {
                supportdenybo.guid = int.Parse(Session["guid"].ToString()); /** from session **/
                supportdenybo.issueId = issueId;
                supportdenybo.supportDeny = true;
                DataTable dt= supportdenybal.updateData(supportdenybo);
                ((Label)e.Item.FindControl("LBLsupportCount")).Text = dt.Rows[0]["supportCount"].ToString();
                ((Label)e.Item.FindControl("LBLdenyCount")).Text = dt.Rows[0]["denyCount"].ToString();
            }
            else if (btncmdname == "deny")
            {
                supportdenybo.guid = int.Parse(Session["guid"].ToString()); ; /** from session **/
                supportdenybo.issueId = issueId;
                supportdenybo.supportDeny = false;
                DataTable dt = supportdenybal.updateData(supportdenybo);
                ((Label)e.Item.FindControl("LBLsupportCount")).Text = dt.Rows[0]["supportCount"].ToString();
                ((Label)e.Item.FindControl("LBLdenyCount")).Text = dt.Rows[0]["denyCount"].ToString();

            }
            else if (btncmdname == "report")
            {
                reportbal.Issue_Report(issueId);
                ((Image)e.Item.FindControl("IMG_Report")).ImageUrl = "../images/flag-red.png";
                ((LinkButton)e.Item.FindControl("Report_Abuse")).Enabled = false;
            }
            else if (btncmdname == "post")
            {

                commentsBO commentsbo = new commentsBO();
                TextBox txtcomment = (TextBox)(e.Item.FindControl("TxtComment"));
                if (txtcomment.Text != "")
                {
                    commentsbo.comment = txtcomment.Text;
                    commentsbo.issueId = issueId;
                    txtcomment.Text = "";
                    commentsbo.guid = int.Parse(Session["guid"].ToString()); /** from session **/
                    commentbal.postComment(commentsbo);
                    ((Repeater)e.Item.FindControl("ListComments")).DataSource = (DataTable)commentbal.getComments(Convert.ToInt64(issueId));
                    ((Repeater)e.Item.FindControl("ListComments")).DataBind();
                }
            }
            else if (btncmdname == "more")
            {
            }
        }
        catch
        {
            throw;
        }
        finally
        {

        }



    }

    protected void ListComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            HiddenField commentId = (HiddenField)e.Item.FindControl("HFcommentId");
            ((LinkButton)e.Item.FindControl("LBlike")).CommandArgument = commentId.Value;
            ((LinkButton)e.Item.FindControl("LBdislike")).CommandArgument = commentId.Value;
            ((LinkButton)e.Item.FindControl("Report_Abuse_Comment")).CommandArgument = commentId.Value;
            DataTable dt = new DataTable();
            dt = (DataTable)commentbal.getComment(Convert.ToInt64(commentId.Value));
            ((Label)e.Item.FindControl("LBLlikeCount")).Text = dt.Rows[0]["likeCount"].ToString();
            ((Label)e.Item.FindControl("LBLdislikeCount")).Text = dt.Rows[0]["dislikeCount"].ToString();
            if (Convert.ToBoolean(dt.Rows[0]["reportAbuse"]) == false)
                ((Image)e.Item.FindControl("IMG_ReportComment")).ImageUrl = "../images/flag-black.png";
            else
            {
                ((Image)e.Item.FindControl("IMG_ReportComment")).ImageUrl = "../images/flag-red.png";
                ((LinkButton)e.Item.FindControl("Report_Abuse_Comment")).Enabled = false;
            }

        }
        catch
        {
            throw;
        }
        finally { }
    }
    protected void ListComments_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        likeDislikeBo likedislikebo = new likeDislikeBo();
        string btncmdname;
        Int64 commentId;
        try
        {
            btncmdname = e.CommandName.ToString();
            commentId = Convert.ToInt64(e.CommandArgument);
            if (btncmdname == "like")
            {
                likedislikebo.guId = int.Parse(Session["guid"].ToString()); /*** from session ***/
                likedislikebo.commentId = commentId;
                likedislikebo.likeDislike = true;
                 DataTable dt= likedislikebal.updateData(likedislikebo);
                ((Label)e.Item.FindControl("LBLlikeCount")).Text = dt.Rows[0]["likeCount"].ToString();
                ((Label)e.Item.FindControl("LBLdislikeCount")).Text = dt.Rows[0]["dislikeCount"].ToString();

            }
            else if (btncmdname == "dislike")
            {
                likedislikebo.guId = int.Parse(Session["guid"].ToString());
                likedislikebo.commentId = commentId;
                likedislikebo.likeDislike = false;
                DataTable dt = likedislikebal.updateData(likedislikebo);
                ((Label)e.Item.FindControl("LBLlikeCount")).Text = dt.Rows[0]["likeCount"].ToString();
                ((Label)e.Item.FindControl("LBLdislikeCount")).Text = dt.Rows[0]["dislikeCount"].ToString();
            }
            else if (btncmdname == "reportcomment")
            {
                reportbal.Comment_Report(commentId);
                ((Image)e.Item.FindControl("IMG_ReportComment")).ImageUrl = "../images/flag-red.png";
                ((LinkButton)e.Item.FindControl("Report_Abuse_Comment")).Enabled = false;
            }

            else
            {
            }
     

        }
        catch
        {
            throw;
        }
        finally
        {
        }

    }
    //protected void BTNissuePost_Click(object sender, EventArgs e)
    //{
    //    issuesBO issuebo = new issuesBO();
    //    String fileName;
    //    try
    //    {
    //        if (TXTissue.Text != "")
    //        {
    //            if (FileUploadIssue.HasFile)
    //            {
    //                fileName = Server.MapPath("~/image/") + FileUploadIssue.FileName;
    //                FileUploadIssue.SaveAs(fileName);
    //            }
    //            issuebo.guid = int.Parse(Session["guid"].ToString());  /** from session **/
    //            issuebo.mpId = mpidval;
    //            issuebo.issueText = TXTissue.Text;
    //            TXTissue.Text = "";
    //            issuesbal.postIssue(issuebo);
    //            loadlist(50,1,mpidval);
    //        }
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //    finally { }

    //}
    /**********************************      RATING            ****************************/
    //private void loadRating()
    //{      /** Current user rating **/
    //    DataTable dt = ratingbal.getrating(mpidval, 0, guId);
    //    if (dt.Rows.Count >= 3)
    //    {
    //        Rating1.CurrentRating = Convert.ToInt32(dt.Rows[0]["rating"]);
    //        Rating2.CurrentRating = Convert.ToInt32(dt.Rows[1]["rating"]);
    //        Rating3.CurrentRating = Convert.ToInt32(dt.Rows[2]["rating"]);
    //    }
    //    loadAvgRating();
    //}
    //private void loadAvgRating()
    //{   /** avg rating **/
    //    DataTable dt = new DataTable();
    //    dt = ratingbal.getrating(mpidval);
    //    if (dt.Rows.Count >= 3)
    //    {
    //        LBLrating1.Text = dt.Rows[0]["avgRAte"].ToString();
    //        LBLrating2.Text = dt.Rows[1]["avgRAte"].ToString();
    //        LBLrating3.Text = dt.Rows[2]["avgRAte"].ToString();
    //    }

    //}
    //protected void Rating1_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    //{
    //    DataTable dt = ratingbal.getrating(mpidval, 1, guId, Convert.ToInt16(e.Value));
    //    Rating1.CurrentRating = Convert.ToInt32(dt.Rows[0]["rating"]);
    //    LBLrating1.Text = dt.Rows[0]["avgRAte"].ToString();
    //}

    //protected void Rating2_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    //{
    //    DataTable dt = ratingbal.getrating(mpidval, 2, guId, Convert.ToInt16(e.Value));
    //    Rating2.CurrentRating = Convert.ToInt32(dt.Rows[0]["rating"]);
    //    LBLrating2.Text = dt.Rows[0]["avgRAte"].ToString();
    //}
    //protected void Rating3_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    //{
    //    DataTable dt = ratingbal.getrating(mpidval, 3, guId, Convert.ToInt16(e.Value));
    //    Rating3.CurrentRating = Convert.ToInt32(dt.Rows[0]["rating"]);
    //    LBLrating3.Text = dt.Rows[0]["avgRAte"].ToString();
    //}
    /*************************************** Rating ends ******************************************/
    protected void googleLogout_Click(object sender, EventArgs e)
    {
        if (Session["userEmail"] != null)
        {
            Session.Abandon();

        }
        // ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "logout()", true);
        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "myfunction", "logout()", true);
    }
    protected void localLogout_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["UserCookies"] != null)
        {   // here we are deleting the cookie.
            Response.Cookies["UserCookies"].Expires = DateTime.Now.AddDays(-1);
            if (Session["userEmail"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
            else if (Session["userEmail"] != null)
            {
                Session.Abandon();
                Response.Redirect("../Default.aspx");
            }
        }
        else
        {
            if (Session["userEmail"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("../Default.aspx");
            }
        }
    }
    protected void Buttonredirect_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web_Forms/Homepage.aspx");
    }


}