<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RailwayReservationPart1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <p style="text-align: center">
        &nbsp;</p>
        <p style="text-align: center">
        LOGIN TO AN EXISTING ACCOUNT:</p>
    <p style="text-align: center">
        &nbsp;</p>
    <p style="text-align: center">
        Username:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p style="text-align: center">
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox2" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p style="text-align: center">
        <asp:Label ID="Label2" runat="server" ForeColor="#FF3300"></asp:Label>
        </p>
<p style="text-align: center">
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" style="text-align: center" />
        </p>
        <p style="text-align: center">
            &nbsp;</p>
<p style="text-align: center">
        Not A User:
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Register" CausesValidation="False" />
        &nbsp;</p>
        
</asp:Content>
