using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDemo
{
  public class SqlRepo
  {
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    public List<string[]> LoadData()
    {
      List<string[]> data = new List<string[]>();
      using (SqlConnection sqlConnection = new SqlConnection(connectionString))
      {
        using (SqlCommand command = sqlConnection.CreateCommand())
        {
          command.CommandText = "select IdDemo, Col1, Col2, Col3 from Demo";
          sqlConnection.Open();
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              //načtení hodnot do pole řetězců
              string[] row = new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };
              data.Add(row);
            }
          }
          sqlConnection.Close();
        }
      }
      return data;
    }

    public void DeleteItem(string id)
    {
      using(SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        using(SqlCommand command = connection.CreateCommand())
        {
          command.CommandText = $"delete from Demo where IdDemo={id}";
          command.ExecuteNonQuery();
        }
        connection.Close();
      }
    }
  }
}
