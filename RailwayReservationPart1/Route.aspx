<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Route.aspx.cs" Inherits="RailwayReservationPart1.Route_Avail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <span style="color: #000099">Showing ROUTE for Train Number:</span>
    <asp:Label ID="Label3" runat="server" ForeColor="#000099"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" Width="1175px" BorderColor="Black" BorderStyle="Solid">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />

         <Columns>
            <asp:BoundField DataField="Station_Name" HeaderText="Boarding Station" SortExpression="Station_Name" />
            <asp:BoundField DataField="Arrival_Time" HeaderText="Arrival Time" SortExpression="Arrival_Time" />
            <asp:BoundField DataField="Departure_Time" HeaderText="Departure Time" SortExpression="Departure_Time" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Distance" HeaderText="Distance" SortExpression="Distance" />

        </Columns> 
    </asp:GridView>
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back to Search Trains" />
</asp:Content>
