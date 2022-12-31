using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiPetshop.Dto;
using ApiPetshop.Models;

namespace ApiPetshop.Controllers
{
    public class LoginController : ApiController
    {
        [AllowAnonymous]
        public LoginResultDto POST(Users login)
        {
            string token;

            JwtManager jwtManager = new JwtManager();

           

            string query = "Select * from dbo.Users where UserName = '" + login.UserName + "' and UserPassword = '" + login.UserPassword + "' ";
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
            con.Open();
            var command = new SqlCommand(query, con);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    login.ID = Convert.ToInt32(reader["ID"]);
                    login.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                    token = jwtManager.GetToken(login.UserName, login.IsAdmin);
                    con.Close();
                    return new LoginResultDto() { Jwt = token, Username = login.UserName, Password = login.UserPassword, UserId = login.ID, IsAdmin = login.IsAdmin };
                }
                else
                {
                    con.Close();
                    return null;
                }
            }

        }
    }
}
