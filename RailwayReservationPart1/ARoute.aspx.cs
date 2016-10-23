using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RailwayReservationPart1
{
    public partial class ARoute : System.Web.UI.Page
    {
        int dist, s_id, d_id, udist, udist2, fdist, day = 1, ffdist, thalt3, value1, thalt4, sdist, lastval;
        static int tdist, dist1, dist2, thalt1, thalt2, udist1, value, newdist, predist, fidist, neid, prid, count = 0, prehalt;
        String utime1, utime2,utime5,utime6,utime7,utime8,sname, ftime,udtime, prefdist;
        static string utime3,utime4,newstat,prestat = null,thalt;
        static double sutime1, sutime3, sutime4, sutime5, sutime6, sutime8, sutime9, sutime10, dutime8, dutime9, dutime10, dtime1, prefmin;
        double atime, dtime, utime, sutime7;
        TimeSpan aftime, dutime;
        Boolean exists;
        static Boolean source,esource,empty,inserted=false;

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = Session["train_num"].ToString();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";

            try
            {
                cn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = cn;
                comm.CommandText = "select MAX(Value) from Train_Route";

                SqlDataReader rr;
                rr = comm.ExecuteReader();
                while (rr.Read())
                {
                    lastval = Convert.ToInt32(rr["Value"].ToString());
                }

                Label11.Text = lastval.ToString();

                rr.Close();
            }

            catch(Exception exc)
            {
                Label11.Text = exc.Message;
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sname = GridView1.SelectedRow.Cells[2].Text.ToString();
            value = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text.ToString());
            udist1 = Convert.ToInt32(GridView1.SelectedRow.Cells[5].Text.ToString());
            //arrival time
            utime1 = (GridView1.SelectedRow.Cells[3].Text.ToString());
            if (udist1 == 0)
            {
                sutime1 = 0;
            }
            else
            {
                sutime1 = TimeSpan.Parse(utime1).TotalMinutes;
            }
            //destination time
            //utime2 = (GridView1.SelectedRow.Cells[4].Text.ToString());
            //sutime2 = TimeSpan.Parse(utime2).TotalMinutes;
            //Label9.Text = udist1.ToString();

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            if(GridView1.Rows.Count == 0)
            {
                Label10.Text = "Enter Source Station : ";
                Label3.Visible = true;
                Label5.Visible = true;
                Label8.Visible = true;
                TextBox2.Visible = true;
                TextBox4.Visible = true;
                TextBox7.Visible = true;
                Button2.Visible = true;
            }
        
            else

            {
                Label10.Text = "Enter Station : ";
                Label3.Visible = true;
                Label8.Visible = true;
                TextBox2.Visible = true;
                TextBox7.Visible = true;
                Button2.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {

                int tnum = Convert.ToInt32(TextBox1.Text);

                if (TextBox2.Text == "")
                {
                    Label9.Text = "Please insert Station_Name";
                }

                else if (TextBox4.Text == "")
                {
                    Label9.Text = "Please insert Departure Time";
                }

                else if (TextBox7.Text == "")
                {
                    Label9.Text = "Enter value";
                }

                else
                {

                    SqlConnection myconn = new SqlConnection();
                    myconn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = myconn;
                    myconn.Open();
                    cmd.CommandText = "select count(*) from Station_Table where Station_Name=@Station_Name";
                    cmd.Parameters.AddWithValue("@Station_Name", TextBox2.Text);
                    Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        myconn.Close();

                        try
                        {

                            SqlConnection myconn2 = new SqlConnection();
                            myconn2.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                            myconn2.Open();

                            SqlCommand cmd2 = new SqlCommand();
                            cmd2.Connection = myconn2;

                            cmd2.CommandText = "update Train_Route SET Value = Value + 1 WHERE Value >= @Value";
                            cmd2.Parameters.AddWithValue("@Value", TextBox7.Text);

                            SqlDataReader rdr2;
                            rdr2 = cmd2.ExecuteReader();
                            rdr2.Close();

                            myconn2.Close();

                            SqlConnection myconn3 = new SqlConnection();
                            myconn3.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                            myconn3.Open();

                            SqlCommand cmd3 = new SqlCommand();
                            cmd3.Connection = myconn3;

                            cmd3.CommandText = "INSERT into Train_Route values (@Train_ID,@Station_Name,@Arrival_Time,@Departure_Time,@Value,@Distance,@Halt,@Day)";
                            cmd3.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                            cmd3.Parameters.AddWithValue("@Station_Name", TextBox2.Text);
                            cmd3.Parameters.AddWithValue("@Arrival_Time", DBNull.Value);
                            cmd3.Parameters.AddWithValue("@Departure_Time", TextBox4.Text);
                            cmd3.Parameters.AddWithValue("@Distance", '0');
                            cmd3.Parameters.AddWithValue("@Value", TextBox7.Text);
                            cmd3.Parameters.AddWithValue("@Halt", DBNull.Value);
                            cmd3.Parameters.AddWithValue("@Day", day);

                            SqlDataReader rdr3;
                            rdr3 = cmd3.ExecuteReader();

                            rdr3.Close();
                            myconn3.Close();
                            Response.Redirect("ARoute.aspx");
                            Label9.Text = "Station successfully inserted.";

                        }

                        catch (Exception ex)
                        {
                            Label9.Text = ex.Message;
                        }
                    }

                    else
                    {
                        Label9.Text = "Station does not exist in Station Table. ";
                    }
                }
            }

            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                conn.Open();

                SqlCommand cmnd = new SqlCommand();
                cmnd.Connection = conn;
                cmnd.CommandText = "select Distance from Train_Route where Train_ID = @Train_ID";
                cmnd.Parameters.AddWithValue("@Train_ID", TextBox1.Text);

                SqlDataReader rd;
                rd = cmnd.ExecuteReader();
                while (rd.Read())
                {
                    tdist = Convert.ToInt32(rd["Distance"].ToString());
                    if (tdist == 0)
                    {
                        source = true;
                        break;
                    }
                    else
                    {
                        source = false;
                    }
                }

                if(source == true)
                {
                    if (TextBox2.Text == "")
                    {
                        Label9.Text = "Please insert Station_Name";
                    }
                    else if (TextBox7.Text == "")
                    {
                        Label9.Text = "Enter value";
                    }
                    else
                    {
                        SqlConnection myconn4 = new SqlConnection();
                        myconn4.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";

                        try
                        {
                            myconn4.Open();
                            SqlCommand cmd4 = new SqlCommand();
                            cmd4.Connection = myconn4;
                            cmd4.CommandText = "select count(*) from Station_Table where Station_Name=@Station_Name";
                            cmd4.Parameters.AddWithValue("@Station_Name", TextBox2.Text);
                            Int32 count = Convert.ToInt32(cmd4.ExecuteScalar());
                            if (count == 1)
                            {
                                //myconn4.Close();

                                SqlConnection myconn5 = new SqlConnection();
                                myconn5.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                                myconn5.Open();
                                SqlCommand cmd5 = new SqlCommand();
                                cmd5.Connection = myconn5;
                                cmd5.CommandText = "Select Station_Name from Train_Route where Train_ID=@Train_ID";
                                cmd5.Parameters.AddWithValue(@"Train_ID", TextBox1.Text);
                                SqlDataReader rdr5;
                                rdr5 = cmd5.ExecuteReader();

                                while (rdr5.Read())
                                {
                                    String str = rdr5["Station_Name"].ToString();
                                    if (str == TextBox2.Text)
                                    {
                                        Label9.Text = "Station exists.";
                                        exists = true;
                                        break;
                                    }
                                    else
                                    {
                                        exists = false;
                                    }

                                }

                                rdr5.Close();
                                //Label9.Text = exists.ToString();

                                if (exists == false)
                                {
                                    try
                                    {
                                        SqlConnection myconn6 = new SqlConnection();
                                        myconn6.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                                        myconn6.Open();

                                        SqlCommand cmd6 = new SqlCommand();
                                        cmd6.Connection = myconn6;

                                        cmd6.CommandText = "select Station_ID,Distance,Halt from Station_Table where Station_Name=@Station_Name";
                                        cmd6.Parameters.AddWithValue("@Station_Name", TextBox2.Text);

                                        SqlDataReader rdr6;
                                        rdr6 = cmd6.ExecuteReader();
                                        while (rdr6.Read())
                                        {
                                            s_id = Convert.ToInt32(rdr6["Station_ID"].ToString());
                                            dist1 = Convert.ToInt32(rdr6["Distance"].ToString());
                                            if (rdr6["Halt"] == DBNull.Value)
                                            {
                                                empty = true;
                                            }

                                            else
                                            {
                                                empty = false;
                                                thalt = (rdr6["Halt"].ToString());

                                            }
                                            //atime1 = Convert.ToDouble(rdr["Arrival_Time"].ToString());
                                            //dtime1 = Convert.ToDouble(rdr["Departure_Time"].ToString());
                                        }

                                        rdr6.Close();

                                        //Label9.Text = thalt.ToString();

                                        SqlCommand cmd7 = new SqlCommand();
                                        cmd7.Connection = myconn6;

                                        cmd7.CommandText = "select Departure_Time from Train_Route where Train_ID=@Train_ID and Distance = 0";
                                        cmd7.Parameters.AddWithValue("@Train_ID", TextBox1.Text);

                                        SqlDataReader rdr7;
                                        rdr7 = cmd7.ExecuteReader();
                                        while (rdr7.Read())
                                        {
                                            ftime = rdr7["Departure_Time"].ToString();
                                            dtime1 = TimeSpan.Parse(ftime).TotalMinutes;
                                        }

                                        rdr7.Close();

                                        SqlCommand cmd8 = new SqlCommand();
                                        cmd8.Connection = myconn6;

                                        cmd8.CommandText = "select Station_ID,Distance from Station_Table where Station_Name in (select Station_Name from Train_Route where Train_ID = @Train_ID and Distance = 0)";
                                        cmd8.Parameters.AddWithValue("@Train_ID", TextBox1.Text);

                                        SqlDataReader rdr8;
                                        rdr8 = cmd8.ExecuteReader();
                                        while (rdr8.Read())
                                        {
                                            d_id = Convert.ToInt32(rdr8["Station_ID"].ToString());
                                            dist2 = Convert.ToInt32(rdr8["Distance"].ToString());
                                            //utime2 = (rdr7["Departure_Time"].ToString());
                                            //sutime2 = TimeSpan.Parse(utime2).TotalMinutes;
                                            //atime2 = Convert.ToDouble(rdr7["Arrival_Time"].ToString());
                                            //dtime2 = Convert.ToDouble(rdr7["Departure_Time"].ToString());
                                        }

                                        if (d_id < s_id)
                                        {
                                            dist = dist1 - dist2;
                                            atime = Convert.ToDouble(dist * 0.75) + dtime1;
                                            Label9.Text = udist1.ToString();
                                            if (atime > 1440)
                                            {
                                                day++;
                                                atime = atime - 1440;
                                            }
                                            dtime = atime + Convert.ToDouble(thalt);
                                            if (dtime > 1440)
                                            {
                                                day++;
                                                dtime = dtime - 1440;
                                            }
                                        }

                                        else if (d_id > s_id)
                                        {
                                            dist = dist2 - dist1;
                                            atime = Convert.ToDouble(dist * 0.75) + dtime1;
                                            if (atime > 1440)
                                            {
                                                day++;
                                                atime = atime - 1440;
                                            }

                                            dtime = atime + Convert.ToDouble(thalt);
                                            if (dtime > 1440)
                                            {
                                                day++;
                                                dtime = dtime - 1440;
                                            }
                                        }
                                        rdr8.Close();

                                        SqlConnection myconn7 = new SqlConnection();
                                        myconn7.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                                        myconn7.Open();

                                        SqlCommand cmd9 = new SqlCommand();
                                        cmd9.Connection = myconn7;

                                        cmd9.CommandText = "update Train_Route SET Value = Value + 1 WHERE Value >= @Value";
                                        cmd9.Parameters.AddWithValue("@Value", TextBox7.Text);

                                        SqlDataReader rdr9;
                                        rdr9 = cmd9.ExecuteReader();
                                        rdr9.Close();

                                        if (empty == true)
                                        {

                                            SqlCommand cmd10 = new SqlCommand();
                                            cmd10.Connection = myconn7;
                                            cmd10.CommandText = "INSERT into Train_Route values (@Train_ID,@Station_Name,@Arrival_Time,@Departure_Time,@Value,@Distance,@Halt,@Day)";
                                            cmd10.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                                            cmd10.Parameters.AddWithValue("@Station_Name", TextBox2.Text);
                                            cmd10.Parameters.AddWithValue("@Arrival_Time", TimeSpan.FromMinutes(atime));
                                            cmd10.Parameters.AddWithValue("@Departure_Time", DBNull.Value);
                                            cmd10.Parameters.AddWithValue("@Value", TextBox7.Text);
                                            cmd10.Parameters.AddWithValue("@Distance", dist);
                                            cmd10.Parameters.AddWithValue("@Halt", DBNull.Value);
                                            cmd10.Parameters.AddWithValue("@Day", day);

                                            SqlDataReader rdr10;
                                            rdr10 = cmd10.ExecuteReader();
                                            rdr10.Close();
                                        }

                                        else

                                        {
                                            SqlCommand cd10 = new SqlCommand();
                                            cd10.Connection = myconn7;
                                            cd10.CommandText = "INSERT into Train_Route values (@Train_ID,@Station_Name,@Arrival_Time,@Departure_Time,@Value,@Distance,@Halt,@Day)";
                                            cd10.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                                            cd10.Parameters.AddWithValue("@Station_Name", TextBox2.Text);
                                            cd10.Parameters.AddWithValue("@Arrival_Time", TimeSpan.FromMinutes(atime));
                                            cd10.Parameters.AddWithValue("@Departure_Time", TimeSpan.FromMinutes(dtime));
                                            cd10.Parameters.AddWithValue("@Value", TextBox7.Text);
                                            cd10.Parameters.AddWithValue("@Distance", dist);
                                            cd10.Parameters.AddWithValue("@Halt", Convert.ToInt32(thalt));
                                            cd10.Parameters.AddWithValue("@Day", day);

                                            SqlDataReader rd10;
                                            rd10 = cd10.ExecuteReader();
                                            rd10.Close();
                                        }
                                        //myconn7.Close();
                                        Response.Redirect("ARoute.aspx");
                                        Label9.Text = "Station successfully inserted."; 
                                    }
                                    catch (Exception ex)
                                    {
                                        Label9.Text = ex.Message;
                                    } 
                                } 
                            }

                            else
                            {
                                Label9.Text = "Station does not exist in the station table.";
                            }
                        }

                        catch (Exception ex)
                        {
                            Label9.Text = ex.Message;
                        }
                    }
                }

                else
                {
                    SqlConnection conn2 = new SqlConnection();
                    conn2.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                    conn2.Open();

                    SqlCommand cd2 = new SqlCommand();
                    cd2.Connection = conn2;

                    cd2.CommandText = "update Train_Route SET Value = Value + 1 WHERE Value >= @Value";
                    cd2.Parameters.AddWithValue("@Value", TextBox7.Text);

                    SqlDataReader rd2;
                    rd2 = cd2.ExecuteReader();
                    rd2.Close();

                    rd2.Close();

                    SqlConnection conn1 = new SqlConnection();
                    conn1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                    conn1.Open();

                    SqlCommand cd = new SqlCommand();
                    cd.Connection = conn1;

                    cd.CommandText = "INSERT into Train_Route values (@Train_ID,@Station_Name,@Arrival_Time,@Departure_Time,@Value,@Distance,@Halt,@Day)";
                    cd.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                    cd.Parameters.AddWithValue("@Station_Name", TextBox2.Text);
                    cd.Parameters.AddWithValue("@Arrival_Time", DBNull.Value);
                    cd.Parameters.AddWithValue("@Departure_Time",DBNull.Value);
                    cd.Parameters.AddWithValue("@Distance", '0');
                    cd.Parameters.AddWithValue("@Value", TextBox7.Text);
                    cd.Parameters.AddWithValue("@Halt", DBNull.Value);
                    cd.Parameters.AddWithValue("@Day", day);
                    inserted = true;

                    cd.ExecuteNonQuery();
                    Response.Redirect("ARoute.aspx");
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            /* Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;*
            Label7.Visible = true;
            Label8.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;
            Button4.Visible = true;

            TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView1.SelectedRow.Cells[3].Text;
            TextBox4.Text = GridView1.SelectedRow.Cells[4].Text;
            TextBox5.Text = GridView1.SelectedRow.Cells[5].Text;
            TextBox6.Text = GridView1.SelectedRow.Cells[6].Text; */

            String str = GridView1.SelectedRow.Cells[1].Text.ToString();
            int temp = Convert.ToInt32(str);
            prestat = GridView1.SelectedRow.Cells[2].Text;
            Label9.Text = prestat.ToString();

            SqlConnection myconn8 = new SqlConnection();
            myconn8.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";

            try
            {
                myconn8.Open();

                SqlCommand cmnd1 = new SqlCommand();
                cmnd1.Connection = myconn8;

                cmnd1.CommandText = "select Distance,Station_ID from Station_Table where Station_Name =@Station_Name";
                cmnd1.Parameters.AddWithValue("@Station_Name", prestat);

                SqlDataReader r;
                r = cmnd1.ExecuteReader();
                while(r.Read())
                {
                    predist = Convert.ToInt32(r["Distance"].ToString());
                    prid = Convert.ToInt32(r["Station_ID"].ToString());
                }

                r.Close();

                SqlCommand cmd11 = new SqlCommand();
                cmd11.Connection = myconn8;

                cmd11.CommandText = "delete from Train_Route where Value = @Value and Train_ID=@Train_ID";
                cmd11.Parameters.AddWithValue("@Value", temp);
                cmd11.Parameters.AddWithValue("@Train_ID", TextBox1.Text);

                SqlDataReader rdr11;
                rdr11 = cmd11.ExecuteReader();
                rdr11.Close();

                SqlCommand cmd12 = new SqlCommand();
                cmd12.Connection = myconn8;

                cmd12.CommandText = "update Train_Route SET Value = Value - 1 WHERE Value > @Value";
                cmd12.Parameters.AddWithValue("@Value", temp);

                SqlDataReader rdr12;
                rdr12 = cmd12.ExecuteReader();
                rdr12.Close();

                myconn8.Close();
                Response.Redirect("ARoute.aspx");
                Label9.Text = "Station successfully deleted.";

            }

            catch (Exception exe)
            {
                Label9.Text = exe.Message;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Label5.Visible = true;
            TextBox4.Visible = true;
            Button6.Visible = true;

            if (GridView1.SelectedRow.RowIndex ==0)
            {
                esource = true;
                TextBox4.Text = GridView1.SelectedRow.Cells[4].Text;
                SqlConnection myconn9 = new SqlConnection();
                myconn9.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                myconn9.Open();

                newstat = GridView1.SelectedRow.Cells[2].Text;

                SqlCommand cmnd2 = new SqlCommand();
                cmnd2.Connection = myconn9;

                cmnd2.CommandText = "select Distance,Station_ID from Station_Table where Station_Name =@Station_Name";
                cmnd2.Parameters.AddWithValue("@Station_Name", newstat);

                SqlDataReader r2;
                r2 = cmnd2.ExecuteReader();

                while(r2.Read())
                {
                    newdist = Convert.ToInt32(r2["Distance"].ToString());
                    neid = Convert.ToInt32(r2["Station_ID"].ToString());
                }

                r2.Close();

                SqlCommand cmd13 = new SqlCommand();
                cmd13.Connection = myconn9;

                cmd13.CommandText = "select Departure_Time,Value from Train_Route where Train_ID =@Train_ID and Station_Name = @Station_Name";
                cmd13.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                cmd13.Parameters.AddWithValue("@Station_Name", GridView1.SelectedRow.Cells[2].Text);

                SqlDataReader rdr13;
                rdr13 = cmd13.ExecuteReader();

                while(rdr13.Read())
                {
                    //utime3 = rdr13["Departure_Time"].ToString();
                    //sutime3 = TimeSpan.Parse(utime3).TotalMinutes;
                    value = Convert.ToInt32(rdr13["Value"].ToString());
                }

                rdr13.Close();
                //Label9.Text = sutime3.ToString();

            }
            else
            {
                esource = false;
                SqlConnection myconn10 = new SqlConnection();
                myconn10.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                myconn10.Open();

                SqlCommand cmd14 = new SqlCommand();
                cmd14.Connection = myconn10;

                cmd14.CommandText = "select Arrival_Time,Value from Train_Route where Train_ID =@Train_ID and Station_Name =@Station_Name";
                cmd14.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                cmd14.Parameters.AddWithValue("@Station_Name", GridView1.SelectedRow.Cells[2].Text);

                SqlDataReader rdr14;
                rdr14 = cmd14.ExecuteReader();

                while (rdr14.Read())
                {
                    utime4 = rdr14["Arrival_Time"].ToString();
                    sutime4 = TimeSpan.Parse(utime4).TotalMinutes;
                    value = Convert.ToInt32(rdr14["Value"].ToString());
                }

                rdr14.Close();
                Label9.Text = sutime4.ToString();
            }

            SqlConnection myconn11 = new SqlConnection();
            myconn11.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            myconn11.Open();

            SqlCommand cmd15 = new SqlCommand();
            cmd15.Connection = myconn11;

            cmd15.CommandText = "select Halt from Station_Table where Station_Name = @Station_Name";
            cmd15.Parameters.AddWithValue("@Station_Name", GridView1.SelectedRow.Cells[2].Text);

            SqlDataReader rdr15;
            rdr15 = cmd15.ExecuteReader();

            while (rdr15.Read())
            {
                if (rdr15["Halt"] != DBNull.Value)
                {
                    thalt1 = Convert.ToInt32(rdr15["Halt"].ToString());
                }
            }

            rdr15.Close();
            //Label9.Text = sutime4.ToString();


            /*  SqlConnection myconn9 = new SqlConnection();
              myconn9.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
              myconn9.Open();

              SqlCommand cmd13 = new SqlCommand();
              cmd13.Connection = myconn9;

              cmd13.CommandText = "select Value,Arrival_Time,Departure_Time,Distance from Train_Route where Train_ID =@Train_ID and Station_Name =@Station_Name";
              cmd13.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
              cmd13.Parameters.AddWithValue("@Station_Name", GridView1.SelectedRow.Cells[2].Text);

              SqlDataReader rdr13;
              rdr13 = cmd13.ExecuteReader();

              while (rdr13.Read())
              {
                  udist2 = Convert.ToInt32(rdr13["Distance"].ToString());
                  utime3 = rdr13["Arrival_Time"].ToString();
                  sutime3 = TimeSpan.Parse(utime3).TotalMinutes;
                  utime4 = rdr13["Departure_Time"].ToString();
                  sutime4 = TimeSpan.Parse(utime4).TotalMinutes;
                  value = Convert.ToInt32(rdr13["Value"].ToString());
              }

              rdr13.Close();

              Label9.Text = sutime4.ToString();
              Label11.Text = sutime2.ToString();

              udist = (udist1 - udist2);
              famin = (sutime1 - sutime3);
              fdmin = (sutime2 - sutime4);

              SqlCommand cmd14 = new SqlCommand();
              cmd14.Connection = myconn9;

              cmd14.CommandText = "update Train_Route set Distance = Distance - @Distance where Train_ID =@Train_ID and Value >@Value";
              cmd14.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
              cmd14.Parameters.AddWithValue("@Value", value);
              cmd14.Parameters.AddWithValue("@Distance", udist);

              SqlDataReader rdr14;
              rdr14 = cmd14.ExecuteReader();

              rdr14.Close();
              //Response.Redirect("ARoute.aspx");

              SqlCommand cmd15 = new SqlCommand();
              cmd15.Connection = myconn9;

              cmd15.CommandText = "select Arrival_Time from Train_Route where Train_ID=@Train_ID and Value>@Value";
              cmd15.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
              cmd15.Parameters.AddWithValue("@Value", value);

              SqlDataAdapter adapter = new SqlDataAdapter(cmd15);
              DataSet dsPubs = new DataSet();
              adapter.Fill(dsPubs, "Train_Route");
              foreach (DataRow row in dsPubs.Tables["Train_Route"].Rows)
              {
                  ListItem newItem = new ListItem();
                  utime5 = row["Arrival_Time"].ToString();
                  sutime3 = TimeSpan.Parse(utime5).TotalMinutes;
                  aftime = TimeSpan.FromMinutes(sutime3);
                  ffaumin = sutime3 - famin;
                  ffautime = TimeSpan.FromMinutes(ffaumin);

                  SqlCommand cmd16 = new SqlCommand();
                  cmd16.Connection = myconn9;

                  cmd16.CommandText = "update Train_Route set Arrival_Time = @Arrival_Time where Train_ID = @Train_ID and Arrival_Time =@Arrival_time1";
                  cmd16.Parameters.AddWithValue("@Arrival_Time", ffautime);
                  cmd16.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                  cmd16.Parameters.AddWithValue("@Arrival_time1", aftime);

                  cmd16.ExecuteNonQuery();

              }

              SqlCommand cmd17 = new SqlCommand();
              cmd17.Connection = myconn9;

              cmd17.CommandText = "select Departure_Time from Train_Route where Train_ID=@Train_ID and Value>@Value";
              cmd17.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
              cmd17.Parameters.AddWithValue("@Value", value);

              SqlDataAdapter adptr = new SqlDataAdapter(cmd17);
              DataSet dsPubs1 = new DataSet();
              adptr.Fill(dsPubs1, "Train_Route");
              foreach (DataRow row in dsPubs1.Tables["Train_Route"].Rows)
              {
                  ListItem newItem = new ListItem();
                  utime6 = row["Departure_Time"].ToString();
                  sutime4 = TimeSpan.Parse(utime6).TotalMinutes;
                  dftime = TimeSpan.FromMinutes(sutime4);
                  ffdumin = sutime4 - fdmin;
                  ffdutime = TimeSpan.FromMinutes(ffdumin);

                  SqlCommand cmd18 = new SqlCommand();
                  cmd18.Connection = myconn9;

                  cmd18.CommandText = "update Train_Route set Departure_Time = @Departure_Time where Train_ID = @Train_ID and Departure_Time =@Departure_time1";
                  cmd18.Parameters.AddWithValue("@Departure_Time", ffdutime);
                  cmd18.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                  cmd18.Parameters.AddWithValue("@Departure_time1", dftime);

                  cmd18.ExecuteNonQuery();

              }
              */
            //Response.Redirect("ARoute.aspx"); 

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlConnection myconn10 = new SqlConnection();
            myconn10.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            myconn10.Open();

            SqlCommand cd2 = new SqlCommand();
            cd2.Connection = myconn10;
            cd2.CommandText = "select Halt,Departure_Time from Train_Route where Distance in (select MAX(Distance) from Train_Route where Train_ID =@Train_ID)";
            cd2.Parameters.AddWithValue("@Train_ID", TextBox1.Text);

            SqlDataReader rd2;
            rd2 = cd2.ExecuteReader();

            while(rd2.Read())
            {
                prehalt = Convert.ToInt32(rd2["Halt"].ToString());
                prefdist = rd2["Departure_Time"].ToString();
                prefmin = TimeSpan.Parse(prefdist).TotalMinutes;
            }

            rd2.Close();

            SqlCommand cmd19 = new SqlCommand();
            cmd19.Connection = myconn10;

            cmd19.CommandText = "UPDATE Train_Route SET Departure_Time =@Departure_Time,Halt =@Halt where Distance in (select MAX(Distance) from Train_Route where Train_ID =@Train_ID)";
            cmd19.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
            cmd19.Parameters.AddWithValue("@Departure_Time", DBNull.Value);
            cmd19.Parameters.AddWithValue("@Halt", DBNull.Value);

            cmd19.ExecuteNonQuery();
            //Label9.Text = prehalt.ToString();
            Response.Redirect("ARoute.aspx");

            myconn10.Close();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            count = 0;
            if(inserted == false)
            {
                prestat = null;
            }
            if (esource == true)
            {
                if (Convert.ToInt32(GridView1.SelectedRow.Cells[5].Text) != 0)
                {
                    utime5 = TextBox4.Text.ToString();
                    sutime5 = TimeSpan.Parse(utime5).TotalMinutes;

                    SqlConnection myconn14 = new SqlConnection();
                    myconn14.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                    myconn14.Open();

                    fidist = 0;

                    SqlCommand cmd26 = new SqlCommand();
                    cmd26.Connection = myconn14;

                    cmd26.CommandText = "UPDATE Train_Route SET Departure_Time =@Departure_Time, Distance = 0, Halt =@Halt, Arrival_Time =@Arrival_Time where Station_Name =@Station_Name";
                    cmd26.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                    cmd26.Parameters.AddWithValue("@Departure_Time", TimeSpan.FromMinutes(sutime5));
                    cmd26.Parameters.AddWithValue("@Station_Name", GridView1.SelectedRow.Cells[2].Text);
                    cmd26.Parameters.AddWithValue("@Halt", DBNull.Value);
                    cmd26.Parameters.AddWithValue("@Arrival_Time", DBNull.Value);

                    cmd26.ExecuteNonQuery();

                    SqlCommand cmnd4 = new SqlCommand();
                    cmnd4.Connection = myconn14;
                    cmnd4.CommandText = "UPDATE Train_Route SET Distance = Distance - @Distance where Train_ID = @Train_ID and Value>@Value";
                    cmnd4.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                    cmnd4.Parameters.AddWithValue("@Value", value);
                    cmnd4.Parameters.AddWithValue("@Distance", Convert.ToInt32(GridView1.SelectedRow.Cells[5].Text));

                    cmnd4.ExecuteNonQuery();

                    SqlCommand cmd27 = new SqlCommand();
                    cmd27.Connection = myconn14;

                    cmd27.CommandText = "select Arrival_Time,Distance,Halt from Train_Route where Train_ID=@Train_ID and Value>@Value";
                    cmd27.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                    cmd27.Parameters.AddWithValue("@Value", value);

                    SqlDataAdapter adapter4 = new SqlDataAdapter(cmd27);
                    DataSet dsPubs4 = new DataSet();
                    adapter4.Fill(dsPubs4, "Train_Route");
                    foreach (DataRow row in dsPubs4.Tables["Train_Route"].Rows)
                    {
                        ListItem newItem = new ListItem();
                        utime7 = row["Arrival_Time"].ToString();
                        sutime7 = TimeSpan.Parse(utime7).TotalMinutes;
                        aftime = TimeSpan.FromMinutes(sutime7);
                        fdist = Convert.ToInt32(row["Distance"].ToString());
                        if (row["Halt"] == DBNull.Value)
                        {
                            thalt2 = 0;
                        }
                        else
                        {
                            thalt2 = Convert.ToInt32(row["Halt"].ToString());
                        }
                        sutime8 = sutime5 + Convert.ToDouble(fdist * 0.75);
                        if (sutime8 > 1440)
                        {
                            sutime8 = sutime8 - 1440;
                            count++;
                            if (count == 1)
                            {
                                day++;
                            }
                        }

                        dutime8 = sutime8 + thalt2;

                        if (dutime8 > 1440)
                        {
                            dutime8 = dutime8 - 1440;
                            count++;
                            if (count == 1)
                            {
                                day++;
                            }
                        }


                        SqlCommand cmd28 = new SqlCommand();
                        cmd28.Connection = myconn14;

                        cmd28.CommandText = "update Train_Route set Arrival_Time = @Arrival_Time,Departure_Time = @Departure_Time,Day =@Day where Train_ID = @Train_ID and Arrival_Time =@Arrival_time2";
                        cmd28.Parameters.AddWithValue("@Arrival_Time", TimeSpan.FromMinutes(sutime8));
                        cmd28.Parameters.AddWithValue("@Departure_Time", TimeSpan.FromMinutes(dutime8));
                        cmd28.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                        cmd28.Parameters.AddWithValue("@Arrival_time2", aftime);
                        cmd28.Parameters.AddWithValue("@Day", day);

                        cmd28.ExecuteNonQuery();

                        //Label9.Text = "Successful";

                    }

                    SqlCommand cmd29 = new SqlCommand();
                    cmd29.Connection = myconn14;

                    cmd29.CommandText = "update Train_Route set Halt = @Halt,Departure_Time =@Departure_Time where Distance in (select MAX(Distance) from Train_Route where Train_ID =@Train_ID)";
                    cmd29.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                    cmd29.Parameters.AddWithValue("@Halt", prehalt);
                    cmd29.Parameters.AddWithValue("@Departure_Time", TimeSpan.FromMinutes(sutime8 + prehalt));

                    cmd29.ExecuteNonQuery();
                }

                else
                {
                    utime5 = TextBox4.Text.ToString();
                    sutime5 = TimeSpan.Parse(utime5).TotalMinutes;

                    SqlConnection myconn11 = new SqlConnection();
                    myconn11.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                    myconn11.Open();

                    if (prestat == null)
                    {
                        fidist = 0;
                    }
                    else
                    {
                        if (neid < prid)
                        {
                            fidist = predist - newdist;
                        }
                        else
                        {
                            fidist = newdist - predist;
                        }
                    }

                    SqlCommand cmd20 = new SqlCommand();
                    cmd20.Connection = myconn11;

                    cmd20.CommandText = "UPDATE Train_Route SET Departure_Time =@Departure_Time where Distance = 0";
                    cmd20.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                    cmd20.Parameters.AddWithValue("@Departure_Time", TimeSpan.FromMinutes(sutime5));

                    cmd20.ExecuteNonQuery();

                    SqlCommand cmnd3 = new SqlCommand();
                    cmnd3.Connection = myconn11;
                    cmnd3.CommandText = "UPDATE Train_Route SET Distance = Distance + @Distance where Train_ID = @Train_ID and Value>@Value";
                    cmnd3.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                    cmnd3.Parameters.AddWithValue("@Value", value);
                    cmnd3.Parameters.AddWithValue("@Distance", fidist);

                    cmnd3.ExecuteNonQuery();

                    SqlCommand cmd21 = new SqlCommand();
                    cmd21.Connection = myconn11;

                    cmd21.CommandText = "select Arrival_Time,Distance,Halt from Train_Route where Train_ID=@Train_ID and Value>@Value";
                    cmd21.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                    cmd21.Parameters.AddWithValue("@Value", value);

                    SqlDataAdapter adapter2 = new SqlDataAdapter(cmd21);
                    DataSet dsPubs2 = new DataSet();
                    adapter2.Fill(dsPubs2, "Train_Route");
                    foreach (DataRow row in dsPubs2.Tables["Train_Route"].Rows)
                    {
                        ListItem newItem = new ListItem();
                        utime7 = row["Arrival_Time"].ToString();
                        sutime7 = TimeSpan.Parse(utime7).TotalMinutes;
                        aftime = TimeSpan.FromMinutes(sutime7);
                        fdist = Convert.ToInt32(row["Distance"].ToString());
                        sutime8 = sutime5 + Convert.ToDouble(fdist * 0.75);
                        if (row["Halt"] != DBNull.Value)
                        {
                            thalt2 = Convert.ToInt32(row["Halt"].ToString());
                        }
                        else
                        {
                            thalt2 = 0;
                        }

                        if (sutime8 > 1440)
                        {
                            sutime8 = sutime8 - 1440;
                            count++;
                            if (count == 1)
                            {
                                day++;
                            }

                        }

                        dutime8 = sutime8 + thalt2;

                        if (dutime8 > 1440)
                        {
                            dutime8 = dutime8 - 1440;
                            count++;
                            if (count == 1)
                            {
                                day++;
                            }

                        }


                        SqlCommand cmd22 = new SqlCommand();
                        cmd22.Connection = myconn11;

                        cmd22.CommandText = "update Train_Route set Arrival_Time = @Arrival_Time,Departure_Time = @Departure_Time,Day =@Day where Train_ID = @Train_ID and Arrival_Time =@Arrival_time2";
                        cmd22.Parameters.AddWithValue("@Arrival_Time", TimeSpan.FromMinutes(sutime8));
                        cmd22.Parameters.AddWithValue("@Departure_Time", TimeSpan.FromMinutes(dutime8));
                        cmd22.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                        cmd22.Parameters.AddWithValue("@Arrival_time2", aftime);
                        cmd22.Parameters.AddWithValue("@Day", day);

                        cmd22.ExecuteNonQuery();

                        //Label9.Text = "Successful";    
                    }

                    SqlCommand cmd30 = new SqlCommand();
                    cmd30.Connection = myconn11;

                    cmd30.CommandText = "update Train_Route set Halt = @Halt,Departure_Time =@Departure_Time where Distance in (select MAX(Distance) from Train_Route where Train_ID =@Train_ID)";
                    cmd30.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                    cmd30.Parameters.AddWithValue("@Halt", prehalt);
                    cmd30.Parameters.AddWithValue("@Departure_Time", TimeSpan.FromMinutes(sutime8 + prehalt));

                    cmd30.ExecuteNonQuery();
                }

                Response.Redirect("ARoute.aspx");
            }
            else
            {
                //Adding any station between source and destination case
                udtime = TextBox4.Text;
                sutime6 = TimeSpan.Parse(udtime).TotalMinutes;
                value1 = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                thalt4 = Convert.ToInt32(GridView1.SelectedRow.Cells[6].Text);
                sdist = Convert.ToInt32(GridView1.SelectedRow.Cells[5].Text);

                SqlConnection myconn12 = new SqlConnection();
                myconn12.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                myconn12.Open();

                SqlCommand cmd25 = new SqlCommand();
                cmd25.Connection = myconn12;

                cmd25.CommandText = "UPDATE Train_Route SET Arrival_Time =@Arrival_Time, Departure_Time =@Departure_Time where Value =@Value";
                cmd25.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                cmd25.Parameters.AddWithValue("@Arrival_Time", TimeSpan.FromMinutes(sutime6));
                cmd25.Parameters.AddWithValue("@Departure_Time", TimeSpan.FromMinutes(sutime6 + thalt4));
                cmd25.Parameters.AddWithValue("@Value", value1);

                cmd25.ExecuteNonQuery();

                SqlCommand cmd23 = new SqlCommand();
                cmd23.Connection = myconn12;

                cmd23.CommandText = "select Arrival_Time,Distance,Halt from Train_Route where Train_ID=@Train_ID and Value>@Value";
                cmd23.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                cmd23.Parameters.AddWithValue("@Value", value);

                SqlDataAdapter adapter3 = new SqlDataAdapter(cmd23);
                DataSet dsPubs3 = new DataSet();
                adapter3.Fill(dsPubs3, "Train_Route");
                foreach (DataRow row in dsPubs3.Tables["Train_Route"].Rows)
                {
                    ListItem newItem = new ListItem();
                    utime8 = row["Arrival_Time"].ToString();
                    sutime9 = TimeSpan.Parse(utime8).TotalMinutes;
                    dutime = TimeSpan.FromMinutes(sutime9);
                    ffdist = Convert.ToInt32(row["Distance"].ToString());
                    sutime10 = sutime6 + Convert.ToDouble((ffdist - sdist) * 0.75);
                    if (row["Halt"] == DBNull.Value)
                    {
                        thalt3 = 0;
                    }
                    else
                    {
                        thalt3 = Convert.ToInt32(row["Halt"].ToString());
                    }

                    if (sutime9 > 1440)
                    {
                        sutime9 = sutime9 - 1440;
                        count++;
                        if (count == 1)
                        {
                            day++;
                        }
                    }

                    dutime10 = sutime10 + thalt3;

                    if (dutime10 > 1440)
                    {
                        dutime10 = dutime10 - 1440;
                        count++;
                        if (count == 1)
                        {
                            day++;
                        }
                    }

                    SqlCommand cmd24 = new SqlCommand();
                    cmd24.Connection = myconn12;

                    cmd24.CommandText = "update Train_Route set Arrival_Time = @Arrival_Time,Departure_Time = @Departure_Time where Train_ID = @Train_ID and Arrival_Time =@Arrival_time1";
                    cmd24.Parameters.AddWithValue("@Arrival_Time", TimeSpan.FromMinutes(sutime10));
                    cmd24.Parameters.AddWithValue("@Departure_Time", TimeSpan.FromMinutes(dutime10));
                    cmd24.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                    cmd24.Parameters.AddWithValue("@Arrival_time1", dutime);

                    cmd24.ExecuteNonQuery();
                    Label9.Text = "Successful";
                }

                SqlCommand cmd31 = new SqlCommand();
                cmd31.Connection = myconn12;

                cmd31.CommandText = "update Train_Route set Halt = @Halt,Departure_Time =@Departure_Time where Distance in (select MAX(Distance) from Train_Route where Train_ID =@Train_ID)";
                cmd31.Parameters.AddWithValue("@Train_ID", TextBox1.Text);
                cmd31.Parameters.AddWithValue("@Halt", prehalt);
                cmd31.Parameters.AddWithValue("@Departure_Time", TimeSpan.FromMinutes(sutime10 + prehalt));

                cmd31.ExecuteNonQuery();

                count = 0;

                //Response.Redirect("ARoute.aspx");
            }
        }
    }
}