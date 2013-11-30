<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="addState.aspx.cs" Inherits="Admin_addState" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <script>
        function selectCountry() {
            alert("Please Select Country");
        }
        function checkdata()
        {
            var country = $('#<%= dropCountry.ClientID %>').val();
            var state = $('#<%= txtstate.ClientID %>').val();
            var cons = $('#<%= txtNoConsti.ClientID %>').val();
            if(state=='' || country==0||cons=='')
            {
                alert("Please fillup all fields");
                return false
            }
            else
            {
                 return true;
             }

        }
        function stateInserted() {

            alert("Successfully Inserted.");
        }
        function stateInsertedFail() {
            alert("Insertion Failed.");
        }
    </script>
    <div id="cont">
        <div id="countr" class="cmn">
            <asp:Label ID="Label1" runat="server" Text="Select Country"></asp:Label><br />

            <asp:DropDownList ID="dropCountry" runat="server" OnSelectedIndexChanged="dropCountry_SelectedIndexChanged" ></asp:DropDownList>
        </div>


        <div id="stat" class="cmn">
            <asp:Label ID="Label2" runat="server" Text="Enter State"></asp:Label><br />

             <asp:TextBox ID="txtstate" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtstate" ErrorMessage="Must Enter State Name" Font-Size="Smaller" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>

         <div id="no" class="cmn">
            <asp:Label ID="Label3" runat="server" Text="No Of Constituency"></asp:Label><br />

             <asp:TextBox ID="txtNoConsti" runat="server"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNoConsti" ErrorMessage=" Enter Number Of Constituency" Font-Size="Smaller" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d{1,3}"></asp:RegularExpressionValidator>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoConsti" ErrorMessage="Required Field" Font-Size="Smaller" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
         

    </div>
    <div id="btn" class="cmn">
             <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />

         </div>
</asp:Content>


