using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication16.Models
{
    public class Manager
    {
        public IEnumerable<PersonProductItem> GetAllAds()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=Craigslist;Integrated Security=True"))
            using (SqlCommand command = connection.CreateCommand())
            {
                List<PersonProductItem> Ad = new List<PersonProductItem>();
                command.CommandText = @"select p.*, i.* 
                                        FROM PersonProduct p
                                        JOIN Item i
                                        ON p.Id = i.PersonProductId
                                        WHERE i.id IN
                                        (SELECT MIN(id) FROM item GROUP BY personproductid)";
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    PersonProductItem P = new PersonProductItem();

                    P.PersonProductId = (int)Reader["id"];
                    P.FirstName = (string)Reader["FirstName"];
                    P.LastName = (string)Reader["LastName"];
                    P.PhoneNumber = (string)Reader["PhoneNumber"];
                    P.Title = (string)Reader["Title"];
                    P.Description = (string)Reader["Description"];
                    P.FileName = (string)Reader["FileName"];
                    Ad.Add(P);

                }
                return Ad;
            }
        }

        public void AddPersonPoduct(PersonProduct PP, String[] fileName)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=Craigslist;Integrated Security=True"))
            using (SqlCommand command = connection.CreateCommand())
            {

                command.CommandText = "INSERT INTO PersonProduct VALUES (@FirstName, @LastName, @PhoneNumber, @Title, @Description) SELECT @@Identity";
                command.Parameters.AddWithValue("@FirstName", PP.FirstName);
                command.Parameters.AddWithValue("@LastName", PP.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", PP.PhoneNumber);
                command.Parameters.AddWithValue("@Title", PP.Title);
                command.Parameters.AddWithValue("@Description", PP.Description);

                connection.Open();
                int Id = (int)(decimal)command.ExecuteScalar();

                command.Parameters.Clear();
                for (int i = 0; i < fileName.Length; i++)
                {
                    command.CommandText = "INSERT INTO ITEM VALUES (@PersonProductId, @FileName)";
                    command.Parameters.AddWithValue("@PersonProductId", Id);
                    command.Parameters.AddWithValue("@FileName", fileName[i]);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }

                
                
            }
        }

        public List<PersonProductItem> GetAd(int Id)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=Craigslist;Integrated Security=True"))
            using (SqlCommand command = connection.CreateCommand())
            {
                List<PersonProductItem> Ad = new List<PersonProductItem>();

                command.CommandText = @"select p.*, i.* 
                                       FROM PersonProduct p
                                        JOIN Item i
                                       ON p.Id = i.PersonProductId
                                       WHERE i.personproductId = @Id";
                command.Parameters.AddWithValue("@Id", Id);
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();
                while (Reader.Read())
                {

                    PersonProductItem P = new PersonProductItem();
                    P.PersonProductId = (int)Reader["id"];
                    P.FirstName = (string)Reader["FirstName"];
                    P.LastName = (string)Reader["LastName"];
                    P.PhoneNumber = (string)Reader["PhoneNumber"];
                    P.Title = (string)Reader["Title"];
                    P.Description = (string)Reader["Description"];
                    P.FileName = (string)Reader["FileName"];
                    P.ItemId = (int)Reader["id"];
                    Ad.Add(P);
                }
                return Ad;
            }
        }

        
    }
}