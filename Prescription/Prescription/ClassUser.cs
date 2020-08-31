using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Prescription
{
    class ClassUser
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Prescription;Integrated Security=True");

        public DataTable readUsers()
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
            string requette = " select * from Users ";
            SqlCommand cmd = new SqlCommand(requette, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            return dt;
        }
        public void insertUser(string name, string email, string passwordUser, string roleUser, string isAuth)
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
            string requette = " insert into Users values(@name,@email ,@passwordUser ,@roleUser,@isAuth)";
            SqlParameter p1 = new SqlParameter("@name", name);
            SqlParameter p2 = new SqlParameter("@email", email);
            SqlParameter p3 = new SqlParameter("@passwordUser", passwordUser);
            SqlParameter p4 = new SqlParameter("@roleUser", roleUser);
            SqlParameter p5 = new SqlParameter("@isAuth", isAuth);
            SqlCommand cmd = new SqlCommand(requette, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateUser(int idUser, string name, string email, string passwordUser, string roleUser)
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
            string requette = " update Users set name=@name ,email=@email ,passwordUser=@passwordUser,roleUser=@roleUser from Users where idUser=@idUser";
            SqlParameter p1 = new SqlParameter("@name", name);
            SqlParameter p2 = new SqlParameter("@email", email);
            SqlParameter p3 = new SqlParameter("@passwordUser", passwordUser);
            SqlParameter p4 = new SqlParameter("@roleUser", roleUser);
            SqlParameter p6 = new SqlParameter("@idUser", idUser);
            SqlCommand cmd = new SqlCommand(requette, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p6);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void deleteUser(int iduser)
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
            string requette = " delete from Users where iduser=@iduser";
            SqlParameter p1 = new SqlParameter("@iduser", iduser);
            SqlCommand cmd = new SqlCommand(requette, con);
            cmd.Parameters.Add(p1);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable searchUser(string email)
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
            string requette = " select * from Users where email like '%'+@email+'%' ";
            SqlParameter p1 = new SqlParameter("@email", email);
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

        public DataTable login(string email,string passwordUser/*, string roleUser*/)
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
            string requette = " select name,email,passwordUser,roleUser from Users where passwordUser=@passwordUser and email=@email ";
            SqlParameter p1 = new SqlParameter("@email", email);
            SqlParameter p2 = new SqlParameter("@passwordUser", passwordUser);
            //SqlParameter p3 = new SqlParameter("@roleUser", roleUser);
            SqlCommand cmd = new SqlCommand(requette, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            //cmd.Parameters.Add(p3);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            return dt;
        }
        public void updateLogin(string email, string passwordUser)
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
            string requette = " update Users set isAuth='true'  from Users where passwordUser=@passwordUser and email=@email";
            SqlParameter p2 = new SqlParameter("@email", email);
            SqlParameter p3 = new SqlParameter("@passwordUser", passwordUser);
            SqlCommand cmd = new SqlCommand(requette, con);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable startLoading()
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
            string requette = " select * from Users where isAuth='true' ";
            SqlCommand cmd = new SqlCommand(requette, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            return dt;
        }
        public void logout()
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BooksManagement;Integrated Security=True");
            con.Open();
            string requette = " update Users set isAuth='false' from Users";
            SqlCommand cmd = new SqlCommand(requette, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
