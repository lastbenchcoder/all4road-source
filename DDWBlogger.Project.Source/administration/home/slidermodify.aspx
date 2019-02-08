<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="slidermodify.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.home.slidermodify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Home Slider</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Content</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Home Slider</a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <asp:Panel ID="pnlErrorMessage" class="page-header" runat="server" Visible="false" Style="margin-top: 10px">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
              <div class="col-sm-12">
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-edit"></i>Modify Home Slider</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-bordered'>
                            <asp:HiddenField ID="hdnSliderId" runat="server" />
                            <div class="form-group">
                                <label for="textfield" class="control-label col-sm-2">Article Id</label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblArticleId" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="textfield" class="control-label col-sm-2">Title</label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblArticle" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="textfield" class="control-label col-sm-2"></label>
                                <div class="col-sm-10">
                                    <div class="input-group">
                                        <asp:Image ID="imgArticle" runat="server" Width="100px" Height="100px" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions pull-right">
                                <asp:Button ID="btnDelete" runat="server" class="btn btn-danger" Text="Delete" OnClick="btnDelete_Click"/>
                                <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
