<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.master"
     AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeaderContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">


    <div id="myCarousel" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
    <li data-target="#myCarousel" data-slide-to="3"></li>
    <li data-target="#myCarousel" data-slide-to="4"></li>
    <li data-target="#myCarousel" data-slide-to="5"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="carousel/img0.jpg" alt="Picture 1" class="img-carousel">
    </div>

    <div class="item">
      <img src="carousel/img1.jpg" alt="Picture 2" class="img-carousel">
    </div>

    <div class="item">
      <img src="carousel/img2.jpg" alt="Picture 3" class="img-carousel">
    </div>

    <div class="item">
      <img src="carousel/img3.jpg" alt="Picture 4" class="img-carousel">
    </div>

    <div class="item">
      <img src="carousel/img4.jpg" alt="Picture 5" class="img-carousel">
    </div>

    <div class="item">
      <img src="carousel/img5.jpg" alt="Picture 6" class="img-carousel">
    </div>
  </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>

<div class="container">



<%

    if (allPhotos.Length == 0)
    {
                   %>
        <div class="row" style="text-align:center;">
            <span class="label label-danger" style="font-size:20px;">We do not have photos in our database.</span>
            </div>
    <%
        }
        else {
            int max = 12;
            if (allPhotos.Length < max)
            {
                max = allPhotos.Length;
            }


            for (int i = 0; i < max; i++)
            {
                string photo = "Photos/" + allPhotos[i].getPHOTO();
                int photoID = allPhotos[i].getID_PHOTO();
                int albumID = allPhotos[i].getID_ALBUM();
                string description = allPhotos[i].getDESCRIPTION();
                string album_name = allPhotos[i].getALBUMNAME();

                if (i % 4 == 0)
                {
        %>
            <div class="row">
            <%
    }
%>
            <div class="col-sm-4">
      <div class="box-thumbnail">
        <a href="viewphoto.aspx?id=<%=photoID %>" title="Picture" class="content-box__link">
            <figure class="content-box__thumb">
                <img src="<%=photo %>" alt="Picture" class="content-box__image">
            </figure>
            </a>
            <h2 class="content-box__info">
                <span class="content-box__description">
                    <%
    if (description.Equals(""))
    {
                        %>
                        This is a default description.
                        <%
    }
    else
    {
                                %>
                    <%=description %>
                    <%
    }
                        %>
                </span>
                <a href="album.aspx?id=<%=albumID %>" title="Album">
                <span class="content-box__title"><%=album_name %></span>
                    </a>
            </h2>
      </div>
    </div>


<%
    if ((i + 1) % 4 == 0)
    {
            %>
        </div>
    <%
            }
        }
    }
%>

    </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>
