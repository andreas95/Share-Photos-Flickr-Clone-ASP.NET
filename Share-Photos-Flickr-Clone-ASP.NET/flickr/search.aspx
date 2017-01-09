<%@ Page Title="Search" MasterPageFile="~/Site.master"
     Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeaderContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">


     <div class="row img-thumbnails">


         <%
             if (text== null || text=="")
             {
                         %>
            <div class="row" style="text-align:center; margin-top:200px;">
            <span class="label label-danger" style="font-size:20px;margin-left: -150px;" >Please enter text for search photos.</span>
            </div>
         <%
             }
             else {
                %>

                          <h3 style="
    color: #dd4b39;
    text-align: center;
    font-weight: 600;
    margin-top: 100px;
    font-size: 20px;
">Search results of <%=text %></h3>

         <%

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


