using MidwestHikes.Data;
using MidwestHikes.Models;
using MidwestHikes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidwestHikes.Controllers
{
    
    public class ParkController : Controller
    {
        private ParkService _parkService = new ParkService();
        public ActionResult Index()
        {
            var model = _parkService.GetParks();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Park";
            List<state> GetStatesList = (new StateService()).GetStatesList().ToList();

            var query = from s in GetStatesList
                        select new SelectListItem()
                        {
                            Value = s.StateId.ToString(),
                            Text = s.StateName
                        };
            ViewBag.StateId = query.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParkCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_parkService.CreatePark(model))
            {
                TempData["SaveResult"] = "Park was added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Park could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _parkService.GetParkById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = _parkService.GetParkById(id);
            var model =
                new ParkEdit
                {
                    ParkId = detail.ParkId,
                    ParkName = detail.ParkName
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ParkEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ParkId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
           
            if (_parkService.UpdatePark(model))
            {
                TempData["SaveResult"] = "Your Park was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Park could not be updated.");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _parkService.GetParkById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePark(int id)
        {
            _parkService.DeletePark(id);
            TempData["SaveResult"] = "The park was deleted";
            return RedirectToAction("Index");
        }


    }
}