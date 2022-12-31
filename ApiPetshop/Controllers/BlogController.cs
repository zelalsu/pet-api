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
using System.Web.Mvc;

namespace ApiPetshop.Controllers
{
    public class BlogController : ApiController
    {

        public HttpResponseMessage Get()
        {


            DataTable table = new DataTable();
            string query = @"select BlogId,BlogName,BlogComment,BlogImage,BlogCommentTwo,BlogCommentThree,BlogCommentFour,BlogImageTwo,BlogImageThree from dbo.Blog";
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public HttpResponseMessage GetById(int id)
        {
            DataTable table = new DataTable();
            string query = @"select BlogId,BlogName,BlogComment,BlogImage,BlogCommentTwo,BlogCommentThree,BlogCommentFour,BlogImageTwo,BlogImageThree from dbo.Blog where BlogId=" + id;
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        public string Put( Blog item)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"UPDATE dbo.Blog set BlogName='" + item.BlogName + @"',BlogComment='" + item.BlogComment + @"' where BlogId=" + item.BlogId + @"";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
                var command = new SqlCommand(query, con);
                using(var da=new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "update successfully";
            }
            catch(Exception ex)

            {
                return "Failed to add:"+ ex.ToString(); 
            }






           
        }
}
    }
