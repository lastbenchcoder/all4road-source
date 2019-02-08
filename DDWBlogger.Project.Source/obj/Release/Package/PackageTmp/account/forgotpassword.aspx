<%@ Page Title="" Language="C#" MasterPageFile="~/account/account.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="DDWBlogger.Project.Source.account.forgotpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>PASSWORD RESET</h2>
    <asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">
        <button type="button" class="close" data-dismiss="alert">×</button>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </asp:Panel>
    <div class="form-group">
        <div class="email controls">
            <asp:TextBox ID="txtUserId" runat="server" name='uemail' placeholder="Email address" class='form-control'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="Enter Registered EmailId to Reset the Password" ControlToValidate="txtUserId" ValidationGroup="fgpwd"
                ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="submit">
        <asp:Button ID="btnForgotPassword" runat="server" Text="Submit" class='btn btn-primary' ValidationGroup="fgpwd" OnClick="btnForgotPassword_Click" />
    </div>
    <div class="forget">
        <a href="/account/login.aspx?a4rredirectUrl=login-administrator-home&pageId=1234HJHJKJ*7987979">
            <span>I Have Password, Login</span>
        </a>
    </div>
</asp:Content>
