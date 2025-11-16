using Azure;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.IO;
namespace ADODOTNETCORE
{
     class Program
    {
        static void Main(string[] args)
        {
            string StudentName;
            int Age;
            string Gender;
            int Standard;
            string ConnectionString = "Server = DESKTOP-Q650CVS; Database =DotNetCoreExe;Trusted_Connection=true;TrustServerCertificate=True;";

            Console.WriteLine("Please select \n 1.Insert Data \n 2.Update Data \n 3.display data \n4.Retrive data of specific user \n 5.Delete data ");
            int userInput  = Convert.ToInt32(Console.ReadLine());

            if (userInput == 1)
            {
                try
                {
                    Console.WriteLine("Enter Student Name :");
                    StudentName = Console.ReadLine();
                    Console.WriteLine("Enter Age");
                    Age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Gender");
                    Gender = Console.ReadLine();
                    Console.WriteLine("Enter the standard:");
                    Standard = Convert.ToInt32(Console.ReadLine());


                    string inertSqlStatement = @"insert into Students values(@StudentName,@Age,@Gender,@Standard)";
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(inertSqlStatement, connection))
                        {
                            command.Parameters.AddWithValue("@StudentName", StudentName);
                            command.Parameters.AddWithValue("@Age", Age);
                            command.Parameters.AddWithValue("@Gender", Gender);
                            command.Parameters.AddWithValue("@Standard", Standard);

                            int RowAffected = command.ExecuteNonQuery();

                            if (RowAffected > 0)
                            {
                                Console.WriteLine($"Data Inserted Sucessfully..");
                            }
                            else
                            {
                                Console.WriteLine($"No data were inserted");
                            }
                        };

                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
            else if (userInput == 2)
            {
                Console.WriteLine("Enter Id For which user you want update the data :");
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter new age of the student :");
                Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter new standard of the student");
                Standard = Convert.ToInt32(Console.ReadLine());
               
                   
                    
                

                string UpdateStudent = @"Update Students SET Age =@Age,Standard =@Standard where ID = @ID";

                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(UpdateStudent, connection))
                        {
                            command.Parameters.AddWithValue("@Age", Age);
                            command.Parameters.AddWithValue("@Standard", Standard);
                            command.Parameters.AddWithValue("@ID",ID);

                            int rowaffected = command.ExecuteNonQuery();

                            if (rowaffected > 0)
                            {
                                Console.WriteLine("Data Updated sucessfully..");
                            }
                            else
                            {
                                Console.WriteLine("No Existing recored is available..");
                            }
                        }
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

               

            }
            else if (userInput == 3)
            {
                string SelectAllData = "Select * from Students";

                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(SelectAllData, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine(
                                        $"\t Id :{reader["Id"]} " +
                                        $"\t Name : {reader["StudentName"]} " +
                                        $"\t Age: {reader["Age"]} " +
                                        $"\t Gender :{reader["Gender"]} " +
                                        $"\t Standard : {reader["Standard"]}\n"
                                        );
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }
           
            else if(userInput == 4)
            {
                Console.WriteLine("Eneter Id to display data of specific user :");
                int ID = Convert.ToInt32(Console.ReadLine());

                string SelectDataById = "Select * from Students where ID = @ID";

                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(SelectDataById, connection))
                        {
                            command.Parameters.AddWithValue("@ID", ID);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine(
                                        $"\t Id :{reader["Id"]} " +
                                        $"\t Name : {reader["StudentName"]} " +
                                        $"\t Age: {reader["Age"]} " +
                                        $"\t Gender :{reader["Gender"]} " +
                                        $"\t Standard : {reader["Standard"]}\n"
                                        );
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }



        }
            
    }
}
