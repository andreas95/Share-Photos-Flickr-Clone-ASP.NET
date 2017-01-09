<%@ Page Title="Signup" Language="C#" MasterPageFile="~/Site.master"
     AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeaderContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">
     <div class="container">
      <div class="row2 main">
        <div class="main-login main-center">
          <form class="form-horizontal" runat="server">
   
            <div class="form-group">
              <label for="name" class="cols-sm-2 control-label">Your Name</label>
              <div class="cols-sm-10">
                <div class="input-group">
                  <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                    <asp:TextBox class="form-control" name="name" id="name"  placeholder="Enter your Name" runat="server" />
                </div>
              </div>
            </div>
              <asp:RequiredFieldValidator id="RequiredFieldName" runat="server" Display="Dynamic"
              ControlToValidate="name"
              ErrorMessage="Name is a required field."
              ForeColor="Red" />

            <div class="form-group">
              <label for="email" class="cols-sm-2 control-label">Your Email</label>
              <div class="cols-sm-10">
                <div class="input-group">
                  <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                    <asp:TextBox class="form-control" name="email" id="email"  placeholder="Enter your Email" runat="server" />
                </div>
              </div>
            </div>
              <asp:RequiredFieldValidator id="RequiredFieldEmail" runat="server" Display="Dynamic"
              ControlToValidate="email"
              ErrorMessage="Email is a required field."
              ForeColor="Red" />
               <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="email" ForeColor="Red" ErrorMessage="Invalid email address." />

            <div class="form-group">
              <label for="username" class="cols-sm-2 control-label">Username</label>
              <div class="cols-sm-10">
                <div class="input-group">
                  <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                    <asp:TextBox  class="form-control" name="username" ID="username"  placeholder="Enter your Username" runat="server" />
                </div>
              </div>
            </div>
            <asp:RequiredFieldValidator id="RequiredFieldUsername" runat="server" Display="Dynamic"
              ControlToValidate="username"
              ErrorMessage="Username is a required field."
              ForeColor="Red" />

            <div class="form-group">
              <label for="password" class="cols-sm-2 control-label">Password</label>
              <div class="cols-sm-10">
                <div class="input-group">
                  <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                    <asp:TextBox TextMode="Password" class="form-control" name="password" id="password"  placeholder="Enter your Password" runat="server" />
                </div>
              </div>
            </div>
              <asp:RequiredFieldValidator id="RequiredFieldPassword" runat="server" Display="Dynamic"
              ControlToValidate="password"
              ErrorMessage="Password is a required field."
              ForeColor="Red" />

            <div class="form-group">
              <label for="confirm" class="cols-sm-2 control-label">Confirm Password</label>
              <div class="cols-sm-10">
                <div class="input-group">
                  <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                    <asp:TextBox TextMode="Password" class="form-control" name="passwordconfirm" id="passwordconfirm"  placeholder="Confirm your Password" runat="server"/>
                </div>
              </div>
            </div>
              <asp:RequiredFieldValidator id="RequiredFieldPassword2" runat="server" Display="Dynamic"
              ControlToValidate="passwordconfirm"
              ErrorMessage="Password is a required field."
              ForeColor="Red" />
              <asp:CompareValidator Display="Dynamic" ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="password"
                ControlToValidate="passwordconfirm" runat="server" />

            <div class="form-group ">
                <asp:Button Text="Register" runat="server" OnClick="Register_User" class="btn btn-primary btn-lg btn-block login-button"/>
            </div>
            <div class="login-register">
                    <a href="login.aspx">Login</a>
                 </div>
          </form>
        </div>
      </div>
    </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>
