<%@ Page Title="" Language="C#" MasterPageFile="~/adminregular/regulardashboard.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="DDWBlogger.Project.Source.adminregular.account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Account Password</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Account Password</a>
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
                                <label for="txtFirstName" class="control-label col-sm-2">Security Question</label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblSecurityQuestion" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Answer</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAnswer" runat="server" class="form-control" placeholder="Answer"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter Answer" ControlToValidate="txtAnswer" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtPassword" class="control-label col-sm-2">Password</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" placeholder="New Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter New Password" ControlToValidate="txtPassword" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtConfirmPassword" class="control-label col-sm-2">Confirm Password</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="form-control" placeholder="Confirm Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter Confirm Password" ControlToValidate="txtConfirmPassword" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red"
                                        ErrorMessage="Password Does Not Match" ControlToValidate="txtConfirmPassword"
                                        ControlToCompare="txtPassword" ValidationGroup="admin"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
