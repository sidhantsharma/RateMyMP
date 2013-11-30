<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<link rel="shortcut icon" href="images/fevi.png" type="image/x-icon" />
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/styleSheet.css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Welcome to Rate My MP</title>

    <script type="text/javascript" src="JS/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="JS/bootstrap.min.js"></script>


    <!--google analytics tool script -->
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-44359262-2', 'ratemymp.co.in');
        ga('send', 'pageview');

    </script>


    <!--  google login -->

    <script src="https://apis.google.com/js/client.js"></script>

    <script type="text/javascript">
        (function () {
            var po = document.createElement('script');
            po.type = 'text/javascript';
            po.async = true;
            po.src = 'https://apis.google.com/js/client:plusone.js?onload=render';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(po, s);
        })();

        function render() {
            //724686509082.apps.googleusercontent.com           client id for testing purpose
            //1098020128859-hipo9jis3pjfocmlrk9v83vqs1dod7uh.apps.googleusercontent.com                client id for ratemymp.co.in
            gapi.signin.render('googlesignup', {
                'callback': 'signinCallback',
                'approvalprompt': 'force',
                'clientid': '1098020128859-hipo9jis3pjfocmlrk9v83vqs1dod7uh.apps.googleusercontent.com',
                'cookiepolicy': 'single_host_origin',
                'height': 'short',
                'requestvisibleactions': 'http://schemas.google.com/AddActivity',
                'scope': 'https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile'
            });
        }

        function signinCallback(authResult) {
            if (authResult) {
                if (authResult['access_token']) {
                    // Successfully authorized
                    // Hide the sign-in button now that the user is authorized, for example:
                    gapi.auth.setToken(authResult);
                    // document.getElementById('customBtn').setAttribute('style', 'display: none');
                    // document.getElementById('logout').setAttribute('style', 'display: block');
                    getemail();

                }
                else if (authResult['error']) {
                    // There was an error.

                }
            }
        }
        function getemail() {

            gapi.client.load('oauth2', 'v2', function () {

                var request = gapi.client.oauth2.userinfo.get();

                request.execute(getEmailCallback);
            });

            // this is used for image also. 

            // gapi.client.load('plus', 'v1', function () {
            //    var request = gapi.client.plus.people.get({
            //        'userId': 'me'
            //    });
            //    request.execute(function (resp) {
            //        // console.log('Retrieved profile for:' + resp.displayName);
            //        alert(resp.displayName);
            //        // alert(resp.email);
            //       // alert(Object.keys(resp));
            //    });
            //});
        }

        function getEmailCallback(obj) {
            //alert(Object.keys(obj));
            // Here obj stores data in json format
            var picture = obj['picture'];
            //alert(picture);
            var email = '';
            var name = '';
            if (obj['email']) {

                email = obj['email'];
            }

            if (obj['name']) {

                name = obj['name'];
            }
            var socialtype = "GOOGLE";
            var social = "yes";
            document.location.href = "Web_Forms/homepage.aspx?email=" + email + "&name=" + name + "&social=" + social + "&socialType=" + socialtype + "&image=" + picture;
            // document.location.href = "Web_Forms/test.aspx?email=" + email + "&name=" + name + "&social=" + social + "&socialType=" + socialtype  + "&image=" + picture;
        }
    </script>


    <%--Messages for user--%>
    <script type="text/javascript">

        function userCreated() {
            alert("Your account is successfully created ");
            document.location.href = "Web_Forms/Homepage.aspx";
        }

        function userUpdated() {
            alert("Your account is successfully Updated ");
            document.location.href = "Web_Forms/Homepage.aspx";
        }

        function userNotCreated() {
            alert("Sorry this account already exists.");

        }

        function WrongCredential() {
            alert("Please give your right Credentials.");

        }
    </script>

    <%--Validations Scripts--%>

    <script>
        function wrongCredential() {
            $("#<%= txtPasscode.ClientID %>").val("");
                $("#<%= txtPassword.ClientID %>").val("");
                $("#<%= txtCPassword.ClientID %>").val("");
                $("#<%= signinemail.ClientID %>").val("");
                alert("Please enter the right passcode and password.");
            }

            function passwordUpdated() {
                alert("Password Successfully Updated. ");
                // setTimeout("redirect()", 3000); // cal the redirect function after 3 seconds
                $("#<%= txtPasscode.ClientID %>").val("");
                $("#<%= txtPassword.ClientID %>").val("");
                $("#<%= txtCPassword.ClientID %>").val("");
                $("#<%= signinemail.ClientID %>").val("");
                // $("#win-forgot").slideUp(500);
            }

            function validateUpdatePassword() {
                var xx = $("#<%= txtPassword.ClientID %>").val();
                var yy = $("#<%= txtCPassword.ClientID %>").val();
                var zz = $("#<%= txtPasscode.ClientID %>").val();

                if (xx !== '' && yy != '' && zz != '') {

                    if (xx.length < 8 || yy.length < 8 || zz.length < 8) {

                        alert("Password  and passcode Must Contain at least 8 character");
                        return false;
                    }
                    else {
                        if (xx == yy) {
                            return true;
                        }
                        else {
                            alert("Password and confirm password must be same.");
                            return false;
                        }

                    }
                }
                else {
                    alert("Please fillup all the fields");
                    return false;
                }

            }



            function signinValueCheck() {
                var email = $("#<%= signinemail.ClientID %>").val();
            var password = $("#<%= signinPassword.ClientID %>").val();
            if (email == "" || password == "" || password.length < 8) {
                alert("Please fillup email and Password having  at least 8 character.");
                return false;
            }
            else {
                __doPostBack("btnSingin", '');// make postback to server.
                return true;
            }

        }
        function OnKeyUp(obj)// for chrome and ie
        {
            if (obj.id == "signinPassword" && window.event.keyCode == 13) {
                var clickButton = document.getElementById("<%= btnSingin.ClientID %>");
                    clickButton.click(); // call click event of  signin button.
                }
            }


            function keypress(event) //for firefox
            {
                var key = event.keyCode;
                if (key == 13) {
                    var btnid = "#<%=btnSingin.ClientID%>";
                   $(btnid).click();

                   // return true;

               }
           }




           // $("#<%= signinPassword.ClientID %>").keydown(function (e) {
        // if (e.keyCode == 13) {
        // $("#<%=btnSingin.ClientID%>").click();
        // }
        // });


        function signupValueCheck() {
            var email = $("#<%= email.ClientID %>").val();
                var password = $("#<%= password.ClientID %>").val();
                var lastName = $("#<%= lastName.ClientID %>").val();
                var firstName = $("#<%= firstName.ClientID %>").val();
                if (email == "" || password == "" || lastName == "" || firstName == "" || password.length < 8) {
                    alert("Please fillup all the field and password having at least 8 character.");
                    return false;
                }
                else {

                    return true;
                }
            }

    </script>

    <script>

        document.getElementById("forgotlink").addEventListener("click", emails, false);// this is needed for chrome browser in case of anchor tag to call click event.
        function emails() {

            var emailID = $('#signinemail').val();
            if (emailID == '') {
                alert("Please Enter email");
                $("#forgotlink").attr('href', "#");
                return false;
            }
            else {
                $("#forgotlink").attr('href', "#forgot");

                //PageMethods.generatePasscode(emailID);
                // here generatePasscode  is a static method in serverside. this is the way how to call serverside method from client side javascript function.
                return PageMethods.generatePasscode(emailID, function (result) {

                    if (result == "showdivs") {
                        alert("Please use recent passcode  given in your email to  reset new password yourself");
                        $("#forgot-popup").fadeIn(500);
                        $("#forgotlink").attr('href', "#forgot");

                    }
                    else if (result == "invalidEmails") {
                        alert("Invalid Emails")
                        $("#forgot").fadeOut(500);
                        $("#forgotlink").attr('href', "#");

                    }
                    else if (result == "enterEmail") {
                        $("#forgotlink").attr('href', "#");

                    }
                });
            }
        }
    </script>


    <script>
        $(document).ready(function () {
            $(".popup-cross").click(function () {
                $("#forgot-popup").fadeOut(500);
            });
            $(".forgot-cancel").click(function () {
                $("#forgot-popup").fadeOut(500);
            });

        });
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <!-- Main Container Start -->
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" EnablePageMethods="true"></asp:ScriptManager>
        <!-- Header Start -->
        <div id="main-header">
            <div id="header-inner">
                <div class="header-logo">
                    <a href="#">
                        <img src="images/logo.png" alt="logo" /></a>
                </div>
                <div class="header-login-btn">
                    <%--<button class="btn" onclick="btnSingin_Click" tabindex="3">Login</button>--%>
                    <asp:Button ID="btnSingin" class="btn" runat="server" OnClick="btnSingin_Click" OnClientClick="return signinValueCheck()" TabIndex="3" Text="Login" />

                </div>
                <div class="header-form">
                    <div class="header-form-row">
                        <div class="header-form-column">
                            <!--<p>Hidden error msg here</p>-->
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <p>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage=" Enter valid email " ControlToValidate="signinemail" ForeColor="#f80606" SetFocusOnError="True" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </p>

                        </div>
                    </div>
                    <div class="header-form-row">
                        <div class="header-form-column">
                            <%--<input class="txt-box" type="text" placeholder="email"/>--%>
                            <asp:TextBox ID="signinemail" class="txt-box" placeholder="email" runat="server" MaxLength="49" TabIndex="1"></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="signinEmailValidation"  runat="server" ErrorMessage=" enter valid email id" ControlToValidate="signinemail" ForeColor="#FF0066" SetFocusOnError="True" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                        </div>
                        <div class="header-form-column">
                            <%--<input class="txt-box" type="password" placeholder="password"/>--%>
                            <asp:TextBox ID="signinPassword" class="txt-box" placeholder="password" runat="server" onKeyPress=" return keypress(event);" onKeyUp="OnKeyUp(this);" TextMode="Password" MaxLength="49" TabIndex="2"></asp:TextBox>

                        </div>
                    </div>
                    <div class="header-form-row">
                        <div class="header-form-column">
                            <div class="header-form-chkbox">
                                <asp:CheckBox ID="chkRememberMe" runat="server" TabIndex="4" />Remember me</div>
                        </div>
                        <div class="header-form-column">
                            <div class="header-form-chkbox">
                                <%--<a class="forgot" href="#">Forgot password?</a>--%>
                                <a id="forgotlink" href="javascript:void(0)" onclick="emails()" class="forgot" tabindex="5">Forgot Password?</a>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <!-- Header Ends -->

        <!-- Middle Start -->
        <div id="main-middle">
            <div id="middle-inner">
                <div class="middle-inner-left">
                    <div class="left-img">
                        <img src="images/SideImg.png" />
                    </div>
                </div>
                <div class="middle-inner-right">
                    <div class="right-content">
                        <div class="right-content-row">

                            <%-- Face book api (        ****************** Start *******************     ) --%>

                            <script type="text/javascript" src="JS/fb.js"></script>
                            <script src="http://connect.facebook.net/en_US/all.js" type="text/javascript"></script>

                            <script>

                                // Init the SDK upon load
                                window.fbAsyncInit = function () {
                                    FB.init({
                                        appId: '421695167935164', // App ID  214812398681584 final app id 421695167935164
                                        channelUrl: '//' + window.location.hostname + '/channel', // Path to your Channel File
                                        status: true, // check login status
                                        cookie: true, // enable cookies to allow the server to access the session
                                        xfbml: true  // parse XFBML

                                    });
                                };
                                // Load the SDK Asynchronously

                                (function (d) {
                                    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
                                    if (d.getElementById(id)) { return; }
                                    js = d.createElement('script'); js.id = id; js.async = true;
                                    js.src = "//connect.facebook.net/en_US/all.js";
                                    ref.parentNode.insertBefore(js, ref);
                                }(document));


                                function login() {

                                    FB.login(function (response) {
                                        // if (response.authResponse) {
                                        //'/me',
                                        FB.api('/me', function (response) {
                                            if (response.name) {
                                                //alert(Object.keys(response));

                                                var picture = "http://graph.facebook.com/" + response.id + "/picture";
                                                var name = "";
                                                var email = "";
                                                var social = "yes";

                                                var socialtype = "FACEBOOK";
                                                name = response.name;
                                                email = response.email;
                                                // alert(email);
                                                // username = response.username 
                                                if (email == undefined) {
                                                    alert("Please allow access to email.");
                                                    FB.logout(function () {
                                                        window.location.reload();
                                                        document.location.href = "Default.aspx";
                                                    });
                                                }
                                                else {
                                                    // alert(email);
                                                    document.location.href = "Web_Forms/homepage.aspx?email=" + email + "&name=" + name + "&social=" + social + "&socialType=" + socialtype + "&image=" + picture;

                                                    //document.location.href = "Web_Forms/test.aspx?email=" + email + "&name=" + name + "&social=" + social + "&socialType=" + socialtype + "&image=" + picture;
                                                    // document.location.href = "test.aspx?emailsval=" + email + "&nameval=" + name + "&socialornot=" + social + "&socialtype=" + socialtype;
                                                }
                                            }
                                            // }

                                        })

                                    }, { scope: 'email' });
                                }
                            </script>
                            <div id="btnfblogin" class="btn-facebook" onclick="login()">Sign In with Facebook</div>
                        </div>
                        <div id="right-content-row">

                            <div id="googlesignup" class="btn-google">Sign In with Google</div>

                            <%--<button class="btn-google">Sign In with Google</button>--%>
                        </div>
                        <div class="right-content-row">
                            <div class="right-content-row-label"><b>OR</b></div>
                            <div class="right-content-row-label">Create Rate My MP account</div>
                        </div>
                        <div class="right-content-row-txtbox">
                            <div class="right-content-column-left">
                                <%--<input class="txt-box" type="text" placeholder="First Name"/>--%>
                                <asp:TextBox ID="firstName" class="txt-box" placeholder="First Name" runat="server" MaxLength="49" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="right-content-column-right">
                                <%--<input class="txt-box" type="text" placeholder="Last Name"/>--%>
                                <asp:TextBox ID="lastName" class="txt-box" placeholder="Last Name" runat="server" TabIndex="9"></asp:TextBox>

                            </div>
                        </div>
                        <div class="right-content-row-txtbox">
                            <div class="right-content-column-left">
                                <%--<input class="txt-box" type="text" placeholder="Email"/>--%>
                                <asp:TextBox ID="email" class="txt-box" placeholder="Email" runat="server" MaxLength="49" TabIndex="10"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="signupEmailValidation" runat="server" ErrorMessage="Enter valid email " ControlToValidate="email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True"></asp:RegularExpressionValidator>
                            </div>
                            <div class="right-content-column-right">
                                <%--<input class="txt-box" type="password" placeholder="Password"/>--%>
                                <asp:TextBox ID="password" class="txt-box" placeholder="Password" runat="server" MaxLength="49" TabIndex="11" TextMode="Password"></asp:TextBox>


                            </div>
                        </div>
                        <div class="right-content-row">
                            <%--<button class="btn-signup">Sign Up</button>--%>
                            <%--<asp:LinkButton ID="btnSignup" class="btn-signup" runat="server"  OnClick="btnSignup_Click" OnClientClick="return signupValueCheck()" TabIndex="12"  Text="Sign Up"/>--%>
                            <asp:Button ID="btnSignup" class="btn-signup" runat="server" OnClick="btnSignup_Click" OnClientClick="return signupValueCheck()" TabIndex="12" Text="Sign Up" />
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <!-- Middle Ends -->

        <!-- Footer Start -->
        <div id="main-footer">
            <div id="footer-inner">
                <div class="footer-nav">
                    <div class="footer-nav-content">
                        <div class="nav-menu"><a href="Web_Forms/aboutus.aspx" class="transition color-white" tabindex="13">About Us</a></div>
                        <div class="nav-menu"><a href="Web_Forms/ourmission.aspx" class="transition color-white" tabindex="14">Our Mission</a></div>
                        <div class="nav-menu"><a href="Web_Forms/contactus.aspx" class="transition color-white" tabindex="15">Contact Us</a></div>
                         <div class="nav-menu"><a href="Web_Forms/howtouse.aspx" class="transition color-white">How to Use</a></div>

                    </div>
                </div>
                <div class="footer-copyright-terms">
                    &copy; 2013 Rate My MP | <a href="#">Terms & Privacy</a>
                </div>

                <div class="footer-social">
                    <div class="social-icon"><a href="https://facebook.com/ratemymp">
                        <img alt="facebook" src="images/facebook.png" /></a></div>
                    <div class="social-icon"><a href="https://twitter.com/ratemymp">
                        <img alt="twitter" src="images/twitter.png" /></a></div>
                </div>
                <div class="footer-follow">
                    Follow us on
                </div>
            </div>
        </div>

        <!-- Footer Ends -->

        <!-- Main Container Ends -->


        <!-- Forgot Pop-up Starts -->
        <div class="popup-container" id="forgot-popup">
            <div class="popup-inner">
                <div class="top-bar">
                    <div class="top-bar-label">Forgot Password?</div>
                    <div class="popup-cross">
                        <img src="images/cross.png" /></div>
                </div>
                <!-- Forgot Pop-up Middle Starts -->
                <div class="popup-middle">
                    <div class="div-row">
                        <div class="txt-label">Get passcode from email and reset password !</div>
                    </div>
                    <div class="div-row">
                        <div class="div-text">
                            <%--<input class="txtBox" type="text" placeholder="Passcode"  />--%>
                            <asp:TextBox ID="txtPasscode" class="txtBox" placeholder="Passcode" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>

                        </div>
                    </div>
                    <div class="div-row">
                        <div class="div-text">
                            <%--<input class="txtBox" type="password" placeholder="New Password"  />--%>
                            <asp:TextBox ID="txtPassword" class="txtBox" placeholder="New Password" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="div-row">
                        <div class="div-text">
                            <%--<input class="txtBox" type="password" placeholder="Confirm Password"/>--%>
                            <asp:TextBox ID="txtCPassword" class="txtBox" placeholder="Confirm Password" runat="server" TextMode="Password"></asp:TextBox>

                        </div>
                    </div>
                    <div class="div-row">
                        <div class="div-btn-update">
                            <%--<button class="btn-each" type="button" >Update</button>--%>
                            <asp:Button ID="PasswordUpdate" class="btn-each" runat="server" OnClick="PasswordUpdate_Click" OnClientClick="return validateUpdatePassword()" Text="Update" />

                        </div>
                        <div class="div-btn-cancel">
                            <button class="btn-each" id="forgot-cancel" onclick="return false;">Cancel</button>
                        </div>
                    </div>
                </div>
                <!-- Forgot Pop-up Middle Ends -->
            </div>
        </div>
        <!-- Forgot Pop-up Ends -->

    </form>
    <!--users nap -->
    <script type="text/javascript">
        var _usersnapconfig = {
            apiKey: '4ad9c2d8-f944-4f85-adf1-2d118d7247ca',
            valign: 'bottom',
            halign: 'right',
            tools: ["pen", "highlight", "note"],
            lang: 'en',
            commentBox: true,
            emailBox: true
        };
        (function () {
            var s = document.createElement('script');
            s.type = 'text/javascript';
            s.async = true;
            s.src = '//api.usersnap.com/usersnap.js';
            var x = document.getElementsByTagName('head')[0];
            x.appendChild(s);
        })();
    </script>


</body>
</html>
