<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="menudetail.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.pages.menudetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Menu Edit</h1>
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
                    <a href="/administration/pages/menus.aspx?redirectUrl=articles-administrator-home&pageId=1234HJHJKJ*7987979">Menus</a>
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
                            <i class="fa fa-th-list"></i>Update Menu</h3>
                        <asp:HiddenField ID="hdnPageId" runat="server" />
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
                            &nbsp;&nbsp;|&nbsp;&nbsp;
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="admin" OnClick="btnDelete_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
