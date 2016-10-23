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
    public partial class Ticket : System.Web.UI.Page
    {
        Int32 count;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["pnr_number"].ToString()=="")
            {
                Response.Redirect("Login.aspx");
            }
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
                {
                    con.Open();
                    cmd.CommandText = "select * from Ticket,Boarding_Details,Passenger_Details where PNR_Num=PNR_number and PNR_number=PNR_No and PNR_Num='"+ Session["pnr_number"].ToString() + "'";
                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();
                
                while(rdr.Read())
                {
                    Label1.Text = rdr["PNR_Num"].ToString();
                    Label2.Text = rdr["Time_of_gen"].ToString();
                    Label3.Text = rdr["Train_number"].ToString();
                    Label12.Text = rdr["Train_name"].ToString();
                    Label13.Text = rdr["B_station"].ToString();
                    Label14.Text = rdr["D_station"].ToString();
                    Label15.Text = rdr["D_time"].ToString();
                    Label16.Text = rdr["A_time"].ToString();
                    Label17.Text = rdr["B_date"].ToString();
                    Label18.Text = rdr["Train_class"].ToString();
                    Label43.Text = rdr["Total_fare"].ToString();
                }
                    con.Close();
                }
                catch (Exception edf)
                {
                    Label39.Text = edf.Message;
                }
            try
            {
                con.Open();
                cmd.CommandText = "select count(*) from Passenger_Details where PNR_No='" + Session["pnr_number"].ToString() + "'";
                count = Convert.ToInt32(cmd.ExecuteScalar());
                
                if (count == 1)
                {
                    TableRow1.Visible = true;
                    TableRow2.Visible = true;
                    TableRow3.Visible = false;
                    TableRow4.Visible = false;
                    TableRow5.Visible = false;
                }
                else if(count ==2)
                {
                    TableRow1.Visible = true;
                    TableRow2.Visible = true;
                    TableRow3.Visible = true;
                    TableRow4.Visible = false;
                    TableRow5.Visible = false;
                }
                else if(count == 3)
                {
                    TableRow1.Visible = true;
                    TableRow2.Visible = true;
                    TableRow3.Visible = true;
                    TableRow4.Visible = true;
                    TableRow5.Visible = false;
                }
                else if(count == 4)
                {
                    TableRow1.Visible = true;
                    TableRow2.Visible = true;
                    TableRow3.Visible = true;
                    TableRow4.Visible = true;
                    TableRow5.Visible = true;
                }
                con.Close();
            }
            catch(Exception edf)
            {
                Label40.Text = edf.Message;
            }
            

            try
            {
                cmd.CommandText = "select * from Passenger_Details where PNR_No='" + Session["pnr_number"].ToString() + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dsPubs = new DataSet();
                con.Open();
                adapter.Fill(dsPubs, "Passenger_Details");
                if (count == 1)
                {
                    foreach (DataRow row in dsPubs.Tables["Passenger_Details"].Rows)
                    {
                        Label19.Text = row["P_Name"].ToString();
                        Label20.Text = row["Age"].ToString();
                        Label21.Text = row["Gender"].ToString();
                        Label32.Text = row["Seat_Num"].ToString();
                    }
                }
                else if (count == 2)
                {
                    int count1 = 1;
                    foreach (DataRow row in dsPubs.Tables["Passenger_Details"].Rows)
                    {
                        if (count1 == 1)
                        {
                                Label19.Text = row["P_Name"].ToString();
                                Label20.Text = row["Age"].ToString();
                                Label21.Text = row["Gender"].ToString();
                                Label32.Text = row["Seat_Num"].ToString();
                        }
                        else if (count1 == 2)
                        {
                                Label22.Text = row["P_Name"].ToString();
                                Label23.Text = row["Age"].ToString();
                                Label24.Text = row["Gender"].ToString();
                                Label34.Text = row["Seat_Num"].ToString();
                        }
                        count1++;
                    }
                }
                else if (count == 3)
                {
                    int count1 = 1;
                    foreach (DataRow row in dsPubs.Tables["Passenger_Details"].Rows)
                    {
                        if (count1 == 1)
                        {
                            Label19.Text = row["P_Name"].ToString();
                            Label20.Text = row["Age"].ToString();
                            Label21.Text = row["Gender"].ToString();
                            Label32.Text = row["Seat_Num"].ToString();
                        }
                        else if (count1 == 2)
                        {
                            Label22.Text = row["P_Name"].ToString();
                            Label23.Text = row["Age"].ToString();
                            Label24.Text = row["Gender"].ToString();
                            Label34.Text = row["Seat_Num"].ToString();
                        }
                        else if(count1 ==3)
                        {
                            Label25.Text = row["P_Name"].ToString();
                            Label26.Text = row["Age"].ToString();
                            Label27.Text = row["Gender"].ToString();
                            Label36.Text = row["Seat_Num"].ToString();
                        }
                        count1++;
                    }
                }
                else
                {
                    int count1 = 1;
                    foreach (DataRow row in dsPubs.Tables["Passenger_Details"].Rows)
                    {
                        if (count1 == 1)
                        {
                            Label19.Text = row["P_Name"].ToString();
                            Label20.Text = row["Age"].ToString();
                            Label21.Text = row["Gender"].ToString();
                            Label32.Text = row["Seat_Num"].ToString();
                        }
                        else if (count1 == 2)
                        {
                            Label22.Text = row["P_Name"].ToString();
                            Label23.Text = row["Age"].ToString();
                            Label24.Text = row["Gender"].ToString();
                            Label34.Text = row["Seat_Num"].ToString();
                        }
                        else if (count1 == 3)
                        {
                            Label25.Text = row["P_Name"].ToString();
                            Label26.Text = row["Age"].ToString();
                            Label27.Text = row["Gender"].ToString();
                            Label36.Text = row["Seat_Num"].ToString();
                        }
                        else if(count1 == 4)
                        {
                            Label28.Text = row["P_Name"].ToString();
                            Label29.Text = row["Age"].ToString();
                            Label30.Text = row["Gender"].ToString();
                            Label38.Text = row["Seat_Num"].ToString();
                        }
                        count1++;
                    }
                }
                con.Close();
            }
            catch(Exception edr)
            {
                Label41.Text = edr.Message;
            }            
        }
    }
}