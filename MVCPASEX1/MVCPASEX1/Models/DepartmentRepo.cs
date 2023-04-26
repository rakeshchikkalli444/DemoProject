using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MVCPASEX1.Models;

namespace MVCPASEX1.Models
{
   
    public class DepartmentRepo
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());

        public string  getdeptid()
        {
            con.Open();
            string dnoid="";
            SqlCommand cmd = new SqlCommand("proc_autoid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

               dnoid = ds.Tables[0].Rows[0]["dno"].ToString();
            }
            con.Close();
            return dnoid;
        }
        public void AddDept(Department d)
        {
            con.Open();
            
                SqlCommand cmd = new SqlCommand("sp_insertdept", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dno", d.dno);
                cmd.Parameters.AddWithValue("@dname", d.dname);
                cmd.Parameters.AddWithValue("@city", d.City);
                cmd.ExecuteNonQuery();
                con.Close();
           
        }


        public List<Department> ShowDept()
        {
            con.Open();
            List<Department> obj = new List<Department>();
            SqlCommand cmd = new SqlCommand("sp_Viewdept", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                obj.Add(new Department
                {
                    dno = Convert.ToInt32(dr["dno"]),
                    dname = Convert.ToString(dr["dname"]),
                    City = Convert.ToString(dr["city"])
                });
            }
            return obj;
        }


        public void UpdateDept(Department d)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_editdept", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dno", d.dno);
            cmd.Parameters.AddWithValue("@dname", d.dname);
            cmd.Parameters.AddWithValue("@city", d.City);
            cmd.ExecuteNonQuery();
            con.Close();
        }



        public void DeleteDept(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_deletedept", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dno", id);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}