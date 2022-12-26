using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_With_ADO.Net.Models
{
    public class PersonCRUD
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

            // string _connectionString = @"Data Source=IN-B2WMGK3\SQLEXPRESS;Initial Catalog=paginationDb;User Id=sa; Password=sa";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("Select * from Person.Person where Id=" + id, sqlConnection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dataTable);
            }

            return dataTable;
        }

        public int CreatePerson(string PersonType, string FirstName, string MiddleName,string LastName, int EmailPromotion)
        {
            
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "INSERT INTO Person.Person(PersonType,FirstName,MiddleName,LastName, EmailPromotion) VALUES (@PersonType, @firstname, @MiddleName, @LastName ,  @EmailPromotion)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PersonType",PersonType);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@MiddleName",MiddleName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@EmailPromotion", EmailPromotion);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateEmployee(string PersonType, string FirstName, string MiddleName, string LastName, int EmailPromotion)
        {
              using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string query = "Update Person.Person SET PersonType=@PersonType, FirstName=@FirstName,MiddleName=@MiddleName, LastName=@lastname ,  EmailPromotion=@EmailPromotion  where Id=@id";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@PersonType", PersonType);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@EmailPromotion", EmailPromotion);
                cmd.Parameters.AddWithValue("@id", Id);
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int id)
        {
               using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string query = "Delete from Person.Person where Id=@id";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}