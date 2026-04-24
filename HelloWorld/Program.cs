using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        Console.Write("Inserisci username: ");
        string username = Console.ReadLine();

        Console.Write("Inserisci password: ");
        string password = Console.ReadLine();

        string connectionString = "Server=localhost;Database=TestDB;Trusted_Connection=True;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // ❌ VULNERABILE A SQL INJECTION
            string query = $"SELECT COUNT(*) FROM Users WHERE Username = '{username}' AND Password = '{password}'";

            SqlCommand cmd = new SqlCommand(query, conn);
            int count = (int)cmd.ExecuteScalar();

            if (count > 0)
                Console.WriteLine("Login riuscito!");
            else
                Console.WriteLine("Credenziali non valide.");
        }
    }
}