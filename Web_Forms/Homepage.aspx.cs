using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

public partial class Homepage : System.Web.UI.Page
{
    private ConstituencyBAL constituency = new ConstituencyBAL();
    private StateBAL statebal = new StateBAL();
    private IssuesBAL issuesbal = new IssuesBAL();
    private SupportDenyBAL supportdenybal = new SupportDenyBAL();
    private LikeDislikeBAL likedislikebal = new LikeDislikeBAL();
    private CommentBAL commentbal = new CommentBAL();
    private ReportBAL reportbal = new ReportBAL();
    private PartyBAL partybal = new PartyBAL();

    /** search and filter variables ***/
    private static int filterseletedval = 0;
    private static string searchquery = "";
    private static int no_of_issues =20;
    private static string filter2 = "1,2,3,4";
    public static string sessionemail="";

    /** filters ***/
    private static int filterDate = 0;
    private static Int64 filterType = 0;
    private static Int16 filterParty = 0;

    userMasterBO userMasterBO = new userMasterBO();
    userMasterBAL userMasterBAL = new userMasterBAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        googleLogout.Attributes.Add("OnClick", "javascript: return logout()");// registering the javascript function for onclick event of linkbutton
        Btnsearch.Attributes.Add("OnClick", "javascript: return mpNotExist()");
        if (!Page.IsPostBack)
       {
            //Btnsearch.Enabled = false;
            //LBsearch.Enabled = false;
           
            loadFiltersData();
           
            userCreateAndSession();
            loadStates();
            loadlist();  
       }

       if (Session["userEmail"] != null)
       {
           string tmpval = " !";
           LBLuserName.Text = "Hi" +", " + Session["fName"].ToString() + tmpval;
       }
    }

    private void loadFiltersData()
    {
        dropDownDateFilter.Items.Insert(0, new ListItem("Newest ", "0"));
        dropDownDateFilter.Items.Insert(1, new ListItem("Oldest", "1"));
      
        dropDownTypeFilter.DataSource = (DataTable)issuesbal.TypeOfIssue();
        dropDownTypeFilter.DataTextField = "type";
        dropDownTypeFilter.DataValueField = "typeId";
        dropDownTypeFilter.DataBind();
        dropDownTypeFilter.Items.Insert(0,new ListItem("All","0"));

        dropDownPartyFilter.DataSource = (DataTable)partybal.getData();
        dropDownPartyFilter.DataTextField = "partyName";
        dropDownPartyFilter.DataValueField = "partyId";
        dropDownPartyFilter.DataBind();
        dropDownPartyFilter.Items.Insert(0, new ListItem("All Party", "0"));
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchEmployees(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandText = "SELECT dbo.mpDetails.constituencyId,dbo.userMaster.profilePic, dbo.constituency.constituency, dbo.state.state, dbo.userMaster.firstName, dbo.userMaster.middleName, dbo.userMaster.lastName,dbo.userMaster.profilePic FROM dbo.constituency INNER JOIN dbo.state ON dbo.constituency.stateId = dbo.state.stateId INNER JOIN dbo.mpDetails ON dbo.state.stateId = dbo.mpDetails.permanentStateId AND dbo.constituency.constituencyId = dbo.mpDetails.constituencyId INNER JOIN dbo.userMaster ON dbo.mpDetails.guid = dbo.userMaster.guid where dbo.userMaster.firstName like '%' + @search+'%' or dbo.userMaster.middleName like '%'+ @search+'%' or dbo.userMaster.lastName like '%' + @search+'%' or  dbo.state.state  like '%'+ @search+'%' or dbo.constituency.constituency like '%'+ @search+'%'";
                cmd.Parameters.AddWithValue("@search", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> employees = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        employees.Add(AjaxControlToolkit.AutoCompleteExtender
                           .CreateAutoCompleteItem(string.Format("{0}{1}{2}{3}{4}{5} ",
                           sdr["firstName"]+" ",sdr["middleName"]+" ", sdr["lastName"] + " ,", sdr["constituency"] + " ,", sdr["state"]+" ,",sdr["profilePic"].ToString()),
                           sdr["constituencyId"].ToString()));
                    }
                }
                conn.Close();
                return employees;
            }
        }
    }
    private void userCreateAndSession()
    {
        string ss = "";
        string fname = "";
        string lname = "";
        if (Request.Cookies["UserCookies"] == null)
        {
            if (Request.UrlReferrer != null  )
            {
                ss = Request.UrlReferrer.AbsoluteUri.ToString();
                ss = ss.Substring(ss.LastIndexOf("/") + 1);
                if (ss == "Default.aspx")
                {
                    if (Session["userEmail"] == null)
                    {   //creat the session for user
                        //if (Request["email"] != null)
                        //{
                        //    Session["userEmail"] = Request["email"].ToString();

                        //}
                        //else
                        //{
                        //    Session["userEmail"] = sessionemail.ToString();
                        //}
                            
                        if ( Request["social"]!=null && Request["social"].ToString() == "yes")
                        {
                            if (Request["email"] != null)
                            {
                                Session["userEmail"] = Request["email"].ToString();

                            }
                            else
                            {
                                Session["userEmail"] = sessionemail.ToString();
                            }
                            
                            Session["socialType"] = Request["socialType"].ToString();  //google or facebook
                            Session["socialOrNot"] = 1; // 1 for login through social network 0 for local login
                            string tnameval = Request["name"].ToString();
                            string[] tnamearray = tnameval.Split(' ');
                            fname = tnamearray[0];
                            Session["fName"] = fname;
                            if (tnamearray.Length > 1)
                            {
                                lname = tnamearray[1];
                            }
                            else
                            {
                                lname = "";
                            }
                            userMasterBO.password = "";
                        }

                        //give the code to insert data into the usermaster table.
                        userMasterBO.email = Session["userEmail"].ToString();
                        userMasterBO.lastName = lname;
                        userMasterBO.firstName = fname;
                        
                        userMasterBO.middleName = "";
                        if (int.Parse(Session["socialOrNot"].ToString()) == 1)
                        {
                            userMasterBO.socialNetwork = true;
                        }
                        else
                        {
                            userMasterBO.socialNetwork = false;
                        }
                        userMasterBO.status = true;
                        userMasterBO.roleId = 3;  //3 for user , 2 for mp,1 for admin, 4  for moderator
                        userMasterBO.snTypeId = userMasterBAL.getSocialNetworkId(Session["socialType"].ToString()); //fetch the corresponding id of socialnetwork
                        userMasterBO.profilePicPath = Request["image"].ToString();
                        //insert data into the database.
                        HiddenField1.Value = userMasterBAL.insertUser(userMasterBO);
                        Session["guid"] = (userMasterBAL.getGuid(userMasterBO)).ToString();
                        LBLuserName.Text = "Hi! " + Session["fName"].ToString();
                        // Label1.Text = Session["guid"].ToString();

                    }
                    else
                    {
                        // Label1.Text = Session["guid"].ToString();
                        loginsuccess.Value = "success";
                    }

                }
                else //every this is already done(session and storing of data in database is already done)
                {
                    //if (Session["userEmail"] == null)
                    //Response.Redirect("../Default.aspx");   
                    loginsuccess.Value = "success";
                }
            }
            else
            {
                if (Session["userEmail"] == null)
                {

                    Response.Redirect("../Default.aspx");
                }    
            }
        }

        if (Session["userEmail"] != null)
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

    private void loadStates()
    { 
        //loading states in drop dow list 
       DDListState.DataSource = (DataTable)statebal.getData();
        DDListState.DataTextField = "state";
        DDListState.DataValueField = "stateId";
        DDListState.DataBind();
        DDListState.Items.Insert(0,new ListItem("Select State","0"));
        DDListConstituency.Items.Insert(0, new ListItem("Select Constituency", "0"));
    }

    protected void DDListState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Image1.ImageUrl = "../images/gif-load.gif";
        Image1.Visible = true;

        Int16 stateId = Convert.ToInt16(DDListState.SelectedValue);
        DDListConstituency.Items.Clear();
        DataTable dt = (DataTable)constituency.getData(stateId);
        if (dt.Rows.Count > 0)
        {
            DDListConstituency.DataSource = dt;
            DDListConstituency.DataTextField = "constituency";
            DDListConstituency.DataValueField = "constituencyId";
            DDListConstituency.DataBind();
            DDListConstituency.Items.Insert(0, new ListItem("Select Constituency", "0"));
        }
        else
        {
            DDListConstituency.Items.Insert(0, new ListItem("Select Constituency", "0"));
        }

        Image1.Visible = false;
    }

    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        
        if (DDListState.SelectedIndex == 0 || DDListConstituency.SelectedIndex == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(),"myfunction","searchvalidate()",true);
        }
        else
        {
            localLogout.Enabled = false;
            googleLogout.Enabled = false;
            facebookLogout.Visible = false;
            Int16 constituencyId = Convert.ToInt16(DDListConstituency.SelectedValue);
            // HFconstituencyId.Value = "1";//constituencyId.ToString();
            //Server.Transfer("usercomment.aspx", true);
            bool res = constituency.checkMpExistOrNot(constituencyId);
            if (res == true)
            {
                Response.Redirect("usercomment.aspx?cid=" + constituencyId);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "mpNotExist()", true);
            }

        }
    }
    //protected void LBtrending_Click(object sender, EventArgs e)
    //{
    //    loadlist(50,0,0);
    //}
    //protected void LBrecent_Click(object sender, EventArgs e)
    //{
    //    loadlist(50, 1,0);
    //}
    //protected void LBpopular_Click(object sender, EventArgs e)
    //{
    //    loadlist(50, 2,0);
    //}
   /*** issues rendering ***********/
 
    protected void ListIssues_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField issueId = (HiddenField)e.Item.FindControl("HFIssueId");
        HiddenField constituencyid = (HiddenField)e.Item.FindControl("HFconstituencyidval");
        DataTable dt = (DataTable)issuesbal.getIssue(Convert.ToInt64(issueId.Value));
        DataTable voterDt = (DataTable)issuesbal.getVoters(Convert.ToInt64(issueId.Value));

        /****Issues***/
        if (dt.Rows.Count > 0)
        {   
           // Int64 issueidval = Int64.Parse(dt.Rows[0]["mpId"].ToString());
          //  string[] mpnamedetails = new string[2];
           // mpnamedetails = issuesbal.getmpname( Int64.Parse(issueId.Value));

            if (dt.Rows[0]["profilePic"].ToString() != "" && dt.Rows[0]["profilePic"].ToString() != "undefined")
            {
                ((Image)e.Item.FindControl("IMGprofilePic")).ImageUrl = dt.Rows[0]["profilePic"].ToString();

                //http://localhost:21913/images/mp/dummy.jpg
            }
            else if (dt.Rows[0]["profilePic"].ToString() == "" || dt.Rows[0]["profilePic"].ToString() == "undefined")
            {
                string destPicFolder = "../images/mp/";
                ((Image)e.Item.FindControl("IMGprofilePic")).ImageUrl = destPicFolder + "dummy.jpg";
            }

            ((Label)e.Item.FindControl("LBLpostedBy")).Text = dt.Rows[0]["firstName"].ToString() + " " + dt.Rows[0]["lastName"].ToString();
            // ((Label)e.Item.FindControl("LBLpstate")).Text = "Andheri East(Mumbai)";
           
            //kkkkkkk
            DataTable MP_SORT_DATA = (DataTable)issuesbal.mpSortDetails(Convert.ToInt64(issueId.Value));
            if (MP_SORT_DATA.Rows.Count != 0)
            {
                ((LinkButton)e.Item.FindControl("mp_name")).Text = MP_SORT_DATA.Rows[0]["firstName"].ToString() + " " + MP_SORT_DATA.Rows[0]["lastName"].ToString();
               ((HiddenField)e.Item.FindControl("constituencyIdVal")).Value =MP_SORT_DATA.Rows[0]["constituencyId"].ToString();
               ((Label)e.Item.FindControl("mp_state_belong")).Text = MP_SORT_DATA.Rows[0]["state"].ToString();
               ((Label)e.Item.FindControl("mp_party")).Text = MP_SORT_DATA.Rows[0]["partyName"].ToString();
            }

            //kkkkkkk


            
            ((Label)e.Item.FindControl("LBLdt")).Text = ((DateTime)(dt.Rows[0]["postedOn"])).ToString("d-MMM-yyyy hh:mm tt");
            if (voterDt.Rows.Count == 2)
            {
                ((Label)e.Item.FindControl("LBLfpname")).Text = voterDt.Rows[0]["firstName"].ToString() + " " + voterDt.Rows[0]["lastName"].ToString() + ",";
                ((Label)e.Item.FindControl("LBLspname")).Text = voterDt.Rows[1]["firstName"].ToString() + " " + voterDt.Rows[1]["lastName"].ToString();
            }
            else if (voterDt.Rows.Count == 1)
            {
                ((Label)e.Item.FindControl("LBLfpname")).Text = voterDt.Rows[0]["firstName"].ToString() + " " + voterDt.Rows[0]["lastName"].ToString();
            }
            else if (voterDt.Rows.Count > 2)
            {
                ((Label)e.Item.FindControl("LBLfpname")).Text = voterDt.Rows[0]["firstName"].ToString() + " " + voterDt.Rows[0]["lastName"].ToString() + ",";
                ((Label)e.Item.FindControl("LBLspname")).Text = voterDt.Rows[1]["firstName"].ToString() + " " + voterDt.Rows[1]["lastName"].ToString() + " and ";
                ((LinkButton)e.Item.FindControl("LBmore")).Text = (Convert.ToUInt64(dt.Rows[0]["voteCount"]) - 2).ToString() + " " + "more..";
                ((LinkButton)e.Item.FindControl("LBmore")).Visible = true;
                ((Panel)e.Item.FindControl("PopupMenu")).Visible = true;
                Label lblvotersName = (Label)e.Item.FindControl("votersName");
                lblvotersName.Text = "";
                voterDt.Rows.RemoveAt(0);
                voterDt.Rows.RemoveAt(0);
                foreach (DataRow dr in voterDt.Rows)
                {
                    lblvotersName.Text += dr["firstName"].ToString() + " " + dr["lastName"].ToString() + "<br/>";
                }

            }
            else
            {
                ((Label)e.Item.FindControl("LBLfpname")).Text = "(None) Be first to vote it";
            }
            ((Label)e.Item.FindControl("LBLIssue")).Text = dt.Rows[0]["issueText"].ToString();

            /*** Type of issues Pic ****/
            Int64 typeofissue = Convert.ToInt64(dt.Rows[0]["issueType"]);
            if(typeofissue == 4)
            ((Image)e.Item.FindControl("PicIssueType")).ImageUrl = "../images/typeofissues/complaint.png";
            else if(typeofissue == 3)
                ((Image)e.Item.FindControl("PicIssueType")).ImageUrl = "../images/typeofissues/recommend.png";
            else if (typeofissue == 2)
                ((Image)e.Item.FindControl("PicIssueType")).ImageUrl = "../images/typeofissues/praise.png";
            else
                ((Image)e.Item.FindControl("PicIssueType")).ImageUrl = "../images/typeofissues/misc.png";
            
            ///***** LinkButtonS *****/
            ((LinkButton)e.Item.FindControl("LBsupport")).CommandArgument = issueId.Value;
            ((LinkButton)e.Item.FindControl("LBdeny")).CommandArgument = issueId.Value;
            ((LinkButton)e.Item.FindControl("LBcomment")).CommandArgument = issueId.Value;
            ((Button)e.Item.FindControl("btnPost")).CommandArgument = issueId.Value;
            ((LinkButton)e.Item.FindControl("Report_Abuse")).CommandArgument = issueId.Value;
            ((LinkButton)e.Item.FindControl("LBmore")).Enabled = false;
            //int x = 10;
            ((LinkButton)e.Item.FindControl("mp_name")).CommandArgument = ((HiddenField)e.Item.FindControl("constituencyIdVal")).Value;
            //((LinkButton)e.Item.FindControl("mp_name")).CommandArgument = x.ToString();

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
    }

    protected void ListIssues_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        supportDenyBO supportdenybo = new supportDenyBO();
        Int64 issueId = Convert.ToInt64(e.CommandArgument);
        string btncmdname;
        try
        {
            btncmdname = e.CommandName.ToString();
            if (btncmdname == "comment")
            {
            //    ((Repeater)e.Item.FindControl("ListComments")).DataSource = (DataTable)commentbal.getComments(Convert.ToInt64(issueId));
            //    ((Repeater)e.Item.FindControl("ListComments")).DataBind();
            }
            else if (btncmdname == "support")
            {
                supportdenybo.guid = int.Parse(Session["guid"].ToString());  /** from session **/
                supportdenybo.issueId = issueId;
                supportdenybo.supportDeny = true;
                DataTable dt = supportdenybal.updateData(supportdenybo);
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
                    commentsbo.comment =txtcomment.Text ;
                    commentsbo.issueId = issueId;
                    txtcomment.Text = "";
                    commentsbo.guid = int.Parse(Session["guid"].ToString()); ; /** from session **/
                    commentbal.postComment(commentsbo);
                    ((Repeater)e.Item.FindControl("ListComments")).DataSource = (DataTable)commentbal.getComments(Convert.ToInt64(issueId));
                    ((Repeater)e.Item.FindControl("ListComments")).DataBind();
                }
             }
            else if (btncmdname == "mpDetailsShow")
            {
               // string tt=((Label) e.Item.FindControl("constituencyIdVal")).ToString();
                Response.Redirect("usercomment.aspx?cid="+issueId.ToString ());
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
    protected void ListComments_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        likeDislikeBo likedislikebo = new likeDislikeBo();
        string btncmdname = e.CommandName.ToString();
        Int64 commentId;
        try
        {
            commentId = Convert.ToInt64(e.CommandArgument);
            if (btncmdname == "like")
            {
                likedislikebo.guId = int.Parse(Session["guid"].ToString()); /*** from session ***/
                likedislikebo.commentId = commentId;
                likedislikebo.likeDislike = true;
                DataTable dt = likedislikebal.updateData(likedislikebo);
                ((Label)e.Item.FindControl("LBLlikeCount")).Text = dt.Rows[0]["likeCount"].ToString();
                ((Label)e.Item.FindControl("LBLdislikeCount")).Text = dt.Rows[0]["dislikeCount"].ToString();

            }
            else if (btncmdname == "dislike")
            {
                likedislikebo.guId = int.Parse(Session["guid"].ToString());
                likedislikebo.commentId = commentId;
                likedislikebo.likeDislike = false;
                DataTable dt = (DataTable)likedislikebal.updateData(likedislikebo);
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
               // Session.RemoveAll();
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
               // Session.RemoveAll();
                Response.Redirect("../Default.aspx");
            } 
        }
    }

   [WebMethod]
    public static void searchIssues(string searchval)
    {
  
        IssuesBAL issuebal = new IssuesBAL();
        DataTable dt=(DataTable) issuebal.SEARCH_AND_FILTER(searchquery,no_of_issues,filterDate,filterType,filterParty);
       //Page page = HttpContext.Current.Handler as Page;
       //UpdatePanel uu = (UpdatePanel)page.FindControl("allUpdate");
       //Repeater rr = (Repeater)uu.FindControl("ListIssues");
       ////Repeater rr = (Repeater)page.FindControl("ListIssues");
      

       //rr.DataSource = dt;
       //rr.DataBind();
       //Button b1 = (Button)page.FindControl("localLogout");
       //b1.Enabled = true;
       //Button b2 = (Button)page.FindControl("Btnsearch");
       //b2.Enabled = true;

      // Homepage ob = new Homepage();
      // ob.checkfunction(dt);
    }
    
    
    public void checkfunction(DataTable dt)
    {
        ListIssues.DataSource = dt;
        ListIssues.DataBind();
        localLogout.Enabled = true; 
        Btnsearch.Enabled = true;
        googleLogout.Enabled = true;
    }
    
    protected void issueSearch_Click(object sender, EventArgs e)
    {
        searchquery = txtsearchBox.Text;
        loadlist();
    }

    /** default loading issue list **/
    private void loadlist()
    {
        searchquery = txtsearchBox.Text;
        if (searchquery.Length == 0)
        {
            DataTable dt = (DataTable)issuesbal.ONLY_FILTER(no_of_issues,filterDate,filterType,filterParty);
            checkfunction(dt);
        }
        else
        {

            DataTable dt = (DataTable)issuesbal.SEARCH_AND_FILTER(searchquery, no_of_issues,filterDate,filterType,filterParty);
            checkfunction(dt);
        }
    }
    /*** filter drop down ***/
    protected void dropDownDateFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        filterDate =Convert.ToInt32(dropDownDateFilter.SelectedValue);
        loadlist();
    }
    protected void dropDownTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
    {

        filterType =Convert.ToInt64( dropDownTypeFilter.SelectedValue);
        loadlist();
    }
    protected void dropDownPartyFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        filterParty = Convert.ToInt16(dropDownPartyFilter.SelectedValue);
        loadlist();
    }
    
}