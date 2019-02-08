<%@ Page Title="" Language="C#" MasterPageFile="~/administration/dashboard.Master" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="ads.aspx.cs" Inherits="DDWBlogger.Project.Source.administration.home.ads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <%
        List<DDWBlogger.Project.Source.Models.Ads> Ads = null;
        using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
        {
            Ads = context.Ads.Include("AddSize").Include("Administrator").ToList();
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Ads</h1>
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
                    <a href="#">Ads</a>
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
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="add" ForeColor="Red" Style="margin-top: 15px" />
            <div class="col-sm-12">
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-edit"></i>Add Advertisement</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-bordered'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Size</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlSize" runat="server" class="form-control" Style="width: 250px">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red"
                                        ErrorMessage="Select Size" ControlToValidate="ddlSize"
                                        ValidationGroup="add" InitialValue="Select.." Display="None"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="textfield" class="control-label col-sm-2">Add Type</label>
                                <div class="col-sm-10">
                                    <div class="input-group">
                                        <asp:RadioButtonList ID="rdoAddType" runat="server" class="form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="rdoAddType_SelectedIndexChanged"
                                            RepeatDirection="Horizontal" Style="cursor: pointer; padding-left: 10px">
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rdoAddType"
                                            ValidationGroup="add" Display="None" ErrorMessage="Select Add Type"></asp:RequiredFieldValidator>
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
                                <div class="form-group">
                                    <label for="txtRedirectUrl" class="control-label col-sm-2">Redirect Url</label>
                                    <div class="col-sm-10">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtRedirectUrl" runat="server" placeholder="..." class='form-control'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                Display="None" ControlToValidate="txtRedirectUrl" ForeColor="Red"
                                                ValidationGroup="add" ErrorMessage="Enter Ads Redirect URL"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnlScript" Visible="false">
                                <div class="form-group">
                                    <label for="txtRedirectUrl" class="control-label col-sm-2">Redirect Url</label>
                                    <div class="col-sm-10">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtScript" runat="server" TextMode="MultiLine" class="form-control" Width="500px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                Display="None" ControlToValidate="txtScript" ForeColor="Red"
                                                ValidationGroup="add" ErrorMessage="Enter Ads Script"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="form-actions pull-right">
                        <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" ValidationGroup="add" />
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
                            All Advertisement
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Type</th>
                                    <th>Size</th>
                                    <th>Banner</th>
                                    <th>RedirectUrl</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th class='hidden-480'>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in Ads)
                                    { %>
                                <tr>
                                    <td><%=item.Type %></td>
                                    <td><%=item.AddSize.Title %></td>
                                    <%if (DDWBlogger.Project.Source.Enums.eAds.Banner.ToString() == item.Type)
                                        { %>
                                    <td>
                                        <img src="../../<%=item.Banner%>" width="50" height="50" /></td>
                                    <%}
                                        else
                                        { %>
                                    <td><code>
                                        <%=Server.HtmlEncode(item.Banner.ToString()) %>
                                    </code></td>
                                    <%} %>
                                    <td><%=item.RedirectUrl %></td>
                                    <td class='hidden-1024'><%=item.DateCreated.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.DateUpdated.ToString("D") %></td>
                                    <td class='hidden-480'><a href="/administration/home/adsmodify.aspx?adsid=<%=item.AdsId %>&redirectUrl=ads-detail-administrator-home&pageId=1234HJHJKJ*7987979"><i class="fa fa-trash"></i></a></td>
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
