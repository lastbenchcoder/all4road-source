<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="adsizes.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.secreadonly.adsizes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<DDWBlogger.Project.Source.Models.AddSize> AddSize = null;
        using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
        {
            AddSize = context.AddSize.ToList();
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Most Common Ad Sizes</h1>
                <p>If you’re doing online advertising, you need to know what banner sizes, here are the Most Common Ad Sizes.</p>
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
                    <a href="/">Ad Sizes</a>
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
                            Ad Sizes
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Title</th>
                                    <th>Description</th>
                                    <th>Width</th>
                                    <th>Height</th>
                                    <th class='hidden-350'>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in AddSize)
                                    { %>
                                <tr>
                                    <td><%=item.Title %></td>
                                    <td><%=item.Description %></td>
                                    <td><%=item.Width %></td>
                                    <td><%=item.Height %></td>
                                    <%if (item.InDisplay == 1)
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success">Active
                                        </span>
                                    </td>
                                    <%}
                                        else
                                        {%>
                                    <td class='hidden-350'>
                                        <span class="label label-danger">In Active
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
