using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoxProblem.Data;
using BoxProblem.Services;

namespace BoxProblem. Controllers
{
    public class BoxController : Controller
    {

private BoxService service;

        public BoxController(ApplicationDbContext context)
        {
            service = new BoxService(context);
        }


        // GET: Employees
        public ActionResult Index(String searchBy, int search)
        {
            if (searchBy == "Cost"){
                List<BoxInventory> allBoxes = service.GetAllBoxes();
                return View(allBoxes.Where(x => (x.Cost == search || search == 0)).ToList());
            }else{
                if (searchBy == "Weight")
                {
                    List<BoxInventory> allBoxes = service.GetAllBoxes();
                    return View(allBoxes.Where(x => (x.Weight == search || search == 0)).ToList());
                }
                else
                {
                    if (searchBy == "Volume")
                    {
                        List<BoxInventory> allBoxes = service.GetAllBoxes();
                        return View(allBoxes.Where(x => (x.Volume == search || search == 0)).ToList());
                    }
                    else
                    {
                        return View(service.GetAllBoxes());
                    }
                }
            }
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoxInventory box)
        {
            if (ModelState.IsValid)
            {
                service.AddBox(box);
                return RedirectToAction("Index");
            }

            return View(box);
        }


       
        public ActionResult Edit(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            return View(box);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BoxInventory box)
        {
            if (ModelState.IsValid)
            {
                service.SaveEdits(box);
                return RedirectToAction("Index");
            }
            return View(box);
        }
   
        public ActionResult Delete(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            return View(box);
        }
        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            service.Delete(box);
            return RedirectToAction("Index");
        }
    }
}