<%@ Page Title="Browse" Language="C#" MasterPageFile="~/Site.master"
     AutoEventWireup="true" CodeFile="browse.aspx.cs" Inherits="browse" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeaderContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">
   
    <div class="container mt40"  style="padding-bottom: 250px;">
    <section class="row2">

        <%
    if (allAlbums.Length == 0)
    {
        %>
                <div class="row" style="text-align:center; margin-top:200px;">
            <span class="label label-danger" style="font-size:20px;">We do not have any albums in our database.</span>
            </div>
        <%
            }
            else {

                for (int i = 0; i < allAlbums.Length; i++)
                {
                    int id = allAlbums[i].getID_ALBUM();
                    string name = allAlbums[i].getNAME();
                    string photo = allAlbums[i].getLastPhoto();
                    string pic="Photos/";
                    if (photo.Equals(""))
                    {
                        pic += "empty.png";
                    } else
                    {
                        pic += photo;
                    }
                            %>
        <article class="col-xs-12 col-sm-6 col-md-3">
            <div class="panel panel-default">
                <div class="panel-body">
                    <a href="album.aspx?id=<%=id %>" title="<%=name %>" Portfolio" class="zoom" data-type="image" data-toggle="lightbox">
                        <img src="<%=pic %>" alt="<%=name %>" Portfolio" style="height:384px;"/>
                        <span class="overlay"><i class="fa fa-sign-in" aria-hidden="true"></i></span>
                    </a>
                </div>
                <div class="panel-footer">
                    <h4><a href="album.aspx?id=<%=id %>" title="<%=name %>" Portfolio"><%=name %></a></h4>  
                </div>
            </div>
        </article>     
        
                       
        <% }
            } %>     
</section>
</div>

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>
