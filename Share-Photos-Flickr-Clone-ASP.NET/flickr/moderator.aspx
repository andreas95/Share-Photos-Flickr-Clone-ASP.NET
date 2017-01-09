<%@ Page Title="Add moderator" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="moderator.aspx.cs" Inherits="moderator" %>


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
">Add new moderator</h3>
                <asp:TextBox runat="server" id="inputName" class="form-control" placeholder="User name" />
                <asp:RequiredFieldValidator id="RequiredField1" runat="server" Display="Dynamic"
                  ControlToValidate="inputName"
                  ErrorMessage="This fied is required."
                  ForeColor="Red" />
                <asp:Button class="btn btn-danger" style="width: 100%; margin-top:10px;" Text="Add moderator" runat="server" OnClick="Add_Moderator" />
            </form><!-- /form -->
        </div><!-- /card-container -->
    </div><!-- /container -->
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>