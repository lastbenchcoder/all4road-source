<%@ Page Title="" Language="C#" MasterPageFile="~/account/account.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DDWBlogger.Project.Source.account.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>SIGN IN</h2>
    <asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">
        <button type="button" class="close" data-dismiss="alert">×</button>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </asp:Panel>
    <div class="form-group">
        <div class="email controls">
            <asp:TextBox ID="txtUserId" runat="server" name='uemail' placeholder="Email address" class='form-control'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="Enter Registered EmailId" ControlToValidate="txtUserId" ValidationGroup="login"
                ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="pw controls">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" name="upw" placeholder="Password" class='form-control'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ErrorMessage="Enter Valid Password" ControlToValidate="txtPassword" ValidationGroup="login"
                ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="submit">
        <div class="remember">
            <input type="checkbox" name="remember" class='icheck-me' data-skin="square" data-color="blue" id="remember" />
            <label for="remember">Remember me</label>
        </div>
        <asp:Button ID="btnSignIn" runat="server" Text="Sign me in" class='btn btn-primary' ValidationGroup="login" OnClick="btnSignIn_Click" />
    </div>
    <div class="forget">
        <a href="/account/forgotpassword.aspx?a4rredirectUrl=forget-administrator-home&pageId=1234HJHJKJ*7987979">
            <span>Forgot password?</span>
        </a>
    </div>
</asp:Content>
