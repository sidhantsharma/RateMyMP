<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ourmission.aspx.cs" Inherits="ourmission" %>

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
                   
            </div></div>
        <div class="tweet_outer">
        <div class="tweet">
                <a href="https://twitter.com/ratemymp" class="twitter-share-button" data-via="" data-lang="en" data-text=" https://twitter.com/ratemymp"> </a>
          </div></div>
      <div class="header_1 ">
          <div class="background_colr">
          <div class="Abt_us">
              <p class="fnt">Our Mission</p>
          </div>
          <p class="p1">
Our mission is to promote dialogue between the Indian government and its citizens so that people’s interests are better represented by our leaders and their policies. We hope to bridge the gaps between the government and citizens, which have inhibited strategic exchange of information that could be used to benefit both parties. We believe that a democracy can only truly flourish when the linkages between the citizens and their representatives are open, safe, and bilateral.          </p>
              </div>
        <p class="p2">
However, we also believe that gaps exist among the Indian people themselves, where there is a lack of consistent communication and exchange of ideas. This is especially true for local issues, which have the greatest impact on our day-to-day lives. Through Rate My MP, we hope to close that divide and foster an environment for healthy and clean political participation within communities on local issues. It is our wish that Rate My MP helps build communities, empower citizens, and inform politicians.       </p>
          
             </div>
        </div>
   </form>
</body>
</html>
