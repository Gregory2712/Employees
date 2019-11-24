using Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employees.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeDBContext EC = new EmployeeDBContext();
            var EmployeeList = EC.Employees.OrderBy(x => x.LastName).ToList();
            return View(EmployeeList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee NewEmployee)
        {
            if (ModelState.IsValid)
            {
                EmployeeDBContext EC = new EmployeeDBContext();
                EC.Employees.Add(NewEmployee);
                EC.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            else
                return View();
            
        }

        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            EmployeeDBContext EC = new EmployeeDBContext();
            Employee EmpToChange = EC.Employees.First(x => x.Id == id);
            return View(EmpToChange);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee EmpToEdit)
        {
            if (ModelState.IsValid)
            {
                EmployeeDBContext EC = new EmployeeDBContext();
                Employee EmpToChange = EC.Employees.First(x => x.Id == EmpToEdit.Id);
                EmpToChange.Email = EmpToEdit.Email;
                EmpToChange.FirstName = EmpToEdit.FirstName;
                EmpToChange.LastName = EmpToEdit.LastName;
                EmpToChange.Phone = EmpToEdit.Phone;
                EC.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            else
                return View();

        }
        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            EmployeeDBContext EC = new EmployeeDBContext();
            Employee EmpToDelete = EC.Employees.First(x => x.Id == id);

            return View(EmpToDelete);
        }
        [HttpPost]
        public ActionResult DeleteEmployee(Employee EmpToDelete1)
        {
            EmployeeDBContext EC = new EmployeeDBContext();
            Employee EmpToDelete = EC.Employees.First(x => x.Id == EmpToDelete1.Id);
            EC.Employees.Remove(EmpToDelete);
            EC.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DetailsEmployee(int id)
        {
            EmployeeDBContext EC = new EmployeeDBContext();
            Employee EmpDetails = EC.Employees.First(x => x.Id == id);
            
            
            return View(EmpDetails);
        }

    }
}