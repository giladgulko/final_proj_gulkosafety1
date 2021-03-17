using final_proj_gulkosafety.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace final_proj_gulkosafety.Controllers
{
    public class userController : ApiController
    {
        // GET all users api/<controller>
        public List<user> Get()
        {
            user u = new user();
            List<user> uList = u.Read();
            return uList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST one project api/<controller>
        public void Post([FromBody] user u)
        {
            u.Insert();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [Route("api/user/{manager_email}/{Foreman_email}/{proj_num}")]
        [HttpGet]
        public List<user> Get(string Manager_email, string Foreman_email, int proj_num)
        {
            user p = new user();
            return p.Read_user_in_project(Manager_email, Foreman_email, proj_num);
        }

    }
}