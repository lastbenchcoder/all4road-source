<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="slider.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.home.slider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <%
        List<DDWBlogger.Project.Source.Models.Slider> Slider = null;
        using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
        {
            Slider = context.Slider.Include("Article").Include("Administrator").ToList();
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Home Slider</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Content</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Home Slider</a>
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
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="srchArticle" ForeColor="Red" Style="margin-top: 15px" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="slider" ForeColor="Red" Style="margin-top: 15px" />
            <div class="col-sm-12">
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-edit"></i>Add Home Slider</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-bordered'>
                            <div class="form-group">
                                <label for="textfield" class="control-label col-sm-2">Enter Article Id</label>
                                <div class="col-sm-10">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtArticleId" TextMode="Number" runat="server" placeholder="..." class='form-control'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtArticleId" ForeColor="Red" ValidationGroup="srchArticle" ErrorMessage="Enter Article Id"></asp:RequiredFieldValidator>
                                        <div class="input-group-btn">
                                            <asp:Button ID="btnSearchArticle" runat="server" Text="Search" class="btn" ValidationGroup="srchArticle" OnClick="btnSearchArticle_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="pnlArticleSearch" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="textfield" class="control-label col-sm-2">Id</label>
                                    <div class="col-sm-10">
                                        <asp:Label ID="lblArticleId" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="textfield" class="control-label col-sm-2">Title</label>
                                    <div class="col-sm-10">
                                        <asp:Label ID="lblArticle" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="textfield" class="control-label col-sm-2"></label>
                                    <div class="col-sm-10">
                                        <div class="input-group">
                                            <asp:Image ID="imgArticle" runat="server" Width="100px" Height="100px" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="textfield" class="control-label col-sm-2">Select Banner Type</label>
                                    <div class="col-sm-10">
                                        <div class="input-group">
                                            <asp:RadioButtonList ID="rdoBannerType" runat="server" class="form-control"
                                                AutoPostBack="true" OnSelectedIndexChanged="rdoBannerType_SelectedIndexChanged"
                                                RepeatDirection="Horizontal" Style="cursor: pointer;  margin-right: 15px;">
                                                <asp:ListItem Value="1" style="margin-right: 15px;">Use Article Image</asp:ListItem>
                                                <asp:ListItem Value="2" style="margin-right: 15px;">Select New Image</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdoBannerType"
                                                ValidationGroup="slider" Display="None" ErrorMessage="Select Banner Type"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <asp:Panel ID="pnlImage" runat="server" Visible="false">
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
                                </asp:Panel>
                                <div class="form-actions pull-right">
                                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" ValidationGroup="slider" />
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            All Home Slider
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                     <th>ArticleId</th>
                                    <th>Article</th>
                                    <th>Administrator</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th class='hidden-480'>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in Slider)
                                    { %>
                                <tr>
                                    <td>
                                        <img src="../../<%=item.Banner%>" width="50" height="50" /></td>
                                     <td><%=item.Article.ArticleId %></td>
                                    <td><%=item.Article.Title %></td>
                                    <td><%=item.Administrator.FirstName %>&nbsp;&nbsp;<%=item.Administrator.LastName %></td>
                                    <td class='hidden-1024'><%=item.DateCreated.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.DateUpdated.ToString("D") %></td>
                                    <td class='hidden-480'><a href="/administration/home/slidermodify.aspx?sliderId=<%=item.SliderId %>&redirectUrl=category-detail-administrator-home&pageId=1234HJHJKJ*7987979"><i class="fa fa-trash"></i></a></td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
