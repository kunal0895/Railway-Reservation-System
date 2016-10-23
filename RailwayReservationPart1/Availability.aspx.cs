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
    public partial class Availability : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                String type = Session["type"].ToString();
                String distance = Session["distance"].ToString();
                if (type == "Sleeper")
                {                  
                    String train_id = Session["train_id"].ToString();
                    cmd.CommandText = "select * from Seat_Availability where Type=@Type and Train_ID=@Train_ID";
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Train_ID", train_id);

                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                    rdr.Close();
                    int fare = Convert.ToInt32(distance);

                    con.Close();
                    Label1.Visible = true;
                    Label1.Text = fare.ToString();
                    Session["total_fare"] = Label1.Text;
                }
                else if(type=="First AC")
                {
                    String train_id = Session["train_id"].ToString();
                    cmd.CommandText = "select * from Seat_Availability where Type=@Type and Train_ID=@Train_ID";
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Train_ID", train_id);

                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                    rdr.Close();
                    int fare = Convert.ToInt32(distance);

                    con.Close();
                    Label1.Visible = true;
                    Label1.Text = (fare*3).ToString();
                    Session["total_fare"] = Label1.Text;
                }
                else if (type == "Second AC")
                {
                    String train_id = Session["train_id"].ToString();
                    cmd.CommandText = "select * from Seat_Availability where Type=@Type and Train_ID=@Train_ID";
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Train_ID", train_id);

                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                    rdr.Close();
                    int fare = Convert.ToInt32(distance);

                    con.Close();
                    Label1.Visible = true;
                    Label1.Text = (fare * 2).ToString();
                    Session["total_fare"] = Label1.Text;
                }
                else if (type == "Third AC")
                {
                    String train_id = Session["train_id"].ToString();
                    cmd.CommandText = "select * from Seat_Availability where Type=@Type and Train_ID=@Train_ID";
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Train_ID", train_id);

                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                    rdr.Close();
                    int fare = Convert.ToInt32(distance);

                    con.Close();
                    Label1.Visible = true;
                    Label1.Text = (fare * 1.5).ToString();
                    Session["total_fare"] = Label1.Text;
                }

            }

            catch (Exception ex)
            {
                Label2.Text = ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["log_customer"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    String type = Session["type"].ToString();
                    String train_id = Session["train_id"].ToString();
                    cmd.CommandText = "select Seats_available from Seat_Availability where Type=@Type and Train_ID=@Train_ID";
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Train_ID", train_id);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["Seats_available"].ToString() == "0")
                        {
                            Label3.Text = "Sorry!!! No Seats available.";
                        }
                        else
                        {
                            Response.Redirect("Book.aspx");
                        }
                    }
                    con.Close();
                }
                catch
                {

                }
            }
        }
    }
}