using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace WebApplication10.models
{
    public class Connection
    {
        public string GetConnectionString()
        {

            return System.Configuration.ConfigurationManager.ConnectionStrings["User"].ConnectionString;

        }
        public bool Login(Register log)
        {

            SqlConnection con = new SqlConnection(GetConnectionString());
            //Register op = new Register();
            string encryptpassword1 = encryptpass(log.password);
            con.Open();
            bool status = true;


            SqlCommand cmd = new SqlCommand("LoginUser", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("Username", log.username);

            SqlParameter p2 = new SqlParameter("Password", encryptpassword1);

            cmd.Parameters.Add(p1);

            cmd.Parameters.Add(p2);

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)

            {

                rd.Read();



                FormsAuthentication.RedirectFromLoginPage(log.username, true);

                return status;

            }
            else
            {
                return status = false;
            }


        }
        public int AddRegister(Register Reg)
        {
            String query = "Insert into Register (Username,EmailAddress,Passwords,Confirmpassword) VALUES (@Username,@EmailAddress, @Passwords, @Confirmpassword)";
            string encryptpassword1 = encryptpass(Reg.password);
            string encryptpassword2 = encryptpass(Reg.confirmPassword);
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = Reg.EmailAddress;
                command.Parameters.Add("@Username", SqlDbType.VarChar).Value = Reg.username;
                command.Parameters.Add("@Passwords", SqlDbType.VarChar).Value = encryptpassword1;
                command.Parameters.Add("@Confirmpassword", SqlDbType.VarChar).Value = encryptpassword2;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return 1;
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