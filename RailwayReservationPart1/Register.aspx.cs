using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace RailwayReservationPart1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["log_customer"] = "";
        }

        protected void CustomValidator1_ServerValidate(object sender,ServerValidateEventArgs args)
        {
            String str = args.Value;
            args.IsValid = false;

            if(str.Length<6||str.Length>25)
            {
                return;
            }

            bool capital = false;
            foreach(char ch in str)
            {
                if(ch >='A' && ch<='Z')
                {
                    capital = true;
                    break;
                }
            }

            if (!capital)
                return;

            bool lower = false;

            foreach(char ch in str)
            {
                if(ch>='a' && ch<='z')
                {
                    lower = true;
                    break;
                }
            }

            if (!lower)
                return;

            bool digit = false;

            foreach(char ch in str)
            {
                if(ch>='0' && ch<='9')
                {
                    digit = true;
                    break;
                }
            }
            if (!digit)
                return;

            args.IsValid = true;
        }
 
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid==true)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into Person(Username,Password,EMail_ID,Mobile_number,Gender)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "','" + TextBox6.Text + "','" + DropDownList1.Text + "')";
                    cmd.CommandText += "insert into Customer(Customer_Uname)values('" + TextBox1.Text + "')";
                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();

                    con.Close();
                    Label2.Text = "Successfully Registered.";
                    TextBox1.Text = "";
                    TextBox4.Text = "";
                    TextBox6.Text = "";

                }
                catch// (Exception edf)
                {
                    Label2.Text = "Username already exist.";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}