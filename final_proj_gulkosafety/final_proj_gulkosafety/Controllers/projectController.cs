﻿using final_proj_gulkosafety.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace final_proj_gulkosafety.Controllers
{
    public class projectController : ApiController
    {
        // GET all projects api/<controller>
        public List<project> Get()
        {
            project p = new project();
            List<project> pList = p.Read();
            return pList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST one project api/<controller>
        public void Post([FromBody] project p)
        {
            p.Insert();
        }

        // PUT api/<controller>/5
        public void Put([FromBody] project p)
        {
            p.UpdateProjectDeatails(p.Project_num, p.Name, p.Company, p.Address, p.Start_date, p.End_date, p.Status, p.Description, p.Safety_lvl, p.Project_type_num, p.Manager_email, p.Foreman_email);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    }
}