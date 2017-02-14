using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotingDojo.Factory;
using quotingDojo.Models;

namespace quotingDojo.Controllers{
    public class QuotesController : Controller{

        private readonly QuoteFactory quoteFactory;
        public QuotesController(){
            quoteFactory = new QuoteFactory();
        }



        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            // ViewBag.AllQuotes = quoteFactory.GetAll();
            ViewBag.errors = new List<Quote>();
            return View("Index");
        }

        // GET: /Quotes/
        [HttpGet]
        [Route("Quotes")]
        public IActionResult Quotes(){
            ViewBag.AllQuotes = quoteFactory.GetAll();
            return View();
        }



        // GET: /AddQuote/
        [HttpPost]
        [Route("AddQuote")]
        public IActionResult AddQuote(Quote NewQuote){
            if(ModelState.IsValid){
                quoteFactory.AddQuote(NewQuote);
                return RedirectToAction("Quotes");
            } else {
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
        }
    }
}
