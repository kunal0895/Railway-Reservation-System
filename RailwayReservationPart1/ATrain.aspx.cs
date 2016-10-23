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
    public partial class ViewTrain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "";
            //if(Session["un"].ToString()=="")
            //{
            //    Response.Redirect("ALogin.aspx");
            //}
            if (Page.Session["SomeInfo"] != null)
            {
                Label1.Text = Page.Session["SomeInfo"].ToString();
                Page.Session.Clear();
            }
            else
            {
                Label1.Text = "";
                Page.Session.Clear();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
          
            if(TextBox1.Text=="" && TextBox2.Text=="")
            {
                Label1.Text = "Please insert values.";
            }
            else if((TextBox1.Text==""||TextBox1.Text.Length<5||TextBox1.Text.Length>5) && TextBox2.Text.Length>0)
            {
                Label1.Text = "Please insert a 5 digit Train Number.";
            }
            else if(TextBox1.Text.Length==5 && TextBox2.Text=="")
            {
                Label1.Text = "Please insert Train Name.";
            }
            else if((TextBox1.Text.Length < 5 || TextBox1.Text.Length > 5) && TextBox2.Text=="")
            {
                Label1.Text = "Enter Train Name and enter 5 digit Train Number.";
            }
           
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText += "insert into Train_Details values('" + TextBox1.Text + "','" + TextBox2.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Label1.Text = "Train succesfully inserted.";
                    Page.Session["SomeInfo"] = Label1.Text;
                    Response.Redirect("ATrain.aspx");
                }
                
                catch 
                {
                    Label1.Text = "Train number already there.";
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                Label2.Text = "";
                Session["train_num"] = GridView1.SelectedRow.Cells[1].Text;
                Response.Redirect("ARoute.aspx");
            }
            else
            {
                Label2.Text = "Please select the Train.";
            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                Label2.Text = "";
                Session["train_num"] = GridView1.SelectedRow.Cells[1].Text;
                Session["train_name"] = GridView1.SelectedRow.Cells[2].Text;
                Response.Redirect("AAvailable.aspx");
            }
            else
            {
                Label2.Text = "Please slect the Train.";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                Label2.Text = "";
                Session["train_num"] = GridView1.SelectedRow.Cells[1].Text;
                Session["train_name"] = GridView1.SelectedRow.Cells[2].Text;
                Response.Redirect("AFrequency.aspx");
            }
            else
            {
                Label2.Text = "Please select the Train.";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowState != DataControlRowState.Edit)
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    String id = e.Row.Cells[1].Text;
                    LinkButton lb1 = (LinkButton)e.Row.Cells[0].Controls[2];
                    if (lb1 != null)
                    {
                        lb1.Attributes.Add("onclick", "return ConfirmOnDelete(" + id + ");");
                    }
                }
            }
        }
    }
}