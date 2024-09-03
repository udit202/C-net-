using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Xml.Linq;

namespace CRUD
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
           //Program.Connection();
            Console.ReadLine();
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Connection has been successfully");
                        int start = 0;
                        do
                        {
                            Console.WriteLine("press 1 for view data");
                            Console.WriteLine("Press 2 for insert Data");
                            Console.WriteLine("Press 3 for update Data");
                            Console.WriteLine("Press 4 for Delete Data");
                            Console.WriteLine("Press 5 for Exit the program");
                            int usercmd = int.Parse(Console.ReadLine());
                            if (usercmd==1)
                            {
                                string query = "Select * from student_data";
                                SqlCommand cmd = new SqlCommand(query,con);
                                
                                SqlDataReader rdr = cmd.ExecuteReader();
                                while (rdr.Read())
                                {
                                    Console.WriteLine("id=" + rdr["id"]);
                                    Console.WriteLine("name=" + rdr["name"]);
                                    Console.WriteLine("age=" + rdr["age"]);
                                    Console.WriteLine("gender=" + rdr["gender"]);
                                    Console.WriteLine("course=" + rdr["course"]);

                                }

                                Console.ReadLine();
                            }
                            else if (usercmd == 2)
                            {
                                Console.WriteLine("How much Records you want to insert into db ");
                                Console.WriteLine("please enter integer value");
                                int recordno = int.Parse(Console.ReadLine()) ;
                               
                                for (  int i =0; i<recordno; i++)
                                {
                                    Console.WriteLine("enter student name");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("enter student age");
                                    int  age = int.Parse(Console.ReadLine());
                                    Console.WriteLine("enter student gender");
                                    string gender = Console.ReadLine();                                                                                
                                    Console.WriteLine("enter student course");
                                    string course = Console.ReadLine();
                                    string query = "INSERT INTO student_data (name, age, gender, course) VALUES (@name, @age, @gender, @course)";

                                    using (SqlCommand cmd = new SqlCommand(query, con))
                                    {
                                        // Adding parameters
                                        cmd.Parameters.AddWithValue("@name", name);
                                        cmd.Parameters.AddWithValue("@age", age);
                                        cmd.Parameters.AddWithValue("@gender", gender);
                                        cmd.Parameters.AddWithValue("@course", course);

                                        // Execute the query
                                        int inserted = cmd.ExecuteNonQuery();
                                        con.Close();
                                        Console.WriteLine($"Number of rows inserted: {inserted}");
                                    }
                                    Console.ReadLine();
                                }
                                
                            }
                            else if (usercmd == 3)
                            {
                                Console.WriteLine("Enter the data id thats you want to update");
                                int id = int.Parse(Console.ReadLine());
                                string query = "Select * from student_data Where id = @id";
                               
                                using (SqlCommand cmd = new SqlCommand(query, con))
                                {
                                    // Adding parameters
                                    cmd.Parameters.AddWithValue("@id", id);
                                    SqlDataReader rdr = cmd.ExecuteReader();
                                    while (rdr.Read())
                                    {
                                        Console.WriteLine("id=" + rdr["id"]);
                                        Console.WriteLine("name=" + rdr["name"]);
                                        Console.WriteLine("age=" + rdr["age"]);
                                        Console.WriteLine("gender=" + rdr["gender"]);
                                        Console.WriteLine("course=" + rdr["course"]);
                                        
                                    }
                                    rdr.Close();
                                }
                                

                                Console.WriteLine("presh 1 for update name");
                                Console.WriteLine("presh 2 for update age ");
                                Console.WriteLine("presh 3 for update gender ");
                                Console.WriteLine("presh 4 for update course");
                                Console.WriteLine("presh 5 for update Everything");
                                Console.WriteLine("if you want to exit press any no greater than 5");
                                int userupdatecmd= int.Parse(Console.ReadLine());
                                
                                if (userupdatecmd == 1)
                                {
                                    Console.WriteLine("Enter New name");
                                    string name = Console.ReadLine();
                                    string updatequery = "UPDATE student_data SET name = @name WHERE id = @id;";
                              
                                    using (SqlCommand cmd = new SqlCommand(updatequery, con))
                                    {
                                        // Adding parameters
                                        cmd.Parameters.AddWithValue("@name", name);
                                        cmd.Parameters.AddWithValue("@id", id);
                                        // Execute the query
                                        int updated = cmd.ExecuteNonQuery();
                                        if (updated > 0)
                                        {
                                            Console.WriteLine("Data updated Successfully");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in the data update");
                                        }
                                    }
                                    Console.ReadLine();

                                }
                                else if (userupdatecmd == 2)
                                {                            
                                    Console.WriteLine("Enter New age");
                                    string age = Console.ReadLine();
                                     string updatequery = "UPDATE student_data SET  age =@age WHERE id = @id;";
                                    using (SqlCommand cmd = new SqlCommand(updatequery, con))
                                    {
                                        // Adding parameters
                                        cmd.Parameters.AddWithValue("@age", age);
                                        cmd.Parameters.AddWithValue("@id", id);
                                        // Execute the query
                                        int updated = cmd.ExecuteNonQuery();
                                        if (updated > 0)
                                        {
                                            Console.WriteLine("Data updated Successfully");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in the data update");
                                        }
                                    }
                                    Console.ReadLine();
                                }
                                else if (userupdatecmd == 3)
                                {
                                    Console.WriteLine("enter student gender");
                                    string gender = Console.ReadLine();
                                    string updatequery = "UPDATE student_data SET  gender =@gender WHERE id = @id;";
                                    using (SqlCommand cmd = new SqlCommand(updatequery, con))
                                    {
                                        // Adding parameters
                                        cmd.Parameters.AddWithValue("@gender", gender);
                                        cmd.Parameters.AddWithValue("@id", id);

                                        // Execute the query
                                        int updated = cmd.ExecuteNonQuery();
                                        if (updated > 0)
                                        {
                                            Console.WriteLine("Data updated Successfully");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in the data update");
                                        }
                                    }
                                    Console.ReadLine();

                                }
                                else if (userupdatecmd == 4)
                                {
                                    Console.WriteLine("enter student course");
                                    string course = Console.ReadLine();
                                    string updatequery = "UPDATE student_data SET  course =@course WHERE id = @id;";
                                    using (SqlCommand cmd = new SqlCommand(updatequery, con))
                                    {
                                        // Adding parameters
                                        cmd.Parameters.AddWithValue("@course", course);
                                        cmd.Parameters.AddWithValue("@id", id);

                                        // Execute the query
                                        int updated = cmd.ExecuteNonQuery();
                                        if (updated > 0)
                                        {
                                            Console.WriteLine("Data updated Successfully");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in the data update");
                                        }
                                    }
                                    Console.ReadLine();
                                }
                                else if (userupdatecmd == 5)
                                {
                                    Console.WriteLine("enter student name");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("enter student age");
                                    int age = int.Parse(Console.ReadLine());
                                    Console.WriteLine("enter student gender");
                                    string gender = Console.ReadLine();
                                    Console.WriteLine("enter student course");
                                    string course = Console.ReadLine();
                                    string updatequery = "UPDATE student_data SET name = @name, age =@age, gender =@gender,course =@course WHERE id = @id;";
                                    using (SqlCommand cmd = new SqlCommand(updatequery, con))
                                    {
                                        // Adding parameters
                                        cmd.Parameters.AddWithValue("@name", name);
                                        cmd.Parameters.AddWithValue("@age", age);
                                        cmd.Parameters.AddWithValue("@gender", gender);
                                        cmd.Parameters.AddWithValue("@course", course);
                                        cmd.Parameters.AddWithValue("@id", id);

                                        // Execute the query
                                        int updated = cmd.ExecuteNonQuery();
                                        if (updated > 0)
                                        {
                                            Console.WriteLine("Data updated Successfully");
                                            Console.ReadLine();

                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in the data update");
                                            Console.ReadLine();
                                        }
                                    }
                                    Console.ReadLine();
                                }
                                else
                                {
                                    break;
                                }




                                Console.ReadLine();


                            }
                            else if (usercmd == 4)
                            {
                                Console.WriteLine("Enter the data id thats you want to update");
                                int id = int.Parse(Console.ReadLine());
                                string query = "Select * from student_data Where id = @id";
                                string dataname = null;

                                using (SqlCommand cmd = new SqlCommand(query, con))
                                {
                                    // Adding parameters
                                    cmd.Parameters.AddWithValue("@id", id);
                                    SqlDataReader rdr = cmd.ExecuteReader();
                                    
                                    while (rdr.Read())
                                    {
                                        dataname = rdr["name"].ToString();
                                        Console.WriteLine("id=" + rdr["id"]);
                                        Console.WriteLine("name=" + rdr["name"]);
                                        Console.WriteLine("age=" + rdr["age"]);
                                        Console.WriteLine("gender=" + rdr["gender"]);
                                        Console.WriteLine("course=" + rdr["course"]);
                                       

                                    }
                                    rdr.Close();
                                }
                                Console.WriteLine($"Are you sure you want to delete {dataname}");
                                Console.WriteLine("press 1 for confirm delete else Press any number ");

                                int confirm = int.Parse(Console.ReadLine());
                                if(confirm == 1)
                                {

                                    string Deletequery="DELETE from student_data where id = @id";
                                    using (SqlCommand cmd = new SqlCommand(Deletequery, con))
                                    {
                                        // Adding parameters
                                        cmd.Parameters.AddWithValue("@id", id);

                                        // Execute the query
                                        int del=cmd.ExecuteNonQuery();
                                        if (del > 0)
                                        {
                                            Console.WriteLine("Data Deleted Successfully");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in the data Deleted");
                                        }
                                    }
                                    Console.ReadLine();
                                }



                            }
                            else if (usercmd == 5)
                            {
                                break;
                            }
                            else
                            {
                                break;
                            }

                        } while (start == 0);



                    }
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }

        }

    }
        //static void Connection()
        //{
        //    //string cs = "Data Source = DESKTOP-SVL401H;Initial Catalog=Learnado;Integrated Security=true;";
        //    string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //    SqlConnection con=null;
        //    try
        //    {
        //        using (con = new SqlConnection(cs))
        //        {
        //            con.Open();
        //            if (con.State == ConnectionState.Open)
        //            {
        //                Console.WriteLine("Connection has been successfully");
        //            }
        //        }
        //    }
                
        //    catch(SqlException ex) {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally { con.Close(); }
            
        //}
    //}
}
