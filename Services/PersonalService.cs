using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Module07DataAccess.Model;
using MySql.Data.MySqlClient;

namespace Module07DataAccess.Services
{
    public class PersonalService
    {
        private readonly string _connectionString;

        public PersonalService()
        {
            var dbService = new DatabaseConnectionService();
            _connectionString = dbService.GetConnectionString();
        }

        public async Task<List<Personal>> GetAllPersonalAsync()
        {
            var personalList = new List<Personal>();

            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    var cmd = new MySqlCommand("SELECT * FROM tblemployee", conn);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            personalList.Add(new Personal
                            {
                                EmployeeID = reader.GetInt32("EmployeeID"),
                                Name = reader.GetString("Name"),
                                Address = reader.GetString("Address"),
                                ContactNo = reader.GetString("ContactNo"),
                                email = reader.GetString("email"),
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Handle your database-related exceptions here (logging, rethrowing, etc.)
                Console.WriteLine($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions here
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return personalList;
        }
    }
}
