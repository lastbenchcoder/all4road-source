<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="newarticle.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.article.newarticle" %>

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
                    <a href="#">Create New Article</a>
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
                            <i class="fa fa-th-list"></i>Article</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="selSubCat" class="control-label col-sm-2">Sub Category(Category)</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlCatSubCat" runat="server" class="form-control" Style="width: 250px">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                        ErrorMessage="Select Sub Category(Category)" ControlToValidate="ddlCatSubCat" ValidationGroup="article" InitialValue="Select.."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtTitle" class="control-label col-sm-2">Title</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter Title" ControlToValidate="txtTitle" ValidationGroup="article"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">Description</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control" placeholder="Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                        ErrorMessage="Enter Description" ControlToValidate="txtDescription" ValidationGroup="article"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="textfield" class="control-label col-sm-2"></label>
                                <div class="col-sm-10">
                                    <asp:Image ID="imgProduct" runat="server" ClientIDMode="Static" Width="100px" Height="100px" class="form-control" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Image !.." ValidationGroup="article" ControlToValidate="imgInp" ForeColor="Red" ValidationExpression="^.+(.jpeg|.jpg|.JPG|.gif|.GIF|.PNG|.png)$"></asp:RegularExpressionValidator>
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
            CKEDITOR.replace('<%=txtDescription.ClientID %>', { filebrowserImageUploadUrl: '../../Upload.ashx' });
        });
    </script>
</asp:Content>
