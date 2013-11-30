<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usercomment.aspx.cs" Inherits="Web_Forms_usercomment" %>

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
    <style type="text/css">
        #AutoCompleteExtender1_completionListElem 
        { 
           background-color:#f2f1e7  !important; 
           width:470px !important;
           padding-left:5px !important;
         position:fixed !important;
        }
      
        #AutoCompleteExtender1_completionListElem li
        {
           padding-left:45px !important;
           padding-top:2px;
           text-align:right;
           height:40px;
           width:400px;
           margin-top:5px;
           background-color:#ffffff !important;
           color:#1f89c7 !important;
            /*opacity:.5;*/ 
          /* background-color:#cccccc !important; */
        }
        .completeListStyle
        {  
          min-height : 30px;  
          max-height:200px;  
          overflow-y:scroll;  
          width: auto;     
          position: relative;
          border:1px solid #ccc;
          box-shadow:1px 1px 1px 1px;
        }
        
    </style>
            
    <script type = "text/javascript">


        function Employees_Populated(sender, e) {
            var employees = sender.get_completionList().childNodes;
            //alert(employees[0].firstChild.nodeValue);

            for (var i = 0; i < employees.length; i++) {
                //employees[i]._value    gives the identifier.
                var tempval = employees[i].firstChild.nodeValue;
                //alert(tempval);
                var kparray = tempval.split(",");
                var dispval = kparray[0] + ", " + kparray[1] + ", " + kparray[2];
                // alert(dispval);
                employees[i].firstChild.nodeValue = dispval;
                var div = document.createElement("DIV");
                // div.id = "mpdropid";
                var tmpimage = kparray[3];
                //alert(tmpimage);
                div.innerHTML = "<img style = 'height:40px;width:40px;float:left;margin-top:-18px;margin-left:-45px; ' src = '../images/mp/" + tmpimage + "'/>";
                employees[i].appendChild(div);
            }
        }
        function OnEmployeeSelected(source, eventArgs) {
            var idx = source._selectIndex;
            var employees = source.get_completionList().childNodes;
            var value = employees[idx]._value;
            var text = employees[idx].firstChild.nodeValue;
            //alert(text); gives first name and last name.
            var id = employees[idx]._value;
            // alert(id);
            // employees[idx].firstChild.nodeValue;
            source.get_element().value = text;
            var flag = 1;
            document.location.href = "usercomment.aspx?cid=" + id;
        }
</script>
 <script type="text/javascript">
     function OnLoading() {
         var s = $("#sticker");
         var pos = s.position();
         //alert(pos.toString());
         $(window).scroll(function () {

             var windowpos = $(window).scrollTop();
             //s.html("Distance from top:" + pos.top + "<br />Scroll position: " + windowpos);
             if (windowpos >= pos.top) {
                 s.addClass("stick");
                 $('.hide_div').slideUp(500);
             } else {
                 s.removeClass("stick");
                 $('.hide_div').slideDown(500);
             }
         });
     }

     $(document).ready(function () {
         var s = $("#sticker");
         var pos = s.position();
         //alert(pos.toString());
         $(window).scroll(function () {

             var windowpos = $(window).scrollTop();
             //s.html("Distance from top:" + pos.top + "<br />Scroll position: " + windowpos);
             if (windowpos >= pos.top) {
                 s.addClass("stick");
                 $('.hide_div').slideUp(500);
             } else {
                 s.removeClass("stick");
                 $('.hide_div').slideDown(500);
             }
         });

         //$('.home_container_sort').click(function () {

         //    $('.sort_drpdwn').slideToggle(900);

         //});
         //$('.home_container_sort_date').click(function () {

         //    $('.sort_drpdwn2').slideToggle(900);

         //});
         //$('.home_container_sort_popularity').click(function () {

         //    $('.sort_drpdwn3').slideToggle(900);

         //});
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
            //document.location.href = " https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://localhost:42433/Default.aspx";
 
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
                   appId: '421695167935164', //  final App ID  421695167935164    testing  214812398681584
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
       <%--Twitter Script--%>
     <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "https://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");
       </script>
     </head>
<body onload="OnLoading();">
    <form id="frmusercomment" runat="server" class="formtag"  >
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true" EnablePageMethods="true"/>

<div id="main"> 
     <div id="top_headerbar">
         <div class="logo">
            	<a href="Homepage.aspx"><img src="../images/Logo.png"/></a>
            </div>   
          <div class="search_box">
                       
               <asp:TextBox ID="txtsearchBox" onKeyPress=" return keypress(event);" onKeyUp = "OnKeyUp(this);" placeholder="Search for Member" class="search-query seach_box_inner" runat="server" TabIndex="1" />
                <asp:AutoCompleteExtender ServiceMethod="SearchEmployees" 
                                         MinimumPrefixLength="1"
                                        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" 
                                        TargetControlID="txtsearchBox"  OnClientPopulated = "Employees_Populated" 
                                        OnClientItemSelected = "OnEmployeeSelected" 
                                        ID="AutoCompleteExtender1" CompletionListCssClass="completeListStyle" runat="server" FirstRowSelected = "true">
                </asp:AutoCompleteExtender>
          </div>    
            	<div class="home_right">
                	<label  class="user_outr"> <asp:Label ID="LBLuserName" runat="server" Text="Label"></asp:Label></label>
                	<%--<input  id="homeRedirect" type ="button" class="btn btn_home" onclick="homeredirect()"  value="Home" />--%>
                    <asp:Button ID="Buttonredirect" class="btn btn_home" runat="server" Text="Home" OnClick="Buttonredirect_Click" TabIndex="3" />
                    <%--<input id="homeRedirect" class="btn btn_home" type="button"   value ="Home" />--%>
                    <input type="button" id="facebookLogout"  class="btn btn_home" value="Logout" runat="server"/>
                    <asp:Button ID="googleLogout" class="btn btn_home" runat="server" Text="Logout" Visible="false" OnClick="googleLogout_Click" TabIndex="4" />
                    <asp:Button ID="localLogout" class="btn btn_home" runat="server" Text="Logout"  Visible="false" OnClick="localLogout_Click" TabIndex="5"/>
                    <asp:LinkButton ID="searchIssues"  style="display:none" runat="server" OnClick="searchIssues_Click" TabIndex="2">LinkButton</asp:LinkButton>
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
             
            <div class="rating">
              <div class="rating_heading">
                   
                    <h4>MP's Rating</h4>
               
              </div>
                    <div class="heading_inner">
            <h6>Avg Rating</h6>
           <h6>Your Rating</h6>
           

       </div>
                  <div class="rating_inner">
                     <div class="rating_inner_1">
                          <div class="icon-heart">
                             <asp:Image ID="Image5" runat="server" ImageUrl="~/images/Availabilitycheckmark.png" />
                         </div>
                     <div class="rating_star">
                         <asp:Label ID="Label55"  runat="server" Text="Availability"/>
                     </div>
                          <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional"><ContentTemplate>
                          <div class="div_stars">
                              <asp:Rating ID="Rating1" runat="server" CurrentRating="0" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                 FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" OnChanged="Rating1_Changed" AutoPostBack="true"  />
                          </div>
                          <div class="rating_avg">
                              <asp:Label ID="LBLrating1" runat="server" Text="0"/>
                          </div>
                          </ContentTemplate>
                              <Triggers>
                                  <asp:AsyncPostBackTrigger ControlID="Rating1" />
                              </Triggers>
                          </asp:UpdatePanel>
                   </div>
                      <div class="rating_inner_1">
                         <div class="icon-heart">
                             <asp:Image ID="Imag" runat="server" ImageUrl="~/images/healthlatest.png"/>
                        </div>
                      <div class="rating_star">
                            <asp:Label ID="Label11" runat="server" Text="Health"/>
                      </div>
                          <asp:UpdatePanel ID="UpdatePanel7"  runat="server" UpdateMode="Conditional"><ContentTemplate>
                          <div class="div_stars">
                              <asp:Rating ID="Rating2" runat="server" CurrentRating="0" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                 FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" OnChanged="Rating2_Changed" AutoPostBack="true" />
                          </div>

                           <div class="rating_avg">
                             <asp:Label ID="LBLrating2" runat="server" Text="0"/>
                           </div>
                        </ContentTemplate>
                              <Triggers>
                                  <asp:AsyncPostBackTrigger ControlID="Rating2" />
                              </Triggers>
                          </asp:UpdatePanel>
                  </div>
                      <div class="rating_inner_1">
                          <div class="icon-heart">
                             <asp:Image ID="Image2" runat="server" ImageUrl="~/images/bookicon.png" />
                         </div>
                     <div class="rating_star">
                         <asp:Label ID="Label22"  runat="server" Text="Education"/>
                     </div>
                          <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional"><ContentTemplate>
                          <div class="div_stars">
                              <asp:Rating ID="Rating3" runat="server" CurrentRating="0" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                 FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" OnChanged="Rating3_Changed" AutoPostBack="true"  />
                          </div>
                          <div class="rating_avg">
                              <asp:Label ID="LBLrating3" runat="server" Text="0"/>
                          </div>
                          </ContentTemplate>
                              <Triggers>
                                  <asp:AsyncPostBackTrigger ControlID="Rating3" />
                              </Triggers>
                          </asp:UpdatePanel>
                   </div>
                       <div class="rating_inner_1">
                          <div class="icon-heart">
                             <asp:Image ID="Image3" runat="server" ImageUrl="~/images/rsz_company.png" />
                         </div>
                     <div class="rating_star">
                          <asp:Label ID="Label33" runat="server" Text="Infrastructure"/>
                     </div>
                           <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional"><ContentTemplate>
                           <div class="div_stars">
                              <asp:Rating ID="Rating4" runat="server" CurrentRating="0" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                 FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" OnChanged="Rating4_Changed" AutoPostBack="true"    />
                          </div>
                          <div class="rating_avg">
                            <asp:Label ID="LBLrating4" runat="server" Text="0"/>
                           </div>
                           </ContentTemplate>
                              <Triggers>
                                  <asp:AsyncPostBackTrigger ControlID="Rating4" />
                              </Triggers>
                          </asp:UpdatePanel>
                   </div>
                     <div class="rating_inner_1">
                          <div class="icon-heart">
                             <asp:Image ID="Image4" runat="server" ImageUrl="~/images/money-bag-32.png" />
                         </div>
                     <div class="rating_star">
                         <asp:Label ID="Label44"  runat="server" Text="Corruption"/>
                     </div>
                          <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional"><ContentTemplate>
                          <div class="div_stars">
                              <asp:Rating ID="Rating5" runat="server" CurrentRating="0" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                 FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" OnChanged="Rating5_Changed" AutoPostBack="true"  />
                          </div>
                          <div class="rating_avg">
                              <asp:Label ID="LBLrating5" runat="server" Text="0"/>
                          </div>
                          </ContentTemplate>
                              <Triggers>
                                  <asp:AsyncPostBackTrigger ControlID="Rating5" />
                              </Triggers>
                          </asp:UpdatePanel>
                   </div>
                      <div class="rating_inner_1">
                          <div class="icon-heart">
                             <asp:Image ID="Image" runat="server" ImageUrl="~/images/Promise-30.png" />
                         </div>
                     <div class="rating_star">
                         <asp:Label ID="Label66"  runat="server" Text="Promises Fulfill"/>
                     </div>
                          <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional"><ContentTemplate>
                          <div class="div_stars">
                              <asp:Rating ID="Rating6" runat="server" CurrentRating="0" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                 FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" OnChanged="Rating6_Changed" AutoPostBack="true"  />
                          </div>
                          <div class="rating_avg">
                              <asp:Label ID="LBLrating6" runat="server" Text="0"/>
                          </div>
                          </ContentTemplate>
                              <Triggers>
                                  <asp:AsyncPostBackTrigger ControlID="Rating6" />
                              </Triggers>
                          </asp:UpdatePanel>
                   </div>
                  </div>
                 <div class="clear"></div>
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
            <div id="home_container_usercomment">
              <div class="text_editor_container">
      

               <%-- <asp:UpdatePanel runat="server" UpdateMode="Conditional"><ContentTemplate>
                --%>
                    <div class="text_editor_outr">
                    
                	<%--<textarea name="textarea" class="jqte-test"></textarea>--%>
                    <asp:TextBox ID="TXTissue" runat="server" CssClass=" txteditor " TextMode="MultiLine" PlaceHolder="Post Issue Here" style="height:100px !important;"/>

                        <asp:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="TXTissue" EnableSanitization="false">
                          <Toolbar> 
                            <asp:Undo />
                            <asp:Redo />
                            <asp:Bold />
                            <asp:Italic />
                            <asp:Underline />
                            <asp:StrikeThrough />
                            <asp:Subscript />
                            <asp:Superscript />
                            <asp:JustifyLeft />
                            <asp:JustifyCenter />
                            <asp:JustifyRight />
                            <asp:JustifyFull />
                            <asp:RemoveFormat />
                            <asp:Cut />
                            <asp:Copy />
                            <asp:Paste />
                            <asp:ForeColorSelector />
                            <asp:FontNameSelector  />
                            <asp:FontSizeSelector />
                        </Toolbar>
                        </asp:HtmlEditorExtender>

                </div>

                              <div class="tweet_outer">
        <div class="tweet">
                <a href="https://twitter.com/ratemymp" class="twitter-share-button" data-via="" data-lang="en" data-text=" https://twitter.com/ratemymp"> </a>
          </div></div>
                       <div class="attach_file">
                           <div class="home_container_dropdown1">
                    <asp:DropDownList ID="dropDownIssueFilter" runat="server"/>
                       
                </div>
                    <asp:Button ID="BTNissuePost" runat="server" Text="Post" OnClick="BTNissuePost_Click" />
                    <asp:FileUpload ID="FileUploadIssue" runat="server" Enabled="false" Visible="false"  />
                </div>   
                      <%--        
               </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BTNissuePost" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                  
                   <div class="home_container_dropdown_user">
                    <div class="sort_by_homepage">
                        <asp:Label ID="Dropdown_label" runat="server" Text="Filter By: "  ></asp:Label>
                        </div>
                    <asp:DropDownList ID="dropDownFilter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropDownFilter_SelectedIndexChanged"/>
                </div>
                 <div class="home_container_dropdown_user">
                    <div class="sort_by_homepage">
                        <asp:Label ID="Label1" runat="server" Text="Sort By:"  ></asp:Label>
                        </div>
                    <asp:DropDownList ID="dropDownSort" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropDownSort_SelectedIndexChanged"/>
                </div>
                 
                </div>
              </div>
             
                  
                
                 <%-- Issues start--%>
             <div class="random_issue1">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>
 <asp:Repeater runat="server" ID="ListIssues" OnItemDataBound="ListIssues_ItemDataBound" OnItemCommand="ListIssues_ItemCommand"><ItemTemplate>    
 <asp:HiddenField ID="HFIssueId" runat="server" Value='<%# Eval("issueId") %>' />                   	
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional"><ContentTemplate> 
                  <div class="home_issue_outr">
                	<div class="home_left_pic"><asp:Image ID="IMGprofilePic" runat="server" />
                         <%-- Tyep of issues --%>
                             
                        <div  class="Typeofissuespic">
                                <asp:Image ID="PicIssueType" runat="server"/>

                             </div>
                	</div>
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
                            <div class="home_right_top1">
                        	<p>Votes by</p>
                            <label><asp:Label ID="LBLfpname" runat="server"/></label>
                            <label><asp:Label ID="LBLspname" runat="server"/></label>
                            <asp:LinkButton ID="LBmore" runat="server" Text="more.." Visible="false" CommandName="more" />
                        </div>
                             <asp:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                                TargetControlID="LBmore"
                                PopupControlID="PopupMenu"
                                HoverCssClass="popupHover"
                                PopupPosition="Right"
                                OffsetX="0"
                                OffsetY="0"
                                PopDelay="50"
                                 />
                             
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
                        <div class="bound1">
                        <%--<i class="icon-thumbs-up"></i>--%><img src="../images/up.png" class="pull-left mg-top5" /><label><asp:Label ID="LBLsupportCount" runat="server"/></label><asp:LinkButton ID="LBsupport" runat="server" Text="Vote Up" CommandName="support"/>
                        <%--<i class="icon-thumbs-down"></i>--%><img src="../images/down.png" class="pull-left mg-top5" /><label><asp:Label ID="LBLdenyCount" runat="server"/></label><asp:LinkButton ID="LBdeny" runat="server" Text="Vote Down" CommandName="deny"/>
                        <%--<i class="icon-comment"></i>--%><img src="../images/comment.png" class="pull-left mg-top5" /><label><asp:Label ID="LBLcommentCount" runat="server"/></label>
                        </div>
                           </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="LBsupport" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="LBdeny" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPost" />
                            </Triggers>
                        </asp:UpdatePanel>
                            <div class="bound2">
                                <asp:LinkButton ID="LBcomment" runat="server" Text="Comment"/>
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
