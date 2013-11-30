using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;
using System.Web.Security;
using System.Web.Services;


public partial class _Default : System.Web.UI.Page
{
     
    userMasterBO userMasterBO = new userMasterBO();
    userMasterBAL userMasterBAL = new userMasterBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
       if (Request.Cookies["UserCookies"] != null)// checking wether there is active cookie for this user or not.
        {
            Response.Redirect("~/Web_Forms/Homepage.aspx");
        }
       if (Page.IsPostBack == false)
       {
           if (Session["userEmail"] != null)
           {
               Session.Abandon();
           }
       }
    }

    protected void btnSingin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string[] userdetails = new string[3];

            // here we will check user and  if user exist we will create session and then redirect to next page.
            if (signinemail.Text != "" || signinPassword.Text != "")
            {
                userMasterBO.email = signinemail.Text;
                userMasterBO.password = signinPassword.Text;
                userdetails = (userMasterBAL.checkUser(userMasterBO)); // if user is valid then it return the user information  email,firstname and guid
                if (userdetails[0] != "")
                {   //here we will maintain cookies for remember me option 
                    if (chkRememberMe.Checked == true)
                    { // here we will create the cookie
                        if (Request.Cookies["UserCookies"] == null)
                        {
                            Response.Cookies["UserCookies"].Value = userdetails[0];
                            Response.Cookies["UserCookies"].Expires = DateTime.Now.AddDays(1);
                        }
                    }
                    else
                    {      //we will delete the cookie
                        if (Request.Cookies["UserCookies"] != null)
                        {

                            Response.Cookies["UserCookies"].Expires = DateTime.Now.AddDays(-1);
                        }
                    }
                    //here we will maintain the session and then transfer to the second page.
                    Session["userEmail"] = userdetails[0];
                    Session["guid"] = userdetails[1]; //unique id for each user.
                    Session["fName"] = userdetails[2];
                    Session["socialType"] = "local";
                    Session["socialOrNot"] = 0; //HERE 0 MEANS LOCAL USER.
                   // Response.Redirect("~/Web_Forms/Homepage.aspx?email="+userdetails[0]);
                    Response.Redirect("~/Web_Forms/Homepage.aspx");
                     
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "WrongCredential()", true);
                }

            }
        }
    }
    protected void btnSignup_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)// if page has not any error message then page.isvalid return the true 
        {
            if (email.Text != "" && password.Text != "" && firstName.Text != "" && lastName.Text != "")
            {
                if (Session["userEmail"] == null)
                {
                    Session["userEmail"] = email.Text;
                    //here we will add first name and last name and put into username.
                    userMasterBO.firstName = firstName.Text;
                    userMasterBO.lastName = lastName.Text;
                        Session["fName"] = userMasterBO.firstName;
                        Session["socialType"] = "local";
                        Session["socialOrNot"] = 0; //HERE 0 MEANS LOCAL USER.
                    //give code for insert
                    //give the code to insert data into the usermaster table.
                    userMasterBO.email = Session["userEmail"].ToString();
                    userMasterBO.password = password.Text;
                    userMasterBO.middleName = "";
                    userMasterBO.socialNetwork = false; //false for local user and true for any user from social network
                    userMasterBO.status = true;
                    userMasterBO.roleId = 3;  //3 for user , 2 for mp,1 for admin, 4  for moderator
                    // userMasterBO.snTypeId = 0;
                    userMasterBO.profilePicPath = "";
                    HiddenField1.Value = userMasterBAL.insertUser(userMasterBO);
                    if (HiddenField1.Value == "User Successfully Created.")
                    {

                        Session["guid"] = (userMasterBAL.getGuid(userMasterBO)).ToString();
                        ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "userCreated()", true);
                        // Response.Redirect("test.aspx", true);
                    }
                    else if (HiddenField1.Value == "User Already Exists.")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "userNotCreated()", true);
                    }
                    else if (HiddenField1.Value == "User Updated.")
                    {
                        Session["guid"] = (userMasterBAL.getGuid(userMasterBO)).ToString();
                        ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "userUpdated()", true);
                    }

                }
                else
                {

                }
            }
        }
    }

    protected void PasswordUpdate_Click(object sender, EventArgs e)
    {

        // first check passcode is correct or not.
        if (txtPasscode.Text != "" && txtPassword.Text != "" && txtCPassword.Text != "")
        {

            if (txtPassword.Text == txtCPassword.Text)
            {
                userMasterBO.email = signinemail.Text;
                userMasterBO.passcode = int.Parse(txtPasscode.Text);
                userMasterBO.password = txtPassword.Text;
                bool res = userMasterBAL.updatePassword(userMasterBO);
                if (res == true)
                {
                    //txtPassword.Text = "";
                    //txtPassword.Text = "";
                    //txtCPassword.Text = "";

                    ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "passwordUpdated()", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "wrongCredential()", true);
                }
            }
            else
            {
                // ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "wrongCredential()", true);
            }

        }
        else
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "giveALLinfo()", true);
        }

    }

    [WebMethod]
    public static string generatePasscode(string emailidval)
    {
        userMasterBO x = new userMasterBO();
        userMasterBAL y = new userMasterBAL();
        Page CurPage = HttpContext.Current.Handler as Page;
        //TextBox tx= (TextBox)CurPage.FindControl("signinemail");

        // string ss= tx.Text;


        // HiddenField hf = (HiddenField)CurPage.FindControl("HiddenField2");

        if (emailidval != "")
        {
            //check email first
            x.email = emailidval;
            bool valid = y.checkValidEmailToResetPassword(x);
            if (valid == true)
            {


                //here we will check passcode is null or not. if null we will create the passcode and save into database and email passcode to users.
                bool passnull = y.checkPasscode(x);
               if ( true) // if (passnull == true)
                {
                    // first create the passcode here. to generate passcode  i have to write the storedprocedure

                    Random rnd = new Random();
                    int passcode = rnd.Next(00000000, 99999999);
                    x.passcode = passcode;
                    //code to send email
                    MailMessage vMsg = new MailMessage();
                    MailAddress vFrom = new MailAddress("dhandrohit@gmail.com", "RATEmymp");
                    vMsg.From = vFrom;
                    vMsg.To.Add(x.email); //This is a string which contains delimited :semicolons for multiple 
                    vMsg.Subject = "Passcode to reset Password in rateMyMp"; //This is the subject;
                    vMsg.Body = passcode.ToString(); //This is the message that needs to be passed.

                    //Create an object SMTPclient for relaying
                    // SmtpClient vSmtp = new SmtpClient();
                    SmtpClient vSmtp = new SmtpClient("smtp.gmail.com", 587);
                    vSmtp.Host = ConfigurationManager.AppSettings["SMTP"];
                    vSmtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FROMEMAIL"], ConfigurationManager.AppSettings["FROMPWD"]);
                    //vSmtp.Credentials = new System.Net.NetworkCredential("lovelybatch", ConfigurationManager.AppSettings["FROMPWD"]);
                    vSmtp.EnableSsl = true;
                    vSmtp.Send(vMsg);

                    //now store same passcode in database under corresponding email address
                    bool success = y.insertPasscode(x);
                    if (success == true)
                    {
                        //HiddenField2.Value = "true";
                        // CurPage. ClientScript.RegisterStartupScript(CurPage.GetType(), "myfunction", "showdiv()", true);
                        // CurPage.ClientScript.RegisterStartupScript( CurPage.GetType(), "myfunction", "showdiv()", true);
                        // ScriptManager.RegisterClientScriptBlock(CurPage,typeof(System.Web.UI.Page),"myfunction","showdiv()",true);

                        return "showdivs";

                    }
                    else
                    {

                        return "xyz"; ;
                    }

                }
                //else
                //{
                //    //HiddenField2.Value = "true";
                //    // CurPage. ClientScript.RegisterStartupScript(CurPage.GetType(), "myfunction", "showdiv()", true);      
                //    return "showdivs";
                //}
            }
            else
            {
                // CurPage.ClientScript.RegisterStartupScript(CurPage.GetType(), "myfunction", "invalidEmail()", true);   
                return "invalidEmails";
            }
        }
        else
        {
            // CurPage.ClientScript.RegisterStartupScript(CurPage.GetType(), "myfunction", "enterEmail()", true);
            return "enterEmails";
        }
    }
}