using System;
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
            
            //var conn = new NpgsqlConnection(connString);
            
            //conn.Close();
            return View();
        }

        public IActionResult Login()
        {

            return View();
        }
        public IActionResult LoginLab(string _username,string _password)
        {
            string connstring = string.Format("Server={0};Port={1};" +
                "User Id={2};Password={3};Database={4};",
                "localhost", "5432", "postgres", "8975kz9t", "askmate");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            NpgsqlCommand cmd;
            string sql;
            try
            {
                conn.Open();
                sql = @"select * from u_login(:_username,:_password)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_username",_username);
                cmd.Parameters.AddWithValue("_password",_password);
                int result = (int)cmd.ExecuteScalar();
                conn.Close();
                if (result==1)
                {
                    return Redirect("/Questions/All");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Something went wrong."+ex);
            }
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
