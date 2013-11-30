<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contactus.aspx.cs" Inherits="contactus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Welcome to Rate My MP</title>
<link rel="stylesheet" type="text/css" href="CSS/bootstrap.min.css" />
<link rel="stylesheet" type="text/css" href="CSS/bootstrap-responsive.min.css" />
<link rel="stylesheet" type="text/css" href="../CSS/style1.css" />

    <!-- google analytics script -->
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
     <%--Twitter Script--%>
     <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "https://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");
       </script>
</head>
<body>
   <form id="mission" runat="server">
    <div id="main">
         <div id="top_headerbar">
         <div class="logo">
            	<%--<a href="Homepage.aspx"><img src="../images/Logo.png"/></a>--%>
              <asp:LinkButton ID="homeRedirect" runat="server" OnClick="homeRedirect_Click"><asp:Image ID="Image1" runat="server" ImageUrl="~/images/Logo.png" /> </asp:LinkButton>
            </div>
        <%--<div class="main_header">
            <div class="logo_1">--%>
                <%--<a href="Homepage.aspx" runat="server"></a>
                <asp:LinkButton ID="homeRedirect" runat="server" OnClick="homeRedirect_Click"><asp:Image ID="Image1" runat="server" ImageUrl="~/images/rmm-logo.png" /> </asp:LinkButton>
            </div>--%>
            <div class="main_header_right">
                

               	<ul class="nav1" >
                   	<li><a href="aboutus.aspx" >About Us</a></li>
                   	<li><a href="ourmission.aspx" >Our Mission</a></li>
                   	<li><a href="contactus.aspx">Contact Us</a></li>
    	         </ul>
                   
            </div>
                </div>
         <div class="tweet_outer">
        <div class="tweet">
                <a href="https://twitter.com/ratemymp" class="twitter-share-button" data-via="" data-lang="en" data-text=" https://twitter.com/ratemymp"> </a>
          </div></div>
      <div class="header_2">
           <div class="background_colr">
          <div class="Abt_us">
              <p class="fnt">Contact Us</p>
          </div>
               <p class="p1">
                   We are always open to user Feedback, Question or Comments. Please submit all queries below :   

               </p>
               </div>
          <div class="message_box" >
              <div class="name4">
                  <asp:Label ID="Label101" runat="server" Text="">Name</asp:Label>
                  <div class="text_box1">
                      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                  </div>    
              </div>
              <div class="email_id">
                  <div class="name5">
                  <asp:Label ID="Label102" runat="server" Text="">Email</asp:Label>
                  <div class="text_box1">
                      <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                  </div>    
              </div>
              </div>
               <%--<div class="contact">
                  <div class="name5">
                  <asp:Label ID="Label104" runat="server" Text="">Contact</asp:Label>
                  <div class="text_box1">
                      <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                  </div>    
              </div>
              </div>--%>
              <div class="message">
                  <asp:Label ID="Label103" runat="server" Text="Message"></asp:Label>
                  <div class="message_box1">
                      <asp:TextBox ID="TextBox3" placeholder="Type your Message here" runat="server" TextMode="MultiLine" Style="width:100%;height:227px;" />
                  </div>
                </div>
               <div class="btn_send">
                   <asp:Button ID="Button1_send" runat="server" Text="Send" />
              </div>
              
          </div>
          <div class="right_contact">
              <div class="feedback_email">
                  <div class="feedback_email_img">
                  <img src="../images/1384293837_email.png" /> </div> <h3> cjayanti@ratemymp.co.in</h3>
              </div>
               <div class="feedback_email_1">
                  <div class="feedback_email_img">
                  <img src="../images/1384293837_email.png" /> </div> <h3> ratemymp.venturepact@gmail.com</h3>
              </div>
              

          </div>
      </div>
    
    </div>
   </form>
</body>
</html>
