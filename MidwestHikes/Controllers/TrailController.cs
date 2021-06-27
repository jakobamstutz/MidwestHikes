using MidwestHikes.Models;
using MidwestHikes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidwestHikes.Controllers
{
    public class TrailController : Controller
    {
        private TrailService _trailService = new TrailService();
        public ActionResult Index()
        {
            var model = _trailService.GetTrails();
            return View(model);
        }
        public ActionResult Create()
        {
            //call a method in service to return model
            //receive view from service and return view with this model that includes list
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrailCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_trailService.CreateTrail(model))
            {
                TempData["SaveResult"] = "Trail was added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Trail could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _trailService.GetTrailById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = _trailService.GetTrailById(id);
            var model =
                new TrailEdit
                {
                    TrailId = detail.TrailId,
                    TrailName = detail.TrailName,
                    TrailDesc = detail.TrailDesc

                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrailEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.TrailId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_trailService.UpdateTrail(model))
            {
                TempData["SaveResult"] = "Your Trail was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Trail could not be updated.");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _trailService.GetTrailById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTrail(int id)
        {
            _trailService.DeleteTrail(id);
            TempData["SaveResult"] = "The trail was deleted";
            return RedirectToAction("Index");
        }


    }
}