<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="menus.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.pages.menus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<DDWBlogger.Project.Source.Models.Menus> _RequestList = null;
        DDWBlogger.Project.Source.App_Data.DBContext context = new DDWBlogger.Project.Source.App_Data.DBContext();
        _RequestList = context.Menus.Include("Pages").Include("Administrator").ToList();
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Menu</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Pages & Detail</a>
                </li>
                <li>
                    <a href="#">Menus</a>
                    <i class="fa fa-angle-right"></i>
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
                            New Menu
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class="form-group">
                            <label class="control-label col-sm-2">Title</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtCategory" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter title" ControlToValidate="txtCategory" ValidationGroup="admin"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">Type</label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlmenutype" runat="server" class="form-control input-sm">
                                    <asp:ListItem>Select..</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Select Menu Type" InitialValue="Select.." ControlToValidate="ddlmenutype" ValidationGroup="admin"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">Have Custom URL?</label>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="isCustomURL" runat="server" OnCheckedChanged="isCustomURL_CheckedChanged" AutoPostBack="true" Text="is Custom URL?"/>
                            </div>
                        </div>
                        <asp:Panel ID="pnlCustomURL" runat="server" Visible="false" class="form-group">
                            <label class="control-label col-sm-2">URL</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtCustomURL" runat="server" class="form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Custom URL Required" ControlToValidate="txtCustomURL" ValidationGroup="admin"></asp:RequiredFieldValidator>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlPageSelection" runat="server" class="form-group">
                            <label class="control-label col-sm-2">Select Page</label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlpage" runat="server" class="form-control input-sm">
                                    <asp:ListItem>Select..</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Select Page" InitialValue="Select.." ControlToValidate="ddlpage" ValidationGroup="admin"></asp:RequiredFieldValidator>
                            </div>
                        </asp:Panel>
                        <div class="form-actions col-sm-offset-2 col-sm-10">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Menus
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Menu Id</th>
                                    <th>Type</th>
                                    <th>Title</th>
                                    <th>Page</th>
                                    <th>Status</th>
                                    <th>CreatedBy</th>
                                    <th>CreatedDate</th>
                                    <th>UpdatedDate</th>
                                    <th>Edit Detail</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <%=item.Menu_Id %></td>
                                    <td>
                                        <%=item.MenuType %></td>
                                    <td><%=item.Title %></td>
                                    <%if (item.Custom_Url == "Pages")
                                        {%>
                                    <td><%=item.Custom_Url %></td>
                                    <%}
                                        else
                                        { %>
                                    <td><%=item.Pages.Title %></td>
                                    <%} %>
                                    <%if (item.StatusId == Convert.ToInt32(DDWBlogger.Project.Source.Enums.eStatus.Active))
                                        {%>
                                    <td><span style="font-weight: bold; color: green">
                                        <%=item.Status %>
                                    </span></td>
                                    <%}
                                        else
                                        { %>
                                    <td><span style="font-weight: bold; color: red">
                                        <%=item.Status %>
                                    </span></td>
                                    <%} %>
                                    <td><%=item.Administrator.FirstName %>&nbsp;&nbsp;<%=item.Administrator.FirstName %></td>
                                    <td><%=item.DateCreated %></td>
                                    <td><%=item.DateUpdated %></td>
                                    <td><a href="/administration/pages/menudetail.aspx?menuid=<%=item.Menu_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
                                    <%
                                        }
                                    %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
