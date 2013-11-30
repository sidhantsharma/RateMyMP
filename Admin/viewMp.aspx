<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewMp.aspx.cs" Inherits="Admin_viewMp" MasterPageFile="~/Admin/Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="cont">
         <asp:UpdatePanel ID="UpCountry" runat="server">
                <ContentTemplate>
        <div id="contry" class="cmn">           
                    <asp:Label ID="Label1" runat="server" Text="Select Country"></asp:Label><br />
                    <asp:DropDownList ID="dropCountry" runat="server"  AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="dropCountry_SelectedIndexChanged">
                    <asp:ListItem>Select Country</asp:ListItem>
                    </asp:DropDownList>                    
        </div>

        <div id="state"  class="cmn">
                    <asp:Label ID="Label2" runat="server" Text="Select State"></asp:Label><br />
                    <asp:DropDownList ID="dropstate" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="dropstate_SelectedIndexChanged">
                         <asp:ListItem>Select State</asp:ListItem>
                    </asp:DropDownList>
        </div>
        <div id="const" class="cmn">
                    <asp:Label ID="Label3" runat="server" Text="Select Constituency"></asp:Label><br />
                    <asp:DropDownList ID="dropconstituency" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropconstituency_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Select Constituency</asp:ListItem>
                    </asp:DropDownList>               
        </div>
        
       <div id="gridContainer">            
                   <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                   <asp:GridView ID="grdViewMP" runat="server" BorderStyle="Double" BackColor="White" BorderColor="#336666" BorderWidth="3px" Caption="Mp Details" CaptionAlign="Top" CellPadding="3" EmptyDataText="NULL"  Width="720px" CellSpacing="5" HorizontalAlign="Center"  >
                       <AlternatingRowStyle BorderStyle="Outset" />
                       <Columns>
                           <%--<asp:HyperLinkField NavigateUrl="~/admin/UpdateMpDetails.aspx" Target="_top" Text="Edit" />--%>
                           <%--<asp:HyperLinkField DataNavigateUrlFields="id" 
                                               DataNavigateUrlFormatString ="~/showdetails.aspx?vid={0}" 
                                               HeaderText="show details" NavigateUrl="~/showdetails.aspx" 
                                               Text="show more details" />--%>
                          <asp:HyperLinkField  DataNavigateUrlFields="mpId" 
                                               DataNavigateUrlFormatString ="~/admin/UpdateMp.aspx?vid={0}" 
                                               HeaderText="show details" NavigateUrl="~/admin/UpdateMp.aspx" 
                                               Text="Click to update" />
                       </Columns>
                       <EditRowStyle BorderStyle="Inset" BorderWidth="2px" />
                       <EmptyDataRowStyle BorderStyle="Ridge" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                       <FooterStyle BackColor="White" ForeColor="#333333" />
                       <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" BorderStyle="Double" />
                       <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                       <RowStyle BackColor="White" BorderStyle="None" Font-Names="Maiandra GD" Font-Overline="False" Font-Size="Medium" ForeColor="#333333" Height="15px" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                       <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F7F7F7" />
                       <SortedAscendingHeaderStyle BackColor="#487575" />
                       <SortedDescendingCellStyle BackColor="#E5E5E5" />
                       <SortedDescendingHeaderStyle BackColor="#275353" />
                   </asp:GridView>
       </div>         
     </ContentTemplate>
                </asp:UpdatePanel>           
   </div>

     
    </asp:Content>