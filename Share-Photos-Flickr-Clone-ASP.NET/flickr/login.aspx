<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master"
     AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeaderContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    <div class="container">
        <div class="card card-container">
            <!-- <img class="profile-img-card" src="//lh3.googleusercontent.com/-6V8xOA6M7BA/AAAAAAAAAAI/AAAAAAAAAAA/rzlHcD0KYwo/photo.jpg?sz=120" alt="" /> -->
            <img id="profile-img" class="profile-img-card" src="https://ssl.gstatic.com/accounts/ui/avatar_2x.png" />
            <p id="profile-name" class="profile-name-card"></p>
            <form class="form-signin" runat="server">
                <span id="reauth-email" class="reauth-email"></span>
                <asp:TextBox runat="server" id="inputUsername" class="form-control" placeholder="Username" />
                <asp:RequiredFieldValidator id="RequiredFieldUsername" runat="server" Display="Dynamic"
                  ControlToValidate="inputUsername"
                  ErrorMessage="Username is a required field."
                  ForeColor="Red" />
                <asp:TextBox runat="server" TextMode="Password" id="inputPassword" class="form-control" placeholder="Password" />
                <asp:RequiredFieldValidator id="RequiredFieldPassword" runat="server" Display="Dynamic"
                  ControlToValidate="inputPassword"
                  ErrorMessage="Password is a required field."
                  ForeColor="Red" />
                <div id="remember" class="checkbox">
                    <label>
                        <asp:CheckBox ID="inputRememberMe" Text="Remember me" runat="server" />
                    </label>
                </div>
                <asp:Button class="btn btn-danger" style="width: 100%;" Text="Sign in" runat="server" OnClick="Login_User" />
            </form><!-- /form -->
            <a href="recover.aspx" class="forgot-password">
                Forgot the password?
            </a>
        </div><!-- /card-container -->
    </div><!-- /container -->
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>
