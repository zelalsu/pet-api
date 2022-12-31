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
    public class AnimalController : ApiController
    {

        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select ID,AnimalName from dbo.Animals";
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da= new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }



    }
}
