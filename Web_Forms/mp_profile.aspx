<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mp_profile.aspx.cs" Inherits="Web_Forms_usercomment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
 <head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Rate My MP</title>
<link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
     <link rel="shortcut icon" href="images/fevi.png" type="image/x-icon"/>
<link rel="stylesheet" type="text/css" href="../css/bootstrap-responsive.css" />
<link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css" />
<link type="text/css" rel="stylesheet" href="../CSS/jquery-te-1.4.0.css"/>
<link rel="stylesheet" type="text/css" href="../css/style1.css" />
<script type="text/javascript" src="../js/jquery.min.js" charset="utf-8"></script>
<script type="text/javascript" src="../JS/jquery.js" charset="utf-8"></script>
<script type="text/javascript" src="../js/jquery-te-1.4.0.min.js" charset="utf-8"></script>
<script type="text/javascript" src="../js/bootstrap.js"></script>
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
 <script type="text/javascript">
     

     $(document).ready(function () {
         

         $('.home_container_sort').click(function () {

             $('.sort_drpdwn').slideToggle(900);

         });

         $("#facebookLogout").click(
            function () {
                kpfb();
            }
                );

     });

 </script>


      <!-- script to logout from  google session  -->
    <script>
        function logout() {

            document.location.href = " https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://ratemymp.co.in";
            return true;
        }

    </script> 
       
    <!-- script to logout from facebook session -->
   <script type="text/javascript" src="/JS/fb.js"></script>
   <script src="http://connect.facebook.net/en_US/all.js" type="text/javascript"></script>
       <script>
           //Load the SDK Asynchronously
           (function (d) {
               var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
               if (d.getElementById(id)) { return; }
               js = d.createElement('script'); js.id = id; js.async = true;
               js.src = "//connect.facebook.net/en_US/all.js";
               ref.parentNode.insertBefore(js, ref);
           }(document));

           // Init the SDK upon load
           var fbl;
           window.fbAsyncInit = function () {
               fb1 = FB.init({
                   appId: '214812398681584', //  final App ID  421695167935164    testing  214812398681584
                   channelUrl: '//' + window.location.hostname + '/channel', // Path to your Channel File
                   status: true, // check login status  
                   cookie: true, // enable cookies to allow the server to access the session
                   xfbml: true  // parse XFBML
               });

             
           };
           
           function kpfb() {
              // alert("hello");
               FB.getLoginStatus(function (response) {
                   if (response.status == 'connected') {
                       //alert(response.status);
                       //alert("kamal");
                       FB.logout(function (response) {

                           kpredirect();
                       });
                   }
               });
           }

           function kpredirect() {
               window.location.reload();
               // alert("test3");
               document.location.href = "../Default.aspx";
           }

    </script>
     <script>
         function homeredirect() {
             document.localName.href = "Homepage.aspx";
         }
         function validatePostContent() {

             var postText = $("#TXTissue").val();
             if(postText=='')
             {
                 return false;
             }
             else {
                 return true;
         }
         }
     </script>
     </head>
<body onload="OnLoading();">
    <form id="frmusercomment" runat="server" class="formtag"  >
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"/>

<div id="main"> 
     <div id="top_headerbar">
         <div class="logo">
            	<a href="Homepage.aspx"><img src="../images/Logo.png"/></a>
            </div>
            	<div class="home_right">

                	<label  class="user_outr"> <asp:Label ID="LBLuserName" runat="server" Text="Label"></asp:Label></label>
                	<%--<input  id="homeRedirect" type ="button" class="btn btn_home" onclick="homeredirect()"  value="Home" />--%>
                    <asp:Button ID="Buttonredirect" class="btn btn_home" runat="server" Text="Home" OnClick="Buttonredirect_Click" />
                    <%--<input id="homeRedirect" class="btn btn_home" type="button"   value ="Home" />--%>
                    <input type="button" id="facebookLogout"  class="btn btn_home" value="Logout" runat="server"/>
                    <asp:Button ID="googleLogout" class="btn btn_home" runat="server" Text="Logout" Visible="false" OnClick="googleLogout_Click" />
                    <asp:Button ID="localLogout" class="btn btn_home" runat="server" Text="Logout"  Visible="false" OnClick="localLogout_Click"/>
                
                </div>


     </div>
    	
    <div id="main_container">

    	<div id="main_left">
            <div id="sticker">
          <div class="mp_info">
          <div class="heading hide_div">
               		<h5>15th Lok Sabha <br />Member of Parliament profile</h5>
               </div>
          	 <div class="mp_info_inner hide_div">
              	<div class="mp_img">
                     <asp:Image ID="imgMpProfile" runat="server" />
                  <div class="mp_pic"> 
                  </div>
               </div>
              
           <div class="up_labels">
                   <div class="name1">
                  <h5>Name:</h5><label><asp:Label ID="lblname" runat="server" /></label>
                  </div>
                  <div class="name1">
                  <h5>Constituency:</h5><label><asp:Label ID="lblconstituency" runat="server" /></label>
                  </div>
                  <div class="name3">
                  <h5>Party:</h5><label><asp:Label ID="lblparty" runat="server" /></label>
                  </div>
               </div>
             </div>
          <div class="down_labels">
               <div class="name2">
               <h5>Contact:</h5><label><asp:Label ID="lblcntct" runat="server" /></label>
               </div>
               <div class="name2">
                 <h5>E-mail:</h5><label><asp:Label ID="lblmail" runat="server" /></label>
                 </div>
                 <div class="name2">
                   <h5>Qualification:</h5><label><asp:Label ID="lbleducational_q" runat="server" /></label>
                   </div>
                   <div class="name2">
                 <h5>Profession:</h5><label><asp:Label ID="lblprofession" runat="server" /></label>
                 </div>
                 <div class="name2">
               <h5>Permanent Address:</h5><label><asp:Label ID="lblp_address" runat="server" /></label>
               </div>
               <div class="name2">
             <h5>Present Address:</h5><label><asp:Label ID="lblpresent_address" runat="server" /></label>
             </div>

          </div>
                
                  
               
             
                                    
            </div>
             
                </div>
            </div>

             
            
            <%--<div class="main_left_links">
            	<ul class="nav nav_inner">
                	<li><a href="javascript:void(0);">About Us</a></li>
                    <li><a href="javascript:void(0);">Our Mission</a></li>
                    <li><a href="javascript:void(0);">Contact Us</a></li>
                </ul>
            </div>--%>
           
        <div id="main_right">
            <div id="home_container_1">
                <div class="issue_count">
                    <asp:Label ID="issue_count_1" runat="server" Text="701"></asp:Label>
                    <p class="p-1">Issues In Your Constituency</p>
                </div>
                 <div class="issue_count">
                    <asp:Label ID="issue_count_2" runat="server" Text="201"></asp:Label>
                    <p class="p-1">Issues Solved</p>
                </div>
                
                
                <div class="home_container_sort" >
                    <asp:Label ID="Label_sort" runat="server" Text="Sort By">


                    </asp:Label>
                    
                    <ul class="sort_drpdwn"> 
                        <li><a href="#"> Praise </a></li>
                        <li><a href="#"> Recommendation </a></li>
                        <li><a href="#"> Complaint </a></li>
                        <li><a href="#"> Miscellaneous </a></li>
                    </ul>
                    
                </div>
              </div>
              
               
                  
                
                 <%-- Issues start--%>
             <div class="random_issue1">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>
 <asp:Repeater runat="server" ID="ListIssues" OnItemDataBound="ListIssues_ItemDataBound" OnItemCommand="ListIssues_ItemCommand"><ItemTemplate>    
 <asp:HiddenField ID="HFIssueId" runat="server" Value='<%# Eval("issueId") %>' />                   	
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional"><ContentTemplate> 
                  <div class="home_issue_outr">
                	<div class="home_left_pic"><asp:Image ID="IMGprofilePic" runat="server" /></div>
                    <div class="home_right_detail">
                    	<div class="home_right_top">
                            <asp:Label CssClass="mp_color" ID="LBLpostedBy" runat="server"/>
                            <asp:Label ID="LBLpstate" runat="server" /> 
                            <asp:Label ID="LBLdt" CssClass="date_time" runat="server" />
                        </div>
                        <div class="issue_outr">
                        <asp:Label ID="LBLIssue" runat="server"/>
                    </div>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional"><ContentTemplate>  
                           <%-- <div class="home_right_top1">
                        	<p>Votes by</p>
                            <label><asp:Label ID="LBLfpname" runat="server"/></label>
                            <label><asp:Label ID="LBLspname" runat="server"/></label>
                            <asp:LinkButton ID="LBmore" runat="server" Text="more.." Visible="false" CommandName="more" />
                        </div>--%>
                             <asp:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                                TargetControlID="LBmore"
                                PopupControlID="PopupMenu"
                                HoverCssClass="popupHover"
                                PopupPosition="Right"
                                OffsetX="0"
                                OffsetY="0"
                                PopDelay="50"
                                 />
                             <%-- Tyep of issues --%>
                             <div  class="Typeofissuespic">
                                <asp:Image ID="PicIssueType" runat="server" />

                             </div>


                            <asp:Panel CssClass="popupMenu" style="background-color:black;color:white;padding:4px;" ID="PopupMenu"  runat="server" Visible="false">
                              <asp:Label ID="votersName" runat="server" />
                             </asp:Panel>
                        </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="LBmore" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                    
                    <div class="likebutton">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional"><ContentTemplate>
                        <div class="bound_mpProfile">
                        <%--<i class="icon-thumbs-up"></i>--%><img src="../images/up.png" class="pull-left mg-top5" /><label><asp:Label ID="LBLsupportCount" runat="server"/></label><asp:LinkButton ID="LBsupport" runat="server" Text="Under Process" CommandName="support"/>
                        <%--<i class="icon-thumbs-down"></i>--%><img src="../images/down.png" class="pull-left mg-top5" /><label><asp:Label ID="LBLdenyCount" runat="server"/></label><asp:LinkButton ID="LBdeny" runat="server" Text="Solved" CommandName="deny"/>
                        <%--<i class="icon-comment"></i>--%><img src="../images/comment.png" class="pull-left mg-top5" /><label><asp:Label ID="LBLcommentCount" runat="server"/></label>
                        </div>
                           </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="LBsupport" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="LBdeny" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPost" />
                            </Triggers>
                        </asp:UpdatePanel>
                            <div class="bound2_mpprofile">
                                <asp:LinkButton ID="LBcomment" runat="server" Text="Reply"/>
                            </div>
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional"><ContentTemplate>
                        <div class="flag">
                            <asp:Image ID="IMG_Report" runat="server" CssClass="pull-left mg-top5" />

                            <asp:LinkButton ID="Report_Abuse" runat="server" CommandName="report" Text="Report Abuse" />
                        </div>
                       </ContentTemplate><Triggers>
                           <asp:AsyncPostBackTrigger ControlID="Report_Abuse" EventName="Click" />
                                         </Triggers></asp:UpdatePanel>

                    </div>
    <%-- Comments start--%>              
          <div class="comment_cont">
                    <asp:Panel ID="Panel1" runat="server">    
     		   <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional"><ContentTemplate>     
                          <div class="user_outer">
                                <asp:Repeater runat="server" ID="ListComments" OnItemCommand="ListComments_ItemCommand" OnItemDataBound="ListComments_ItemDataBound" > <ItemTemplate>     
                                 <div class="img_outer">
                              <asp:Image ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"profilePic") %>'/>
                          </div>	
                                      <div class="comm_section">
                                    <div class="name_label">
                                       <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"firstName") + " " %> '/><asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lastName") %>'/> 
                                     </div>
                             <div class="date_label">
                                 <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"postedOn","{0:d-MMM-yyyy hh:mm tt}") %>'/>
                               </div>
                       <div class="comment_label">
                           <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"comment") %>'/>
                         </div>
                      </div>
                    <asp:HiddenField runat="server" ID="HFcommentId" Value='<%# DataBinder.Eval(Container.DataItem,"commentId") %>' />
                     <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional"><ContentTemplate>
                        <div class="sub_icons"> 
                               <%--<i class="icon icon-thumbs-up"></i>--%><img src="../images/up.png" class="pull-left mg-top5" /><asp:Label runat="server" ID="LBLlikeCount"/><asp:LinkButton ID="LBlike" runat="server" Text="Like" CommandName="like"/> 
                               <%--<i class="icon icon-thumbs-down"></i>--%><img src="../images/down.png" class="mg-top5" /><asp:Label runat="server" ID="LBLdislikeCount"/> <asp:LinkButton ID="LBdislike" runat="server" Text="Dislike" CommandName="dislike"/>
                            <asp:Image ID="IMG_ReportComment" runat="server"/>
                            <asp:LinkButton ID="Report_Abuse_Comment" runat="server" CommandName="reportcomment" Text="Report Abuse" class="mg-left3" />
                        </div>
                    </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="LBlike" EventName="Click" />
                             <asp:AsyncPostBackTrigger ControlID="LBdislike" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click" />
                              <asp:AsyncPostBackTrigger ControlID="Report_Abuse_Comment" EventName="Click" />
                         </Triggers>
                     </asp:UpdatePanel>
                   </ItemTemplate></asp:Repeater> 
                    
                    <div class="text_comment">
                            <asp:TextBox ID="txtcomment" runat="server" TextMode="MultiLine" style="width:95%" />
                             <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtComment" WatermarkText="Type Comment Here"/>
                        </div>
                       <div class="post_button">
                           <asp:Button ID="btnPost" runat="server" Text="Post" CommandName="post" style=" padding:  3px 15px 3px 15px;" />
                       </div> 
                        
                   
               </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="LBcomment" EventName="Click" />
                    </Triggers>
            	</asp:UpdatePanel>
                         <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server"
                         TargetControlID="Panel1"
                         ExpandControlID="LBComment"
                         CollapseControlID="LBComment" 
                         Collapsed="True"
                         SuppressPostBack="true"
                           />        
              </asp:Panel>
              </div>
      </div>
    <%-- Comments end--%>
</ContentTemplate>
</asp:UpdatePanel> 
</ItemTemplate></asp:Repeater>
</ContentTemplate>
 </asp:UpdatePanel> 
               </div>
           
            <%-- Issues end--%>

     
   </div>
         
   </div>
</div>
  
  

    <script>
   // $('.jqte-test').jqte();

    // settings of status
    var jqteStatus = true;
    $(".status").click(function () {
        jqteStatus = jqteStatus ? false : true;
        $('.jqte-test').jqte({ "status": jqteStatus })
    });
</script>
        
    </form>
</body>

</html>
