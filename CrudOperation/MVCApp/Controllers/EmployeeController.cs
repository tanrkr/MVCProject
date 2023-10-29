using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyDB;
namespace MVCApp.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (CrudEntities dc = new CrudEntities())
            {
                return dc.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (CrudEntities dc = new CrudEntities())
            {
                return dc.Employees.FirstOrDefault(p => p.EmpID == id);
            }
        }
        public void Post([FromBody] Employee emp)
        {
            using (CrudEntities dc = new CrudEntities())
            {
                dc.Employees.Add(emp);
                dc.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (CrudEntities dc = new CrudEntities())
            {
                var Data= dc.Employees.FirstOrDefault(p => p.EmpID == id);
                if (Data != null) 
                {
                    dc.Employees.Remove(Data);
                    dc.SaveChanges();
                }
            }
        }
        public void Put(int id,[FromBody] Employee emp)
        {
           
            using (CrudEntities dc = new CrudEntities())
            {
                var Data = dc.Employees.FirstOrDefault(p => p.EmpID == id);
                if (Data != null)
                {
                   
                    Data.EmpName = emp.EmpName;
                    Data.Address = emp.Address;
                    Data.MaritalStatus = emp.MaritalStatus; 
                    dc.SaveChanges();
                }
              
            }
        }

    }
}
