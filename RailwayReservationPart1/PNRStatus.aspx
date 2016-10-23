<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PNRStatus.aspx.cs" Inherits="RailwayReservationPart1.CheckPnr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center">
    &nbsp;</p>
<p style="text-align: center">
    <strong>Passenger Current Status</strong></p>
<p style="text-align: center">
    Enter the PNR for your booking below to get the current status. You will find it on the top left corner of the ticket.</p>
<p style="text-align: center">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</p>
    <p style="text-align: center">
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
</p>
<p style="text-align: center">
    <asp:Button ID="Button1" runat="server" Text="Get Status" OnClick="Button1_Click" />
</p>
    <p style="text-align: center">
        &nbsp;</p>
    <p style="text-align: center">
        &nbsp;</p>
<p style="text-align: center">
    &nbsp;</p>
</asp:Content>
