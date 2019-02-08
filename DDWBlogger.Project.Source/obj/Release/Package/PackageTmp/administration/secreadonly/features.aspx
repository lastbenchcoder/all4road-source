<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="features.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.secreadonly.features" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%
         List<DDWBlogger.Project.Source.Models.ArticleAndTypes> ArticleAndTypes = null;
         using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
         {
             ArticleAndTypes = context.ArticleAndTypes.ToList();
         }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All ArticleAndTypes For the Application</h1>
                <p>Here are the ArticleAndTypes used in this application, No Modification allowed to the ArticleAndTypes. If any modification please contact administrator.</p>
            </div>          
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">ReadOnly Section</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/">ArticleAndTypes</a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            ArticleAndTypes
				</h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Title</th>
                                    <th>Description</th>
                                    <th class='hidden-350'>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in ArticleAndTypes)
                                    { %>
                                <tr>
                                    <td><%=item.Type %></td>
                                    <td><%=item.Description %></td>
                                    <%if (item.InDisplay == 1)
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success">
                                           Active
                                        </span>
                                    </td>
                                    <%}
                                        else
                                        {%>
                                    <td class='hidden-350'>
                                        <span class="label label-danger">
                                            In Active
                                        </span>
                                    </td>
                                    <%} %>
                                    <td class='hidden-1024'><%=item.DateCreated.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.DateUpdated.ToString("D") %></td>
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
