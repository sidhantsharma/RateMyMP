<%@ Page Language="C#" AutoEventWireup="true" CodeFile="aboutus.aspx.cs" Inherits="aboutus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Welcome to Rate My MP</title>
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
              <p class="fnt">About Us</p>
            
          </div>

          <p class="p1">
              Rate My MP is a tool that provides citizens in India a public platform to share their ideas and concerns with their government representatives and each other. Through words, pictures, or video testimony, you can bring to light prominent issues facing your community and communicate them directly with your MPs on an open forum.
          </p>
              </div>
        <p class="p2">
            At the core of Rate My MP is the crowdsourcing model. In a country as large and diverse as India, with so many unique views and beliefs, the best result is obtained when everyone pitches in. That’s why Rate My MP needs you to contribute to your constituency’s page on issues that matter to YOU. Discuss the increasing prices of basic needs, the lack of job opportunities, or the growth of corruption. Or take a picture or video of the bad conditions of roads in your constituency, or the heap of garbage lying across the street, uncollected for weeks. Check out what other people are saying in your community and connect with them by commenting on their posts or supporting their posts.
       </p>
          <p class="p2">
              For the politician, Rate My MP provides a means of gaining valuable information about your constituents’ beliefs so that you can take better and more well informed decisions. Find out what your constituents are thinking and feeling about certain policies, interact with them individually or in groups, and answer their questions, and address their concerns.
              </p>

          <p class="p2">
              For the people, Rate My MP is an opportunity for you to participate in your government, learn about your constituency, and meet other motivated people who are invested in positively changing the country.
              </p>
             </div>
       </div>
          
   </form>
</body>
</html>
