using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace final_proj_gulkosafety.Models.DAL
{
    public class DBServices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {
            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }
        //insert a new user
        public int InsertUser(user _user)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            String cStr = BuildInsertCommand(_user);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildInsertCommand(user _user)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}', '{4}')", _user.Email, _user.Name, _user.Phone, _user.Password, _user.User_type_num);
            String prefix = "INSERT INTO user " + "(email,name,phone,password,user_type_num)";
            command = prefix + sb.ToString();

            return command;

        }
        //insert a new defect
        public int InsertDefect(defect def)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            String cStr = BuildInsertCommand(def);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildInsertCommand(defect _defect)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}')", _defect.Name, _defect.Grade, _defect.Defect_type_num);
            String prefix = "INSERT INTO defect " + "(name, grade,defect_type_num)";
            command = prefix + sb.ToString();

            return command;

        }
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }


        // get all defect
        public List<defect> ReadDefect()
        {
            SqlConnection con = null;
            List<defect> defectList = new List<defect>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM defect";
                SqlCommand cmd = new SqlCommand(selectSTR, con);


                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    defect _defect = new defect();
                    _defect.Defect_num = Convert.ToInt32(dr["defect_num"]);
                    _defect.Name = (string)dr["name"];
                    _defect.Grade = Convert.ToDouble(dr["grade"]);
                    _defect.Defect_type_num = Convert.ToInt32(dr["defect_type_num"]);

                    defectList.Add(_defect);
                }

                return defectList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }
        //update project user
        public int UpdateProjectUser(int proj_num, string manager_email, string foreman_email)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString");
            }
            catch (Exception)
            {
                throw new Exception("The connection to sever is not good");
            }

            String cStr = BuildupdateCommand(proj_num, manager_email, foreman_email);

            cmd = CreateCommand(cStr, con);

            try
            {
                int numEffected = cmd.ExecuteNonQuery();
                return numEffected;
            }
            catch (Exception)
            {
                throw new Exception("The update project user failed");
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }

        private String BuildupdateCommand(int proj_num, string manager_email, string foreman_email)
        {
            String command;
            command = "UPDATE project SET manager_email='" + manager_email + "'foreman_email='" + foreman_email + "'WHERE project_num ='" + proj_num;

            return command;
        }



        //update project detail
        public int UpdateProjectDeatails(int proj_num, string name, string company, string address, DateTime start_date, DateTime end_date, int status, string description, double safety_lvl, int project_type_num, string manager_email, string foreman_email)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString");
            }
            catch (Exception)
            {
                throw new Exception("The connection to sever is not good");
            }

            String cStr = BuildupdateCommand(proj_num, name, company, address, start_date, end_date, status, description, safety_lvl, project_type_num, manager_email, foreman_email);

            cmd = CreateCommand(cStr, con);

            try
            {
                int numEffected = cmd.ExecuteNonQuery();
                return numEffected;
            }
            catch (Exception)
            {
                throw new Exception("The update of project details failed");
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }

        private String BuildupdateCommand(int proj_num, string name, string company, string address, DateTime start_date, DateTime end_date, int status, string description, double safety_lvl, int project_type_num, string manager_email, string foreman_email)
        {
            String command;
            command = "UPDATE project SET name='" + name + "'company='" + company + "'address='" + address + "'start_date='" + start_date + "'end_date='" + end_date + "status=" + status + "description='" + description + "safety_lvl=" + safety_lvl + "project_type_num=" + project_type_num + "manager_email='" + manager_email + "'foreman_email='" + foreman_email + "'WHERE project_num =" + proj_num;

            return command;
        }
        //update project status
        public int UpdateProjectStatus(int proj_num, int status)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString");
            }
            catch (Exception)
            {
                throw new Exception("The connection to sever is not good");
            }

            String cStr = BuildupdateCommand(proj_num, status);

            cmd = CreateCommand(cStr, con);

            try
            {
                int numEffected = cmd.ExecuteNonQuery();
                return numEffected;
            }
            catch (Exception)
            {
                throw new Exception("The update of project status failed");
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }
        private String BuildupdateCommand(int proj_num, int status)
        {
            String command;
            command = "UPDATE project SET status=" + status + "WHERE project_num =" + proj_num;

            return command;
        }

        //returns all projects
        public List<project> ReadProjects()
        {
            SqlConnection con = null;
            List<project> projectList = new List<project>();

            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "";

                selectSTR = "select * from project";



                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    project p = new project();

                    p.Project_num = Convert.ToInt32(dr["project_num"]);
                    p.Name = (string)dr["name"];
                    p.Company = (string)dr["company"];
                    p.Address = (string)dr["address"];
                    p.Start_date = Convert.ToDateTime(dr["start_date"]);
                    p.End_date = Convert.ToDateTime(dr["end_date"]);
                    p.Status = Convert.ToInt32(dr["status"]);
                    p.Description = (string)dr["description"];
                    p.Safety_lvl = Convert.ToDouble(dr["safety_lvl"]);
                    p.Project_type_num = Convert.ToInt32(dr["project_type_num"]);
                    p.Manager_email = (string)dr["manager_email"];
                    p.Foreman_email = (string)dr["foreman_email"];

                    projectList.Add(p);


                }

                return projectList;
            }
            catch (Exception)
            {
                // write to log
                throw new Exception("Can not read projects");
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }
        //return all users in project
        public List<user> Read_user_in_project(string manager_email, string foreman_email)
        {
            SqlConnection con = null;
            List<user> userList = new List<user>();

            try
            {
                con = connect("DBConnectionString");

                String selectSTR = "  select * from [user]  WHERE email='" + manager_email + "' or email='" + foreman_email + "'";

                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    user user_proj = new user();

                    user_proj.Email = (string)dr["email"];
                    user_proj.Name = (string)dr["name"];
                    user_proj.Phone = (string)dr["phone"];
                    user_proj.Password = (string)dr["password"];
                    user_proj.User_type_num = Convert.ToInt32(dr["user_type_num"]);
                    userList.Add(user_proj);

                }

                return userList;
            }
            catch (Exception)
            {
                // write to log
                throw new Exception("Can not read user");
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }
        //read projects' report
        public List<report> ReadReport(int proj_num)
        {
            SqlConnection con = null;
            List<report> reportList = new List<report>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM report WHRER projet_num=" + proj_num;
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    report _report = new report();
                    _report.Report_num = Convert.ToInt32(dr["report_num"]);
                    _report.Date = Convert.ToDateTime(dr["date"]);
                    _report.Time = Convert.ToDateTime(dr["time"]);
                    _report.Grade = Convert.ToDouble(dr["grade"]);
                    _report.Comment = (string)dr["comment"];
                    _report.Project_num = Convert.ToInt32(dr["project_num"]);
                    reportList.Add(_report);
                }

                return reportList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }
        //delete project 
        public int DeleteProject(int proj_num)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString");
            }
            catch (Exception)
            {
                throw new Exception("The connection to sever is not good");
            }

            String cStr = BuildDeleteCommand(proj_num);

            cmd = CreateCommand(cStr, con);

            try
            {
                int numEffected = cmd.ExecuteNonQuery();
                return numEffected;
            }
            catch (Exception)
            {
                throw new Exception("The project was not deleted");
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }
        private String BuildDeleteCommand(int proj_num)
        {
            String command;
            command = "delete from project where project_num="+proj_num;
            return command;
        }

        //insert a new report
        public int InsertReport(report _report)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            String cStr = BuildInsertCommand(_report);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildInsertCommand(report _report)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}','{1}','{2}','{3}','{4}')", _report.Date, _report.Time, _report.Grade, _report.Comment, _report.Project_num);
            String prefix = "INSERT INTO report " + "(date,time,grade,comment,project_num)";
            command = prefix + sb.ToString();

            return command;

        }

        //insert a whole new project
        public int InsertProject(project _project)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            String cStr = BuildInsertCommand(_project);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        private String BuildInsertCommand(project _project)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')", _project.Name, _project.Company, _project.Address, _project.Start_date, _project.End_date, _project.Status, _project.Description, _project.Safety_lvl, _project.Project_type_num, _project.Manager_email, _project.Foreman_email);
            String prefix = "INSERT INTO project " + "(name,company,address,start_date,end_date,status,description,safety_lvl,project_type_num,manager_email,foreman_email)";
            command = prefix + sb.ToString();

            return command;

        }
        //returns all project types with weights
        public List<project_type> ReadProjectTypes()
        {
            List<project_type> ptlist = new List<project_type>();
            return ptlist;
        }
        //insert a whole new project type- with weights
        public void InsertProjectType(project_type pt)
        {

        }
        //returns all users
        public List<user> ReadUsers()
        {
            List<user> ulist = new List<user>();
            return ulist;
        }


        //returns all user types
        public List<user_type> ReadUserTypes()
        {
            List<user_type> utlist = new List<user_type>();
            return utlist;
        }
        //insert a new user type
        public void InsertUserType(user_type ut)
        {

        }
    }
}