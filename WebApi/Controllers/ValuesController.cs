using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeClass;
namespace WebApi.Controllers
{
    // [Authorize]
    public class ValuesController : ApiController
    {
        [HttpGet]
        // GET api/values
        public IEnumerable<employee> Get()
        {
            using (EmployeeDBEntities ABC = new EmployeeDBEntities())
                return ABC.employees.ToList();
        }
        [HttpGet]
        // GET api/values/5
        public IEnumerable<employee> Get(int id)
        {
            using (EmployeeDBEntities ABC = new EmployeeDBEntities())
                yield return ABC.employees.FirstOrDefault(x => x.UserID == id);
        }
        [HttpPost]
        // POST api/values
        public void Post([FromBody]employee value)
        {
            using (EmployeeDBEntities ABC = new EmployeeDBEntities())
            {
                ABC.employees.Add(value);
                ABC.SaveChanges();
            }
        }
        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]employee value)
        {
            //using (EmployeeDBEntities ABC = new EmployeeDBEntities())
            //{
            //    ABC.employees.a(value);
            //    abc.savechanges();
            //}
        }
        [HttpDelete]
        // DELETE api/values/5
        public void Delete(int value)
        {
            using (EmployeeDBEntities ABC = new EmployeeDBEntities())
            {
                ABC.employees.Remove(ABC.employees.FirstOrDefault(x => x.UserID == value));
                ABC.SaveChanges();
            }
        }
    }
}
