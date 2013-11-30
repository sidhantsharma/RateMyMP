using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_registerMp : System.Web.UI.Page
{
    mpDetailsBO mpDetailsBO = new mpDetailsBO();
    mpDetailsBAL mpDetailsBAL = new mpDetailsBAL();
    userMasterBO userMasterBO = new userMasterBO();
    userMasterBAL userMasterBAL = new userMasterBAL();
    //string[] electedYearVal = { "Select Year","2014", "2009", "2004", "1999"};
    protected void Page_Load(object sender, EventArgs e)
    {
        btnRegister.Attributes.Add("OnClick", "javascript: return mpDetailsValidate()");
        
        if (!IsPostBack)
        { 
            loadcountry();
            loadYear();
        }
    }
    protected void loadYear()
    {

        DropDownelectedYear.Items.Clear();
        DropDownelectedYear.Items.Insert(0, new ListItem("Select Year", "0"));
        DropDownelectedYear.Items.Insert(1, new ListItem("2014", "1"));
        DropDownelectedYear.Items.Insert(2, new ListItem("2009", "2"));
        DropDownelectedYear.Items.Insert(3, new ListItem("2004", "3"));
        // DropDownelectedYear.DataBind();
    }
    protected void loadcountry()
    {
        DropDowncountry.Items.Clear();
        DropDowncountry.DataSource = mpDetailsBAL.loadCountry();
        DropDowncountry.DataTextField = "country";
        DropDowncountry.DataValueField = "countryId";
        DropDowncountry.DataBind();
        DropDowncountry.Items.Insert(0, new ListItem("Select Country", "0"));
     
    }
   
    protected void btnreg_Click(object sender, EventArgs e)
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
        // code to upload and manage unique name of image.

        Guid guid;
        guid= Guid.NewGuid(); // create gloablly unique identifier.
        string s = guid .ToString();
        string filename = FileUpload1.FileName;          
        string ext = Path.GetExtension(filename); // give extension of selected file
        string[] ss = filename.Split('.'); // split path into two part  --- name and extension
        string actualImagePath = ss[0]; // getting the name part of selected file.
        string actualFileName = actualImagePath + guid + ext;
        string destfolder = Server.MapPath("~/images/mp/");
        filename = destfolder + actualFileName;
        FileUpload1.SaveAs(filename);
        userMasterBO.profilePicPath = actualFileName;

        //now part of mpdetails field
  
        mpDetailsBO.countryId =int.Parse( DropDowncountry.SelectedValue);
        mpDetailsBO.constituencyId = Int16.Parse(DropDownconstituency.SelectedValue);
        mpDetailsBO.electedYear = Int16.Parse(DropDownelectedYear.SelectedItem.ToString());
        mpDetailsBO.partyId = byte.Parse(DropDownparty.SelectedValue);
        mpDetailsBO.phone = phone.Text;
        mpDetailsBO.mobile = mobile.Text;
        mpDetailsBO.qualification = qualification.Text;
        mpDetailsBO.profession = profession.Text;
        mpDetailsBO.permenantAddress = permanentAddress.Text;
        if (DropDownpermanentDistrict.SelectedIndex == 0)
        {
            mpDetailsBO.permanentDistrict = 0;
        }
        else
        {
            mpDetailsBO.permanentDistrict = Int16.Parse(DropDownpermanentDistrict.SelectedValue);
        }
        if (DropDownpermanentState.SelectedIndex == 0)
        {
            mpDetailsBO.permanentState = 0;
        }
        else
        {
            mpDetailsBO.permanentState = byte.Parse(DropDownpermanentState.SelectedValue);
        }
       
        mpDetailsBO.currentAddress = currentAddress.Text;

        if (DropDowncurrentDistrict.SelectedIndex == 0)
        {
            mpDetailsBO.currentDistrictId = 0;
        }
        else
        {
            mpDetailsBO.currentDistrictId = Int16.Parse(DropDowncurrentDistrict.SelectedValue);
        }
        if (DropDowncurrentState.SelectedIndex == 0)
        {
            mpDetailsBO.currentStateId = 0;
        }
        else
        {
            mpDetailsBO.currentStateId = byte.Parse(DropDowncurrentState.SelectedValue);
        }

        saveMpDetails( actualFileName,destfolder);

    }
    protected void saveMpDetails( string actualFileName,string destfolder)
    {

      bool done = mpDetailsBAL.saveMpDetails(userMasterBO,mpDetailsBO);
      if (done == true)
      {
          //  mp aleredy exist
          File.Delete(destfolder + actualFileName);
          ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "mpAlreadyExists()", true);
      }
      else
      {
          // new mp entered.
          ClientScript.RegisterStartupScript(this.GetType(), "myfunction", "newMpRegistered()", true);
      }


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

            DropDownpermanentState.DataSource = dt;
            DropDownpermanentState.DataTextField = "state";
            DropDownpermanentState.DataValueField = "stateId";
            DropDownpermanentState.DataBind();
            DropDownpermanentState.Items.Insert(0, new ListItem("Select State", "0"));

            DropDowncurrentState.DataSource = dt;
            DropDowncurrentState.DataTextField = "state";
            DropDowncurrentState.DataValueField = "stateId";
            DropDowncurrentState.DataBind();
            DropDowncurrentState.Items.Insert(0, new ListItem("Select State", "0"));

            // put party in party combo box.
            dt.Dispose();
            dt = mpDetailsBAL.loadParty(conutryId);
            DropDownparty.DataSource = dt;
            DropDownparty.DataTextField = "partyName";
            DropDownparty.DataValueField = "partyId";
            DropDownparty.DataBind();
            DropDownparty.Items.Insert(0,new ListItem("Select Party","0"));
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
        }
        else
        {
            DropDownpermanentDistrict.Items.Clear();
            DropDownpermanentDistrict.Items.Insert(0, new ListItem("Select Distirict", "0"));
        }
    }
    protected void DropDowncurrentState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownpermanentState.SelectedIndex != 0)
        {
            byte stateId = byte.Parse(DropDowncurrentState.SelectedValue);
            DropDowncurrentDistrict.DataSource = mpDetailsBAL.loadDistrict(stateId);
            DropDowncurrentDistrict.DataTextField = "districtName";
            DropDowncurrentDistrict.DataValueField = "districtId";
            DropDowncurrentDistrict.DataBind();
            DropDowncurrentDistrict.Items.Insert(0, new ListItem("Select District", "0"));
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