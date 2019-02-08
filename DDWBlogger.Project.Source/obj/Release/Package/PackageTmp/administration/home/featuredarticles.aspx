<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" CodeBehind="featuredarticles.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.home.featuredarticles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <%
        List<DDWBlogger.Project.Source.Models.ArticleAndFeatures> ArticleAndFeatures = null;
        using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
        {
            ArticleAndFeatures = context.ArticleAndFeatures.Include("ArticleAndTypes").Include("Article").ToList();
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Featured Articles</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Articles</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Featured Articles</a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <asp:Panel ID="pnlErrorMessage" ClientIDMode="Static" class="page-header" runat="server" Visible="false" Style="margin-top: 10px">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <asp:Label ID="lblMessage" ClientIDMode="Static" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="srchArticle" ForeColor="Red" style="margin-top:15px"/>
            <div class="col-sm-12">
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-edit"></i>Search And Choose Article</h3>
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
                                    <label for="textfield" class="control-label col-sm-2">Feature</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="ddlArticleFeature" runat="server" class='form-control'>
                                            <asp:ListItem>Select..</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                            ErrorMessage="Select Feature" ControlToValidate="ddlArticleFeature" ValidationGroup="feature" InitialValue="Select.."></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-actions pull-right">
                                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Add to Feature" OnClick="btnSave_Click" ValidationGroup="feature" />
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
                            All Featured Articles
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Feature</th>
                                    <th>Article</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th class='hidden-480'>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in ArticleAndFeatures)
                                    { %>
                                <tr>
                                    <td>
                                        <img src="../../<%=item.Article.FeaturedBanner%>" width="50" height="50" /></td>
                                    <td><%=item.ArticleAndTypes.Type %></td>
                                    <td><%=item.Article.Title %></td>
                                    <td class='hidden-1024'><%=item.DateCreated.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.DateUpdated.ToString("D") %></td>
                                    <td class='hidden-480'>
                                        <a href="#" onclick="DeleteFeaturedArticle(<%=item.ArticleAndFeaturesId%>)" style="cursor: pointer"><i class="fa fa-trash"></i></a>
                                    </td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function DeleteFeaturedArticle(featureId) {
            var result = confirm("Are you sure you want to delete?");
            if (result) {
                PageMethods.DeleteFeaturedArticle(featureId, OnSuccess);
            }
        }
        function OnSuccess(response, userContext, methodName) {
            window.location.href = "/administration/home/featuredarticles.aspx?id=2000&redirectUrl=articles-administrator-home&pageId=1234HJHJKJ*7987979";
        }
    </script>
</asp:Content>
