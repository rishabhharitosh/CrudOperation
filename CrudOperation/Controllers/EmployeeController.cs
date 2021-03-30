using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmpContext _Db;
        public EmployeeController(EmpContext db)
        {
            _Db = db;
        }
        public IActionResult EmployeeList()
        {
            try
            {
                var EmployeeList = from a in _Db.tbl_Employee
                                   join b in _Db.tbl_Department
                                   on a.ID equals b.ID
                                   into Dep
                                   from b in Dep.DefaultIfEmpty()

                                   select new Employee
                                   {
                                       ID = a.ID,
                                       Name=a.Name,
                                       Mobile=a.Mobile,
                                       Email=a.Email,
                                       DepartmentID=a.DepartmentID,
                                       Description=a.Description,
                                       Department =b==null?"":b.Department
                                   };

                return View(EmployeeList);
            }
            catch(Exception ex)
            {
                return View();
            }
            
        }

        public IActionResult Create(Employee emp)
        {
            loadDDL();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee emp)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (emp.ID == 0)
                    {
                        _Db.tbl_Employee.Add(emp);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(emp).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();

                    }
                    return RedirectToAction("EmployeeList");
 
                }
                return View();
            }
            catch(Exception e)
            {
                return RedirectToAction("EmployeeList");
            }
        }
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                var empl =await _Db.tbl_Employee.FindAsync(id);
                if(empl!=null)
                {
                    _Db.tbl_Employee.Remove(empl);
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("EmployeeList");
            }
            catch(Exception ex)
            {
                return RedirectToAction("EmployeeList");
            }
        }
        private void loadDDL()
        {
            try
            {
                List<Departments> DList = new List<Departments>();
                DList = _Db.tbl_Department.ToList();
                DList.Insert(0, new Departments { ID = 0, Department = "please select" });
                ViewBag.dlist = DList;
            }
            catch(Exception ec)
            {

            }
        }

    }
}
