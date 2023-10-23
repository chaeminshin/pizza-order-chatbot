using System;
using Microsoft.Data.Sqlite;

namespace PizzaDataN
{
    class PizzaData
    {
        public String GetPizzaData(int step)
        {
            var message = "";
            using (var connection = new SqliteConnection("Data Source=Pizza.db"))
            {
                int nStep = step;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT message
                    FROM PizzaOrder
                    WHERE step = $step
                ";
                command.Parameters.AddWithValue("$step", nStep);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        message = reader.GetString(0);
                    }
                }            
            }
            return message;
        }
    }
}
