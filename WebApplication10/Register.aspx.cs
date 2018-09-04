using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10
{
    public partial class Register : System.Web.UI.Page
    {
        public string GetConnectionString()
        {

            return System.Configuration.ConfigurationManager.ConnectionStrings["User"].ConnectionString;

        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void Registers(object sender, EventArgs e)
        {
            try
            {
                String query = "Insert into Register (Username,EmailAddress,Passwords,Confirmpassword) VALUES (@Username,@EmailAddress, @Passwords, @Confirmpassword)";
                string encryptpassword1 = encryptpass(passwords.Value);
                string encryptpassword2 = encryptpass(confirmpassword.Value);
                string address;
                address = Convert.ToString(CheckEmail(email.Value));
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (address == "True")
                    {
                        command.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = email.Value;
                        command.Parameters.Add("@Username", SqlDbType.VarChar).Value = username1.Value;
                        command.Parameters.Add("@Passwords", SqlDbType.VarChar).Value = encryptpassword1;
                        command.Parameters.Add("@Confirmpassword", SqlDbType.VarChar).Value = encryptpassword2;

}
                    else if(address=="False")
                    {
                        error.InnerText = "Email already exists";
                    }


                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    //command.Parameters.Add("@Passwords", SqlDbType.VarChar).Value = passwords.Value.Trim();
                    //command.Parameters.Add("@Confirmpassword", SqlDbType.VarChar).Value = confirmpassword.Value.Trim();
                }

            }
            catch (Exception ex)
            {
                Response.Write("ok");
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
       
        public bool CheckEmail(string email)
        {
            bool status = false;
            string constr = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CheckEmail", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email.Trim());
                    conn.Open();
                    status = Convert.ToBoolean(cmd.ExecuteScalar());
                    conn.Close();
                }
               
            }
            return status;
        }
    }
}