<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="approvecomments.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.article.approvecomments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Ratings & Review</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Articles</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Ratings & Review</a>
                </li>
                <li>
                    <a href="#">
                        <asp:Label ID="lblBcTitle" runat="server"></asp:Label></a>
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
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Ratings & Review Confirmation
                        </h3>
                    </div>
                    <div class="box-content nopadding">

                        <div class="preview-img col-sm-3">
                            <a href="#">
                                <asp:HiddenField ID="hdnCommentId" runat="server" />
                                <asp:Image ID="imgProduct" runat="server" ClientIDMode="Static" Width="200px" Style="margin-top: 10px" />
                            </a>
                        </div>
                        <div class="post-content col-sm-9">
                            <h4 class="post-title">
                                <a href="#">
                                    <asp:Label ID="lblProductTitle" runat="server"></asp:Label></a>
                            </h4>
                            <div class="post-meta">
                                <span class="date">
                                    <i class="fa fa-calendar"></i>
                                    <asp:Label runat="server" ID="lblDate"></asp:Label>
                                </span>
                                <span class="author">
                                    <i class="fa fa-user"></i>
                                    <a href="#">
                                        <asp:Label ID="lblUserDetail" runat="server"></asp:Label>
                                    </a>
                                </span>
                            </div>
                            <div class="post-text">
                                <p>
                                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                </p>
                            </div>
                        </div>
                        <div class="pull-right" style="margin-top: 20px; margin-bottom: 20px; margin-right: 10px">
                            <asp:Button ID="btnApprove" class="btn btn-primary" runat="server" Text="Approve" OnClientClick="return confirmationApprove();" OnClick="btnApprove_Click" />
                            <asp:Button ID="btnReject" class="btn btn-danger" runat="server" Text="Reject" OnClientClick="return confirmationReject();" OnClick="btnReject_Click" />
                        </div>
                        <script type="text/javascript">
                            function confirmationApprove() {
                                if (confirm('are you sure you want to approve ?')) {
                                    return true;
                                } else {
                                    return false;
                                }
                            }

                            function confirmationReject() {
                                if (confirm('are you sure you want to reject ?')) {
                                    return true;
                                } else {
                                    return false;
                                }
                            }
                        </script>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
