using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_With_ADO.Net.Models
{
    public class Person_CRUD_
    {
        private string _connectionString = @"Data Source=IN-9TP1PL3\SQLEXPRESS;Initial Catalog=AdventureWorks2014;User Id=sa;Password=sa";

        public DataTable GetAllPerson()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select * from Person.Person", sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        public DataTable GetPersonById(int id)
        {
            DataTable dataTable = new DataTable();

             using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("Select * from Person.Person where BusinessEntityID=" + id, sqlConnection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dataTable);
            }

            return dataTable;
        }

        public int CreatePerson( int BusinessEntityID,string PersonType,string FirstName, string MiddleName, string LastName, string EmailPromotion)
        {

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "INSERT INTO Person.Person(BusinessEntityID,PersonType,FirstName,MiddleName,LastName, EmailPromotion) VALUES ( @BusinessEntityID,@PersonTYpe,@firstname, @MiddleName, @LastName ,  @EmailPromotion)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BusinessEntityID", BusinessEntityID);
                cmd.Parameters.AddWithValue("@PersonType", PersonType);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@EmailPromotion", EmailPromotion);
                return cmd.ExecuteNonQuery();
            }
        }

     

        public int UpdatePerson(string PersonType,int BusinessEntityID, string FirstName, string MiddleName, string LastName, string EmailPromotion)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string query = "Update Person.Person SET PersonType=@PersonType, FirstName=@FirstName,MiddleName=@MiddleName, LastName=@lastname ,  EmailPromotion=@EmailPromotion  where BusinessEntityID=@id";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@PersonType", PersonType);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@EmailPromotion", EmailPromotion);
               
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int BusinessEntityID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string query = "Delete from Person.Person where BusinessEntityID=@BusinessEntityID";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@BusinessEntityID", BusinessEntityID);
                return cmd.ExecuteNonQuery();
            }
        }

       
    }
}