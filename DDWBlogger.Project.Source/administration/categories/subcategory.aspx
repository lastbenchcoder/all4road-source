<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="subcategory.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.categories.subcategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<DDWBlogger.Project.Source.Models.SubCategory> SubCategory = null;
        using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
        {
            SubCategory = context.SubCategory.Include("Category").Include("Administrator").Include("Status").ToList();
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All SubCategory</h1>
            </div>
            <div class="pull-right">
                <a href="#modal-SubCategory" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
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
                    <a href="#">SubCategory</a>
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
                            SubCategory
				</h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Title</th>
                                    <th>Description</th>
                                    <th>Category</th>
                                    <th class='hidden-350'>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th class='hidden-480'>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in SubCategory)
                                    { %>
                                <tr>
                                    <td><%=item.Title %></td>
                                    <td><%=item.Description %></td>
                                    <th><%=item.Category.Title %></th>
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
                                    <td class='hidden-480'><a href="/administration/categories/SubCategorydetail.aspx?catid=<%=item.SubCategoryId %>&redirectUrl=SubCategory-detail-administrator-home&pageId=1234HJHJKJ*7987979"><i class="fa fa-edit"></i></a></td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="modal-SubCategory" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">New SubCategory</h4>
                </div>
                <!-- /.modal-header -->
                <div class="modal-body">
                    <div class="form-group">
                        <asp:TextBox ID="txtTitle" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                            ErrorMessage="Enter SubCategory Title" ControlToValidate="txtTitle" ValidationGroup="SubCategory"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="form-control" placeholder="Description" Style="height: 100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                            ErrorMessage="Enter SubCategory Description" ControlToValidate="txtDescription" ValidationGroup="SubCategory"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" Style="width: 250px">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                            ErrorMessage="Select Category" ControlToValidate="ddlCategory" ValidationGroup="SubCategory" InitialValue="Select.."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!-- /.modal-body -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="SubCategory" OnClick="btnSubmit_Click" />
                </div>
                <!-- /.modal-footer -->
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>
