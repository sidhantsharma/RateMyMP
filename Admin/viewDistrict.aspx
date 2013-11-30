<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewDistrict.aspx.cs" Inherits="Admin_viewDistrict" MasterPageFile="~/Admin/Admin.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="content1" ClientIDMode="Static" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >
    <div id="cont">
        <div id="select">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                            <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Select Country"></asp:Label>
                            <br />
                            <asp:DropDownList ID="dropCountry" runat="server" AutoPostBack="True" CssClass="dropdown" OnSelectedIndexChanged="dropCountry_SelectedIndexChanged" ClientIDMode="Static">
                            </asp:DropDownList>
                            <br />
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" ClientIDMode="Static" DisplayAfter="1" DynamicLayout="False">
                                <ProgressTemplate>
                                    Loading...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Select State"></asp:Label>
                            <br />
                            <asp:DropDownList ID="dropState" runat="server" AutoPostBack="True" CssClass="dropdown" OnSelectedIndexChanged="dropState_SelectedIndexChanged">
                            </asp:DropDownList>

                </ContentTemplate>


            </asp:UpdatePanel>
            

            </div>

            <asp:UpdatePanel ID="UpdatePanel2" ClientIDMode="Static" runat="server">
                        <ContentTemplate>



                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2" ClientIDMode="Static" DisplayAfter="1">
                                <ProgressTemplate>
                                    Loading...
                                </ProgressTemplate>
                            </asp:UpdateProgress>





                                <br />
        <div id="view">
            <asp:GridView ID="grdDistrict" runat="server" AllowSorting="True" BorderStyle="None" CaptionAlign="Right" CellPadding="4" ClientIDMode="Static" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnRowDataBound="grdDistrict_RowDataBound" OnRowCancelingEdit="grdDistrict_RowCancelingEdit" OnRowEditing="grdDistrict_RowEditing" OnRowUpdating="grdDistrict_RowUpdating" OnRowUpdated="grdDistrict_RowUpdated">
                <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <EditRowStyle BorderStyle="Inset" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#CC3333" Font-Bold="True" ForeColor="White" />

                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />



                <Columns>
                    <asp:TemplateField HeaderText="ID">

                        <ItemTemplate>
                            <asp:Label ID="lblId" CssClass="lbl" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="District">

                        <ItemTemplate>
                            <asp:Label ID="lblDistrict" CssClass="lbl" runat="server"></asp:Label>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtdistrict" CssClass="txtbox" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

<%-- buttons --%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Edit" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>

                        </asp:TemplateField>

                </Columns>



            </asp:GridView>

        </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            

        
        

    </div>

</asp:Content>
