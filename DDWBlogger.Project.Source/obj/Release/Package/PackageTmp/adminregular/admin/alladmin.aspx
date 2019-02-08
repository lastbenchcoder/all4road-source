<%@ Page Title="" Language="C#" MasterPageFile="~/adminregular/regulardashboard.Master" AutoEventWireup="true" CodeBehind="alladmin.aspx.cs" Inherits="DDWBlogger.Project.Source.adminregular.admin.alladmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<DDWBlogger.Project.Source.Models.Administrator> Administrator = null;
        var adminKey = Session["RgAdminKey"].ToString();
        using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
        {
            Administrator = context.Administrator.Include("Role").Include("Status").ToList();
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Administrators</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/adminregular/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Administration</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">All Administrator</a>
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
                            Administrator
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>FullName</th>
                                    <th>EmailId</th>
                                    <th>Role</th>
                                    <th>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in Administrator)
                                    { %>
                                <tr>
                                    <td>
                                        <img src="../../<%=item.Banner%>" width="50" height="50" /></td>
                                    <td><%=item.FirstName %>&nbsp;&nbsp;<%=item.LastName %></td>
                                    <td><%=item.EmailId %></td>
                                    <td><%=item.Role.Title %></td>
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
                                        <span class="label label-danger">In Active
                                        </span>
                                    </td>
                                    <%} %>
                                    <td class='hidden-1024'><%=item.DateCreated.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.DateUpdated.ToString("D") %></td>
                                    <% if (item.AdministratorId.ToString() == adminKey)
                                        { %>
                                    <td>
                                        <a href="/adminregular/profile.aspx?adminid=<%=item.AdministratorId %>&pageId=1234"><i class="fa fa-edit fa-lg"></i></a>
                                    </td>
                                    <%}
    else
    {%>
                                    <td><i class="fa fa-edit fa-lg"></i></td>
                                    <%} %>
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
