using System.Data.SqlClient;

namespace DatabaseDemo
{
  public partial class Form1 : Form
  {
    private SqlRepo sqlRepo;

    public Form1()
    {
      InitializeComponent();
      sqlRepo = new SqlRepo();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      foreach (var row in sqlRepo.LoadData())
      {
        listView1.Items.Add(new ListViewItem(row));
      }
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
      if (listView1.SelectedIndices.Count > 0)
      {
        var id = listView1.Items[listView1.SelectedIndices[0]].SubItems[0].Text;
        sqlRepo.DeleteItem(id);
      }
      else
      {
        MessageBox.Show("Vyberte položku");
      }
    }
  }
}