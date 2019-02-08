<%@ Page Title="" Language="C#" MasterPageFile="~/account/account.Master" AutoEventWireup="true" CodeBehind="passwordreset.aspx.cs" Inherits="DDWBlogger.Project.Source.account.passwordreset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>PASSWORD RESET</h2>
    <asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">
        <button type="button" class="close" data-dismiss="alert">×</button>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </asp:Panel>
    <div class="form-group">
        <div class="pw controls">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" name="upw" placeholder="New Password" class='form-control'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ErrorMessage="Enter New Password" ControlToValidate="txtPassword" ValidationGroup="pwdreset"
                ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="pw controls">
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" name="upw" placeholder="Confirm Password" class='form-control'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="Confirm Password" ControlToValidate="txtConfirmPassword" ValidationGroup="pwdreset"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red"
                ErrorMessage="Password Does Not Match" ControlToValidate="txtConfirmPassword"
                ControlToCompare="txtPassword" ValidationGroup="pwdreset"></asp:CompareValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="pw controls">
            <asp:Label ID="lblSecQuestion" runat="server"></asp:Label>
        </div>
    </div>
    <div class="form-group">
        <div class="email controls">
            <asp:TextBox ID="txtAnswer" runat="server" name='answer' placeholder="Answer" class='form-control'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ErrorMessage="Enter Answer" ControlToValidate="txtAnswer" ValidationGroup="pwdreset"
                ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="submit">
        <asp:Button ID="btnForgotPassword" runat="server" Text="Submit" class='btn btn-primary' ValidationGroup="pwdreset" OnClick="btnForgotPassword_Click"/>
    </div>
    <div class="forget">
        <a href="/account/login.aspx?a4rredirectUrl=login-administrator-home&pageId=1234HJHJKJ*7987979">
            <span>I Have Password, Login</span>
        </a>
    </div>
</asp:Content>
