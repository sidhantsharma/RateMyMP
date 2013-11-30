<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewstates.aspx.cs" Inherits="Admin_view_viewstates" MasterPageFile="~/Admin/Admin.master" %>

<asp:Content ClientIDMode="Static" ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <div id="cont">
        <div id="select">
            <asp:Label CssClass="lbl" ID="Label1" runat="server" Text="Select Country"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:DropDownList CssClass="dropdown" ID="dropCountry" runat="server" OnSelectedIndexChanged="dropCountry_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True" ClientIDMode="Static"></asp:DropDownList>
            <br />


            <div class="result">
                <asp:GridView ID="grdState" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="grdState_RowCancelingEdit"  OnRowDataBound="grdState_RowDataBound"  OnRowEditing="grdState_RowEditing" OnRowUpdating="grdState_RowUpdating">
                    <Columns>
                        
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:Label CssClass="lbl" runat="server" ID="lblId">    </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="State Name">
                            <ItemTemplate>
                                <asp:Label ID="lblStateName" CssClass="lbl" runat="server">   </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox cssclass="txtbox" ID="txtStateName" runat="server"></asp:TextBox>
                            </EditItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Edit" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Insert" Text="Insert"></asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>


                </asp:GridView>



            </div>

            </div>

    </div>

</asp:Content>