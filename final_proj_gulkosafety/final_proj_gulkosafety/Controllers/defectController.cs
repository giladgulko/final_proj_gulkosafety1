﻿using matanProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace matanProject.Controllers
{
    public class defectController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        public List<defect> Get()
        {
            defect _defect = new defect();
            return _defect.ReadDefect();
        }

        // POST api/<controller>
        public void Post([FromBody]defect _defect)
        {
            _defect.InsertDefect();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}