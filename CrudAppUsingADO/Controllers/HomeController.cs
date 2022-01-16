using CrudAppUsingADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;


namespace CrudAppUsingADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> obj = db.GetEmployees();
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee Emp)
        {

            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext Context = new EmployeeDBContext();
                    bool check = Context.AddEmployee(Emp);
                    if (check == true)
                    {  
                        TempData["Insert Message"] = "data has been inserted successfully";
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
         
        }

        public ActionResult Edit(int Id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(modal => modal.Id == Id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int Id,Employee Emp)
        {

            if (ModelState.IsValid == true)
            {
                EmployeeDBContext Context = new EmployeeDBContext();
                bool check = Context.UpdateEmployee(Emp);
                if (check == true)
                {
                    TempData["UpdateMessage"] = "data has been Updated successfully";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(modal => modal.Id == Id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int Id, Employee Emp)
        {

                EmployeeDBContext Context = new EmployeeDBContext();
                bool check = Context.DeleteEmployee(Id);
                if (check == true)
                {
                    TempData["DeleteMessage"] = "data has been deleted successfully";
                    return RedirectToAction("Index");
                }
          
                return View();
        }
        public ActionResult Details(int Id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(modal => modal.Id == Id);
            return View(row);
        }

    }
}