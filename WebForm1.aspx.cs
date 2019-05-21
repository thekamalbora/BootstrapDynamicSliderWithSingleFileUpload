using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SaveImageInDataBaseAndRetriveDynamicConcept
{
    public partial class WebForm1 : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload/" + str));
                string Image = "Upload/" + str.ToString();
                string name = TextBox1.Text;

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QL8HUND\SQLEXPRESS;Initial Catalog=asp.net;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into imagedb values(@name,@Image)", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@Image", Image);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Label1.Text = "Image Uploaded";
                Label1.ForeColor = System.Drawing.Color.ForestGreen;

            }

            else
            {
                Label1.Text = "Please Upload your Image";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

       
    }
    }
