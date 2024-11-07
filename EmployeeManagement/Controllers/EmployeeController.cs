using System.Web.Mvc;
using System.Collections.Generic;
using EmployeeManagement.Models;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeDAL employeeDAL = new EmployeeDAL();

        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> employees = employeeDAL.GetAllEmployees();
            return View(employees);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                employeeDAL.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }


        public ActionResult Edit(int id)
        {
            Employee emp = employeeDAL.GetAllEmployees().Find(e => e.EmployeeID == id);
            return View(emp);
        }


        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                employeeDAL.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }


        public ActionResult Delete(int id)
        {
            employeeDAL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
