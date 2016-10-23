<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="RailwayReservationPart1.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        YOUR BOOKING HISTORY:</p>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="PNR_Num" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" Width="1173px" BorderColor="Black">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="PNR_Num" HeaderText="PNR Number" ReadOnly="True" SortExpression="PNR_Num" />
                <asp:BoundField DataField="Train_number" HeaderText="Train Number" SortExpression="Train_number" />
                <asp:BoundField DataField="Train_name" HeaderText="Train Name" SortExpression="Train_name" />
                <asp:BoundField DataField="B_date" HeaderText="Date" SortExpression="B_date" />
                <asp:BoundField DataField="B_station" HeaderText="Boarding station" SortExpression="B_station" />
                <asp:BoundField DataField="D_time" HeaderText="Departure Time" SortExpression="D_time" />
                <asp:BoundField DataField="D_station" HeaderText="Destination Station" SortExpression="D_station" />
                <asp:BoundField DataField="A_time" HeaderText="Arrival Time" SortExpression="A_time" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Ticket.PNR_Num, Boarding_Details.Train_number, Boarding_Details.Train_name, Boarding_Details.B_date, Boarding_Details.B_station, Boarding_Details.D_time, Boarding_Details.D_station, Boarding_Details.A_time FROM Ticket INNER JOIN Boarding_Details ON Ticket.PNR_Num = Boarding_Details.PNR_number WHERE (Ticket.Cust_ID = @Cust_ID)">
            <SelectParameters>
                <asp:SessionParameter Name="Cust_ID" SessionField="log_customer" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cancel Ticket" />
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Details" />
&nbsp;
        <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
