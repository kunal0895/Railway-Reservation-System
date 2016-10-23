<%@ Page Title="" Language="C#" MasterPageFile="~/Admin2.Master" AutoEventWireup="true" CodeBehind="ARoute1.aspx.cs" Inherits="RailwayReservationPart1.ARoute1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Train Route:</p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Train Number: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Enter Source Station:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Enter Destination Station:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enter" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:ListBox ID="ListBox1" runat="server" Height="61px" Width="366px"></asp:ListBox>
    </p>
</asp:Content>
