<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="ratingsreview.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.article.ratingsreview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<DDWBlogger.Project.Source.Models.ReviewComment> ReviewComment = null;
        using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
        {
            ReviewComment = context.ReviewComment.Include("Article").Include("Status").ToList();
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Article Comments</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Article</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Ratings & Review</a>
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
                            Comments
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Article</th>
                                    <th>FullName</th>
                                    <th>EmailId</th>
                                    <th>Comment</th>
                                    <th>Rating</th>
                                    <th>Like</th>
                                    <th class='hidden-350'>Status</th>
                                    <th class='hidden-480'>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in ReviewComment)
                                    { %>
                                <tr>
                                    <td><%=item.Article.Title %></td>
                                    <td><%=item.FullName %></td>
                                    <td><%=item.EmailId %></td>
                                    <td><%=item.CommentDescription %></td>
                                    <td>
                                        <span class="stars" style="float: right"><%=Convert.ToDecimal(item.Rating) %></span>
                                    </td>
                                    <%if (item.Like == 1)
                                        { %>
                                    <td>Like</td>
                                    <%}
                                        else
                                        { %>
                                    <td>Dislike</td>
                                    <%} %>
                                    <%if (item.Status.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString())
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
                                    </td>
                                    <%} %>
                                    <td class='hidden-480'><a href="/administration/article/approvecomments.aspx?commentid=<%=item.ReviewCommentId %>&redirectUrl=category-detail-administrator-home&pageId=1234HJHJKJ*7987979"><i class="fa fa-edit"></i></a></td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
