using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        //localhost:1234/Employees/Index

        public ActionResult Index()
        {
            List<Employee> employees = Employee.GetAllEmployees();
            return View(employees);
        }

        // GET: EmployeesController/Details/5
        //localhost:1234/Employees/Details/1
        public ActionResult Details(int id)
        {
            //Employee obj = new Employee();
            //obj.EmpNo = id;
            //obj.Name = "Afnan";
            //obj.Basic = 100000;
            //obj.DeptNo = 10;
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // GET: EmployeesController/Create

        public ActionResult Create()
        {
            
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //ModelBinding
        //public ActionResult Create(IFormCollection collection, string Name, int EmpNo, decimal Basic, int DeptNo, Employee obj)
        public ActionResult Create(Employee obj)
        {
            try
            {
                Employee.Insert(obj);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //using Binding - variable name must be same as HTML control name
        public ActionResult Create1(IFormCollection collection,string Name,int EmpNo, decimal Basic, int DeptNo)
        {
            try
            {
                //string name = collection["Name"];
                //string empno = collection["EmpNo"];
                //string basic = collection["Basic"];
                //string deptno = collection["DeptNo"];

                //Employee obj = new Employee();
                //obj.EmpNo = Convert.ToInt32(EmpNo);
                //Employee.Insert(obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //using IFormCollection
        public ActionResult Create2(IFormCollection collection)
        {
            try
            {
                string name = collection["Name"];
                string empno = collection["EmpNo"];
                string basic = collection["Basic"];
                string deptno = collection["DeptNo"];

                Employee obj = new Employee();
                obj.EmpNo = Convert.ToInt32(empno);

                Employee.Insert(obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                Employee.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
