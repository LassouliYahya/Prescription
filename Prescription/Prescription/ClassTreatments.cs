using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.IO;

namespace Prescription
{
    class ClassTreatments
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Prescription;Integrated Security=True");

        public DataTable readTreatments()
            {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Prescription;Integrated Security=True");
                con.Open();
                string requette = " select * from Treatments ";
                SqlCommand cmd = new SqlCommand(requette, con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                con.Close();
                return dt;
            }

            public void insertTreatments( string nameTreatment)
            {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Prescription;Integrated Security=True");
            con.Open();
                string requette = " insert into Treatments values(@nameTreatment)";
                //SqlParameter p1 = new SqlParameter("@idTreatment", idTreatment);//7int f db dayr id identity1,1
                SqlParameter p2 = new SqlParameter("@nameTreatment", nameTreatment);
                SqlCommand cmd = new SqlCommand(requette, con);
                cmd.Parameters.Add(p2);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            public void updateTreatments(int idTreatment, string nameTreatment)
            {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
                string requette = " update Treatments set nameTreatment=@nameTreatment from Treatments where idTreatment=@idTreatment";
                SqlParameter p1 = new SqlParameter("@idTreatment", idTreatment);
                SqlParameter p2 = new SqlParameter("@nameTreatment", nameTreatment);
                SqlCommand cmd = new SqlCommand(requette, con);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                
                cmd.ExecuteNonQuery();
                con.Close();
            }
            public void deleteTreatments(int idTreatment)
            {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
                string requette = " delete from Treatments where idTreatment=@idTreatment";
                SqlParameter p1 = new SqlParameter("@idTreatment", idTreatment);
                SqlCommand cmd = new SqlCommand(requette, con);
                cmd.Parameters.Add(p1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            public DataTable searchTreatments(string nameTreatment)
            {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
                string requette = " select * from Treatments where nameTreatment like '%'+@nameTreatment+'%' ";
                SqlParameter p1 = new SqlParameter("@nameTreatment", nameTreatment);
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
        public DataTable searchTreatmentSansID()
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
            string requette = " select nameTreatment from Treatments ";
            SqlCommand cmd = new SqlCommand(requette, con);
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
