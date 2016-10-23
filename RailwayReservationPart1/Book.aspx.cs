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
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String train_id = Session["train_id"].ToString();
            String type = Session["type"].ToString();
            
            TextBox12.Text = Session["train_id"].ToString();
            TextBox13.Text = Session["train_name"].ToString();
            TextBox14.Text = Session["dep_station"].ToString();
            TextBox15.Text = Session["source_station"].ToString();
            TextBox16.Text = Session["dep_time"].ToString();
            TextBox17.Text = Session["arr_time"].ToString();
            TextBox18.Text = Session["date"].ToString();
            TextBox19.Text = Session["type"].ToString();

            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myconn;
            cmd.CommandText = "select Seats_Available from Seat_Availability where Train_ID=@Train_ID and Type=@Type";
            cmd.Parameters.AddWithValue("Train_ID",train_id);
            cmd.Parameters.AddWithValue("Type", type);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dsPubs = new DataSet();
            try
            {
                myconn.Open();
                adapter.Fill(dsPubs, "Seat_Availability");
                foreach (DataRow row in dsPubs.Tables["Seat_Availability"].Rows)
                {
                    if (row["Seats_Available"].ToString()=="1")
                    {
                        //DropDownList1.Items.Remove();
                        
                        ListItem newItem1 = new ListItem();
                        newItem1.Text = "2";
                        DropDownList1.Items.Remove(newItem1);
                        ListItem newItem2 = new ListItem();
                        newItem2.Text = "3";
                        DropDownList1.Items.Remove(newItem2);
                        ListItem newItem3 = new ListItem();
                        newItem3.Text = "4";
                        DropDownList1.Items.Remove(newItem3);
                        
                    }
                    else if(row["Seats_Available"].ToString() == "2")
                    {
                        ListItem newItem1 = new ListItem();
                        newItem1.Text = "3";
                        DropDownList1.Items.Remove(newItem1);
                        ListItem newItem2 = new ListItem();
                        newItem2.Text = "4";
                        DropDownList1.Items.Remove(newItem2);
                    }
                    else if (row["Seats_Available"].ToString() == "3")
                    {
                        ListItem newItem1 = new ListItem();
                        newItem1.Text = "4";
                        DropDownList1.Items.Remove(newItem1);
                    }
                }
            }
            catch(Exception er)
            {
                Label2.Text = er.Message;
            }
            if (DropDownList1.SelectedItem.Text == "-----")
            {
                TableRow1.Visible = false;
                TableRow2.Visible = false;
                TableRow3.Visible = false;
                TableRow4.Visible = false;
                TableRow5.Visible = false;
                Button1.Visible = false;
                Label3.Visible = false;
            }
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedItem.Text == "-----")
            {
                TableRow1.Visible = false;
                TableRow2.Visible = false;
                TableRow3.Visible = false;
                TableRow4.Visible = false;
                TableRow5.Visible = false;
                Button1.Visible = false;
                Label3.Visible = false;
            }
            else if(DropDownList1.SelectedItem.Text=="1")
            {
                TableRow1.Visible = true;
                TableRow2.Visible = true;
                TableRow3.Visible = false;
                TableRow4.Visible = false;
                TableRow5.Visible = false;
                Button1.Visible = true;
                Label3.Visible = true;
            }
            else if(DropDownList1.SelectedItem.Text == "2")
            {
                TableRow1.Visible = true;
                TableRow2.Visible = true;
                TableRow3.Visible = true;
                TableRow4.Visible = false;
                TableRow5.Visible = false;
                Button1.Visible = true;
                Label3.Visible = true;
            }
            else if (DropDownList1.SelectedItem.Text == "3")
            {
                TableRow1.Visible = true;
                TableRow2.Visible = true;
                TableRow3.Visible = true;
                TableRow4.Visible = true;
                TableRow5.Visible = false;
                Button1.Visible = true;
                Label3.Visible = true;
            }
            else if (DropDownList1.SelectedItem.Text == "4")
            {
                TableRow1.Visible = true;
                TableRow2.Visible = true;
                TableRow3.Visible = true;
                TableRow4.Visible = true;
                TableRow5.Visible = true;
                Button1.Visible = true;
                Label3.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                Session["no_of_passengers"] = DropDownList1.SelectedItem.Text;
                Session["passenger_name1"] = TextBox1.Text;
                Session["passenger_age1"] = TextBox2.Text;
                Session["passenger_gender1"] = DropDownList2.SelectedItem.Text;

                Session["passenger_name2"] = TextBox4.Text;
                Session["passenger_age2"] = TextBox5.Text;
                Session["passenger_gender2"] = DropDownList3.SelectedItem.Text;

                Session["passenger_name3"] = TextBox7.Text;
                Session["passenger_age3"] = TextBox8.Text;
                Session["passenger_gender3"] = DropDownList4.SelectedItem.Text;

                Session["passenger_name4"] = TextBox10.Text;
                Session["passenger_age4"] = TextBox11.Text;
                Session["passenger_gender4"] = DropDownList5.SelectedItem.Text;

                Response.Redirect("FinalMessage.aspx");
            }
        }
    }
}