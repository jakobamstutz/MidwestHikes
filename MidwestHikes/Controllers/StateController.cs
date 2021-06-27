using Microsoft.AspNet.Identity;
using MidwestHikes.Models;
using MidwestHikes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidwestHikes.Controllers
{
    public class StateController : Controller
    {
        private StateService _stateService = new StateService();
        public ActionResult Index()
        {
            var model = _stateService.GetStates();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StateCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_stateService.CreateState(model))
            {
                TempData["SaveResult"] = "State was added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "State could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _stateService.GetStateById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = _stateService.GetStateById(id);
            var model =
                new StateEdit
                {
                    StateId = detail.StateId,
                    StateName = detail.StateName
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StateEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.StateId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_stateService.UpdateState(model))
            {
                TempData["SaveResult"] = "Your state was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your state could not be updated.");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _stateService.GetStateById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteState(int id)
        {
            _stateService.DeleteState(id);
            TempData["SaveResult"] = "The state was deleted";
            return RedirectToAction("Index");
        }

        
    }
}