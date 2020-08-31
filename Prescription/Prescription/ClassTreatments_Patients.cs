using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Prescription
{
    class ClassTreatments_Patients
    {
        //Treatments_Patients
        //    idTreatment_Patient
        //    idPatient
        //    treatmentName
        //    treatmentDose
        //    treatmentAll
        //    treatmentDuration
        //    treatmentTime

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Prescription;Integrated Security=True");
            public DataTable readTreatments_Patients(int idPatient)
            {
                //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
                con.Open();
                string requette = " select treatmentName,treatmentDuration,treatmentTime from Treatments_Patients where idPatient=@idPatient ";
                SqlParameter p1 = new SqlParameter("@idPatient", idPatient);
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

            public void insertTreatments_Patients(int idPatient,string treatmentName, string treatmentAll, string treatmentDuration, string treatmentTime)
            {
                //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
                con.Open();
                string requette = " insert into Treatments_Patients values(@idPatient,@treatmentName ,@treatmentAll,@treatmentDuration,@treatmentTime)";
                SqlParameter p1 = new SqlParameter("@idPatient", idPatient);
                SqlParameter p2 = new SqlParameter("@treatmentName", treatmentName);
                SqlParameter p3 = new SqlParameter("@treatmentAll", treatmentAll);
                SqlParameter p4 = new SqlParameter("@treatmentDuration", treatmentDuration);
                SqlParameter p5 = new SqlParameter("@treatmentTime", treatmentTime);
            SqlCommand cmd = new SqlCommand(requette, con);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
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
