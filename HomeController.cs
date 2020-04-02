﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AskSprint1_1.Models;
using Npgsql;

namespace AskSprint1_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var connString = "Host=localhost;Username=postgres;Password=admin;Database=test2";
            var conn = new NpgsqlConnection(connString);
            using (var cmd = new NpgsqlCommand("SELECT * from fridge", conn))
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.NextResult())
                {
                    var fridgeId = reader["fridge_id"];
                    var fridgeName = reader["fridge_name"];
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}