using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ADonetExample.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
    }

    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=VidhiDB;Integrated Security=true");

        public List<EmployeeModel> getEmployees()
        {

            List<EmployeeModel> listobj = new List<EmployeeModel>();
            SqlCommand cmd = new SqlCommand("sp_getEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel empobj = new EmployeeModel();
                empobj.EmpId = Convert.ToInt32(dr[0]);
                empobj.EmpName = Convert.ToString(dr[1]);
                empobj.EmpSalary = Convert.ToInt32(dr[2]);

                listobj.Add(empobj);
            }
            return listobj;
        }

        public int saveEmployee(EmployeeModel emp)
        {

            SqlCommand cmd = new SqlCommand("sp_SaveEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@empName", emp.EmpName);
            cmd.Parameters.AddWithValue("@empSalary", emp.EmpSalary);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public EmployeeModel getEmployeeByEmpId(int? id)
        {

            EmployeeModel obj = new EmployeeModel();

            SqlCommand cmd = new SqlCommand("spr_getEmployeesbyId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);


            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                obj.EmpId = Convert.ToInt32(dr[0]);
                obj.EmpName = Convert.ToString(dr[1]);
                obj.EmpSalary = Convert.ToInt32(dr[2]);


            }
            return obj;
        }



        public int updateEmployeeByEmpId(EmployeeModel emp)
        {

            SqlCommand cmd = new SqlCommand("spr_updateEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@empId", emp.EmpId);
            cmd.Parameters.AddWithValue("@empName", emp.EmpName);
            cmd.Parameters.AddWithValue("@empSalary", emp.EmpSalary);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        
        public int deleteEmployeeByEmpId(int ? Id)
        {

            SqlCommand cmd = new SqlCommand("spr_deleteEmployeebyId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@empId", Id);
            
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}