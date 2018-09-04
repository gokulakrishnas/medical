using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Services;

namespace WebApplication10
{
    /// <summary>
    /// Summary description for login
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class login : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public Boolean Register(string Username, string emailaddress, string password, string confirmpassword)
        {
            Boolean value = false;
            try
            {
                
                String query = "Insert into Register (Username,EmailAddress,Passwords,Confirmpassword) VALUES (@Username,@EmailAddress, @Passwords, @Confirmpassword)";
                string encryptpassword1 = encryptpass(password);
                string encryptpassword2 = encryptpass(confirmpassword);
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = emailaddress;
                    command.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;
                    command.Parameters.Add("@Passwords", SqlDbType.VarChar).Value = encryptpassword1;
                    command.Parameters.Add("@Confirmpassword", SqlDbType.VarChar).Value = encryptpassword2;
                    connection.Open();
                    int op = command.ExecuteNonQuery();
                    if (op == 1)
                    {
                        return value =true;

                    }
                    connection.Close();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("exception", Ex);
            }
            return value;





        }
        [WebMethod]
        public Boolean Login(string username, string password)
        {

            string encryptpassword1 = encryptpass(password);
            SqlConnection con = new SqlConnection(GetConnectionString());

            con.Open();
            SqlCommand cmd = new SqlCommand("LoginUser", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("Username", username);

            SqlParameter p2 = new SqlParameter("Password", encryptpassword1);

            cmd.Parameters.Add(p1);

            cmd.Parameters.Add(p2);

            SqlDataReader rd = cmd.ExecuteReader();

            Boolean value = false;

            if (rd.HasRows)

            {
                rd.Read();
                return value = true;
            }
            else
            {
                return value = false;
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
        public string GetConnectionString()
        {

            return System.Configuration.ConfigurationManager.ConnectionStrings["User"].ConnectionString;

        }
    }
}
