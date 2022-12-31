using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiPetshop.Models;

namespace ApiPetshop.Controllers

{
    public class UserController : ApiController
    {
        
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select ID,UserFirstName,UserName,UserMail,UserPassword from dbo.Users";
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post( Users user)
        {
            
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.Users (UserFirstName,UserName,UserMail,UserPassword,IsAdmin) values(
                    '" + user.UserFirstName + @"',
                    '" + user.UserName + @"',
                    '" + user.UserMail + @"',
                    '" + user.UserPassword + @"',
                    '0'

                  
                )";
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);

                }
                return "Başarıyla eklendi";
            }
            catch (Exception ex)
            {

                return "Failed to successfully : " + ex.ToString();
            }
        }




    }
}
