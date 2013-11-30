<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<script type="text/javascript" src="../JS/jquery.js"></script>
<link type="text/css" rel="stylesheet" href="../CSS/Admin/adminLogin.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Welcome Admin</title>

<script >
    $(document).ready(function () {
        $("#forgot-link").click(function () {
            $("#popup-container").fadeIn(500);
            // $("#popup-container").slideDown(500);

        });
        $("#btnCancel").click(function () {
            $("#popup-container").fadeOut(500);
        });

        $("#popup-cross").click(function () {
            $("#popup-container").fadeOut(500);
        });

    });
</script>
    <script>
        function loginValueCheck() {
            var email = $("#<%= txtUserName.ClientID %>").val();
            var password = $("#<%= txtPassword.ClientID %>").val();
            if (email == "" || password == "" || password.length < 8) {
                alert("Please fillup user name and password having  at least 8 character.");
                return false;
            }
            else {
                return true;
            }
        }
        function loginCancel() {
          $("#<%= txtUserName.ClientID %>").val("");
            $("#<%= txtPassword.ClientID %>").val("");
            return false;   
        }
        function wrongcredential() {
            $("#<%= txtUserName.ClientID %>").val("");
            $("#<%= txtPassword.ClientID %>").val("");
            alert("Wrong Credential");
        }
    </script>
</head>

<body>
     <form id="form1" runat="server">
	<!-- Main Container Start -->
    <div id="main-container">
    	<!-- Login Outer Start -->
    	<div id="login-outer">
            <div id="login-inner">
            	<div id="header">
                	<h2> Admin Panel Login</h2>
                </div>
                <!-- Middle Start -->
                <div id="middle">
                		<div class="div-row"></div>
                    	<div class="div-row">
                        	<div class="div-icon"><img src="../Images/admin/user.png" /></div>
                            <div class="div-text"><asp:TextBox ID="txtUserName" class="txtBox" placeholder="username" runat="server"></asp:TextBox></div>
                        </div>
                    	<div class="div-row"></div>
                    	<div class="div-row">
                       		<div class="div-icon"><img src="../Images/admin/password.png" /></div>
                            <div class="div-text"><asp:TextBox ID="txtPassword" class="txtBox" placeholder="password" runat="server" TextMode="Password"></asp:TextBox></div>
                        </div>
                    	<div class="div-row mg-top20">
                        	<div class="div-btn">
                            <asp:Button ID="btnLogin" class="btn"  runat="server" Text="LOGIN" OnClick="btnLogin_Click" />
                            </div>
                           
                        	<div class="div-btn">
                                <asp:Button ID="btnCancel" class="btn"  runat="server" Text="CANCEL" />
                            </div>
                        </div>
                    	<div class="div-row">
                        	<div class="div-link">
                            	<a href="#" id="forgot-link">Forgot Password?</a>
                            </div>
                        </div>
			   </div>
                <!-- Middle Ends -->                
                <div id="footer">
                </div>
            </div>
        </div>
       	<!-- Login Outer Ends -->
    </div>
    <!-- Main Container Ends -->
    
    
    <!-- Forgot Pop-up Starts -->
    <div id="popup-container">
    	<div id="popup-inner">
        	<div id="top-bar">
	            <div id="forgot-label">Forgot Password ?</div>
            	<div id="popup-cross"><img src="../Images/admin/cross.png" /></div>
        	</div>
			 <!-- Forgot Pop-up Middle Starts -->
           <div id="popup-middle">
           		<div class="div-row">
                	<h3 class="mg-left10">Please enter code and reset your password...</h3>
                </div>
           		<div class="div-row mg-top10">
                	<div class="div-text mg-left100">
                        <asp:TextBox ID="txtPasscode" class="popup-txtBox" placeholder="Passcode" runat="server"></asp:TextBox></div>
                </div>
           		<div class="div-row mg-top10">
                	<div class="div-text mg-left100"> <asp:TextBox ID="txtUPassword" class="popup-txtBox" placeholder="New Password" runat="server" TextMode="Password"></asp:TextBox></div>
                </div>
           		<div class="div-row mg-top10">
                	<div class="div-text mg-left100"> <asp:TextBox ID="txtUCPassword" class="popup-txtBox" placeholder="Confirm Password" runat="server" TextMode="Password"></asp:TextBox></div>
                </div>
                <div class="div-row mg-top20">
                  	<div class="div-btn">
                          <asp:Button ID="btnUpdate" class="btn" runat="server" Text="Update" /></div>
                    <div class="div-btn">
                   	   <asp:Button ID="btnUCancel" class="btn" runat="server" Text="Cancel" /> </div>
            	</div>
           </div>
			<!-- Forgot Pop-up Middle Starts -->
		</div>
    </div>
    <!-- Forgot Pop-up Ends -->
         </form>
</body>
</html>
