<%@ Page Title="Recover" Language="C#" MasterPageFile="~/Site.master"
     AutoEventWireup="true" CodeFile="recover.aspx.cs" Inherits="recover" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeaderContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">
   <div class="container">
    <div class="row">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-default" style="    max-width: 350px;    padding: 40px 40px;    margin-top: 70px;">
                    <div class="panel-body">
                        <div class="text-center">
                          <h3><i class="fa fa-lock fa-4x"></i></h3>
                          <h2 class="text-center">Forgot Password?</h2>
                          <p>You can reset your password here.</p>
                            <div class="panel-body">
                              
                              <form class="form" runat="server"> 
                                <fieldset>
                                  <div class="form-group">
                                    <div class="input-group">
                                      <span class="input-group-addon"><i class="glyphicon glyphicon-envelope color-blue"></i></span>
                                      <asp:TextBox runat="server" ID="email" placeholder="email address" class="form-control"/>
                                    </div>
                                     <asp:RequiredFieldValidator id="RequiredFieldEmail" runat="server" Display="Dynamic"
                                      ControlToValidate="email"
                                      ErrorMessage="Email is a required field."
                                      ForeColor="Red" />
                                       <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ControlToValidate="email" ForeColor="Red" ErrorMessage="Invalid email address." />
                                  </div>
                                  <div class="form-group">
                                    <asp:Button runat="server" OnClick="Recover" Text="Send My Password" class="btn btn-lg btn-primary btn-block" />
                                  </div>
                                </fieldset>
                              </form>
                              
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>
