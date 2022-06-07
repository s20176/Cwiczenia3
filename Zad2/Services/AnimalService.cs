using System.Collections.Generic;
using System.Data.SqlClient;
using Zad2.Model;

namespace Zad2.Services
{
    public class AnimalService : IAnimalService
    {

        private static string connectionString = @"Server=localhost,1401; Database=Master; User Id=sa; Password=<YourStrong!Passw0rd>";

        public void addAnimal(Animal animal)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var com = new SqlCommand($"INSERT INTO Animal (Name,Description,Category,Area) VALUES (@param1,@param2,@param3,@param4)", con);
                com.Parameters.AddWithValue("@param1", animal.Name);
                com.Parameters.AddWithValue("@param2", animal.Description);
                com.Parameters.AddWithValue("@param3", animal.Category);
                com.Parameters.AddWithValue("@param4", animal.Area);
                con.Open();
                com.ExecuteNonQuery();
            }
        }

        public void deleteAnimal(int idAnimal)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var com = new SqlCommand($"DELETE FROM Animal WHERE IdAnimal=@param1", con);
                com.Parameters.AddWithValue("@param1", idAnimal);
                con.Open();
                com.ExecuteNonQuery();
            }
        }

        public Animal getAnimal(int idAnimal)
        {
            Animal result = null;
            using (var con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Animal WHERE IdAnimal=@param1", con);
                command.Parameters.AddWithValue("@param1", idAnimal);
                con.Open();
                var dr = command.ExecuteReader();
                if (dr.Read())
                {
                    result=new Animal
                    {
                        IdAnimal = int.Parse(dr["IdAnimal"].ToString()),
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    };
                }
            }
            return result;
        }

        public List<Animal> getAnimals(string orderBy)
        {
            List<Animal> result = new List<Animal>();
            using (var con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Animal ORDER BY {orderBy}", con);
                con.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(new Animal
                    {
                        IdAnimal = int.Parse(dr["IdAnimal"].ToString()),
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    }); ;
                }
            }
            return result;
        }

        public void updateAnimal(int idAnimal, Animal animal)
        {
            using (var con = new SqlConnection(connectionString))
            {
                var com = new SqlCommand($"UPDATE Animal SET Name=@param2, Description=@param3, Category=@param4, Area=@param5 WHERE IdAnimal=@param1", con);
                com.Parameters.AddWithValue("@param1", idAnimal);
                com.Parameters.AddWithValue("@param2", animal.Name);
                com.Parameters.AddWithValue("@param3", animal.Description);
                com.Parameters.AddWithValue("@param4", animal.Category);
                com.Parameters.AddWithValue("@param5", animal.Area);
                con.Open();
                com.ExecuteNonQuery();
            }
        }
    }
}
