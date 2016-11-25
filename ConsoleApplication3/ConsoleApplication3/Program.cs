using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL 
{
    class Program
    {
        private static string connectionString =
            "Server = ealdb1.eal.local; Database = ejl40_db; User ID = ejl40_usr; Password = Baz1nga40";


        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Run();
        }
        private void Run()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    Console.WriteLine("type 1 to insert a new pet");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            String sqlString =
                                "INSERT INTO VALUES(@PetType, @PetBreed, @petDOB, @PetWeight, @owner ID)";
                            SqlCommand cmd = new SqlCommand(sqlString, con);
                            Console.WriteLine("write pet name");
                            cmd.Parameters.AddWithValue("@PetName", Console.ReadLine());

                            Console.WriteLine("Write Pet type");
                            cmd.Parameters.AddWithValue("@PetType", Console.ReadLine());

                            Console.WriteLine("Write pet breed");
                            cmd.Parameters.AddWithValue("@PetBreed", Console.ReadLine());

                            Console.WriteLine("Write pet date of birth");
                            Console.WriteLine("Write day: ");
                            int day = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Write month: ");
                            int month = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Write year: ");
                            int year = Convert.ToInt32(Console.ReadLine());
                            DateTime DOB = new DateTime(year, month, day);
                            cmd.Parameters.AddWithValue("@PetDOB", DOB.ToShortDateString());

                            Console.WriteLine("Write Pet Weight");
                            cmd.Parameters.AddWithValue("@PetWeight", Console.ReadLine());

                            Console.WriteLine("Write Owner ID");
                            cmd.Parameters.AddWithValue("@owner ID", Console.ReadLine());
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            break;
                    }
                }
                catch (SqlException e)
                {

                    Console.WriteLine("error: "+e);
                    Console.ReadKey();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error" + e);
                    Console.ReadKey();
                }
            }
        }
    }
}

