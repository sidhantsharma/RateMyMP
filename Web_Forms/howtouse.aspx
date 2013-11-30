<%@ Page Language="C#" AutoEventWireup="true" CodeFile="howtouse.aspx.cs" Inherits="Web_Forms_howtouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>How To Use</title>
<link rel="stylesheet" type="text/css" href="CSS/bootstrap.min.css" />
    <link rel="shortcut icon" href="images/fevi.png" type="image/x-icon"/>
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
      <form id="about" runat="server">
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
        <%--</div>--%>
      <div class="header_1 ">
          <div class="background_colr">
          <div class="Abt_us">
              <p class="fnt">How To Use</p>
            
          </div>

          <%--<p class="p1">
              Rate My MP is a tool that provides citizens in India a public platform to share their ideas and concerns with their government representatives and each other. Through words, pictures, or video testimony, you can bring to light prominent issues facing your community and communicate them directly with your MPs on an open forum.
          </p>--%>
              </div>
          <div class="outer_help">
        <p class="p2">
Step 1: Select your State and Constituency and access your Member of Parliament’s profile. In addition to your own Member of Parliament, you can access any MP from any State or Constituency as well.

</p>


            <div class="help_image">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/1.jpg" />

            </div>



<p class="p2">

Step 2:  Write anything you want about your Member of Parliament. It can be personal experiences you’ve had with the MP, problems you’re experiencing in your constituency, things you’ve read about the MP, or even your own analysis on contemporary issues. Remember, comments that get 20 Votes Up will be sent directly to the MP, so be sure to write something you think others will agree with. Categorise your comment as praise, criticism, suggestions, or miscellaneous, and click Post!
               <div class="help_image1">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/2.jpg" />
                   </div>
    </p>

          <p class="p2">
Step 3: Take a look through other comments about your MP! You can sort them by type, date, and popularity. Vote up comments that you agree with and vote down ones that you don’t agree with. These users are part of you constituency too so look out for comments you really like and contact the poster!
  
              <div class="help_image3">
 <asp:Image ID="Image4" runat="server" ImageUrl="~/images/3.jpg" />
                  </div>
              </p>
          <p class="p2">
Step 4: Scroll down and Rate Your MP on important performance metrics!
              <div class="help_image3">
  <asp:Image ID="Image5" runat="server" ImageUrl="~/images/4.jpg" />
                  </div>

       </p>
          
             </div>
          </div>

       </div>
          
   </form>
</body>
</html>

