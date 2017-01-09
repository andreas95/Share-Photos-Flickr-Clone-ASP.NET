<%@ Page Title="Upload" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="upload" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeaderContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">
     <div class="container">
        <div class="card card-container" style="max-width: 550px;">
            <form runat="server" class="form-signin"> 
            <h3 style="
    color: #dd4b39;
    text-align: center;
    font-weight: 600;
    margin-top: -10px;
    font-size: 20px;
    margin-left: -20px;
">Upload photos</h3>
                <asp:FileUpload ID="FileUpload1" style="margin-bottom:20px;" runat="server" />
                <asp:DropDownList ID="AlbumsList" class="form-control" style="margin-bottom: 20px;" runat="server">
                    <Items>
                    </Items>
                </asp:DropDownList>
            <asp:TextBox id="inputDescription" runat="server" class="form-control" style="max-width:470px; margin-bottom: 20px; max-height:150px; height:150px;" TextMode="MultiLine"
                rows="5" Columns="50" placeholder="Description"></asp:TextBox>
            <asp:TextBox ID="inputFacebook" runat="server" class="form-control" placeholder="Facebook page"></asp:TextBox>
            <asp:TextBox ID="inputTwitter" runat="server" class="form-control" placeholder="Twitter page"></asp:TextBox>
            <asp:Button Text="Upload" runat="server" OnClick="upload_photo" class="btn btn-primary"
                 style="background-color:  #f26522; border: 0; margin-top:10px;"/>
                </form>
        </div><!-- /card-container -->
    </div><!-- /container -->
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>
