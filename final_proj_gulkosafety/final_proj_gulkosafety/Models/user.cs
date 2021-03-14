using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_proj_gulkosafety.Models
{
    public class user
    {
        string email;
        string name;
        string phone;
        string password;
        int user_type_num;

        public user(string email, string name, string phone, string password, int user_type_num)
        {
            Email = email;
            Name = name;
            Phone = phone;
            Password = password;
            User_type_num = user_type_num;
        }

        public string Email { get => email; set => email = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Password { get => password; set => password = value; }
        public int User_type_num { get => user_type_num; set => user_type_num = value; }

        public user() { }

        public List<user> Read()
        {
            DBServices dbs = new DBServices();
            return dbs.ReadUsers();
        }

        public void Insert()
        {
            DBServices dbs = new DBServices();
            dbs.InsertUser(this);
        }
    }
}