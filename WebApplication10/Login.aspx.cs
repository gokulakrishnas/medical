using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10
{
    public partial class Login : System.Web.UI.Page
    {
        public string GetConnectionString()
        {

            return System.Configuration.ConfigurationManager.ConnectionStrings["User"].ConnectionString;

        }
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void Logins(object sender, EventArgs e)
        {
            // con.Open();
            // SqlCommand cmd = con.CreateCommand();
            // cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText= "select * from Register where Username='" + username1.Value + "' and Passwords='" + passwords.Value+ "'";
            // cmd.ExecuteNonQuery();
            // DataTable dt = new DataTable();
            // SqlDataAdapter da = new SqlDataAdapter(cmd);
            // da.Fill(dt);
            // foreach(DataRow dr in dt.Rows)
            // {
            //     Session["Username"] = dr["Username"].ToString();
            //     Response.Redirect("Register.aspx");
            // }

            // con.Close();
            string encryptpassword1 = encryptpass(passwords.Value);
            try

            {

                SqlConnection con = new SqlConnection(GetConnectionString());

                con.Open();



                SqlCommand cmd = new SqlCommand("LoginUser", con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("Username", username1.Value);

                SqlParameter p2 = new SqlParameter("Password", encryptpassword1);

                cmd.Parameters.Add(p1);

                cmd.Parameters.Add(p2);

                SqlDataReader rd = cmd.ExecuteReader();



                if (rd.HasRows)

                {

                    rd.Read();

                    //lblinfo.Text = "You are Authorized.";

                    FormsAuthentication.RedirectFromLoginPage(username1.Value, true);

                    Response.Redirect("Default.aspx");

                }

                //else

                //{

                //    lblinfo.Text = "Invalid username or password.";

                //}

            }

            catch (Exception Ex)

            {

                Console.WriteLine("ok", Ex);

            }



        }
        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
    }
}