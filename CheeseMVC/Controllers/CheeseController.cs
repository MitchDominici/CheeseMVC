using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CheeseMVC.Controllers
{
    
    public class CheeseController : Controller
    {
  
        private static Dictionary<string, string> cheeses = new Dictionary<string, string>();

        public static string cheese { get; private set; }

        public IActionResult Index()
        {
            
            ViewBag.cheeses = cheeses;

            return View();

        }

        public IActionResult Add()
        {
            
            return View();
        }
        
        [Route("/cheese/add")]
        [HttpPost]
        public IActionResult NewCheese(string name, string description)
        {
            
            cheeses.Add(name, description);
            return Redirect("/cheese");
        }
        [HttpGet]
        public IActionResult Remove()
        {
            ViewBag.cheeses = cheeses;
            return View();
        }

        [Route("/cheese/remove")]
        [HttpPost]
        public IActionResult RemoveCheese(string cheese )
        {
            
            cheeses.Remove(cheese);
            return Redirect("Index");
        }
 
    }
}
