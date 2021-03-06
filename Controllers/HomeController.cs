﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CounterApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CounterApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CounterContext _context;
        private readonly static string _itemName = "newSession";

        public HomeController(CounterContext counterContext) 
        {
            _context = counterContext;
        }
        
        public IActionResult Index()
        { 
            Counter counter = adjustCount(); 
            return View(counter);
        }

        public IActionResult About()
        {
            Counter counter = adjustCount(); 
            ViewData["Message"] = "Your application description page.";
            return View(counter);
        }

        public IActionResult Contact()
        {
            Counter counter = adjustCount();
            ViewData["Message"] = "Your contact page.";
            return View(counter);
        }
        private Counter adjustCount() {
            Counter counter = new Counter();
            if(HttpContext.Items[_itemName].ToString().Equals("Y")) {
                counter.count = _context.Counters.Count() + 1;
                _context.Add(counter);
                _context.SaveChanges();
            }
            counter = _context.Counters.LastOrDefault();    
            return counter; 
        }
    }
}
