using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeRecordApp.Models;

namespace EmployeeRecordApp.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDataEntities entities = new EmployeeDataEntities();
        
        public ActionResult List(string Option, string search)
        {
            if (Option== "Age")
            {
                int age = Convert.ToInt32(search);
                return View(entities.Employees.Where(x => x.Age == age || search== null).ToList());

            }
            else if (Option== "Salary")

            {
                int salary = Convert.ToInt32(search);
                return View((entities.Employees.Where(x => x.Salary == salary|| search== null)).ToList());
            }
            else if (Option == "Location")

            {
                return View((entities.Employees.Where(x => x.Location == search|| search == null)).ToList());
            }
            else
            {
                return View(entities.Employees.ToList());
            }
        
        }
 
    
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
                {
                entities.Employees.Add(employee);
                entities.SaveChanges();
                return View("AddedNewRecord");
            }
            else
            {
                return View("Error");
            }
            
        }

        public ActionResult Delete(int? id)
        {
            Employee employee = entities.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee employee = entities.Employees.Find(id);
            entities.Employees.Remove(employee);
            entities.SaveChanges();
            return View ("Success");
        }

    }
}