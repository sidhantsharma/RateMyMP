<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rate My MP</title>
    <link rel="stylesheet" type="text/css" href="../CSS/bootstrap.css" />
    <link rel="shortcut icon" href="images/fevi.png" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="../CSS/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/bootstrap-responsive.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/style1.css" />
    <script type="text/javascript" src="../JS/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="../JS/bootstrap.js"></script>
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
    <style type="text/css">
        #AutoCompleteExtender1_completionListElem {
            background-color: #f2f1e7 !important;
            width: 470px !important;
            padding-left: 5px !important;
            position: fixed !important;
        }

            #AutoCompleteExtender1_completionListElem li {
                padding-left: 45px !important;
                padding-top: 2px;
                text-align: right;
                height: 40px;
                width: 400px;
                margin-top: 5px;
                background-color: #ffffff !important;
                color: #1f89c7 !important;
                /*opacity:.5;*/
                /* background-color:#cccccc !important; */
            }

        .completeListStyle {
            min-height: 30px;
            max-height: 200px;
            overflow-y: scroll;
            width: auto;
            position: relative;
            border: 1px solid #ccc;
            box-shadow: 1px 1px 1px 1px;
        }
    </style>

    <script type="text/javascript">


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
    <!-- script to logout from  google session  -->


    <script>
        function logout() {

            document.location.href = " https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://ratemymp.co.in";
            //document.location.href = " https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://localhost:42433/Default.aspx";

            return true;
        }

    </script>
    <!-- document.location.href = " https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://ratemymp.venturepact.com"; -->
    <!--  document.location.href = " https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://localhost:21913/Default.aspx"; -->
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
                appId: '421695167935164', // final App ID 421695167935164       .................  testing  214812398681584
                channelUrl: '//' + window.location.hostname + '/channel', // Path to your Channel File
                status: true, // check login status  
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true  // parse XFBML
            });

            //$("#facebookLogout").click(function () {
            //    kpfb();

            //});
        };

        $(document).ready(function () {

            $("#facebookLogout").click(function () {
                kpfb();
            });
        });

        function kpfb() {
            //alert("kamal");
            FB.getLoginStatus(function (response) {
                if (response.status == 'connected') {
                    //alert("hello");
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
        function searchvalidate() {
            alert("Please select both state and constituency");

        }
        function mpNotExist() {

            var stateid = $('#<%=DDListState .ClientID %>').val();
               var constituencyid = $('#<%= DDListConstituency.ClientID %>').val();
               if (stateid == 0 || constituencyid == 0) {
                   alert("Please select both state and constituency.");
                   return false;
               }
               else {
                   return true;

               }

           }

           //$(document).ready(function () {
           //function init()
           //{
           //    if ($("#txtsearchBox").keydown == 13) {

           //        alert("kamal");
           //        var searchVal = $('#txtsearchBox').val();

           //        //$("#localLogout").attr('disabled', "disabled");
           //        $("#localLogout").attr("disabled", "true");
           //        //$("#Btnsearch").add.attr('disabled', "disabled");
           //        $("#Btnsearch").add.attr("disabled", "true");
           //        PageMethods.getIssuesBasedOnSearchText(searchVal);
           //    }
           //}
           //});


           function OnKeyUp(obj)// for chrome and ie
           {
               if (obj.id == "txtsearchBox" && window.event.keyCode == 13) {

                   $("#localLogout").attr('disabled', "disabled");
                   $("#Btnsearch").attr('disabled', "disabled");
                   $("#googleLogout").attr('disabled', "disabled");

                   var clickButton = document.getElementById("<%= issueSearch.ClientID %>");
                   clickButton.click(); // call click event of  issuesearch button.
                   //getdata();
               }
           }


           function keypress(event) //for firefox
           {
               var key = event.keyCode;
               if (key == 13) {
                   //alert("hello");
                   $("#localLogout").attr('disabled', "disabled");
                   $("#Btnsearch").attr('disabled', "disabled");
                   $("#googleLogout").attr('disabled', "disabled");
                   var btnid = "#<%=issueSearch.ClientID%>";
                   //alert(btnid);
                   //$(btnid).click();


                   var clickButton = document.getElementById("<%= issueSearch.ClientID %>");
                   clickButton.click();

                   //getdata();
               }
           }

           function getdata() {



               //$("#localLogout").attr('disabled', "disabled");
               //$("#Btnsearch").attr('disabled', "disabled");
               //var searchVal = $('#txtsearchBox').val();
               // PageMethods.searchIssues(searchVal); 
           }

    </script>
    <%--Twitter Script--%>
    <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "https://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");
    </script>

</head>
<body>
    <form id="frmhomepage" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true" EnablePageMethods="true" />

        <div id="main">
            <div id="top_headerbar">
                <div class="logo">
                    <a href="Homepage.aspx">
                        <img src="../images/Logo.png" /></a>
                </div>
                <div class="search_box">
                    <asp:LinkButton ID="LBsearch" runat="server" class="icon-search search_icon" />
                    <asp:TextBox ID="txtsearchBox" onKeyPress=" return keypress(event);" onKeyUp="OnKeyUp(this);" placeholder="Search for Member, Constituency or state" class="search-query seach_box_inner" runat="server" />
                    <asp:AutoCompleteExtender ServiceMethod="SearchEmployees"
                        MinimumPrefixLength="1"
                        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                        TargetControlID="txtsearchBox" OnClientPopulated="Employees_Populated"
                        OnClientItemSelected="OnEmployeeSelected"
                        ID="AutoCompleteExtender1" CompletionListCssClass="completeListStyle" runat="server" FirstRowSelected="false">
                    </asp:AutoCompleteExtender>
                    <%--<asp:TextBoxWatermarkExtender runat="server" TargetControlID="txtsearchBox" WatermarkText="Search for Member, Constituency or state" 
                           />--%>
                    <!--  OnClientPopulating="onPopulating"  -->
                </div>
                <div class="home_right">
                    <label class="user_outr">
                        <asp:Label ID="LBLuserName" runat="server" Text="" /></label>
                    <%--<input type="button" class="btn btn_home" value="Home" />--%>
                    <input type="button" id="facebookLogout" class="btn btn_home" value="Logout" runat="server" />
                    <asp:Button ID="googleLogout" class="btn btn_home" runat="server" Text="Logout" Visible="false" OnClick="googleLogout_Click" />
                    <asp:Button ID="localLogout" class="btn btn_home" runat="server" Text="Logout" Visible="false" OnClick="localLogout_Click" />
                    <asp:LinkButton ID="issueSearch" class="btn btn_home" Style="display: none" runat="server" OnClick="issueSearch_Click">LinkButton</asp:LinkButton>
                </div>


            </div>
            <div id="main_container">

                <div id="main_left">

                    <div class="search_bar">
                        <h3>Select a Member</h3>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <div class="select_outr">
                                    <asp:DropDownList ID="DDListState" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="member_select" OnSelectedIndexChanged="DDListState_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="select_outr">
                                    <asp:Image ID="Image1" Visible="false" runat="server" />
                                    <asp:DropDownList ID="DDListConstituency" runat="server" CssClass="member_select">
                                    </asp:DropDownList>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:HiddenField ID="HFconstituencyId" runat="server" />
                        <div class="search_button">
                            <asp:Button ID="Btnsearch" CssClass="btn" runat="server" Text="Search" OnClick="Btnsearch_Click" />
                        </div>

                    </div>
                    <div class="main_left_links">
                        <ul class="nav nav_inner">
                            <li><a href="aboutus.aspx">About Us</a></li>
                            <li><a href="ourmission.aspx">Our Mission</a></li>
                            <li><a href="contactus.aspx">Contact Us</a></li>
                        </ul>
                    </div>
                </div>
                <div id="main_right">
                    <div id="home_container">
                        <%--<div class="issue_links">
                    	<ul class="nav nav-pills">
                            <li><asp:LinkButton ID="LBtrending" runat="server" Text="Trending Issues" OnClick="LBtrending_Click" /></li>
                            <li><asp:LinkButton ID="LBrecent" runat="server" Text="Recent Issues" OnClick="LBrecent_Click" /></li>
                            <li><asp:LinkButton ID="LBpopular" runat="server" Text="Most Popular Tags" OnClick="LBpopular_Click" /></li>
                           <li><a href="javascript:void(0);">Trending Issues</a></li>
                            <li><a href="javascript:void(0);">Recent Issues</a></li>
                            <li><a href="javascript:void(0);">Most Popular Tags</a></li>
                        </ul>
                	</div>--%>


                        <div class="home_container_dropdown">
                            <div class="sort_by_homepage">
                                <asp:Label ID="Label_sby" runat="server" Text="Sort By:"></asp:Label>
                                <asp:Label ID="Dropdown_label" runat="server" Text="Date "></asp:Label>
                            </div>
                            <asp:DropDownList ID="dropDownDateFilter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropDownDateFilter_SelectedIndexChanged" />
                        </div>
                        <div class="home_container_dropdown">
                            <div class="sort_by_homepage">
                                <asp:Label ID="Label1" runat="server" Text="Type:"></asp:Label>
                            </div>
                            <asp:DropDownList ID="dropDownTypeFilter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropDownTypeFilter_SelectedIndexChanged" />
                        </div>
                        <div class="home_container_dropdown">
                            <div class="sort_by_homepage">
                                <asp:Label ID="Label2" runat="server" Text="Party:"></asp:Label>
                            </div>
                            <asp:DropDownList ID="dropDownPartyFilter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropDownPartyFilter_SelectedIndexChanged" />
                        </div>

                        <div class="tweet_outer">
                            <div class="tweet">
                                <a href="https://twitter.com/ratemymp" class="twitter-share-button" data-via="" data-lang="en" data-text=" https://twitter.com/ratemymp"></a>
                            </div>
                        </div>
                    </div>

                    <%-- Issues start--%>
                    <div class="random_issue">
                        <asp:UpdatePanel ID="allUpdate" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Repeater runat="server" ID="ListIssues" OnItemDataBound="ListIssues_ItemDataBound" OnItemCommand="ListIssues_ItemCommand">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HFIssueId" runat="server" Value='<%# Eval("issueId") %>' />
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="home_issue_outr">

                                                    <div class="home_left_pic">
                                                        <asp:Image ID="IMGprofilePic" runat="server" />
                                                        <%-- Tyep of issues --%>

                                                        <div class="Typeofissuespic">
                                                            <asp:Image ID="PicIssueType" runat="server" />

                                                        </div>
                                                    </div>
                                                    <div class="home_right_detail">
                                                        <div class="home_right_top">

                                                            <asp:Label CssClass="mp_color" ID="LBLpostedBy" runat="server" />
                                                            <asp:Label ID="LBLpstate" runat="server" />
                                                            <b style="color: #00ADEF;">on </b><%--<asp:Label CssClass="mp_color" ID="mp_name" runat="server" Text=""></asp:Label>--%>
                                                            <asp:LinkButton ID="mp_name" CssClass="mp_color" runat="server" CommandName="mpDetailsShow" />
                                                            (
                            <asp:Label ID="mp_state_belong" runat="server" Text="Label" Style="color: #00ADEF;" />
                                                            ,
                             <asp:Label ID="mp_party" runat="server" Text="Label" Style="color: #00ADEF;" />
                                                            )
                            <%--<asp:Label ID="constituencyIdVal" runat="server"  Visible="false"></asp:Label>--%>
                                                            <asp:HiddenField ID="constituencyIdVal" runat="server" />


                                                            <asp:Label ID="LBLdt" CssClass="date_time" runat="server" />
                                                        </div>
                                                        <div class="issue_outr">
                                                            <asp:Label ID="LBLIssue" runat="server" />
                                                        </div>
                                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <div class="home_right_top1">
                                                                    <p class="votes_font">Votes by</p>
                                                                    <label>
                                                                        <asp:Label ID="LBLfpname" runat="server" /></label>
                                                                    <label>
                                                                        <asp:Label ID="LBLspname" runat="server" /></label>
                                                                    <asp:LinkButton ID="LBmore" runat="server" Text="more.." Visible="false" CommandName="more" />
                                                                </div>
                                                                <asp:HoverMenuExtender ID="HoverMenuExtender1" runat="server"
                                                                    TargetControlID="LBmore"
                                                                    PopupControlID="PopupMenu"
                                                                    HoverCssClass="popupHover"
                                                                    PopupPosition="Right"
                                                                    OffsetX="0"
                                                                    OffsetY="0"
                                                                    PopDelay="50" />


                                                                <asp:Panel CssClass="popupMenu" Style="background-color: black; color: white; padding: 4px;" ID="PopupMenu" runat="server" Visible="false">
                                                                    <asp:Label ID="votersName" runat="server" />
                                                                </asp:Panel>


                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="LBmore" EventName="Click" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>

                                                    </div>

                                                    <div class="likebutton">
                                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <div class="bound1">
                                                                    <%--<i class="icon-thumbs-up"></i>--%>
                                                                    <img src="../images/up.png" class="pull-left mg-top5" /><label><asp:Label ID="LBLsupportCount" runat="server" /></label><asp:LinkButton ID="LBsupport" runat="server" Text="Vote Up" CommandName="support" />
                                                                    <%--<i class="icon-thumbs-down"></i>--%><img src="../images/down.png" class="pull-left mg-top5" /><label><asp:Label ID="LBLdenyCount" runat="server" /></label><asp:LinkButton ID="LBdeny" runat="server" Text="Vote Down" CommandName="deny" />
                                                                    <%--<i class="icon-comment"></i>--%><img src="../images/comment.png" class="pull-left mg-top5" /><label><asp:Label ID="LBLcommentCount" runat="server" /></label>

                                                                </div>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="LBsupport" />
                                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="LBdeny" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                        <div class="bound2">
                                                            <asp:LinkButton ID="LBcomment" runat="server" Text="Comment" />
                                                        </div>
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <div class="flag">
                                                                    <asp:Image ID="IMG_Report" runat="server" CssClass="pull-left mg-top5" />

                                                                    <asp:LinkButton ID="Report_Abuse" runat="server" CommandName="report" Text="Report Abuse" />
                                                                </div>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="Report_Abuse" EventName="Click" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>


                                                </div>
                                                <%-- Comments start--%>
                                                <div class="comment_cont">
                                                    <asp:Panel ID="Panel1" runat="server">
                                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <div class="user_outer">
                                                                    <asp:Repeater runat="server" ID="ListComments" OnItemCommand="ListComments_ItemCommand" OnItemDataBound="ListComments_ItemDataBound">
                                                                        <ItemTemplate>
                                                                            <div class="img_outer">
                                                                                <%--<asp:Image runat="server" ImageUrl='<%#  DataBinder.Eval(Container.DataItem,"profilePic")!=null ? DataBinder.Eval(Container.DataItem,"profilePic") :"../images/mp/dummy.jpg" %>'/>--%>
                                                                                <asp:Image ID="Image2" runat="server" ImageUrl='<%#  DataBinder.Eval(Container.DataItem,"profilePic")%>' />
                                                                            </div>
                                                                            <div class="comm_section">
                                                                                <div class="name_label">
                                                                                    <asp:Label runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"firstName") + " " %> ' /><asp:Label runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lastName") %>' />
                                                                                </div>
                                                                                <div class="date_label">
                                                                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"postedOn","{0:d-MMM-yyyy hh:mm tt}") %>' />
                                                                                </div>
                                                                                <div class="comment_label">
                                                                                    <asp:Label runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"comment") %>' />
                                                                                </div>
                                                                            </div>
                                                                            <asp:HiddenField runat="server" ID="HFcommentId" Value='<%# DataBinder.Eval(Container.DataItem,"commentId") %>' />
                                                                            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <div class="sub_icons">
                                                                                        <%--<i class="icon icon-thumbs-up"></i>--%>
                                                                                        <img src="../images/up.png" class="pull-left mg-top5" /><asp:Label runat="server" ID="LBLlikeCount" /><asp:LinkButton ID="LBlike" class="mg-left3" runat="server" Text="Like" CommandName="like" />
                                                                                        <%--<i class="icon icon-thumbs-down"></i>--%><img src="../images/down.png" class="mg-right3" /><asp:Label runat="server" ID="LBLdislikeCount" />
                                                                                        <asp:LinkButton ID="LBdislike" runat="server" Text="Dislike" CommandName="dislike" />

                                                                                        <%--<img src="../images/flag-black.png" /><asp:LinkButton ID="LinkButton1" class="mg-left3" runat="server">Report Abuse</asp:LinkButton>--%>
                                                                                        <asp:Image ID="IMG_ReportComment" runat="server" />
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
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>

                                                                    <div class="text_comment">
                                                                        <asp:TextBox ID="txtcomment" placeholder="Type Comment Here" runat="server" TextMode="MultiLine" Style="width: 95%" />
                                                                        <%--<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtComment" WatermarkText="Puts Your Comments"/>--%>
                                                                    </div>
                                                                    <div class="post_button">
                                                                        <asp:Button ID="btnPost" runat="server" Text="Post" CommandName="post" Style="padding: 3px 15px 3px 15px;" />
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
                                                            SuppressPostBack="true" />
                                                    </asp:Panel>
                                                </div>
                                                </div>
    <%-- Comments end--%>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ContentTemplate>
                            <%--     <Triggers>
         <asp:AsyncPostBackTrigger ControlID="LBtrending" EventName="Click" />
         <asp:AsyncPostBackTrigger ControlID="LBrecent" EventName="Click" />
         <asp:AsyncPostBackTrigger ControlID="LBpopular" EventName="Click" />
     </Triggers>--%>
                        </asp:UpdatePanel>
                    </div>

                    <%-- Issues end--%>
                </div>


            </div>
        </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="loginsuccess" runat="server" />
    </form>
    <!-- user nap script-->
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
