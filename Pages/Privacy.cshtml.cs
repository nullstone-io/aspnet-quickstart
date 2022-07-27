using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace aspnet_quickstart.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    public List<string> Result = new List<string>();

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
            try
            {
                string connectionString = Environment.GetEnvironmentVariable("SQLSERVER_DSN");
                // string connectionString = "Data Source=db;Initial Catalog=master;User ID=sa;Password=Password1234%^&*";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Result.Add("Connecting to Sql Server...");

                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();

                    String sql = "SELECT name, collation_name FROM sys.databases";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Result.Add(reader.GetString(0));
                                Console.WriteLine(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                Result.Add($"Error occurred: {e.ToString()}");
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
    }
}

