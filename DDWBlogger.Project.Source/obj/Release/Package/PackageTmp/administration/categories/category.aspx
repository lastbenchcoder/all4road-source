<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.categories.category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<DDWBlogger.Project.Source.Models.Category> Category = null;
        using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
        {
            Category = context.Category.Include("Administrator").Include("Status").ToList();
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Category</h1>
            </div>
            <div class="pull-right">
                <a href="#modal-category" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Categories</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Category</a>
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
                            Category
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
                                     <th class='hidden-480'>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in Category)
                                    { %>
                                <tr>
                                    <td><%=item.Title %></td>
                                    <td><%=item.Description %></td>
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
                                    <td class='hidden-1024'><%=item.DateCreated.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.DateUpdated.ToString("D") %></td>
                                     <td class='hidden-480'><a href="/administration/categories/categorydetail.aspx?catid=<%=item.CategoryId %>&redirectUrl=category-detail-administrator-home&pageId=1234HJHJKJ*7987979"><i class="fa fa-edit"></i></a></td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="modal-category" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">New Category</h4>
                </div>
                <!-- /.modal-header -->
                <div class="modal-body">
                    <div class="form-group">
                        <asp:TextBox ID="txtTitle" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                            ErrorMessage="Enter Category Title" ControlToValidate="txtTitle" ValidationGroup="category"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="form-control" placeholder="Description" Style="height: 100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                            ErrorMessage="Enter Category Description" ControlToValidate="txtDescription" ValidationGroup="category"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!-- /.modal-body -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="category" OnClick="btnSubmit_Click" />
                </div>
                <!-- /.modal-footer -->
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>
