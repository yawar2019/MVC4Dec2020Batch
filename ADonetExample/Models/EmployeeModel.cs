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

        public List<EmployeeModel> getEmployees() {

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

        public int saveEmployee(EmployeeModel emp) {

            SqlCommand cmd = new SqlCommand("sp_getEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("",);
            cmd.Parameters.AddWithValue("",);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}