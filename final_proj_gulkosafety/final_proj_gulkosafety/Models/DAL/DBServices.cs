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



        public List<defect> ReadDefect()
        {
            SqlConnection con = null;
            List<defect> defectList = new List<defect>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM defect";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    defect _defect = new defect();
                    _defect.Defects_num = Convert.ToInt32(dr["defects_num"]);
                    _defect.Name = (string)dr["name"];
                    _defect.Grade = Convert.ToInt32(dr["Grade"]);
                    _defect.Defect_type_num = Convert.ToInt32(dr["Defect_type_num"]);

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
        //returns all projects
        public List<project> ReadProjects()
        {
            List<project> plist = new List<project>();
            return plist;
        }

        //insert a whole new project
        public void InsertProject(project p)
        {

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
        //insert a new user
        public void InsertUser(user u)
        {

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