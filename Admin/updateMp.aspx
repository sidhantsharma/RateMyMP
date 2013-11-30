<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="updateMp.aspx.cs" Inherits="Admin_updateMp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

  
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

      
    <div id="content">
   
         <script lang="javascript" type="text/javascript">
             function mpDetailsValidate() {
                
                 var fname = $('#<%= firstName.ClientID %>').val();
                 var lname = $('#<%= lastName.ClientID %>').val();
                 var email = $('#<%= email.ClientID %>').val();
                 var fupload = $('#<%= FileUpload1.ClientID %>').val();
                 var country = $('#<%= DropDowncountry.ClientID %>').val();
                 var state = $('#<%= DropDownState.ClientID %>').val();
                 var constituency = $('#<%= DropDownconstituency.ClientID %>').val();
                 var party = $('#<%= DropDownparty.ClientID %>').val();
                 var electedYear = $('#<%= DropDownelectedYear.ClientID %>').val();
                 if(fname==''||lname==''||email==''||country==0||state==0||constituency==0||party==0||electedYear==0)
                 {
                     alert("please fill up all required field.");
                     return false;
                }
                 else
                 {
                    return true;
                }
             }

             function mpAlreadyExists() {
                 alert("This MP already exist.");
             }
             function newMpRegistered() {
                 alert("MP details successfully inserted.");
             }

    </script>
        <asp:ToolkitScriptManager runat="server"></asp:ToolkitScriptManager>
         
         
        <asp:Label CssClass="lbl" ID="fstName" runat="server" Text="First Name" Width="200px"></asp:Label>
        <asp:TextBox ID="firstName" runat="server" Width="142px"></asp:TextBox>
        <br />
        <asp:Label CssClass="lbl" ID="MdlName" runat="server" Text="Middle Name" Width="200px"></asp:Label>
        <asp:TextBox ID="middleName" runat="server" Width="142px"></asp:TextBox>
        <br/>
        
        <asp:Label CssClass="lbl" ID="lstName" runat="server" Text="Last Name" Width="200px"></asp:Label>   
        <asp:TextBox ID="lastName" runat="server" Width="142px"></asp:TextBox>
        <br/>
        <asp:Label CssClass="lbl" ID="lemail" runat="server" Text="E-Mail" Width="200px"></asp:Label>   
         <asp:TextBox ID="email" runat="server" Width="142px" TextMode="Email"></asp:TextBox>

             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ErrorMessage="Enter Valid Email" Font-Size="Smaller" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

        <br/>

        <asp:Label CssClass="lbl" ID="profilepic" runat="server" Text="Upload A profile Pic" Width="200px"></asp:Label>   
        <asp:FileUpload ID="FileUpload1" runat="server" />
        
        <br/>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
         <ContentTemplate>
        <asp:Label CssClass="lbl" ID="lcountry" runat="server" Text="Country" Width="200px"></asp:Label>   
        <asp:DropDownList ID="DropDowncountry" runat="server" Width="143px" OnSelectedIndexChanged="DropDowncountry_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>Select Country</asp:ListItem>
        </asp:DropDownList>

        <br/>
        <asp:Label CssClass="lbl" ID="Labelstate" runat="server" Text="State" Width="200px"></asp:Label>  
        <asp:DropDownList ID="DropDownState" runat="server" Width="143px" AutoPostBack="True" OnSelectedIndexChanged="DropDownState_SelectedIndexChanged">
            <asp:ListItem>Select State</asp:ListItem>
        </asp:DropDownList>
        <br/>
        <asp:Label CssClass="lbl" ID="lconstituency" runat="server" Text="Constituency" Width="200px" Height="20px"></asp:Label>   
        <asp:DropDownList ID="DropDownconstituency" runat="server" Width="143px">
            <asp:ListItem Selected="True">Select Constituency</asp:ListItem>
        </asp:DropDownList>

        <br/>
        
        
        <asp:Label CssClass="lbl" ID="lparty" runat="server" Text="Party" Width="201px" Height="23px"></asp:Label>  
        <asp:DropDownList ID="DropDownparty" runat="server" Width="143px">
            <asp:ListItem>Select Party</asp:ListItem>
        </asp:DropDownList>
        
         <br/>
        
        
        <asp:Label CssClass="lbl" ID="lelectedYear" runat="server" Text="Elected Year" Width="200px" Height="20px"></asp:Label>  
        <asp:DropDownList ID="DropDownelectedYear" runat="server">   
        </asp:DropDownList>

         <br/>
        <asp:Label CssClass="lbl" ID="Lphone" runat="server" Text="Phone" Width="200px"></asp:Label>   
        <asp:TextBox ID="phone" runat="server" Width="142px" MaxLength="20" OnTextChanged="phone_TextChanged"></asp:TextBox>
        
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="phone" ErrorMessage="Enter Valid Phone Number" Font-Size="Smaller" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d{10,17}"></asp:RegularExpressionValidator>
        
        <br/>
        <asp:Label CssClass="lbl" ID="Lmobile" runat="server" Text="Mobile" Width="200px"></asp:Label>   
        <asp:TextBox ID="mobile" runat="server" Width="142px" MaxLength="20" TextMode="Phone"></asp:TextBox>
        
             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="mobile" ErrorMessage="Enter Valid Mobile Number" Font-Size="Smaller" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d{10,17}"></asp:RegularExpressionValidator>
        
        <br/>
        <asp:Label CssClass="lbl" ID="Lqualfication" runat="server" Text="Qualification" Width="200px"></asp:Label>   
        <asp:TextBox ID="qualification" runat="server" Width="142px"></asp:TextBox>
        
        <br/>
        <asp:Label CssClass="lbl" ID="lprofession" runat="server" Text="Profession" Width="200px"></asp:Label>   
        <asp:TextBox ID="profession" runat="server" Width="142px"></asp:TextBox>
        
        <br/>
        <asp:Label CssClass="lbl" ID="lpermAddr" runat="server" Text="Permanent Address" Width="200px"></asp:Label>
        <asp:TextBox ID="permanentAddress" runat="server" Width="142px"></asp:TextBox>
        
         <br/>
        <asp:Label CssClass="lbl" ID="permState" runat="server" Text="Permanent State" Width="200px"></asp:Label>  
        <asp:DropDownList ID="DropDownpermanentState" runat="server" Width="143px" AutoPostBack="True" OnSelectedIndexChanged="DropDownpermanentState_SelectedIndexChanged">
            <asp:ListItem>Select State</asp:ListItem>
        </asp:DropDownList>

        <br/>
       
         <asp:Label CssClass="lbl" ID="permDist" runat="server" Text="Permanent District" Width="200px"></asp:Label>   
        <asp:DropDownList ID="DropDownpermanentDistrict" runat="server" Width="143px">
            <asp:ListItem>Select District</asp:ListItem>
        </asp:DropDownList>
         <br/>
        <asp:Label CssClass="lbl" ID="curAddr" runat="server" Text="Current Address" Width="200px"></asp:Label>   
        <asp:TextBox ID="currentAddress" runat="server" Width="142px"></asp:TextBox>
        
        <br/>
      
         <asp:Label CssClass="lbl" ID="curState" runat="server" Text="Current State" Width="200px"></asp:Label>   
        <asp:DropDownList ID="DropDowncurrentState" runat="server" Width="143px" AutoPostBack="True" OnSelectedIndexChanged="DropDowncurrentState_SelectedIndexChanged">
            <asp:ListItem>Select State</asp:ListItem>
        </asp:DropDownList>

         <br/>
         <asp:Label CssClass="lbl" ID="curDist" runat="server" Text="Current  District" Width="200px"></asp:Label>  
        <asp:DropDownList ID="DropDowncurrentDistrict" runat="server" Width="143px">
             <asp:ListItem>Select District</asp:ListItem>
        </asp:DropDownList>

        <br/>
        </ContentTemplate>
      </asp:UpdatePanel>        
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    
    </div>
     
  
</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .lbl
        {}
    </style>
</asp:Content>



