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
    public class AnimalItemController : ApiController
    {
        // GET: AnimalItem
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select ID,AnimalId,ItemName from dbo.AnimalItem";
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
            string query = @"select ID,AnimalId,ItemName from dbo.AnimalItem where AnimalId="+id;
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}