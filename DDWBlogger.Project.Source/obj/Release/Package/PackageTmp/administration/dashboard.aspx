<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.dashboard1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        DDWBlogger.Project.Source.ViewModel.AdminDashboardModel adm = null;
        if (Session["AdminKey"] != null)
        {
            int adminId = Convert.ToInt32(Session["AdminKey"].ToString());
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
                        <i class="fa fa-user"></i>
                        <div class="details">
                            <span class="big"><%=adm.totAdministrator %></span>
                            <span>Administrators</span>
                        </div>
                    </li>
                    <li class='satgreen'>
                        <i class="fa fa-bell-o"></i>
                        <div class="details">
                            <span class="big"><%=adm.totCategory %></span>
                            <span>Category</span>
                        </div>
                    </li>
                    <li class='satgreen'>
                        <i class="fa fa-book"></i>
                        <div class="details">
                            <span class="big"><%=adm.totArticle %></span>
                            <span>Articles</span>
                        </div>
                    </li>
                    <li class='lightred'>
                        <i class="fa fa-comment"></i>
                        <div class="details">
                            <span class="big"><%=adm.totReviewComment %></span>
                            <span>Comments</span>
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
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Pending Invitations
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>EmailId</th>
                                    <th>Role</th>
                                    <th class='hidden-350'>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in adm.Invitation.Where(m => m.Status.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString()))
                                    { %>
                                <tr>
                                    <td><%=item.EmailId %></td>
                                    <td><%=item.Role.Title %></td>
                                    <%if (item.Status.Title == DDWBlogger.Project.Source.Enums.eStatus.Completed.ToString())
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success">
                                            <%=item.Status.Title %>
                                        </span>
                                    </td>
                                    <%}
                                        else
                                        {%>
                                    <td class='hidden-350'>
                                        <span class="label label-danger">Pending
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
