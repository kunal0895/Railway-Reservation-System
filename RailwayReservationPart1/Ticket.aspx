<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="RailwayReservationPart1.Ticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    PNR&nbsp; Number:&nbsp;
    <asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Time:&nbsp;
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Train Number: "></asp:Label>
&nbsp;&nbsp;<asp:Label ID="Label3" runat="server"></asp:Label>
    &nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Text="Train Name: "></asp:Label>
&nbsp;&nbsp;<asp:Label ID="Label12" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Boarding Station: "></asp:Label>
&nbsp;&nbsp;<asp:Label ID="Label13" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label7" runat="server" Text="Destination Station: "></asp:Label>
    &nbsp;
    <asp:Label ID="Label14" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Text="Departure Time: "></asp:Label>
&nbsp;
    <asp:Label ID="Label15" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server" Text="Arrival Time: "></asp:Label>
&nbsp;&nbsp;<asp:Label ID="Label16" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="Label10" runat="server" Text="Date: "></asp:Label>
&nbsp;&nbsp;<asp:Label ID="Label17" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label11" runat="server" Text="Train Class: "></asp:Label>
&nbsp;&nbsp;<asp:Label ID="Label18" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="Label42" runat="server" Text="Total Amount: "></asp:Label>
    <asp:Label ID="Label43" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderColor="Black" BorderWidth="1px" GridLines="Both" CellPadding="8" Width="1174px">
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableHeaderCell>Sr. No.</asp:TableHeaderCell>
            <asp:TableHeaderCell>Passenger Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Age</asp:TableHeaderCell>
            <asp:TableHeaderCell>Gender</asp:TableHeaderCell>
            <asp:TableHeaderCell>Seat No.</asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server" Visible="False">
            <asp:TableCell>1. </asp:TableCell>
            <asp:TableCell><asp:Label ID="Label19" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label20" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label21" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label32" runat="server" />
</asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow3" runat="server" Visible="False"><asp:TableCell>2. </asp:TableCell><asp:TableCell><asp:Label ID="Label22" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label23" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label24" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label34" runat="server" />
</asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow4" runat="server" Visible="False"><asp:TableCell>3. </asp:TableCell><asp:TableCell><asp:Label ID="Label25" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label26" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label27" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label36" runat="server" />
</asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow5" runat="server" Visible="False"><asp:TableCell>4. </asp:TableCell><asp:TableCell><asp:Label ID="Label28" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label29" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label30" runat="server" />
</asp:TableCell><asp:TableCell><asp:Label ID="Label38" runat="server" />
</asp:TableCell></asp:TableRow></asp:Table><br /><asp:Label ID="Label39" runat="server" ForeColor="Red"></asp:Label><br /><br /><asp:Label ID="Label40" runat="server" ForeColor="Red"></asp:Label><br /><br /><asp:Label ID="Label41" runat="server" ForeColor="Red"></asp:Label><br /><br /></asp:Content>
