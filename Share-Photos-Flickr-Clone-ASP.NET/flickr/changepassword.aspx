<%@ Page Title="Change password" MasterPageFile="~/Site.master"
     Language="C#" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="changepassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeaderContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <div class="container">
        <div class="card card-container">
            <form class="form-signin" runat="server">
                <h3 style="
    color: #dd4b39;
    text-align: center;
    font-weight: 600;
    margin-top: -10px;
    font-size: 20px;
">Change your password</h3>
                <span id="reauth-email" class="reauth-email"></span>
                <asp:TextBox runat="server" TextMode="Password" ID="OLDPASSWORD" placeholder="Old password" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="Dynamic"
                  ControlToValidate="OLDPASSWORD"
                  ErrorMessage="Password is a required field."
                  ForeColor="Red" />

                <asp:TextBox runat="server" TextMode="Password" ID="NEWPASSWORD" placeholder="New password" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Display="Dynamic"
                  ControlToValidate="NEWPASSWORD"
                  ErrorMessage="Password is a required field."
                  ForeColor="Red" />

             <asp:TextBox runat="server" TextMode="Password" ID="NEWPASSWORD2" placeholder="Confirm password" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Display="Dynamic"
                  ControlToValidate="NEWPASSWORD2"
                  ErrorMessage="Password is a required field."
                  ForeColor="Red" />
                <asp:CompareValidator Display="Dynamic" ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="NEWPASSWORD"
                ControlToValidate="NEWPASSWORD2" runat="server" />

                <asp:Button class="btn btn-danger" style="width: 100%; margin-top:10px;" Text="Change password" runat="server" OnClick="Change_Password" />
            </form><!-- /form -->
        </div><!-- /card-container -->
    </div><!-- /container -->
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>
