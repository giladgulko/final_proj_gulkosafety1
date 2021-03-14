using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_proj_gulkosafety.Models
{
    public class Class1
    {
        int age;
        string name;

        public Class1(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
    }
}