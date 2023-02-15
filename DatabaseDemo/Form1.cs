using System.Data.SqlClient;

namespace DatabaseDemo
{
  public partial class Form1 : Form
  {
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      LoadData();
    }

    private void LoadData()
    {
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
              //naètení hodnot do pole øetìzcù
              string[] data = new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };
              //vytvoøení položky pro ListView
              ListViewItem item = new ListViewItem(data);
              //vložení do ListView
              listView1.Items.Add(item);
            }
          }
          sqlConnection.Close();
        }
      }
    }
  }
}