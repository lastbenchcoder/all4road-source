<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="articles.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.article.articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<DDWBlogger.Project.Source.Models.Article> Article = null;
        using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
        {
            Article = context.Article.Include("Administrator").Include("SubCategory").Include("ReviewComment").Include("Status").ToList();
            foreach (var item in Article)
            {
                item.SubCategory.Category = context.Category.Where(m => m.CategoryId == item.SubCategory.CategoryId).FirstOrDefault();
            }
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Articles</h1>
            </div>
            <div class="pull-right">
                <a href="/administration/article/newarticle.aspx?redirectUrl=articles-administrator-home&pageId=1234HJHJKJ*7987979" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
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
                    <a href="#">All Articles</a>
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
                            Articles
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                     <th>Id</th>
                                    <th>Title</th>
                                    <th>Category</th>
                                    <th>Administrator</th>
                                    <th class='hidden-350'>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th class='hidden-480'>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in Article)
                                    { %>
                                <tr>
                                    <td>
                                        <img src="../../<%=item.FeaturedBanner%>" width="50" height="50" /></td>
                                     <td><%=item.ArticleId %></td>
                                    <td><%=item.Title %></td>
                                    <td><%=item.SubCategory.Title %>(<%=item.SubCategory.Category.Title %>)</td>
                                    <td><%=item.Administrator.FirstName %> &nbsp;&nbsp;<%=item.Administrator.LastName %></td>
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
                                    </td>
                                    <%} %>
                                    <td class='hidden-1024'><%=item.DateCreated.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.DateUpdated.ToString("D") %></td>
                                    <td class='hidden-480'><a href="/administration/article/articledetail.aspx?articleid=<%=item.ArticleId %>&redirectUrl=category-detail-administrator-home&pageId=1234HJHJKJ*7987979"><i class="fa fa-edit"></i></a></td>
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
