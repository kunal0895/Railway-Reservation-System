<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="RailwayReservationPart1.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    SEARCH TRAIN...<br />
    <br />
    <br />
    Enter Source Station:
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Enter Destination Station:
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    Enter Journey Date:&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server" TextMode="Date"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label2" runat="server" ForeColor="#FF3300"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search Trains" />
    <br />
    <br />
    <asp:Label ID="Label8" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" OnDataBound="GridView1_DataBound" DataKeyNames="Train_ID" ForeColor="#333333" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True" AutoGenerateColumns="False" Width="1176px" BorderColor="Black" BorderStyle="Solid">
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
            <asp:BoundField DataField="Station_Name" HeaderText="Boarding Station" SortExpression="Station_Name" />
            <asp:BoundField DataField="Departure_Time" HeaderText="Departure Time" SortExpression="Departure_Time" />
            <asp:BoundField DataField="Station_Name1" HeaderText="Destination Station" SortExpression="Station_Name1" />
            <asp:BoundField DataField="Arrival_Time" HeaderText="Arrival Time" SortExpression="Arrival_Time" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Distance" HeaderText="Distance" SortExpression="Distance" />

        </Columns> 
    </asp:GridView>
    <br />
    <asp:Label ID="Label3" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Visible="False"></asp:Label>
    <br />
    <br />
    &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Get Route" Height="25px" Width="139px" Visible="False" />
    &nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Availability and Fare" Height="25px" Width="142px" Visible="False" />
    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" runat="server" Text="Select class :" Visible="False"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" Visible="False" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="0">-----</asp:ListItem>
        <asp:ListItem Value="1">Sleeper</asp:ListItem>
        <asp:ListItem Value="2">First AC</asp:ListItem>
        <asp:ListItem Value="3">Second AC</asp:ListItem>
        <asp:ListItem Value="4">Third AC</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <br />
</asp:Content>
