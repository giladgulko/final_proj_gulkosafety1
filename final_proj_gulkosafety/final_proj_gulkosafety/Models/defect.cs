using matanProject.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matanProject.Models
{
    public class defect
    {
        int defects_num;
        string name;
        float grade;
        int defect_type_num;


        public int Defects_num { get => defects_num; set => defects_num = value; }
        public string Name { get => name; set => name = value; }
        public float Grade { get => grade; set => grade = value; }
        public int Defect_type_num { get => defect_type_num; set => defect_type_num = value; }

        public defect(int defects_num, string name, float grade, int defect_type_num)
        {
            Defects_num = defects_num;
            Name = name;
            Grade = grade;
            Defect_type_num = defect_type_num;
        }

        public defect()
        {

        }

        public void InsertDefect()
        {
            DBServices dbs = new DBServices();
            dbs.InsertDefect(this);
        }

        public List<defect> ReadDefect()
        {
            DBServices dbs = new DBServices();
            List<defect> defectList = dbs.ReadDefect();
            return defectList;
        }
    }
}