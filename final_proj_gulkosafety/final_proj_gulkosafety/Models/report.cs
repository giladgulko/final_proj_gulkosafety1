﻿using final_proj_gulkosafety.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_proj_gulkosafety.Models
{
    public class report
    {
        int report_num;
        DateTime date;
        DateTime time;
        string comment;
        double grade;
        string user_mail;
        int project_num;
        List<defect> defectsList;



        public int Report_num { get => report_num; set => report_num = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime Time { get => time; set => time = value; }
        public string Comment { get => comment; set => comment = value; }
        public double Grade { get => grade; set => grade = value; }
        public string User_mail { get => user_mail; set => user_mail = value; }
        public int Project_num { get => project_num; set => project_num = value; }
        public List<defect> DefectsList { get => defectsList; set => defectsList = value; }


        public report(int report_num, DateTime date, DateTime time, string comment, double grade, string user_mail, int project_num, List<defect> defectsList )
        {
            Report_num = report_num;
            Date = date;
            Time = time;
            Comment = comment;
            Grade = grade;
            User_mail = user_mail;
            Project_num = project_num;
            DefectsList = defectsList;
        }

        public report()
        {

        }

        //public void InsertReport()
        //{
        //    DBServices dbs = new DBServices();
        //    dbs.InsertReport(this);
        //}

        public List<report> ReadReport(int proj_num)
        {
            DBServices dbs = new DBServices();
            List<report> reportList = dbs.ReadReport(proj_num);
            return reportList;
        }

    }
}