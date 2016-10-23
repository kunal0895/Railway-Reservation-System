<%@ Page Title="" Language="C#" MasterPageFile="~/Admin2.Master" AutoEventWireup="true" CodeBehind="AFrequency.aspx.cs" Inherits="RailwayReservationPart1.AFrequency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="color: #000099">
        &nbsp;</p>
    <p>
        <span style="color: #000099">
        <asp:Label ID="Label1" runat="server" Text="Train Number: "></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Train Name: "></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server"></asp:Label>
    </p>
    <p>
        Select a value to insert:</span></p>
    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="89px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Selected="True">-----</asp:ListItem>
        <asp:ListItem>Sun</asp:ListItem>
        <asp:ListItem>Mon</asp:ListItem>
        <asp:ListItem>Tue</asp:ListItem>
        <asp:ListItem>Wed</asp:ListItem>
        <asp:ListItem>Thu</asp:ListItem>
        <asp:ListItem>Fri</asp:ListItem>
        <asp:ListItem>Sat</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add" />
  &nbsp;
    <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="Label"></asp:Label>
  <br />
    <br />
    <span style="color: #000099">The Train runs on the following days:</span><br/>
    
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="Black" BorderStyle="Solid" CellPadding="4" ForeColor="#333333" AutoGenerateSelectButton="True" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BorderColor="Black" Width="165px">
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
            <asp:BoundField DataField="Day" HeaderText="Day" SortExpression="Day" />
          
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Day] FROM [Train_Frequency] WHERE ([Train_Num] = @Train_Num)">
            <SelectParameters>
                <asp:ControlParameter ControlID="Label2" Name="Train_Num" PropertyName="Text" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Remove" />
&nbsp;
        <asp:Label ID="Label8" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label>
    </p>
</asp:Content>
