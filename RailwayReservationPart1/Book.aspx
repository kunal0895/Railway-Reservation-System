<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="RailwayReservationPart1.Book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label4" runat="server" Text="Train Number: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox12" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Text="Train Name: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox13" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Boarding Station: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox14" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label7" runat="server" Text="Destination Station: "></asp:Label>
    <asp:TextBox ID="TextBox15" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Text="Departure Time: "></asp:Label>
&nbsp;
    <asp:TextBox ID="TextBox16" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server" Text="Arrival Time: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox17" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label10" runat="server" Text="Date: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox18" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label11" runat="server" Text="Train Class: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox19" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Number of Passengers:"></asp:Label>
&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="96px">
        <asp:ListItem Selected="True">-----</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
        
    <br />
    <asp:Label ID="Label3" runat="server" Text="Enter Passenger Details (Name according to the ID card):"></asp:Label>
    <br />
        
    <br />
    <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderColor="#000000" BorderWidth="1px" GridLines="Both" CellPadding="8" style="text-align: left" Width="585px">
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableHeaderCell>Sr. No.</asp:TableHeaderCell>
            <asp:TableHeaderCell>Passenger Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Age</asp:TableHeaderCell>
            <asp:TableHeaderCell>Gender</asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server" Visible="False">
            <asp:TableCell>1. </asp:TableCell>
            <asp:TableCell><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1" ID="RequiredFieldValidator7" ErrorMessage="*" ForeColor="Red"/>
            </asp:TableCell><asp:TableCell><asp:TextBox ID="TextBox2" runat="server" TextMode="Number"></asp:TextBox>
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox2" ID="RequiredFieldValidator8" ErrorMessage="*" ForeColor="Red"/>
            </asp:TableCell><asp:TableCell><asp:DropDownList ID="DropDownList2" runat="server">
                           <asp:ListItem Selected="True">Male</asp:ListItem>
                           <asp:ListItem>Female</asp:ListItem>
                           </asp:DropDownList>
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow3" runat="server" Visible="False">
            <asp:TableCell>2. </asp:TableCell><asp:TableCell><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox4" ID="RequiredFieldValidator1" ErrorMessage="*" ForeColor="Red"/>
            </asp:TableCell><asp:TableCell><asp:TextBox ID="TextBox5" runat="server" TextMode="Number"></asp:TextBox>
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox5" ID="RequiredFieldValidator2" ErrorMessage="*" ForeColor="Red"/>
            </asp:TableCell><asp:TableCell><asp:DropDownList ID="DropDownList3" runat="server">
                           <asp:ListItem Selected="True">Male</asp:ListItem>
                           <asp:ListItem>Female</asp:ListItem>
                           </asp:DropDownList>
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow4" runat="server" Visible="False">
            <asp:TableCell>3. </asp:TableCell><asp:TableCell><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox7" ID="RequiredFieldValidator3" ErrorMessage="*" ForeColor="Red"/>
            </asp:TableCell><asp:TableCell><asp:TextBox ID="TextBox8" runat="server" TextMode="Number"></asp:TextBox>
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox8" ID="RequiredFieldValidator4" ErrorMessage="*" ForeColor="Red"/>
            </asp:TableCell><asp:TableCell><asp:DropDownList ID="DropDownList4" runat="server">
                           <asp:ListItem Selected="True">Male</asp:ListItem>
                           <asp:ListItem>Female</asp:ListItem>
                           </asp:DropDownList>
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow5" runat="server" Visible="False">
            <asp:TableCell>4. </asp:TableCell><asp:TableCell><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox10" ID="RequiredFieldValidator5" ErrorMessage="*" ForeColor="Red"/>
            </asp:TableCell><asp:TableCell><asp:TextBox ID="TextBox11" runat="server" TextMode="Number"></asp:TextBox>
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox11" ID="RequiredFieldValidator6" ErrorMessage="*" ForeColor="Red"/>
            </asp:TableCell><asp:TableCell><asp:DropDownList ID="DropDownList5" runat="server">
                           <asp:ListItem Selected="True">Male</asp:ListItem>
                           <asp:ListItem>Female</asp:ListItem>
                           </asp:DropDownList>
            </asp:TableCell></asp:TableRow></asp:Table><br />
    <br /><asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="False"></asp:Label><br /><br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Book" /><br /><br />

</asp:Content>
