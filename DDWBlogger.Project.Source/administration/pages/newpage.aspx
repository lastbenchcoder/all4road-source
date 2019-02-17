<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="newpage.aspx.cs" 
    Inherits="DDWBlogger.Project.Source.administration.pages.newpage" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>New Article</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/pages/allpages.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">All Pages</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Create New Page</a>
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
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Pages</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="selSubCat" class="control-label col-sm-2">Page Title</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtOfferTitle" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ErrorMessage="Enter Title" ControlToValidate="txtOfferTitle" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtTitle" class="control-label col-sm-2">Page Content</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtSmallDescription" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtSmallDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSubmit" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="article" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtSmallDescription.ClientID %>', { filebrowserImageUploadUrl: '../../Upload.ashx' });
        });
    </script>
</asp:Content>
