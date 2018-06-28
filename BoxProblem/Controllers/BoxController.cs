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
        public ActionResult Index(String searchBy,double search)
        {
            List<BoxInventory> allBoxes = service.GetAllBoxes();
            double error = 1.0;
            if (!(searchBy == null))
            {
                switch (searchBy)
                {
                    case "All":
                        return View(allBoxes);
                    case "Cost":
                        return View(allBoxes.Where(x => (Math.Abs((double)x.Cost - Math.Abs(search)) < error)).ToList());
                    case "Weight":
                        return View(allBoxes.Where(x => (x.Weight == (int)search)).ToList());
                    case "Volume":
                        return View(allBoxes.Where(x => (x.Volume == (int)search)).ToList());
                    case "InventoryCount":
                        return View(allBoxes.Where(x => (x.InventoryCount == (int)search)).ToList());
                    case "hasLiquid":
                        return View(allBoxes.Where(x => (x.CanHoldLiquid == true)).ToList());
                    case "noLiquid":
                        return View(allBoxes.Where(x => (x.CanHoldLiquid == false)).ToList());
                    default:
                        return View(allBoxes);
                }
            }else{
                return View(allBoxes);
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