using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiPetshop.Models;
namespace ApiPetshop.Controllers
{
    public class ItemPropsController : ApiController
    {
        // GET: ItemProps

        public HttpResponseMessage Get()
        {

            DataTable table = new DataTable();
            string query = @"select ID,ItemId,ProductName,ProductBrand,ProductProps,Image from dbo.ItemProps";
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);

            }
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    var img = Image.FromStream(new MemoryStream(Convert.FromBase64String(table.Rows[i]["image"].ToString())));
            //    table.Rows[i]["image"] = img;
            //}

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }



        public HttpResponseMessage GetById(int id)
        {

            DataTable table = new DataTable();
            string query = @"select ID,ItemId,ProductName,ProductBrand,ProductProps,Image from dbo.ItemProps where ItemId=" + id;
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        public string Post(ItemProps item)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.ItemProps (ItemId,ProductName,ProductBrand,ProductProps,Image) values (
            '" + item.ItemId + @"',
            '" + item.ProductName + @"',
            '" + item.ProductBrand + @"',
            '" + item.ProductProps + @"',
            '" + item.Image + @"',
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


        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Put(ItemProps item)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"UPDATE  dbo.ItemProps set 
                ProductName= '" + item.ProductName + @"',
                ProductBrand   = '" + item.ProductBrand + @"',
                ProductProps='" + item.ProductProps + @"',
  
                where ID=" + item.ID + @"";
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return Request.CreateResponse("deneme güncellendi");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse("deneme" + ex.ToString());
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();


                string query = @"delete from  dbo.ItemProps where ID= " + id;
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PetShopDb"].ConnectionString);
                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Delete succesfully";
            }
            catch (Exception ex)
            {

                return "Failed to delete : " + ex.ToString();
            }

        }
    }
}