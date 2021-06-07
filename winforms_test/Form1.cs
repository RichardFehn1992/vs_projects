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

            TreeNode mainNode = new TreeNode();
            mainNode.Name = "mainNode";
            mainNode.Text = "Main";
            treeView1.Nodes.Add(mainNode);
            treeView1.Nodes.Add(mainNode);
        }

        private void button_test_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Console.WriteLine("hi");

            switch (e.Action)
            {
                case TreeViewAction.ByMouse:

                    Console.WriteLine("hi"); 
                    break; 
            }
        }
    }
}
