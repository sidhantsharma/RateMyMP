<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="moderateIssues.aspx.cs" Inherits="Admin_moderateIssues" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div>
        <center><h3>Issues that are reported as abuse Issue</h3>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:GridView ID="girdviewIssueReportedAbuse" runat="server" AutoGenerateColumns="False" OnRowUpdating="girdviewIssueReportedAbuse_RowUpdating">
                        <Columns>
                            
                <asp:TemplateField HeaderText="User Id"   Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblGuid" runat="server" Text='<%# Eval("guid") %>'></asp:Label>
                     </ItemTemplate>
               </asp:TemplateField>
                 <asp:TemplateField HeaderText="Issue Id" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblIssueId" runat="server" Text='<%# Eval("issueId") %>'></asp:Label>
                     </ItemTemplate>
               </asp:TemplateField>
                 <asp:TemplateField HeaderText="Issues" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblIssue" runat="server" Text='<%# Eval("issueText") %>'></asp:Label>
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
                    </asp:GridView>
              </ContentTemplate>
           </asp:UpdatePanel>
          </center>
    </div>
</asp:Content>


