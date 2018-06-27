using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoxProblem.Data;
using BoxProblem.Services;

namespace BoxProblem.Controllers
{
    public class BoxController : Controller
    {
        private BoxService service;

        public BoxController(ApplicationDbContext context)
        {
            service = new BoxService(context);
        }


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            return View(box);
        }
    }
}