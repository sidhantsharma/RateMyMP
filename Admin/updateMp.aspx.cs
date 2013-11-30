using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_updateMp : System.Web.UI.Page
{
    mpDetailsBO mpDetailsBO = new mpDetailsBO();
    mpDetailsBAL mpDetailsBAL = new mpDetailsBAL();
    userMasterBO userMasterBO = new userMasterBO();
    userMasterBAL userMasterBAL = new userMasterBAL();
    Int64 mpid = 0;
    DataTable dt1;
    //string[] electedYearVal = { "Select Year","2014", "2009", "2004", "1999"};
    protected void Page_Load(object sender, EventArgs e)
    {
        btnUpdate.Attributes.Add("OnClick", "javascript: return mpDetailsValidate()");
        if (!IsPostBack)
        {
            mpid = Int64.Parse( Request["vid"]);
            dt1 = mpDetailsBAL.getMpDetails(mpid);
            loadcountry();
            loadYear();
            firstName.Text=dt1.Rows[0]["firstName"].ToString ();
            middleName.Text = dt1.Rows[0]["middleName"].ToString();
            lastName.Text = dt1.Rows[0]["lastName"].ToString();
            email.Text = dt1.Rows[0]["email"].ToString();
            phone.Text = dt1.Rows[0]["phone"].ToString();
            mobile.Text = dt1.Rows[0]["mobile"].ToString();
            qualification.Text = dt1.Rows[0]["qualification"].ToString();
            profession.Text = dt1.Rows[0]["profession"].ToString();
            currentAddress.Text = dt1.Rows[0]["currentAddress"].ToString();
            permanentAddress.Text = dt1.Rows[0]["permanentAddress"].ToString();
        }
    }
    protected void loadYear()
    {

        Int16 electedYear = Int16.Parse( dt1.Rows[0]["electedYear"].ToString());
        DropDownelectedYear.Items.Clear();
        DropDownelectedYear.Items.Insert(0, new ListItem("Select Year", "0"));
        DropDownelectedYear.Items.Insert(1, new ListItem("2014", "1"));
        DropDownelectedYear.Items.Insert(2, new ListItem("2009", "2"));
        DropDownelectedYear.Items.Insert(3, new ListItem("2004", "3"));
        // DropDownelectedYear.DataBind();
       
        DropDownelectedYear.Items.FindByText(electedYear.ToString()).Selected= true;
           }
    protected void loadcountry()
    {
        string eyear=dt1.Rows[0]["country"].ToString();
        DropDowncountry.Items.Clear();
        DropDowncountry.DataSource = mpDetailsBAL.loadCountry();
        DropDowncountry.DataTextField = "country";
        DropDowncountry.DataValueField = "countryId";
        DropDowncountry.DataBind();
        DropDowncountry.Items.Insert(0, new ListItem("Select Country", "0"));
        DropDowncountry.Items.FindByText(eyear).Selected = true;
        int x = DropDowncountry.SelectedIndex;
        loadstate();
       // int y = x;
        //DropDowncountry.SelectedIndexChanged(null, null);

    }
    protected void loadstate()
    {
        if (DropDowncountry.SelectedIndex != 0)
        {
            int conutryId = Convert.ToInt32(DropDowncountry.SelectedValue);

            DataTable dt = mpDetailsBAL.loadState(conutryId);
            DropDownState.DataSource = dt;
            DropDownState.DataTextField = "state";
            DropDownState.DataValueField = "stateId";
            DropDownState.DataBind();
            DropDownState.Items.Insert(0, new ListItem("Select State", "0"));
            string estate = dt1.Rows[0]["state"].ToString();
            DropDownState.Items.FindByText(estate).Selected = true;
            loadconstituency();// to load and select the relevant constituency.

            DropDownpermanentState.DataSource = dt;
            DropDownpermanentState.DataTextField = "state";
            DropDownpermanentState.DataValueField = "stateId";
            DropDownpermanentState.DataBind();
            DropDownpermanentState.Items.Insert(0, new ListItem("Select State", "0"));
            string pstate = dt1.Rows[0]["permanentState"].ToString();
            DropDownpermanentState.Items.FindByText(pstate).Selected = true;
            loadpermanentDistrict();

            DropDowncurrentState.DataSource = dt;
            DropDowncurrentState.DataTextField = "state";
            DropDowncurrentState.DataValueField = "stateId";
            DropDowncurrentState.DataBind();
            DropDowncurrentState.Items.Insert(0, new ListItem("Select State", "0"));
            string cstate = dt1.Rows[0]["currentState"].ToString();
            DropDowncurrentState.Items.FindByText(cstate).Selected = true;
            loadcurrentDistrict();

            // put party in party combo box.
            dt.Dispose();
            dt = mpDetailsBAL.loadParty(conutryId);
            DropDownparty.DataSource = dt;
            DropDownparty.DataTextField = "partyName";
            DropDownparty.DataValueField = "partyId";
            DropDownparty.DataBind();
            DropDownparty.Items.Insert(0, new ListItem("Select Party", "0"));
            string pparty = dt1.Rows[0]["partyName"].ToString();
            DropDownparty.Items.FindByText(pparty).Selected = true;
        }
        else
        {
            DropDownState.Items.Clear();
            DropDownState.Items.Insert(0, new ListItem("Select State", "0"));
            DropDownpermanentState.Items.Clear();
            DropDownpermanentState.Items.Insert(0, new ListItem("Select State", "0"));
            DropDowncurrentState.Items.Clear();
            DropDowncurrentState.Items.Insert(0, new ListItem("Select State", "0"));
        }
    }
    protected void loadconstituency()
    {
        if (DropDownState.SelectedIndex != 0)
        {
            byte stateId = byte.Parse(DropDownState.SelectedValue);
            DropDownconstituency.DataSource = mpDetailsBAL.loadConstituency(stateId);
            DropDownconstituency.DataTextField = "constituency";
            DropDownconstituency.DataValueField = "constituencyId";
            DropDownconstituency.DataBind();
            DropDownconstituency.Items.Insert(0, new ListItem("Select Constituency", "0"));
            string pconstituency = dt1.Rows[0]["constituency"].ToString();
            DropDownconstituency.Items.FindByText(pconstituency).Selected = true;
        }
        else
        {
            DropDownconstituency.Items.Clear();
            DropDownconstituency.Items.Insert(0, new ListItem("Select Constituency", "0"));
        }

    }
    protected void loadpermanentDistrict()
    {
        if (DropDownpermanentState.SelectedIndex != 0)
        {
            byte stateId = byte.Parse(DropDownpermanentState.SelectedValue);
            DropDownpermanentDistrict.DataSource = mpDetailsBAL.loadDistrict(stateId);
            DropDownpermanentDistrict.DataTextField = "districtName";
            DropDownpermanentDistrict.DataValueField = "districtId";
            DropDownpermanentDistrict.DataBind();
            DropDownpermanentDistrict.Items.Insert(0, new ListItem("Select District", "0"));
            string pDistrict = dt1.Rows[0]["permanentDistrict"].ToString();
          //  DropDownpermanentDistrict.Items.FindByText(pDistrict).Selected = true;
        }
        else
        {
            DropDownpermanentDistrict.Items.Clear();
            DropDownpermanentDistrict.Items.Insert(0, new ListItem("Select Distirict", "0"));
        }
    }
    protected void loadcurrentDistrict()
    {
        if (DropDowncurrentState.SelectedIndex != 0)
        {
            byte stateId = byte.Parse(DropDowncurrentState.SelectedValue);
            DropDowncurrentDistrict.DataSource = mpDetailsBAL.loadDistrict(stateId);
            DropDowncurrentDistrict.DataTextField = "districtName";
            DropDowncurrentDistrict.DataValueField = "districtId";
            DropDowncurrentDistrict.DataBind();
            DropDowncurrentDistrict.Items.Insert(0, new ListItem("Select District", "0"));
            string cDistrict = dt1.Rows[0]["currentDistrict"].ToString();
            DropDowncurrentDistrict.Items.FindByText(cDistrict).Selected = true;
        }
        else
        {
            DropDowncurrentDistrict.Items.Clear();
            DropDowncurrentDistrict.Items.Insert(0, new ListItem("Select Distirict", "0"));
        }
    }
   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // mp user part.
        userMasterBO.email = email.Text;
        userMasterBO.firstName = firstName.Text;
        userMasterBO.middleName = middleName.Text;
        userMasterBO.lastName = lastName.Text;
        userMasterBO.socialNetwork = false;
        userMasterBO.snTypeId = 0;// 0 for local user
        userMasterBO.status = false;
        userMasterBO.password = "";
        userMasterBO.guid = Int64.Parse( dt1.Rows[0]["guid"].ToString());
        // code to upload and manage unique name of image.

        Guid guid;
        guid= Guid.NewGuid(); // create gloablly unique identifier.
        string s = guid .ToString();
        string filename = FileUpload1.FileName;
        string actualFileName = "";
        string destfolder = "";
        if (filename != "")
        {
            string oldimagename = dt1.Rows[0]["profilePic"].ToString();
           
            string ext = Path.GetExtension(filename); // give extension of selected file
            string[] ss = filename.Split('.'); // split path into two part  --- name and extension
            string actualImagePath = ss[0]; // getting the name part of selected file.
            actualFileName = actualImagePath + guid + ext;
             destfolder = Server.MapPath("~/images/mp/");
             if (oldimagename != "")
             {
                 File.Delete(destfolder + oldimagename);// deleting old image.
             }
            filename = destfolder + actualFileName;
            FileUpload1.SaveAs(filename);// upload file to server.
           
        }
        
        //now part of mpdetails field
        userMasterBO.profilePicPath = actualFileName;
        mpDetailsBO.mpId = Int64.Parse( dt1.Rows[0]["mpid"].ToString());
        mpDetailsBO.countryId =int.Parse( DropDowncountry.SelectedValue);
        mpDetailsBO.constituencyId = Int16.Parse(DropDownconstituency.SelectedValue);
        mpDetailsBO.electedYear = Int16.Parse(DropDownelectedYear.SelectedItem.ToString());
        mpDetailsBO.partyId = byte.Parse(DropDownparty.SelectedValue);
        mpDetailsBO.phone = phone.Text;
        mpDetailsBO.mobile = mobile.Text;
        mpDetailsBO.qualification = qualification.Text;
        mpDetailsBO.profession = profession.Text;
        mpDetailsBO.permenantAddress = permanentAddress.Text;
        mpDetailsBO.permanentDistrict = Int16.Parse(DropDownpermanentDistrict.SelectedValue);
        mpDetailsBO.permanentState = byte.Parse(DropDownpermanentState.SelectedValue);
        mpDetailsBO.currentAddress = currentAddress.Text;
        mpDetailsBO.currentDistrictId = Int16.Parse(DropDowncurrentDistrict.SelectedValue);
        mpDetailsBO.currentStateId = byte.Parse(DropDowncurrentState.SelectedValue);
        updateMpDetails();
    }
    protected void updateMpDetails( )
    {

      bool done = mpDetailsBAL.updateMpDetails(userMasterBO,mpDetailsBO);
      if (done == true)
      {
          // print successfully updated.
          clearfield();
          ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "mpUpdatd()", true);
      }

    }
    protected void clearfield()
    {
            firstName.Text="";
            middleName.Text = "";
            lastName.Text = "";
            email.Text = "";
            phone.Text = "";
            mobile.Text = "";
            qualification.Text = "";
            profession.Text ="";
            currentAddress.Text = "";
            permanentAddress.Text = "";
        DropDowncountry.SelectedIndex=0;
        DropDownelectedYear.SelectedIndex=0;
        DropDownState.SelectedIndex=0;
        DropDownconstituency.SelectedIndex=0;
        DropDownpermanentState.SelectedIndex=0;
        DropDowncurrentState.SelectedIndex=0;
        DropDownpermanentDistrict.SelectedIndex=0;
        DropDowncurrentDistrict.SelectedIndex=0;

        }
    
    protected void DropDowncountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDowncountry.SelectedIndex != 0)
        {
            int conutryId = Convert.ToInt32(DropDowncountry.SelectedValue);

            DataTable dt = mpDetailsBAL.loadState(conutryId);
            DropDownState.DataSource = dt;
            DropDownState.DataTextField = "state";
            DropDownState.DataValueField = "stateId";
            DropDownState.DataBind();
            DropDownState.Items.Insert(0, new ListItem("Select State", "0"));
            string estate = dt1.Rows[0]["state"].ToString();
            DropDownState.Items.FindByText(estate).Selected = true;

            DropDownpermanentState.DataSource = dt;
            DropDownpermanentState.DataTextField = "state";
            DropDownpermanentState.DataValueField = "stateId";
            DropDownpermanentState.DataBind();
            DropDownpermanentState.Items.Insert(0, new ListItem("Select State", "0"));
            string pstate = dt1.Rows[0]["permanentState"].ToString();
            DropDownpermanentState.Items.FindByText(pstate).Selected = true;

            DropDowncurrentState.DataSource = dt;
            DropDowncurrentState.DataTextField = "state";
            DropDowncurrentState.DataValueField = "stateId";
            DropDowncurrentState.DataBind();
            DropDowncurrentState.Items.Insert(0, new ListItem("Select State", "0"));
            string cstate = dt1.Rows[0]["currentState"].ToString();
            DropDowncurrentState.Items.FindByText(cstate).Selected = true;

            // put party in party combo box.
            dt.Dispose();
            dt = mpDetailsBAL.loadParty(conutryId);
            DropDownparty.DataSource = dt;
            DropDownparty.DataTextField = "partyName";
            DropDownparty.DataValueField = "partyId";
            DropDownparty.DataBind();
            DropDownparty.Items.Insert(0,new ListItem("Select Party","0"));
            string pparty = dt1.Rows[0]["partyName"].ToString();
            DropDowncurrentState.Items.FindByText(pparty).Selected = true;
        }
        else
        {
            DropDownState.Items.Clear();
            DropDownState.Items.Insert(0, new ListItem("Select State", "0"));
            DropDownpermanentState.Items.Clear();
            DropDownpermanentState.Items.Insert(0, new ListItem("Select State", "0"));
            DropDowncurrentState.Items.Clear();
            DropDowncurrentState.Items.Insert(0, new ListItem("Select State", "0"));
        }
    }
    protected void DropDownState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DropDownState.SelectedIndex!=0)
        {
            byte stateId=  byte.Parse(DropDownState.SelectedValue);
            DropDownconstituency.DataSource = mpDetailsBAL.loadConstituency(stateId);
            DropDownconstituency.DataTextField = "constituency";
            DropDownconstituency.DataValueField = "constituencyId";
            DropDownconstituency.DataBind();
            DropDownconstituency.Items.Insert(0, new ListItem("Select Constituency", "0"));
            string pconstituency = dt1.Rows[0]["constituency"].ToString();
            DropDowncurrentState.Items.FindByText(pconstituency).Selected = true;
        }
        else
        {
            DropDownconstituency.Items.Clear();
            DropDownconstituency.Items.Insert(0, new ListItem("Select Constituency", "0"));
        }
    }
    protected void DropDownpermanentState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownpermanentState.SelectedIndex != 0)
        {
            byte stateId = byte.Parse(DropDownpermanentState.SelectedValue);
            DropDownpermanentDistrict.DataSource = mpDetailsBAL.loadDistrict(stateId);
            DropDownpermanentDistrict.DataTextField = "districtName";
            DropDownpermanentDistrict.DataValueField = "districtId";
            DropDownpermanentDistrict.DataBind();
            DropDownpermanentDistrict.Items.Insert(0, new ListItem("Select District", "0"));
            string pDistrict = dt1.Rows[0]["permanentDistrict"].ToString();
            DropDownpermanentDistrict.Items.FindByText(pDistrict).Selected = true;
        }
        else
        {
            DropDownpermanentDistrict.Items.Clear();
            DropDownpermanentDistrict.Items.Insert(0, new ListItem("Select Distirict", "0"));
        }
    }
    protected void DropDowncurrentState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDowncurrentState.SelectedIndex != 0)
        {
            byte stateId = byte.Parse(DropDowncurrentState.SelectedValue);
            DropDowncurrentDistrict.DataSource = mpDetailsBAL.loadDistrict(stateId);
            DropDowncurrentDistrict.DataTextField = "districtName";
            DropDowncurrentDistrict.DataValueField = "districtId";
            DropDowncurrentDistrict.DataBind();
            DropDowncurrentDistrict.Items.Insert(0, new ListItem("Select District", "0"));
            string cDistrict = dt1.Rows[0]["currentDistrict"].ToString();
            DropDowncurrentDistrict.Items.FindByText(cDistrict).Selected = true;
        }
        else
        {
            DropDowncurrentDistrict.Items.Clear();
            DropDowncurrentDistrict.Items.Insert(0, new ListItem("Select Distirict", "0"));
        }
    }
    protected void phone_TextChanged(object sender, EventArgs e)
    {
       
    }
    
}