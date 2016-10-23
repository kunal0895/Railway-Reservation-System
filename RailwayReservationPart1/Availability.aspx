<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Availability.aspx.cs" Inherits="RailwayReservationPart1.Availability" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <span style="color: #000099">Showing AVAILABILITY:
    <br />
    </span>
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" BorderColor="Black" BorderStyle="Solid" AutoGenerateColumns="False" Width="1171px">
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
            <asp:BoundField DataField="Train_ID" HeaderText="Train Number" SortExpression="Train_ID" />
            <asp:BoundField DataField="Train_Name" HeaderText="Train Name" SortExpression="Train_Name" />
            <asp:BoundField DataField="Type" HeaderText="Class" SortExpression="Type" />
            <asp:BoundField DataField="Seats_Available" HeaderText="Seat Availability" SortExpression="Seats_Available" />
        </Columns> 
    </asp:GridView>
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Table ID="Table1" runat="server" BorderColor="Black" ForeColor="#000099" Height="25px" Width="110px">
        <asp:TableRow>
            <asp:TableCell>Fare:</asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back to Search Trains" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Proceed to Booking" Width="195px" />
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
