using Exercice1.Classes;
using MySql.Data.MySqlClient;

namespace Exercice1.Repository;

public class StudentRepository
{
private string connectionString = "Server=localhost;Database=demo_ado ;User ID=root;Password=Root";

public void Add(Student student)
{

    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            
            string query = "INSERT INTO Student (lastname,firstname,classe_number,diplome_date) VALUES (@lastname,@firstname,@classe_number,@diplome_date)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@lastname", student.LastName);
            cmd.Parameters.AddWithValue("@firstname", student.FirstName);
            cmd.Parameters.AddWithValue("@classe_number", student.ClasseNumber);
            cmd.Parameters.AddWithValue("@diplome_date", student.DiplomeDate);
            
            int rowAffected = cmd.ExecuteNonQuery();
            if(rowAffected > 0)
            {
                Console.WriteLine("Student added :!");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Erreur : "+ex.Message);
        }
    };
}

public List<Student> GetAll()
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        List<Student> students = new List<Student>();
        try
        {
            connection.Open();
            string query = "SELECT * FROM Student";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student student = new Student(
                        reader.GetInt32("id"),
                        reader.GetString("lastname"),
                        reader.GetString("firstname"),
                        reader.GetInt32("classe_number"),
                        reader.GetDateTime("diplome_date")
                    );
                    students.Add(student);
                }
            }

            reader.Close();

            return students;

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
            return new List<Student>();
        }
    }
}



public Student GetById(int id)
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        try
        {
            connection.Open();

            string query = "SELECT * FROM Student WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Student student = new Student(
                    reader.GetInt32("id"),
                    reader.GetString("lastname"),
                    reader.GetString("firstname"),
                    reader.GetInt32("classe_number"),
                    reader.GetDateTime("diplome_date")
                );
                return student;
            }
            return null;

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
            return null;
        }
       
    };
    
}

public void Update(Student student)
{


    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        try
        {
            connection.Open();
        
            string queryCheck = "SELECT COUNT(*) FROM Personne WHERE id = @id";
            MySqlCommand cmdCheck = new MySqlCommand(queryCheck, connection);
            cmdCheck.Parameters.AddWithValue("@id", student.Id);
            int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

            if (count == 0)
            {
                Console.WriteLine("No Student found");
                return;
            }
        
            string query = "UPDATE Student SET lastname = @lastname , firstname = @firstname , classe_number = @classe_number , diplome_date = @diplome_date WHERE id = @id";
        

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.Parameters.AddWithValue("@lastname", student.LastName);
            cmd.Parameters.AddWithValue("@firstname", student.FirstName);
            cmd.Parameters.AddWithValue("@classe_number", student.ClasseNumber);
            cmd.Parameters.AddWithValue("@diplome_date", student.DiplomeDate);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Student Update");
            }

        }
        catch (Exception ex) 
        {
            Console.WriteLine("Erreur : "+ex.Message);
        }
    }
}

public void Delete(int id)
{

    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        try
        {
            connection.Open();

            string query = "DELETE FROM Personne WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Student Deleted");
            }
            else
            {
                Console.WriteLine("No Student found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur :"+ex.Message);
        }  
    }
}

public List<Student> GetAll(int classeNumber)
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        List<Student> students = new List<Student>();
        try
        {
            connection.Open();
            string query = "SELECT * FROM Student WHERE classe_number = @classe_number";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@classe_number", classeNumber);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student student = new Student(
                        reader.GetInt32("id"),
                        reader.GetString("lastname"),
                        reader.GetString("firstname"),
                        reader.GetInt32("classe_number"),
                        reader.GetDateTime("diplome_date")
                    );
                    students.Add(student);
                }
            }

            reader.Close();

            return students;

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
            return new List<Student>();
        }
    }
}

public List<Student> GetAll(string Lastname)
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        List<Student> students = new List<Student>();
        try
        {
            connection.Open();
            string query = "SELECT * FROM Student WHERE lastname Like @lastname";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@lastname",Lastname+"%");

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student student = new Student(
                        reader.GetInt32("id"),
                        reader.GetString("lastname"),
                        reader.GetString("firstname"),
                        reader.GetInt32("classe_number"),
                        reader.GetDateTime("diplome_date")
                    );
                    students.Add(student);
                }
            }

            reader.Close();

            return students;

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
            return new List<Student>();
        }
    }
}


}