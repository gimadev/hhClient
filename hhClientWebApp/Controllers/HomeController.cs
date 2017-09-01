using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hhClientWebApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using Microsoft.EntityFrameworkCore;

namespace hhClientWebApp.Controllers
{
    public class HomeController : Controller
    {

        Data data;
        string jsonString;

        public IActionResult Index()
        {
            using (var context = new HhContext())
            {
                bool res = context.Database.EnsureCreated();
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public IActionResult List()
		{
            SetData().Wait();

            using (var context = new HhContext())
            {
                context.Database.EnsureCreated();
                
                using (var transaction = context.Database.BeginTransaction())
                {
                    
                    var vacancy = context.Set<Vacancy>();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Vacancies] ON");
                    vacancy.AddRange(data.Vacancies);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Vacancies] OFF");

                    transaction.Commit();
                }

            }

            return Json(data);
		}

        /*
        private async Task<int> WriteData(Data data)
        {

        }

        private async Task<int> WriteRow(Vacancy vacancy)
        {

        }
        */

        private async Task SetData(){
            data = await GetDataAsync();
        }

		private async Task SetJson()
		{
            jsonString = await GetDataHh();
		}

        private async Task<Data> GetDataAsync(){
            var serializer = new DataContractJsonSerializer(typeof(Data));
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Add("User-Agent", "HH-User-Agent");
            var streamTask = client.GetStreamAsync("https://api.hh.ru/vacancies?page=0&per_page=50");
            return serializer.ReadObject(await streamTask) as Data;
        }

        private async Task<string> GetDataHh(){
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "HH-User-Agent");
            return await client.GetStringAsync("https://api.hh.ru/vacancies?page=0&per_page=50");
        }

    }
}
