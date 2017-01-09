<%@ Page Title="View photo"  MasterPageFile="~/Site.master"
     Language="C#" AutoEventWireup="true" CodeFile="viewphoto.aspx.cs" Inherits="viewphoto" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeaderContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">
<div class="container" style="margin-top:10px;">

    <%
        if (picture.Equals("Photos/"))
        {
            %>
                        <div class="row" style="text-align:center; padding-top: 200px;">
            <span class="label label-danger" style="font-size:20px;">This photos doesn't exist in our database.</span>
            </div>
            <%
                }
                else {

             %>
  <div class="row form-group"  style="margin-bottom: 100px;">
            <div class="panel panel-default" style="    margin: 0 auto;
    max-width: 900px;">
                <div class="panel-image">
                    <img src="<%=picture %>" class="panel-image-preview" />
                    <label for="toggle-4"></label>
                </div>
                <input type="checkbox" id="toggle-4" checked class="panel-image-toggle">
                <div class="panel-body">
                    <h4>Description</h4>
                    <p>
                        <%
                            if (description.Equals(""))
                            {
                            %>
                                This picture do not have description.
                            <%
                                }
                                else {
                        %>
                        <%=description %>
                        <%
                            }
                        %>
                    </p>
                </div>
                <div class="panel-footer text-center">
                    <%
                        if (candelete && this.Page.User.Identity.IsAuthenticated)
                        {
                      %>
                    <a href="deletephoto.aspx?id=<%=photoId %>" alt="Delete photo" title="Delete photo"><i style="color:red;" class="fa fa-trash" aria-hidden="true"></i></a>
                    <a href="photo_editor"><i class="fa fa-pencil" aria-hidden="true"></i></a>
                    <%
                        }
                    %>
                    <a href="#comments" id="btn-comments"><i class="fa fa-comments" aria-hidden="true"></i></a>
                    <a href="download.aspx?filename=<%=picture %>"><span class="glyphicon glyphicon-download"></span></a>
                    <a href="#facebook"><span class="fa fa-facebook"></span></a>
                    <a href="#twitter"><span class="fa fa-twitter"></span></a>
                    <a href="#share"><span class="glyphicon glyphicon-share-alt"></span></a>
                </div>
        </div>
  <script>
    $(document).ready(function(){

        $("#btn-comments").click(function(){
            $('#comments').toggle();
        });

        $(".close").click(function(){
          $('#comments').hide();
        });

    });
  </script>


    <div id="comments" class="detailBox" style="display: none;">
    <div class="titleBox">
      <label>Comment Box</label>
        <button type="button" class="close" aria-hidden="true">×</button>
    </div>
    <div class="commentBox">
        <%
            if (!this.Page.User.Identity.IsAuthenticated) {
        %>
            <span class="label label-danger" style="font-size: 15px;">Only users are able to view comments or comment on this photo.</span>
        <% } else {
        %>
        <p class="taskDescription">Write a comment for this photo.</p>
    </div>
    <div class="actionBox">
        <ul class="commentList">
           <%
                if (allComments.Length == 0) {
            %>
                <span class="label label-danger" style="font-size: 11px;">We do not have photos in our database.</span>
            <%
                } else {

                for (int i = 0; i < allComments.Length; i++) {
   

                if ((candelete && allComments[i].getStatus() == 0) || allComments[i].getStatus() == 1) {
                %>
                 <li>
                    <div class="commenterImage">
                      <img src="http://bootdey.com/img/Content/user_1.jpg">
                    </div>
                    <div class="commentText">
                        <p class=""><%=allComments[i].getText() %></p> <span class="date sub-text"><%=allComments[i].getDate_added().ToString("MMMM dd, yyyy") %></span>

                    </div>
                    <%
                        if (candelete) {
                    %>
                    <div class="comment-actions">
                        <span class="delete-comment"><a href="deletecomment.aspx?photo=<%=allComments[i].getId_photo() %>&comment=<%=allComments[i].getId_commnet() %>"><i class="fa fa-times fa-lg" aria-hidden="true" style="color: #dd4b39;;"></i></a></span>
                        <%
                            if (allComments[i].getStatus() == 0) {
                        %>
                        <span class="accept-comment"><a href="acceptcomment.aspx?photo=<%=allComments[i].getId_photo() %>&comment=<%=allComments[i].getId_commnet() %>"><i class="fa fa-check fa-lg" aria-hidden="true" style="color: #3cba54;"></i></a></span>
                        <%
                            }
                        %>
                    </div>
                    <% 
                        }
                    %>
                </li>
           <%
           }
            }
                }
           %>
        </ul>
        <form class="form-inline" runat="server">
            <div class="form-group" style="    width: 93%;">
                <asp:TextBox ID="inputComment" runat="server" class="form-control" type="text" placeholder="Your comments" style="    width: 100%;" />
                <asp:RequiredFieldValidator id="RequiredFieldComment" runat="server" Display="Dynamic"
                  ControlToValidate="inputComment"
                  ErrorMessage="This field is required."
                  ForeColor="Red" />
            </div>
            <div class="form-group">
                <asp:Button runat="server" Text="Add" class="btn btn-default" OnClick="Add_Comment"/>
            </div>
        </form>
    </div>
    <%
        }
    %>
</div>




  </div>
    <%} %>
</div>
    </asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>


