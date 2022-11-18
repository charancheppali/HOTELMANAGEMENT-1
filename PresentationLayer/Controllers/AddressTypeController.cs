using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusinessObject;

namespace PresentationLayer.Controllers
{
    public class AddressTypeController : Controller
    {
        // GET: AddressType
        public ActionResult Index()
        {
            AddressTypeBusiness atb = new AddressTypeBusiness();

            var addressTypeList = atb.GetAllAddressTypes();

            return View(addressTypeList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddressTypeModel atm)
        {
            AddressTypeBusiness atb = new AddressTypeBusiness();
            atb.AddAddressType(atm);
            return RedirectToAction("index");
        }
        public ActionResult Edit(int Id)
        {
            AddressTypeBusiness atb = new AddressTypeBusiness();
            AddressTypeModel addressTypeModel = atb.GetAddressTypeById(Id);
            return View(addressTypeModel);
        }
        [HttpPost]
        public ActionResult Edit(AddressTypeModel addressTypeModel)
        {
            AddressTypeBusiness atb = new AddressTypeBusiness();
            atb.UpdateAddressType(addressTypeModel);
            return RedirectToAction("index");
        }
        public ActionResult Delete(int Id)
        {
            AddressTypeBusiness atb = new AddressTypeBusiness();
            atb.DeleteAddressType(Id);
            return RedirectToAction("index");
        }
    }
}