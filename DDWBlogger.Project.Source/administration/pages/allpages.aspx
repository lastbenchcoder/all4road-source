<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="allpages.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.pages.allpages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<DDWBlogger.Project.Source.Models.Pages> _RequestList = null;
        DDWBlogger.Project.Source.App_Data.DBContext context = new DDWBlogger.Project.Source.App_Data.DBContext();
        _RequestList = context.Pages.Include("Administrator").ToList();
    %>


    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Contact Information</h1>
            </div>
            <div class="pull-right">
                <a href="/administration/pages/newpage.aspx?redId=7654765465456456SGGDSDGDGGGGGGGGGGGGGGGGG89709709&pageId=1234" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Content</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Pages & Detail</a>
                </li>
                <li>
                    <a href="#">All Pages</a>
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
                            Contact Information
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Pages Id</th>
                                    <th>Title</th>
                                    <th>DateCreated</th>
                                    <th>DateUpdated</th>
                                    <th>CreatedBy</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in _RequestList)
                                    { %>
                                <tr>
                                    <td><%=item.Page_Id %></td>
                                    <td><%=item.Title %></td>
                                    <td><%=item.DateCreated.ToString("D") %></td>
                                    <td><%=item.DateUpdated.ToString("D") %></td>
                                    <td><%=item.Administrator.FirstName %> &nbsp;&nbsp;<%=item.Administrator.FirstName %></td>
                                    <td>
                                        <a href="/administration/pages/pagedetail.aspx?pageid=<%=item.Page_Id %>&page-Id=1234"><i class="fa fa-edit fa-lg"></i></a>
                                    </td>
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
