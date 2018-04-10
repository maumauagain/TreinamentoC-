using System;
using Activity.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;

namespace Activity.ConUl
{
    class Program
    {

        static void Main(string[] args)
        {
            Project BussinesProject = new Project();

            Console.WriteLine("Minha primeira aplicação Console no .Net Core");
            string CONNECTION_STRING = @"Data source=localhost; Initial catalog=BaseProject; Integrated Security=true";
            //var db = new SqlConnection(CONNECTION_STRING);

            void CreateUser()
            {
                using (var db = new SqlConnection(CONNECTION_STRING))
                {
                    using (var cmd = new SqlCommand("", db))
                    {
                        cmd.CommandText = @"
                        insert into Persons
                        values (@id, @name, @birthdate, @email)";
                        cmd.Parameters.AddWithValue("@id", Int32.Parse(Console.ReadLine()));
                        cmd.Parameters.AddWithValue("@name", Console.ReadLine());
                        cmd.Parameters.AddWithValue("@birthdate", DateTime.Parse(Console.ReadLine()));
                        cmd.Parameters.AddWithValue("@email", Console.ReadLine());
                        db.Open();
                        cmd.ExecuteNonQuery();
                        db.Close();

                    }
                }
            }

            void UpdateUser()
            {
                using (var db = new SqlConnection(CONNECTION_STRING))
                {
                    using (var cmd = new SqlCommand("", db))
                    {
                        cmd.CommandText = @"
                        update Persons
                        set name = @title
                        where id = @id";
                        cmd.Parameters.AddWithValue("@title", Console.ReadLine());
                        cmd.Parameters.AddWithValue("@id", 1);
                        db.Open();
                        cmd.ExecuteNonQuery();
                        db.Close();

                    }
                }
            }

            

            Console.ReadKey();

        }
    }
}
