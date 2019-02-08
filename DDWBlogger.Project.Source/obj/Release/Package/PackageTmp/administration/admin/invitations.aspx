<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="invitations.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.admin.invitations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<DDWBlogger.Project.Source.Models.Invitation> Invitation = null;
        using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
        {
            Invitation = context.Invitation.Include("Role").Include("Status").ToList();
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Invitation</h1>
            </div>
            <div class="pull-right">
                <a href="#modal-Invitation" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Administration</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Invitation</a>
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
                            Invitation
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Code</th>
                                    <th>EmailId</th>
                                    <th>Role</th>
                                    <th>Status</th>
                                    <th>Registration Link</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in Invitation)
                                    { %>
                                <tr>
                                    <td><%=item.InvitationCode %></td>
                                    <td><%=item.EmailId %></td>
                                    <td><%=item.Role.Title %></td>
                                    <%if (item.Status.Title == DDWBlogger.Project.Source.Enums.eStatus.Completed.ToString())
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success"><%=item.Status.Title %>
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
                                    <td>
                                        <p><%=System.Configuration.ConfigurationSettings.AppSettings["DomainUrl"].ToString() %>/account/invitation.aspx?code=<%= item.InvitationCode %>&emailid=<%= item.EmailId %></p>
                                    </td>
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
    <div id="modal-Invitation" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">New Invitation</h4>
                </div>
                <!-- /.modal-header -->
                <div class="modal-body">
                    <div class="form-group">
                        <asp:TextBox ID="txtEmailId" runat="server" class="form-control" placeholder="EmailId"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                            ErrorMessage="Enter EmailId" ControlToValidate="txtEmailId" ValidationGroup="Invitation"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlRole" runat="server" class="form-control" Style="width: 250px">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                            ErrorMessage="Select Role" ControlToValidate="ddlRole" ValidationGroup="Invitation" InitialValue="Select.."></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!-- /.modal-body -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="Invitation" OnClick="btnSubmit_Click" />
                </div>
                <!-- /.modal-footer -->
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>
