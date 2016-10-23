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
    public partial class FinalMessage : System.Web.UI.Page
    {
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        int sa;
        int la;
        protected void Page_Load(object sender, EventArgs e)
        {
            int rn = RandomNumber(00000000,99999999);
            Label1.Text = rn.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                con.Open();
                cmd.CommandText = "insert into Ticket values('"+ Label1.Text + "','"+ Session["log_customer"].ToString() + "','"+System.DateTime.Now+"','"+Session["total_fare1"].ToString()+"')";
                SqlDataReader rdr = cmd.ExecuteReader();
                con.Close();
                
            }
            catch (Exception edf)
            {
                Label2.Text = edf.Message;
            }
            
            try
            {
                con.Open();
                cmd.CommandText = "select MAX(Seat_Num) as SN from Passenger_Details,Boarding_Details where PNR_No = PNR_number and Train_number = '"+ Session["train_id"].ToString() + "' and Train_class = '"+ Session["type"].ToString() + "'";
                //SqlDataReader rdr = cmd.ExecuteReader();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dsPubs = new DataSet();
                adapter.Fill(dsPubs, "Mix");
                foreach (DataRow row in dsPubs.Tables["Mix"].Rows)
                {
                    if (row["SN"] != DBNull.Value)
                    {
                        la = Convert.ToInt32(row["SN"].ToString());
                        la++;
                    }
                    else
                    {
                        la = 1;
                    }
                }
                    /*while (rdr.Read())
                {
                    
                }*/
                con.Close();
            }
            catch(Exception edr)
            {
                Label3.Text = edr.Message;
            }
            try
            {

                //int la = 1;
                //String comp_no = "S1";
                int nop = Convert.ToInt32(Session["no_of_passengers"]);
                if (nop==1)
                {
                    con.Open();
                    cmd.CommandText = "insert into Passenger_Details values('" + Label1.Text + "','" + la + "','" + Session["passenger_age1"].ToString() + "','" + Session["passenger_gender1"].ToString() + "','" + Session["passenger_name1"].ToString() + "')";
                    SqlDataReader r = cmd.ExecuteReader();
                    
                    la++;
                }
                else if (nop == 2)
                {
                    con.Open();
                    cmd.CommandText = "insert into Passenger_Details values('" + Label1.Text + "','" + la + "','" + Session["passenger_age1"].ToString() + "','" + Session["passenger_gender1"].ToString() + "','" + Session["passenger_name1"].ToString() + "')";

                    la++;
                    cmd.CommandText += "insert into Passenger_Details values('" + Label1.Text + "','" + la + "','" + Session["passenger_age2"].ToString() + "','" + Session["passenger_gender2"].ToString() + "','" + Session["passenger_name2"].ToString() + "')";

                    la++;
                    SqlDataReader r = cmd.ExecuteReader();
                }
                else if (nop == 3)
                {
                    con.Open();
                    cmd.CommandText = "insert into Passenger_Details values('" + Label1.Text + "','" + la + "','" + Session["passenger_age1"].ToString() + "','" + Session["passenger_gender1"].ToString() + "','" + Session["passenger_name1"].ToString() + "')";

                    la++;
                    cmd.CommandText += "insert into Passenger_Details values('" + Label1.Text + "','" + la + "','" + Session["passenger_age2"].ToString() + "','" + Session["passenger_gender2"].ToString() + "','" + Session["passenger_name2"].ToString() + "')";

                    la++;
                    cmd.CommandText += "insert into Passenger_Details values('" + Label1.Text + "','" + la + "','" + Session["passenger_age3"].ToString() + "','" + Session["passenger_gender3"].ToString() + "','" + Session["passenger_name3"].ToString() + "')";

                    la++;
                    SqlDataReader r = cmd.ExecuteReader();
                }
                else
                {
                    con.Open();
                    cmd.CommandText = "insert into Passenger_Details values('" + Label1.Text + "','" + la + "','" + Session["passenger_age1"].ToString() + "','" + Session["passenger_gender1"].ToString() + "','" + Session["passenger_name1"].ToString() + "')";

                    la++;
                    cmd.CommandText += "insert into Passenger_Details values('" + Label1.Text + "','" + la + "','" + Session["passenger_age2"].ToString() + "','" + Session["passenger_gender2"].ToString() + "','" + Session["passenger_name2"].ToString() + "')";

                    la++;
                    cmd.CommandText += "insert into Passenger_Details values('" + Label1.Text + "','" + la + "','" + Session["passenger_age3"].ToString() + "','" + Session["passenger_gender3"].ToString() + "','" + Session["passenger_name3"].ToString() + "')";

                    la++;
                    cmd.CommandText += "insert into Passenger_Details values('" + Label1.Text + "','" + la + "','" + Session["passenger_age4"].ToString() + "','" + Session["passenger_gender4"].ToString() + "','" + Session["passenger_name4"].ToString() + "')";

                    la++;
                    SqlDataReader r = cmd.ExecuteReader();
                }
                con.Close();
            }
            catch (Exception edf)
            {
                Label4.Text = edf.Message;
            }
            try
            {
                con.Open();
                cmd.CommandText = "insert into Boarding_Details values('" + Label1.Text + "','" + Session["train_id"].ToString() + "','" + Session["train_name"].ToString() + "','"+ Session["date"].ToString() + "','"+ Session["dep_time"].ToString() + "','"+ Session["dep_station"].ToString() + "','"+ Session["arr_time"].ToString() + "','"+ Session["source_station"].ToString() + "','"+ Session["type"].ToString() + "')";
                SqlDataReader rdr = cmd.ExecuteReader();
                con.Close();

            }
            catch (Exception edf)
            {
                Label5.Text = edf.Message;
            }
            try
            {
                con.Open();
                cmd.CommandText = "select Seats_Available from Seat_Availability where Train_ID='" + Session["train_id"].ToString() + "' and Type = '" + Session["type"].ToString() + "'";
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    sa = Convert.ToInt32(rdr["Seats_Available"].ToString());
                }
                con.Close();

            }
            catch (Exception edf)
            {
                Label6.Text = edf.Message;
            }
            try
            {
                con.Open();
                int nop = Convert.ToInt32(Session["no_of_passengers"]);
                int diff = sa - nop;
                cmd.CommandText = "update Seat_Availability set Seats_Available='"+ diff.ToString() + "' where Train_ID='"+Session["train_id"].ToString()+"' and Type = '"+Session["type"].ToString()+"'";
                SqlDataReader rdr = cmd.ExecuteReader();
                con.Close();

            }
            catch (Exception edf)
            {
                Label7.Text = edf.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ticket.aspx");
        }
    }
}