using final_proj_gulkosafety.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace final_proj_gulkosafety.Controllers
{
    public class reportController : ApiController
    {
        public List<report> GetProjectReports(int proj_num)
        { 
            report r = new report();
            List<report> reprotList = r.ReadReport(proj_num);
            return reprotList;
        }
        // POST api/<controller>
      //  public void Post([FromBody] report r)
       // {
        //    r.InsertReport();
      //  }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}