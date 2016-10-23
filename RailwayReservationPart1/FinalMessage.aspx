<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FinalMessage.aspx.cs" Inherits="RailwayReservationPart1.FinalMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Your ticket is confirmed.</p>
    <p>
        &nbsp;</p>
    <p>
        PNR Number:&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label7" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label8" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="PNRStatus.aspx">View Ticket</asp:HyperLink>
    <br />
    <br />
    <br />
</asp:Content>
