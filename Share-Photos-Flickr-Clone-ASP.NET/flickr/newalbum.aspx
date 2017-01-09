<%@ Page  Title="Add album" MasterPageFile="~/Site.master" 
     Language="C#" AutoEventWireup="true" CodeFile="newalbum.aspx.cs" Inherits="newalbum" %>

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
">Create a new album</h3>
                <asp:TextBox runat="server" id="inputAlbum" class="form-control" placeholder="Album name" />
                <asp:RequiredFieldValidator id="RequiredField1" runat="server" Display="Dynamic"
                  ControlToValidate="inputAlbum"
                  ErrorMessage="This fied is required."
                  ForeColor="Red" />
                <asp:Button class="btn btn-danger" style="width: 100%; margin-top:10px;" Text="Create album" runat="server" OnClick="Create_Album" />
            </form><!-- /form -->
        </div><!-- /card-container -->
    </div><!-- /container -->
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>



