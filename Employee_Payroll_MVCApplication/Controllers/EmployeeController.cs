using Employee_Payroll_MVCApplication.Models;
using Employee_Payroll_MVCApplication.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Payroll_MVCApplication.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Retrieve data from the dat base
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeList()
        {
            List<EmployeeDetailModel> list = GetAllEmployee();
            return View(list);
        }

        /// <summary>
        /// Get all Employees 
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDetailModel> GetAllEmployee()
        {
            try
            {
                List<EmployeeDetailModel> list = (from e in db.Employees
                                                  join d in db.Departments on e.DepartmentId equals d.DeptId
                                                  join s in db.Salaries on e.SalaryId equals s.SalaryId
                                                  select new EmployeeDetailModel
                                                  {
                                                      EmpId = e.EmpId,
                                                      Name = e.Name,
                                                      Gender = e.Gender,
                                                      DepartmentId = d.DeptId,
                                                      Department = d.DeptName,
                                                      SalaryId = s.SalaryId,
                                                      Amount = s.Amount,
                                                      StartDate = e.StartDate,
                                                      Description = e.Description
                                                  }).ToList<EmployeeDetailModel>();

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}