<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.master"
     AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeaderContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="BodyContent">
   <div class="container" style="text-align: center;">
  <div class="row2">
   <div class="youtube-container" style="    display: inline-table;">
     <h1 style="color: #ff0084;
    font-size: 26px;
    font-weight: 700;
        text-align: left;
    margin-left: 25px;
    margin-top: 0;
    ">Contact us</h1> 

<div style="text-align: left; margin-left: 40px; margin-top: 0;padding-right: 30px;">
<div class="google-maps">
    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2848.888727446979!2d26.09948441590742!3d44.435444679102226!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40b1ff473869f53f%3A0xee62eda4d786c152!2sUniversitatea+din+Bucure%C8%99ti!5e0!3m2!1sro!2sro!4v1480525324292" width="600" height="350" frameborder="0" style="border:0"></iframe>
</div>
<div style="display: block;margin-top:20px;">
<div style="display: block;float:left;">
<div style="display: block;    padding-bottom: 20px;">
<h2 style="    font-weight: 500;
    font-size: 22px;
    line-height: normal;
    color: #000000;"><i class="fa fa-pencil" aria-hidden="true" style="    color: #dd4b39;"></i> Get in Touch</h2>
</div>
<div class="from-contact">
<form class="form-horizontal" runat="server">
  <div class="form-group">
    <label for="name" class="col-sm-2 control-label">Name</label>
    <div class="col-sm-10">
      <asp:TextBox runat="server" class="form-control" id="contactName" name="name" placeholder="First & Last Name" />
    </div>
  </div>
  <div class="form-group">
    <label for="email" class="col-sm-2 control-label">Email</label>
    <div class="col-sm-10">
       <asp:TextBox runat="server" class="form-control" id="contactEmail" name="email" placeholder="example@domain.com" />
    </div>
  </div>
  <div class="form-group">
    <label for="message" class="col-sm-2 control-label">Message</label>
    <div class="col-sm-10">
        <asp:TextBox TextMode="MultiLine" runat="server" class="form-control" rows="5" Columns="50" id="contactMessage" name="message" style="max-height: 200px; height: 150px; max-width: 350px;" />
    </div>
  </div>
  <div class="form-group">
    <div class="col-sm-10 col-sm-offset-2">
        <asp:Button Text="Send email" runat="server" OnClick="Send_Email" class="btn btn-primary" style="background-color:  #f26522; border: 0; float:right;"/>
    </div>
  </div>
  <div class="form-group">
    <div class="col-sm-10 col-sm-offset-2">
      <! Will be used to display an alert to the user>
    </div>
  </div>
</form>
</div>
</div>
 <div style="display: block;float:right;">
<div style="display: block;    padding-bottom: 20px;    padding-bottom: 100px;">
<h2 style="    font-weight: 500;
    font-size: 24px;
    line-height: normal;
    color: #000000;"><i class="fa fa-globe" aria-hidden="true" style="    color: #dd4b39;"></i> Office Address</h2>
</div>
<p>Site name Inc.<br>
935 W. Webster Ave New Streets Chicago<br> IL 60614, NY Newyork USA<br>
Mobile: +2346 17 38 93<br>
Fax: 1-714-252-0026</p>
 </div>
</div>


</div>

    </div>
  </div>
</div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="NavigationContent">
</asp:Content>
