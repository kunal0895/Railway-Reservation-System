using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace RailwayReservationPart1
{
    public partial class AHome : System.Web.UI.Page
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
                cmd.CommandText = "select Admin_Uname,EMail_ID,Mobile_number,Gender,Work_exp,Salary from Admin,Person where Admin_Uname=Username and Admin_Uname=@un";
                if (Session["un"].ToString()=="")
                    {
                    Response.Redirect("ALogin.aspx");
                    }
                else
                { 
                    cmd.Parameters.AddWithValue("@un", Session["un"].ToString());
                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Label1.Text = rdr["Admin_Uname"].ToString();
                        Label2.Text = rdr["EMail_ID"].ToString();
                        Label3.Text = rdr["Mobile_number"].ToString();
                        Label4.Text = rdr["Gender"].ToString();
                        Label5.Text = rdr["Work_exp"].ToString();
                        Label6.Text = rdr["Salary"].ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception edf)
            {
                Label7.Text = edf.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["un"] = "";
            Response.Redirect("ALogin.aspx");
        }
    }
}