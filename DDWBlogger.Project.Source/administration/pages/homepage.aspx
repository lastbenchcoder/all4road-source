<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.pages.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Application & Meta Keys</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Content</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                 <li>
                    <a href="#">Pages & Detail</a>
                </li>
                <li>
                    <a href="#">Home Page Data</a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <div class="row margin-top">
            <div class="col-sm-12">
                <div class="alert alert-info">
                    <h4>Why This?</h4>
                    <p>
                        All these details are very important for the Front End Application.
                        In this section you can enable or disable the front end controls and 
                        options, also you can provide the contact information where customer can reach you.
                    </p>
                </div>
            </div>
        </div>
        <asp:Panel ID="pnlErrorMessage" class="page-header" runat="server" Visible="false" Style="margin-top: 10px">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </asp:Panel>
        <asp:HiddenField ID="hdnAppId" runat="server"></asp:HiddenField>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Basic Detail

                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Application Name</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtTitle" runat="server" placeholder="Title" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Application Title" ControlToValidate="txtTitle" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Meta Key Words</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtSearchKeywords" runat="server" placeholder="Search Keywords" TextMode="multiline" class="form-control" Height="70px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Atleast One Keyword" ControlToValidate="txtSearchKeywords" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Logo</label>
                                <div class="col-sm-10">
                                    <asp:Image ID="imgProduct" runat="server" ClientIDMode="Static" Width="100px" Height="100px" class="form-control" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Image !.." ControlToValidate="imgInp" ForeColor="Red" ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.PNG|.png)$"></asp:RegularExpressionValidator>
                                    <asp:FileUpload ID="imgInp" runat="server" ClientIDMode="Static" class="form-control" Width="30%" />
                                    <label></label>
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
                                <label for="txtFirstName" class="control-label col-sm-2">Meta Description</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDescription" runat="server" placeholder="Description" TextMode="multiline" class="form-control" Height="80px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Application Description" ControlToValidate="txtDescription" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Contact Detail And Other

                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">EmailId</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEmailId" runat="server" placeholder="EmailId" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter EmailId" ControlToValidate="txtEmailId" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Phone</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtPhone" runat="server" placeholder="Phone" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Phone Number" ControlToValidate="txtPhone" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Copyright Mennsage</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtCopyRight" runat="server" class="form-control" placeholder="EX: Rachna Teracotta All Right Reserved"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Social Links

                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Facebook</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtFacebook" runat="server" placeholder="Facebook" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2">Google</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtGoogle" runat="server" placeholder="Google" class="form-control"></asp:TextBox>
                                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2">Twitter</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtTwitter" runat="server" placeholder="Twitter" class="form-control"></asp:TextBox>
                                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2">Pintrest</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtPintrest" runat="server" placeholder="Pintrest" class="form-control"></asp:TextBox>
                                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2">Youtube</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtYoutube" runat="server" placeholder="Youtube" class="form-control"></asp:TextBox>
                                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Hide or Show the Options

                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label></label>
                                <div class="col-lg-10">
                                    <asp:CheckBox ID="chkHomeTopBar" runat="server" Checked="true" />
                                    <span class="custom-checkbox"></span>Header Top Bar
                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <div class="form-group">
                                <label></label>
                                <div class="col-lg-10">
                                    <asp:CheckBox ID="chkDisplay_468_60" runat="server" Checked="true" />
                                    <span class="custom-checkbox"></span>Display Banner 468*60
                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <div class="form-group">
                                <label></label>
                                <div class="col-lg-10">
                                    <asp:CheckBox ID="chkDisplay_250_250" runat="server" Checked="true" />
                                    <span class="custom-checkbox"></span>Display Banner 250*250
                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <div class="form-group">
                                <label></label>
                                <div class="col-lg-10">
                                    <asp:CheckBox ID="chkSlider" runat="server" Checked="true" />
                                    <span class="custom-checkbox"></span>Slider
                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <div class="form-group">
                                <label></label>
                                <div class="col-lg-10">
                                    <asp:CheckBox ID="chkDisplayFeatured" runat="server" Checked="true" />
                                    <span class="custom-checkbox"></span>Display Featured Articles
                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <div class="form-group">
                                <label></label>
                                <div class="col-lg-10">
                                    <asp:CheckBox ID="chkDisplayBest" runat="server" Checked="true" />
                                    <span class="custom-checkbox"></span>Display Best Articles
                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>

                            <div class="form-group">
                                <label>Select Category1 To Display The Articles</label>
                                <div class="col-lg-10">
                                    <asp:DropDownList ID="ddlCatSubCat1" runat="server" class="form-control" Style="width: 250px">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                                        ErrorMessage="Select Sub Category(Category)" ControlToValidate="ddlCatSubCat1" ValidationGroup="login" InitialValue="Select.."></asp:RequiredFieldValidator>
                                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <div class="form-group">
                                <label>Select Category2 To Display The Articles</label>
                                <div class="col-lg-10">
                                    <asp:DropDownList ID="ddlCatSubCat2" runat="server" class="form-control" Style="width: 250px">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red"
                                        ErrorMessage="Select Sub Category(Category)" ControlToValidate="ddlCatSubCat2" ValidationGroup="login" InitialValue="Select.."></asp:RequiredFieldValidator>
                                    <div>&nbsp;</div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10 pull-right">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="login" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
