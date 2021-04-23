using DemoData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DemoWebCliente.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var listEmisores = GetItemsAPI();
            return View(listEmisores);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Javascript()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Emisores entity1 = new Emisores();
                entity1.Id = this.Request.Form["Id"];
                entity1.Rfc = this.Request.Form["Rfc"];
                var FechaInicioOperacion = this.Request.Form["FechaInicioOperacion"];
                var Capital = this.Request.Form["Capital"];
                entity1.FechaInicioOperacion = FechaInicioOperacion == "0" || FechaInicioOperacion == "" ? new DateTime?() : new DateTime?(Convert.ToDateTime(FechaInicioOperacion));
                entity1.Capital = Capital == "0" || Capital == "" ? 0 : new Decimal?(Convert.ToDecimal(Capital));

                PostItem(JsonConvert.SerializeObject(entity1));
                
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Message;
                return View();
                
            }
        }
        public List<Emisores> GetItemsAPI()
        {
            List<Emisores> resul = new List<Emisores>();
            var url = "https://localhost:44357/Emisores";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using(WebResponse response = request.GetResponse())
                { 
                    using (Stream strReader = response.GetResponseStream())
                    {
                    if (strReader == null) return resul;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        resul = JsonConvert.DeserializeObject < List < Emisores >> (responseBody);
                        Console.WriteLine(responseBody);

                    }
                    }

                }

            }
            catch (Exception ex)
            {

                throw;
            }







            return resul;

        }

        private void PostItem(string data)
        {
            var url = $"https://localhost:44357/Emisores";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

    }
}