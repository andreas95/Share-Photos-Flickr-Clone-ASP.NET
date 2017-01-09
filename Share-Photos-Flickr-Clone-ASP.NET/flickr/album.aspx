<%@ Page Title="Albums" Language="C#" MasterPageFile="~/Site.master"
     AutoEventWireup="true" CodeFile="album.aspx.cs" Inherits="album" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeaderContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">
    
<div class="container" style="    margin-bottom: 130px;">
     <div class="row img-thumbnails">

         <%
             if (allPhotos.Length == 0)
             {
                         %>
            <div class="row" style="text-align:center; margin-top:200px;">
            <span class="label label-danger" style="font-size:20px;">This album is empty</span>
            </div>
         <%
             }
             else {

                 for (int i=0; i<allPhotos.Length; i++) {
                     int id = allPhotos[i].getID_PHOTO();
                     string photo = allPhotos[i].getPHOTO();
       %>
      <div class="col-md-6">
          <a href="viewphoto.aspx?id=<%=id %>">
              <img src="Photos/<%=photo %>" class="img-thumbnail">
          </a>
      </div>
      
         <%
        }
    } %>
  </div>
  
</div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>
