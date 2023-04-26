using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPASEX1.Models;

namespace MVCPASEX1.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
       public ActionResult AddDepartment()
        {
            Department d = new Department();
            DepartmentRepo dr = new DepartmentRepo();
            //string dnoid=dr.getdeptid();
            d.dno =Convert.ToInt32(dr.getdeptid());
            return View(d);
        }

        [HttpPost]
        public ActionResult AddDepartment(Department d)
       {
            
            if(ModelState.IsValid)
            {
                DepartmentRepo dr = new DepartmentRepo();
                try
                {
                    dr.AddDept(d);
                }
                catch
                {
                    ViewBag.Message = String.Format("Id Already Used");
                    return RedirectToAction("AddDepartment");
                }
                return RedirectToAction("DepartmentDetails");
            }
            return View();
       }


        public ActionResult DepartmentDetails()
        {
            DepartmentRepo dr = new DepartmentRepo();
            ModelState.Clear();
            return View(dr.ShowDept());
        }



        public ActionResult EditDepartment(int id)
        {

            DepartmentRepo dr = new DepartmentRepo();
            return View(dr.ShowDept().Find(dept => dept.dno == id));
        }

        [HttpPost]
        public ActionResult EditDepartment(int id,Department d)
        {
            if(ModelState.IsValid)
            {
                DepartmentRepo dr = new DepartmentRepo();
                dr.UpdateDept(d);
                return RedirectToAction("DepartmentDetails");
            }
            return View();
        }



        public ActionResult DeleteDeptdetails(int id)
        {
             if(ModelState.IsValid)
             {
                 DepartmentRepo dr = new DepartmentRepo();
                 dr.DeleteDept(id);
                 return RedirectToAction("DepartmentDetails");
             }
             return View();
        }
	}
}