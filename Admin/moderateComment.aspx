<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="moderateComment.aspx.cs" Inherits="Admin_moderateComment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
   
    <div>
    <h3><center>Comment that are reported as abuse comment
        
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
         <ContentTemplate>
        <asp:GridView ID="gridviewReportAbuseComment" runat="server" AutoGenerateColumns="False"  OnRowUpdating="gridviewReportAbuseComment_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
            <Columns>

                <asp:TemplateField HeaderText="User Id"   Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblGuid" runat="server" Text='<%# Eval("guid") %>'></asp:Label>
                     </ItemTemplate>
               </asp:TemplateField>
                 <asp:TemplateField HeaderText="Comment Id" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblCommentId" runat="server" Text='<%# Eval("commentId") %>'></asp:Label>
                     </ItemTemplate>
               </asp:TemplateField>
                 <asp:TemplateField HeaderText="Comment" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblComment" runat="server" Text='<%# Eval("comment") %>'></asp:Label>
                     </ItemTemplate>
               </asp:TemplateField>
                 <asp:TemplateField HeaderText="Enabled" Visible="true">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkEnableDisable" runat="server" Visible="true" Checked='<%# Convert.ToBoolean(Eval("enable")) %>'> </asp:CheckBox>
                    </ItemTemplate>
                     <EditItemTemplate>
                         <asp:CheckBox ID="chkEnableDisable1" runat="server" Visible="true" Checked='<%# Convert.ToBoolean(Eval("enable")) %>'> </asp:CheckBox>
                     </EditItemTemplate>
               </asp:TemplateField>
                <asp:TemplateField HeaderText="Report As Abuse" Visible="true">
                     <ItemTemplate>
                             <asp:CheckBox ID="chkReportAbuse" Visible="true" runat="server" Checked='<%# Convert.ToBoolean(Eval("reportAbuse")) %>'></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Update">
                     <ItemTemplate>
                              <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update"   CausesValidation="false"  >Update</asp:LinkButton>
                     </ItemTemplate>
                 </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
             </ContentTemplate>
      
        </asp:UpdatePanel>
      </center>
    </div>    
</asp:Content>


