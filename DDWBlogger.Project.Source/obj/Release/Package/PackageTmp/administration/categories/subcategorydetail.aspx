<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="subcategorydetail.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.categories.subcategorydetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <a href="/administration/categories/SubCategory.aspx?redirectUrl=SubCategory-administrator-home&pageId=1234HJHJKJ*7987979">SubCategory</a>
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
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Update SubCategory</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <asp:HiddenField ID="hdnSubCategoryId" runat="server" />
                            <div class="form-group">
                                <label for="textfield" class="control-label col-sm-2">Title</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter SubCategory Title" ControlToValidate="txtTitle" ValidationGroup="SubCategory"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label col-sm-2">Description</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="form-control" placeholder="Description" Style="height: 100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter SubCategory Description" ControlToValidate="txtDescription" ValidationGroup="SubCategory"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="textarea" class="control-label col-sm-2">Category</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" Style="width: 250px">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                                        ErrorMessage="Select Category" ControlToValidate="ddlCategory" ValidationGroup="SubCategory" InitialValue="Select.."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="textarea" class="control-label col-sm-2">Status</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control" Style="width: 250px">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                        ErrorMessage="Select Status" ControlToValidate="ddlStatus" ValidationGroup="SubCategory" InitialValue="Select.."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="SubCategory" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn" ValidationGroup="SubCategory" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
