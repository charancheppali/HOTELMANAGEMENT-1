using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusinessObject;
using PresentationLayer;

namespace PresentationLayer.Controllers
{
    public class GenderController : Controller
    {
        // GET: Gender
        public ActionResult Index()
        {
            GenderBusiness gb = new GenderBusiness();
            var genderList = gb.GetAllGenders();
            return View(genderList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GenderModel genderModel)
        {
            GenderBusiness genderBusiness = new GenderBusiness();
            genderBusiness.AddGender(genderModel);
            return RedirectToAction("index");
        }
        public ActionResult Edit(int Id)
        {
            GenderBusiness genderBusiness = new GenderBusiness();
            GenderModel genderModel = genderBusiness.GetGenderById(Id);
            return View(genderModel);
        }

        [HttpPost]
        public ActionResult Edit(GenderModel genderModel)
        {
            GenderBusiness genderBusiness = new GenderBusiness();
            genderBusiness.UpdateGender(genderModel);
            return RedirectToAction("index");
        }

        public ActionResult Delete(int Id)
        {
            GenderBusiness genderBusiness = new GenderBusiness();
            genderBusiness.DeleteGender(Id);
            return RedirectToAction("index");
        }
    }
}