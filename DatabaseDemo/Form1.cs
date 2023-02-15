using System.Data.SqlClient;

namespace DatabaseDemo
{
  public partial class Form1 : Form
  {
    private SqlRepo sqlRepo;

    public Form1()
    {
      InitializeComponent();
      sqlRepo= new SqlRepo();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      foreach(var row in sqlRepo.LoadData())
      {
        listView1.Items.Add(new ListViewItem(row));
      }
    }

    
  }
}