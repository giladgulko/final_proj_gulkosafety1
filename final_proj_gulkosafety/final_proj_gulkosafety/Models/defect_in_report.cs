using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_proj_gulkosafety.Models
{
    public class defect_in_report
    {
        int report_num;
        int defects_num;
        DateTime fix_date;
        DateTime fix_time;
        string picture_link;
        int fix_status;
        string description;


        public int Report_num { get => report_num; set => report_num = value; }
        public int Defects_num { get => defects_num; set => defects_num = value; }
        public DateTime Fix_date { get => fix_date; set => fix_date = value; }
        public DateTime Fix_time { get => fix_time; set => fix_time = value; }
        public string Picture_link { get => picture_link; set => picture_link = value; }
        public int Fix_status { get => fix_status; set => fix_status = value; }
        public string Description { get => description; set => description = value; }

        public defect_in_report(int report_num, int defects_num, DateTime fix_date, DateTime fix_time, string picture_link, int fix_status, string description)
        {
            Report_num = report_num;
            Defects_num = defects_num;
            Fix_date = fix_date;
            Fix_time = fix_time;
            Picture_link = picture_link;
            Fix_status = fix_status;
            Description = description;
        }
        public defect_in_report()
        {

        }
    }
}