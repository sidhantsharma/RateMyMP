<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewParty.aspx.cs" Inherits="Admin_viewParty" MasterPageFile="~/Admin/Admin.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="content1" ClientIDMode="Static" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >
    <div id="cont">
        <div id="select">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <asp:Label CssClass="lbl" ID="Label1" runat="server" Text="Select Country"></asp:Label><br />
            <asp:DropDownList CssClass="dropdown" ID="dropCountry"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropCountry_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
                    <br />
                    

                </ContentTemplate>


            </asp:UpdatePanel>
            
            

        </div>
        <br />
        <div id="view">
            <asp:GridView ID="grdParty" runat="server" AllowSorting="True" BorderStyle="None" CaptionAlign="Right" CellPadding="4" ClientIDMode="Static" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnRowDataBound="grdParty_RowDataBound" OnRowCancelingEdit="grdParty_RowCancelingEdit" OnRowEditing="grdParty_RowEditing" OnRowUpdating="grdParty_RowUpdating">
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


                    <asp:TemplateField HeaderText="Party Name">

                        <ItemTemplate>
                            <asp:Label ID="lblParty" CssClass="lbl" runat="server"></asp:Label>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtParty" CssClass="txtbox" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Abbreviation">

                        <ItemTemplate>
                            <asp:Label ID="lblabb" CssClass="lbl" runat="server"></asp:Label>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtabb" CssClass="txtbox" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Total Members">

                        <ItemTemplate>
                            <asp:Label ID="lblMem" CssClass="lbl" runat="server"></asp:Label>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtMem" CssClass="txtbox" runat="server"></asp:TextBox>
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

    </div>

</asp:Content>
