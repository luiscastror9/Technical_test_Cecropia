using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiClient;
using WebApplication.Models;
using System.Net.Http;
using System.Data;
using Newtonsoft.Json;
using RestSharp;


namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            ClassApiClient Api = new ClassApiClient();
          
            RestSharp.RestResponse response = (RestSharp.RestResponse)Api.ListApi("api", "Product");
          
            JsonSerializerSettings settings = new JsonSerializerSettings

                 {
                     TypeNameHandling = TypeNameHandling.Objects
                 };
            object Productos = RestSharp.SimpleJson.DeserializeObject(response.Content);
            IEnumerable<Products> obj = JsonConvert.DeserializeObject<IEnumerable<Products>>(Productos.ToString(), settings);

           // Products pr = (Products)Productos;

            return View(obj);
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            ClassApiClient Api = new ClassApiClient();
            Dictionary<string, string> parameters = new Dictionary<string,string>();
            parameters.Add("id", id.ToString());

            RestSharp.RestResponse response = (RestSharp.RestResponse)Api.Api("api", "Product","Details",parameters);

            JsonSerializerSettings settings = new JsonSerializerSettings

            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            object Productos = RestSharp.SimpleJson.DeserializeObject(response.Content);
            Products obj = JsonConvert.DeserializeObject<Products>(Productos.ToString(), settings);
            return View(obj);
        }

        //
        // GET: /Product/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ClassApiClient Api = new ClassApiClient();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("Name", collection.GetValue("Name").AttemptedValue.ToString());
                parameters.Add("Brand", collection.GetValue("Brand").AttemptedValue.ToString());
                parameters.Add("Size", collection.GetValue("Size").AttemptedValue.ToString());
                parameters.Add("Price", collection.GetValue("Price").AttemptedValue.ToString());
                parameters.Add("Quantity_in_stock", collection.GetValue("Quantity_in_stock").AttemptedValue.ToString());
                parameters.Add("Created_date", DateTime.Now.ToString());
                parameters.Add("Updated_date", DateTime.Now.ToString());

                RestSharp.RestResponse response = (RestSharp.RestResponse)Api.Api("api", "Product", "Create", parameters);

                JsonSerializerSettings settings = new JsonSerializerSettings

                {
                    TypeNameHandling = TypeNameHandling.Objects
                };
                object Productos = RestSharp.SimpleJson.DeserializeObject(response.Content);
                Products obj = JsonConvert.DeserializeObject<Products>(Productos.ToString(), settings);
                if (response.StatusDescription == "Created")
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Save Successfully'); window.location = \"/Product/Index\";</script>");

                // return RedirectToAction("Index");
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Error on Save'); window.location = \"/Product/Create\";</script>");


                }
               
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            ClassApiClient Api = new ClassApiClient();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());

            RestSharp.RestResponse response = (RestSharp.RestResponse)Api.Api("api", "Product", "Details", parameters);

            JsonSerializerSettings settings = new JsonSerializerSettings

            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            object Productos = RestSharp.SimpleJson.DeserializeObject(response.Content);
            Products obj = JsonConvert.DeserializeObject<Products>(Productos.ToString(), settings);
            return View(obj);
 
           
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
            ClassApiClient Api = new ClassApiClient();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());
            parameters.Add("Name", collection.GetValue("Name").AttemptedValue.ToString());
            parameters.Add("Brand", collection.GetValue("Brand").AttemptedValue.ToString());
            parameters.Add("Size", collection.GetValue("Size").AttemptedValue.ToString());
            parameters.Add("Price", collection.GetValue("Price").AttemptedValue.ToString());
            parameters.Add("Quantity_in_stock", collection.GetValue("Quantity_in_stock").AttemptedValue.ToString());
            parameters.Add("Created_date", collection.GetValue("Created_date").AttemptedValue.ToString());
                parameters.Add("Updated_date", DateTime.Now.ToString());
            RestSharp.RestResponse response = (RestSharp.RestResponse)Api.Api("api", "Product", "Update", parameters);

            JsonSerializerSettings settings = new JsonSerializerSettings

            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            object Productos = RestSharp.SimpleJson.DeserializeObject(response.Content);
            Products obj = JsonConvert.DeserializeObject<Products>(Productos.ToString(), settings);

            if (response.StatusDescription == "Created")
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Save Successfully'); window.location = \"/Product/Index\";</script>");

                // return RedirectToAction("Index");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Error on Save'); window.location = \"/Product/Create\";</script>");


            }
            }
            catch
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Error on Update '); window.location = \"/Product/Edit/"+id+";</script>");
            }
        }

        //
        // GET: /Product/Delete/5
         [HttpPost]
        public string Delete(int id)
        {
            try { 
            ClassApiClient Api = new ClassApiClient();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());

            RestSharp.RestResponse response = (RestSharp.RestResponse)Api.Api("api", "Product", "Delete", parameters);

            JsonSerializerSettings settings = new JsonSerializerSettings

            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            object Productos = RestSharp.SimpleJson.DeserializeObject(response.Content);
           // Products obj = JsonConvert.DeserializeObject<Products>(Productos.ToString(), settings);
            string resp ="true";
            return resp;
                }
            catch 
            {
                string resp = "true";
                return resp;
            }

        }

     
       
   
    }
}
