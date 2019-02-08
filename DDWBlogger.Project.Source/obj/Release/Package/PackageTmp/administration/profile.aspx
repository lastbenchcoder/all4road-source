<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Profile Update</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">My Profile Update</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">
                        <asp:Label ID="lblBcTitle" runat="server"></asp:Label></a>
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
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Update Account Password</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <asp:HiddenField ID="hdnAdminId" runat="server" />
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">FirstName</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtFirstName" runat="server" class="form-control" placeholder="FirstName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter FirstName" ControlToValidate="txtFirstName" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtPassword" class="control-label col-sm-2">LastName</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtLastName" runat="server" class="form-control" placeholder="LastName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter LastName" ControlToValidate="txtLastName" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtPassword" class="control-label col-sm-2">EmailId</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEmailId" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtPassword" class="control-label col-sm-2">Phone Number</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtPhone" runat="server" TextMode="Number" class="form-control" placeholder="Phone"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter Phone Number" ControlToValidate="txtPhone" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">Description</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control" placeholder="Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter Description" ControlToValidate="txtDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="textfield" class="control-label col-sm-2"></label>
                                <div class="col-sm-10">
                                    <asp:Image ID="imgProduct" runat="server" ClientIDMode="Static" Width="100px" Height="100px" class="form-control" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Image !.." ValidationGroup="admin" ControlToValidate="imgInp" ForeColor="Red" ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.PNG|.png)$"></asp:RegularExpressionValidator>
                                    <asp:FileUpload ID="imgInp" runat="server" ClientIDMode="Static" class="form-control" />
                                    <script type="text/javascript">
                                        function readURL(input) {
                                            if (input.files && input.files[0]) {
                                                var reader = new FileReader();

                                                reader.onload = function (e) {
                                                    $('#imgProduct').attr('src', e.target.result);
                                                }

                                                reader.readAsDataURL(input.files[0]);
                                            }
                                        }

                                        $("#imgInp").change(function () {
                                            readURL(this);
                                        });
                                    </script>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtLoginId" class="control-label col-sm-2">LoginId/UserId</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtLoginId" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <asp:Panel ID="pnlRole" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="txtLoginId" class="control-label col-sm-2">Role</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="ddlRole" runat="server" class="form-control" Style="width: 250px">
                                            <asp:ListItem>Select..</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                                            ErrorMessage="Select Role" ControlToValidate="ddlRole" ValidationGroup="admin" InitialValue="Select.."></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Security Question</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlSecQuestion" runat="server" class="form-control" Style="width: 250px">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red"
                                        ErrorMessage="Select Security Question" ControlToValidate="ddlSecQuestion" ValidationGroup="admin" InitialValue="Select.."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Answer</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAnswer" runat="server" class="form-control" placeholder="Answer"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter Answer" ControlToValidate="txtAnswer" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Status</label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSubmit" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
