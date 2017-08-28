﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hhClientWebApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;

namespace hhClientWebApp.Controllers
{
    public class HomeController : Controller
    {
        private Data data;

        public IActionResult Index()
        {
            SetData().Wait();
            return View(data);
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

        private async Task SetData(){
            data = await GetDataAsync();
        }

        private async Task<Data> GetDataAsync(){
            var serializer = new DataContractJsonSerializer(typeof(Data));
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Add("User-Agent", "HH-User-Agent");
            var streamTask = client.GetStreamAsync("https://api.hh.ru/vacancies?page=0&per_page=50");
            return serializer.ReadObject(await streamTask) as Data;
        }

    }
}