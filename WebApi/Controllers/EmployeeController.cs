using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeClass;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public List<employee> Get()

        {

            using (EmployeeDBEntities entity = new EmployeeDBEntities())
            {


                return entity.employees.ToList();
               

            }




        }
        [HttpGet]
        
        public employee Get(int id)

        {
            using (EmployeeDBEntities entity = new EmployeeDBEntities())

            {
                return entity.employees.FirstOrDefault(x => x.UserID == id);

            }
        }
        [HttpPost]
        public void Post([FromBody]employee value)
        {
            using (EmployeeDBEntities entity = new EmployeeDBEntities())
            {
                var emp = new employee()

                {
                    Name = value.Name,
                    Designation = value.Designation,
                    UserID = value.UserID,
                    Department = value.Department
                };
                entity.employees.Add(emp);
                entity.SaveChanges();
            }
        }

        [HttpPut]
        public void Put(int id, [FromBody]employee value)
        {
            using (EmployeeDBEntities entity = new EmployeeDBEntities())
            {
                var ent = entity.employees.FirstOrDefault(x => x.UserID == id);

                ent.Department = value.Department;
                ent.Designation = value.Designation;
                ent.Name = value.Name;

                entity.SaveChanges();
            }

        }
        [HttpDelete]
        public void Delete (int id)
        {
            using (EmployeeDBEntities ABV = new EmployeeDBEntities())
            {
                ABV.employees.Remove(ABV.employees.FirstOrDefault(x => x.UserID == id));

                ABV.SaveChanges();

            }


        }
    }

}
