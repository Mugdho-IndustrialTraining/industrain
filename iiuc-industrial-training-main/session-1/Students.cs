using System;
using System.Data;
using MySql.Data.MySqlClient;

public class StudentDatabase
{
    private readonly string connectionString = "Server=localhost;Database=studentdb;Uid=root;Pwd=yourpassword;";

    public DataTable GetStudents()
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM students";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }

    public void AddStudent(string firstName, string lastName, int age, string gender, string course)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO students (FirstName, LastName, Age, Gender, Course) VALUES (@FirstName, @LastName, @Age, @Gender, @Course)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Course", course);
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateStudent(int id, string firstName, string lastName, int age, string gender, string course)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "UPDATE students SET FirstName = @FirstName, LastName = @LastName, Age = @Age, Gender = @Gender, Course = @Course WHERE StudentID = @StudentID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StudentID", id);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Course", course);
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteStudent(int id)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "DELETE FROM students WHERE StudentID = @StudentID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StudentID", id);
            cmd.ExecuteNonQuery();
        }
    }
}
