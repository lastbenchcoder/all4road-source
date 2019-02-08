<%@ Page Title="" Language="C#" MasterPageFile="~/adminregular/regulardashboard.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="DDWBlogger.Project.Source.adminregular._dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-footer:last-child {
            border-radius: 0 0 calc(3px - 1px) calc(3px - 1px);
        }

        .pd-20 {
            padding: 20px;
        }

        .bd-t {
            border-top: 1px solid rgba(0, 0, 0, 0.15);
        }

        .card-footer {
            border-top-width: 0;
            border-radius: 0;
        }

        .card-header, .card-footer {
            border-color: #dee2e6;
            padding-left: 15px;
            padding-right: 15px;
        }

        .card-footer {
            padding: 0.75rem 1.25rem;
            background-color: rgba(0, 0, 0, 0.03);
            border-top: 1px solid rgba(0, 0, 0, 0.125);
        }

        .align-items-center {
            align-items: center !important;
        }

        .media {
            display: flex;
            align-items: flex-start;
        }

        *, *::before, *::after {
            box-sizing: inherit;
        }

        user agent stylesheet div {
            display: block;
        }

        .mg-l-15 {
            margin-left: 15px;
        }

        .media-body {
            flex: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        DDWBlogger.Project.Source.ViewModel.AdminDashboardModel adm = null;
        if (Session["RgAdminKey"] != null)
        {
            int adminId = Convert.ToInt32(Session["RgAdminKey"].ToString());
            DDWBlogger.Project.Source.ViewModel.AdminDashBoard AdminDashBoard = new DDWBlogger.Project.Source.ViewModel.AdminDashBoard();
            adm = AdminDashBoard.GetDashboard(adminId);
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Welcome <%=adm.Administrator.FirstName +" "+ adm.Administrator.LastName%>!!!</h1>
            </div>
            <div class="pull-right">
                <ul class="stats">
                    <li class='satgreen'>
                        <i class="fa fa-book"></i>
                        <div class="details">
                            <span class="big"><%=adm.totArticle %></span>
                            <span>Articles</span>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Administrator</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Dashboard</a>
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
                <div></div>
                <div class="card-footer pd-20 bd-t" style="margin-top: 20px">
                    <div class="media align-items-center">
                        <img src="../../<%=adm.Administrator.Banner%>" class="wd-40 rounded-circle" alt="" width="44">
                        <div class="media-body mg-l-15">
                            <input type="text" class="txtArticle form-control" placeholder="Start creating new article..." />
                        </div>
                        <!-- media-body -->
                    </div>
                    <!-- media -->
                </div>
                <script>
                    $('.txtArticle').keypress(function (e) {
                        if (e.which == 13) {
                            window.location.href = "/adminregular/article/newarticle.aspx?title=" + $('.txtArticle').val() + "&redirectUrl=articles-administrator-home&pageId=1234HJHJKJ*7987979";
                            return false;    //<---- Add this line
                        }
                    });
                </script>
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-bars"></i>
                            Timeline
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <style>
                            .card {
                                position: relative;
                                display: flex;
                                flex-direction: column;
                                min-width: 0;
                                word-wrap: break-word;
                                background-color: #fff;
                                background-clip: border-box;
                                border: 1px solid rgba(0, 0, 0, 0.125);
                                border-radius: 3px;
                            }

                            .card-body {
                                flex: 1 1 auto;
                                padding: 1.25rem;
                            }

                            .card-title {
                                margin-bottom: 0.75rem;
                            }

                            .card-subtitle {
                                margin-top: -0.375rem;
                                margin-bottom: 0;
                            }

                            .card-text:last-child {
                                margin-bottom: 0;
                            }

                            .card-link:hover {
                                text-decoration: none;
                            }

                            .card-link + .card-link {
                                margin-left: 1.25rem;
                            }

                            .card > .list-group:first-child .list-group-item:first-child {
                                border-top-left-radius: 3px;
                                border-top-right-radius: 3px;
                            }

                            .card > .list-group:last-child .list-group-item:last-child {
                                border-bottom-right-radius: 3px;
                                border-bottom-left-radius: 3px;
                            }

                            .card-header {
                                padding: 0.75rem 1.25rem;
                                margin-bottom: 0;
                                background-color: rgba(0, 0, 0, 0.03);
                                border-bottom: 1px solid rgba(0, 0, 0, 0.125);
                            }

                                .card-header:first-child {
                                    border-radius: calc(3px - 1px) calc(3px - 1px) 0 0;
                                }

                            .card-footer {
                                padding: 0.75rem 1.25rem;
                                background-color: rgba(0, 0, 0, 0.03);
                                border-top: 1px solid rgba(0, 0, 0, 0.125);
                            }

                                .card-footer:last-child {
                                    border-radius: 0 0 calc(3px - 1px) calc(3px - 1px);
                                }

                            .card-header-tabs {
                                margin-right: -0.625rem;
                                margin-bottom: -0.75rem;
                                margin-left: -0.625rem;
                                border-bottom: 0;
                            }

                            .card-header-pills {
                                margin-right: -0.625rem;
                                margin-left: -0.625rem;
                            }

                            .card-img-overlay {
                                position: absolute;
                                top: 0;
                                right: 0;
                                bottom: 0;
                                left: 0;
                                padding: 1.25rem;
                            }

                            .card-img {
                                width: 100%;
                                border-radius: calc(3px - 1px);
                            }

                            .card-img-top {
                                width: 100%;
                                border-top-left-radius: calc(3px - 1px);
                                border-top-right-radius: calc(3px - 1px);
                            }

                            .card-img-bottom {
                                width: 100%;
                                border-bottom-right-radius: calc(3px - 1px);
                                border-bottom-left-radius: calc(3px - 1px);
                            }

                            @media (min-width: 576px) {
                                .card-deck {
                                    display: flex;
                                    flex-flow: row wrap;
                                    margin-right: -15px;
                                    margin-left: -15px;
                                }

                                    .card-deck .card {
                                        display: flex;
                                        flex: 1 0 0%;
                                        flex-direction: column;
                                        margin-right: 15px;
                                        margin-left: 15px;
                                    }
                            }

                            @media (min-width: 576px) {
                                .card-group {
                                    display: flex;
                                    flex-flow: row wrap;
                                }

                                    .card-group .card {
                                        flex: 1 0 0%;
                                    }

                                        .card-group .card + .card {
                                            margin-left: 0;
                                            border-left: 0;
                                        }

                                        .card-group .card:first-child {
                                            border-top-right-radius: 0;
                                            border-bottom-right-radius: 0;
                                        }

                                            .card-group .card:first-child .card-img-top {
                                                border-top-right-radius: 0;
                                            }

                                            .card-group .card:first-child .card-img-bottom {
                                                border-bottom-right-radius: 0;
                                            }

                                        .card-group .card:last-child {
                                            border-top-left-radius: 0;
                                            border-bottom-left-radius: 0;
                                        }

                                            .card-group .card:last-child .card-img-top {
                                                border-top-left-radius: 0;
                                            }

                                            .card-group .card:last-child .card-img-bottom {
                                                border-bottom-left-radius: 0;
                                            }

                                        .card-group .card:not(:first-child):not(:last-child) {
                                            border-radius: 0;
                                        }

                                            .card-group .card:not(:first-child):not(:last-child) .card-img-top,
                                            .card-group .card:not(:first-child):not(:last-child) .card-img-bottom {
                                                border-radius: 0;
                                            }
                            }

                            .card-columns .card {
                                margin-bottom: 0.75rem;
                            }

                            @media (min-width: 576px) {
                                .card-columns {
                                    column-count: 3;
                                    column-gap: 1.25rem;
                                }

                                    .card-columns .card {
                                        display: inline-block;
                                        width: 100%;
                                    }
                            }

                            .mg-t-20 {
                                margin-top: 20px;
                            }

                            .bd-primary {
                                border-color: #0866C6;
                            }

                            .card {
                                border-radius: 0;
                            }

                            .card {
                                position: relative;
                                display: flex;
                                flex-direction: column;
                                min-width: 0;
                                word-wrap: break-word;
                                background-color: #fff;
                                background-clip: border-box;
                                border: 1px solid rgba(0, 0, 0, 0.125);
                                border-radius: 3px;
                            }

                            .card-body {
                                padding: 20px;
                            }

                            .card-body {
                                flex: 1 1 auto;
                                padding: 1.25rem;
                            }

                            .media {
                                display: flex;
                                align-items: flex-start;
                            }

                            .wd-50 {
                                width: 50px;
                            }

                            .rounded-circle {
                                border-radius: 50%;
                            }

                            img {
                                vertical-align: middle;
                                border-style: none;
                            }

                            .mg-l-20 {
                                margin-left: 20px;
                            }

                            .media-body {
                                flex: 1;
                            }

                            .tx-15 {
                                font-size: 15px;
                            }

                            .mg-b-5 {
                                margin-bottom: 5px;
                            }

                            h6, .h6 {
                                font-size: 1rem;
                            }

                            .mg-b-20 {
                                margin-bottom: 20px;
                            }

                            p {
                                margin-bottom: 20px;
                            }

                            p {
                                margin-top: 0;
                                margin-bottom: 1rem;
                            }

                            .mg-b-0 {
                                margin-bottom: 0px;
                            }
                        </style>
                        <div class="card bd-primary">
                            <div class="card-body">
                                <div class="media-list">
                                    <%if (adm.Article.Count() > 0)
                                        {
                                            foreach (var item in adm.Article)
                                            {
                                    %>
                                    <div class="media">
                                        <img src="../../<%=item.FeaturedBanner %>" class="wd-50 rounded-circle" alt="">
                                        <div class="media-body mg-l-20">
                                            <h6 class="tx-15 mg-b-5"><a href="/adminregular/article/articledetail.aspx?articleid=<%=item.ArticleId %>&redirectUrl=category-detail-administrator-home&pageId=1234HJHJKJ*7987979"><%=item.Title %></a></h6>
                                            <p class="mg-b-20">On: <a href=""><%=item.DateCreated.ToString("D") %></a></p>
                                            <p>
                                                <%if (item.Description.Length > 300)
                                                    { %>
                                                <span><%=item.Description.Substring(0, 300) %><span>...</span></span>
                                                <%}
                                                    else
                                                    { %>
                                                <span><%=item.Description %><span>...</span></span>
                                                <%} %>
                                            </p>
                                            <p class="mg-b-0">
                                                <%if (item.Status.Title == DDWBlogger.Project.Source.Enums.eStatus.Published.ToString() && item.Status.StatusFor == "Articles")
                                                    { %>
                                                <td class='hidden-350'>
                                                    <span class="label label-success"><%=item.Status.Title %>
                                                    </span>
                                                </td>
                                                <%}
                                                    else
                                                    {%>
                                                <td class='hidden-350'>
                                                    <span class="label label-danger"><%=item.Status.Title %>
                                                    </span>
                                                    &nbsp; &nbsp;
                                                    Pending for Publish From Administrator
                                                </td>
                                                <%} %>
                                            </p>
                                        </div>
                                        <!-- media-body -->
                                    </div>
                                    <!-- media -->

                                    <hr class="mg-y-20">
                                    <%
                                            }
                                        } %>
                                </div>
                                <!-- media-list -->
                            </div>
                            <!-- card-body -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
