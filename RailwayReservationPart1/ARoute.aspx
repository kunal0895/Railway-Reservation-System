<%@ Page Title="" Language="C#" MasterPageFile="~/Admin2.Master" AutoEventWireup="true" CodeBehind="ARoute.aspx.cs" Inherits="RailwayReservationPart1.ARoute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Train Number:"></asp:Label>
&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Add Station" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete Station" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Update Route" />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Finalize Route" />
    
    <br />
    <br />
    <asp:Label ID="Label10" runat="server"></asp:Label>
    
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Station Name :" Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Text="Time :" Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox4" runat="server" Visible="False"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Update" Visible="False" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label8" runat="server" Text="Value : " Visible="False"></asp:Label>
    <asp:TextBox ID="TextBox7" runat="server" Visible="False" TextMode="Number"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Insert" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label11" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Route:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" AutoGenerateEditButton="True" DataKeyNames="Value" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1175px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Value" HeaderText="Value" SortExpression="Value" ReadOnly="True" />
            <asp:BoundField DataField="Station_Name" HeaderText="Station_Name" SortExpression="Station_Name" />
            <asp:BoundField DataField="Arrival_Time" HeaderText="Arrival_Time" SortExpression="Arrival_Time" />
            <asp:BoundField DataField="Departure_Time" HeaderText="Departure_Time" SortExpression="Departure_Time" />
            <asp:BoundField DataField="Distance" HeaderText="Distance" SortExpression="Distance" />
            <asp:BoundField DataField="Halt" HeaderText="Halt" SortExpression ="Halt" />
            <asp:BoundField DataField="Day" HeaderText="Day" SortExpression="Day" />
        </Columns>
        <EditRowStyle BorderColor="Black" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Value], [Station_Name], [Arrival_Time], [Departure_Time], [Distance], [Halt], [Day] FROM [Train_Route] WHERE ([Train_ID] = @Train_ID)" UpdateCommand="UPDATE Train_Route SET Station_Name=@Station_Name,Arrival_Time=@Arrival_Time,Departure_Time=@Departure_Time,Distance=@Distance WHERE Value=@Value" DeleteCommand="DELETE FROM Train_Route WHERE Value=@Value">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="Train_ID" PropertyName="Text" Type="String" />
        </SelectParameters>
        <UpdateParameters>
                <asp:Parameter Name="Station_Name" Type="String" />
                <asp:Parameter Name="Arrival_Time" Type="String" />
            <asp:Parameter Name="Departure_Time" Type="String" />
            <asp:Parameter Name="Distance" Type="Int32" />
            <asp:Parameter Name="Value" Type="Int32" />
        </UpdateParameters>
        <DeleteParameters>
                <asp:Parameter Name="Value" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <br />
    <br />
</asp:Content>
