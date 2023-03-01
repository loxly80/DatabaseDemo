using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDemo
{
  public class Item
  {
    public int Id { get; set; }
    public string Col1 { get; set; } = "";
    public string Col2 { get; set; } = "";
    public string Col3 { get; set; } = "";

    public Item(int id, string col1, string col2, string col3)
    {
      Id = id;
      Col1 = col1;
      Col2 = col2;
      Col3 = col3;
    }

    public Item(string col1, string col2, string col3)
    {
      Id = -1;
      Col1 = col1;
      Col2 = col2;
      Col3 = col3;
    }

    public ListViewItem ToListViewItem()
    {
      return new ListViewItem(new string[] { Id.ToString(), Col1, Col2, Col3 });
    }
  }
}
