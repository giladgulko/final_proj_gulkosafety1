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
        //get all project's reports
        public List<report> Get(int proj_num)
        {
            report r = new report();
            List<report> reprotList = r.ReadReport(proj_num);
            return reprotList;
        }

        public void Post([FromBody] report r)
        {
            r.InsertReport();
        }

        public void DeleteReport([FromBody] report r)
        {
            r.DeleteReport(r.Report_num);
        }

        public void UpdateReport([FromBody] report r)
        {
            r.UpdateReport(r.Report_num,r.Date,r.Time,r.Comment,r.Grade,r.Project_num,r.User_mail);
        }
    }
}