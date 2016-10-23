<%@ Page Title="" Language="C#" MasterPageFile="~/Admin2.Master" AutoEventWireup="true" CodeBehind="AHome.aspx.cs" Inherits="RailwayReservationPart1.AHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br style="color: #000000" />
        <span style="color: #000000">YOUR ACCOUNT DETAILS:</span></p>
    <p>
        &nbsp;</p>
    <p style="color: #000000">
        &nbsp;Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" ForeColor="Black" style="color: #000000"></asp:Label>
    </p>
    <p>
        <span style="color: #000000">&nbsp;EMail ID&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </span>
        <asp:Label ID="Label2" runat="server" ForeColor="Black" style="color: #000000"></asp:Label>
    </p>
    <p>
        <span style="color: #000000">&nbsp;Mobile Number:&nbsp;&nbsp;&nbsp;&nbsp;
        </span>
        <asp:Label ID="Label3" runat="server" ForeColor="Black" style="color: #000000"></asp:Label>
    </p>
    <p>
        <span style="color: #000000">&nbsp;Gender&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </span>
        <asp:Label ID="Label4" runat="server" ForeColor="Black" style="color: #000000"></asp:Label>
    </p>
    <p>
        <span style="color: #000000">&nbsp;Work Experience:&nbsp;&nbsp;
        </span>
        <asp:Label ID="Label5" runat="server" ForeColor="Black" style="color: #000000"></asp:Label>
    </p>
    <p>
        <span style="color: #000000">&nbsp;Salary:&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </span>
        <asp:Label ID="Label6" runat="server" ForeColor="Black" style="color: #000000"></asp:Label>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
    </p>
    <p>
        <asp:Label ID="Label7" runat="server" ForeColor="Black"></asp:Label>
    </p>
</asp:Content>
