using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winforms_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            StringHandler h_str = new StringHandler(); 
            ListViewHandler h_listView = new ListViewHandler();

            h_listView.set_position_and_size(ref listView1, 20, 20, 300, 200);
            h_listView.set_config_settings(ref listView1, View.Details, true, true, true, true, true, SortOrder.Ascending);

            h_listView.add_column(ref listView1, "name", -2);
            h_listView.add_column(ref listView1, "quantity", -2);
            h_listView.add_column(ref listView1, "size", -2);
            h_listView.add_column(ref listView1, "range", -2);

            for(int i = 0; i < 3; i++)
            {
                ListViewItem item = new ListViewItem("item: " + h_str.intToStr(i), 0);
                // Place a check mark next to the item.
                item.Checked = true;
                item.SubItems.Add("1");
                item.SubItems.Add("2");
                item.SubItems.Add("3");
                item.ForeColor = Color.Black;
                item.BackColor = Color.LightGray; 

                listView1.Items.Add(item); 
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("haha"); 
        }
    }
}
