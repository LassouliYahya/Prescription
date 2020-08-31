using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Prescription
{
    class ClassPatients
    {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Prescription;Integrated Security=True");
        public DataTable readPatient()
            {
                //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
                con.Open();
                string requette = " select * from Patients ";
                SqlCommand cmd = new SqlCommand(requette, con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                con.Close();
                return dt;
            }

            public void insertPatient(string name, int age, string patientType)
            {
                //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
                con.Open();
                string requette = " insert into Patients values(@name,@age ,@patientType)";
                SqlParameter p1 = new SqlParameter("@name", name);
                SqlParameter p2 = new SqlParameter("@age", age);
                SqlParameter p3 = new SqlParameter("@patientType", patientType);
                SqlCommand cmd = new SqlCommand(requette, con);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            public void updatePatient(int idPatient, string name, int age, string patientType)
            {
                //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
                con.Open();
                string requette = " update Patients set name=@name ,title=@title ,age=@age ,patientType=@patientType from Patients where idPatient=@idPatient";
                SqlParameter p1 = new SqlParameter("@idPatient", idPatient);
                SqlParameter p2 = new SqlParameter("@name", name);
                SqlParameter p3 = new SqlParameter("@author", age);
                SqlParameter p4 = new SqlParameter("@price", patientType);
                SqlCommand cmd = new SqlCommand(requette, con);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            public void deletePatient(int idPatient)
            {
                //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
                con.Open();
                string requette = " delete from Patients where idPatient=@idPatient";
                SqlParameter p1 = new SqlParameter("@idPatient", idPatient);
                SqlCommand cmd = new SqlCommand(requette, con);
                cmd.Parameters.Add(p1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            public DataTable searchPatient(string name)
            {
                //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
                con.Open();
                string requette = " select * from Patients where name like '%'+@name+'%' ";
                SqlParameter p1 = new SqlParameter("@name", name);
                SqlCommand cmd = new SqlCommand(requette, con);
                cmd.Parameters.Add(p1);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                con.Close();
                return dt;
            }
        }
}

