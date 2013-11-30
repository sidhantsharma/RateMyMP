<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="addConstituency.aspx.cs" Inherits="Admin_addConstituency" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
     
    <script>
        function constituencyInserted() {
            alert("successfully inserted");
        }
        function constituencyInsertedFail() {
            alert("insertion Failed");
        }
        function validateAll() 
        {
            var country = $('#<%=dropCountry.ClientID  %>').val();
            var state = $('#<%=dropState.ClientID  %>').val();
            var constituency = $('#<%=txtconstituency.ClientID  %>').val();
            if (country == 0 || state == 0 || constituency == '')
            {
                alert("Please fillup all the fields");
                return false;

            }
            else
            {
                return true;

            }

           

        }

    </script>
    <div id="cont">
        <div id="countr" class="cmn">
            <asp:Label ID="Label1" runat="server" Text="Select Country"></asp:Label> <br />

            <asp:DropDownList ID="dropCountry" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="dropCountry_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>


        <div id="stat" class="cmn">
            <asp:Label ID="Label2" runat="server" Text="Select State"></asp:Label> <br />

            <asp:DropDownList ID="dropState" runat="server">
                <asp:ListItem>Select State</asp:ListItem>
            </asp:DropDownList>
        </div>


        <div id="consti" class="cmn">
            <asp:Label ID="Label3" runat="server" Text="Enter Constituency Name"></asp:Label> <br />

            <asp:TextBox ID="txtconstituency" runat="server"></asp:TextBox>
            <br /><%--

            <asp:Label ID="Label4" runat="server" Text="Select Party"></asp:Label> <br />

            <asp:DropDownList ID="dropparty" runat="server"></asp:DropDownList>--%>
        </div>
           <div id="btn"">
             <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />

         </div>
     </div>
</asp:Content>



