<%@ Page Language="C#"  MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="addDistrict.aspx.cs" Inherits="Admin_addDistrict" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <script>
        function validateAll()
        {
            
            var stateid = $('#<%=dropState.ClientID %>').val();
            var district = $('#<%=txtDistrict.ClientID %>').val();
            var conutry = $('#<%=dropCountry.ClientID %>').val();
            if (stateid == 0 || district == '' || countr == 0)
            {
                alert("Please fillup all fields");
                return false
            }
            else
            {
                return true;

            }
        
        }
        function districtInserted() {
            alert("Successfully inserted.");


        }
        function districtInsertedFail() {
            alert("Insertion Failed.");

        }

    </script>
    <div id="cont">  
        <div id="countr" class="cmn">
            <asp:Label ID="Label1" runat="server" Text="Select Country"></asp:Label><br />

            <asp:DropDownList ID="dropCountry" runat="server" OnSelectedIndexChanged="dropCountry_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>

        <div id="stat" class="cmn">
            <asp:Label ID="Label2" runat="server" Text="Select State"></asp:Label><br />
            <asp:DropDownList ID="dropState" runat="server">
                <asp:ListItem>Select State</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="consti" class="cmn">
            <asp:Label ID="Label3" runat="server" Text="Enter District Name"></asp:Label><br />

            <asp:TextBox ID="txtDistrict" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
     <div id="btn">
             <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
     </div>
</asp:Content>


