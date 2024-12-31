using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index() //Url : www.xyz.com/Employees/Index
        {
            List<Employee> objEmp = Employee.GetAllEmployees();
            return View(objEmp);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            //Employee objEmp = new Employee()
            //{
            //    Name = "Kartik",
            //    Basic = 100000,
            //    DeptNo = 10,
            //    EmpNo  = id
            //};

            Employee objEmp = new Employee();
            objEmp = Employee.GetSingleEmployee(id);
            return View(objEmp);
        }

        // GET: EmployeesController/Create
        //[HttpGet] //No need to metion explicityly for get methods => Default ACtion - Get
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create

        //Using IFormCollection
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create1(IFormCollection collection)
        {
            try
            {
                int EmpNo = Convert.ToInt32(collection["EmpNo"]);
                string? Name = collection["Name"];
                decimal Basic = Convert.ToDecimal(collection["Basic"]);
                int DeptNo = Convert.ToInt32(collection["DeptNo"]);

                Employee objEmp = new Employee()
                {
                    Basic = Basic,
                    DeptNo = DeptNo,
                    EmpNo = EmpNo,
                    Name = Name
                };

                Employee.InsertUsingStoredProcedure(objEmp);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Using Request Parameters
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2(String Name, int EmpNo, decimal Basic, int DeptNo)
        {
            try
            {


                //int EmpNo = Convert.ToInt32(collection["EmpNo"]);
                //string? Name = collection["Name"];
                //decimal Basic = Convert.ToDecimal(collection["Basic"]);
                //int DeptNo = Convert.ToInt32(collection["DeptNo"]);

                Employee objEmp = new Employee()
                {
                    Basic = Basic,
                    DeptNo = DeptNo,
                    EmpNo = EmpNo,
                    Name = Name
                };

                Employee.InsertUsingStoredProcedure(objEmp);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Using Model Object Binding
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee objEmp)
        {
            try
            {

                //int EmpNo = Convert.ToInt32(collection["EmpNo"]);
                //string? Name = collection["Name"];
                //decimal Basic = Convert.ToDecimal(collection["Basic"]);
                //int DeptNo = Convert.ToInt32(collection["DeptNo"]);

                //Employee objEmp = new Employee()
                //{
                //    Basic = Basic,
                //    DeptNo = DeptNo,
                //    EmpNo = EmpNo,
                //    Name = Name
                //};

                Employee.InsertUsingStoredProcedure(objEmp);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee objEmp = Employee.GetSingleEmployee(id);
            return View(objEmp);
            
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Employee objEmp = new Employee()
                {
                    EmpNo = id,
                    Basic = Convert.ToDecimal(collection["Basic"]),
                    DeptNo = Convert.ToInt32(collection["DeptNo"]),
                    Name = collection["Name"]
                };

                Employee.InsertUsingStoredProcedure(objEmp);

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
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
