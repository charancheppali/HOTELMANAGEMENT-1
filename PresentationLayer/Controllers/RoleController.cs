using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusinessObject;

namespace PresentationLayer.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            RoleBussiness role = new RoleBussiness();
            var roleList = role.GetAllRoles();
            return View(roleList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoleModel roleModel)
        {
            RoleBussiness roleBussiness = new RoleBussiness();
            roleBussiness.AddRole(roleModel);
            return RedirectToAction("index");
        }
        public ActionResult Edit(int Id)
        {
            RoleBussiness roleBussiness = new RoleBussiness();
            RoleModel roleModel = roleBussiness.GetRoleModelById(Id);
            return View(roleModel);
        }
        [HttpPost]
        public ActionResult Edit(RoleModel roleModel)
        {
            RoleBussiness roleBussiness = new RoleBussiness();
            roleBussiness.UpdateRole(roleModel);
            return RedirectToAction("index");
        }
        public ActionResult Delete(int Id)
        {
            RoleBussiness roleBussiness = new RoleBussiness();
            roleBussiness.DeleteRole(Id);
            return RedirectToAction("index");
        }
    }
}