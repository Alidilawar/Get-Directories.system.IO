using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace List_all_Files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            textBox1.Text = dlg.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var files = Directory.GetFiles(textBox1.Text , "*.*" + comboBox1.Text , SearchOption.AllDirectories);
                // *.* -------> For All Types
                // System.IO.SearchOption.AllDirectories ----> For All Folder includng Sub folder in the folder whose path is mentioned in the textBox

                listBox1.DataSource = files;

                MessageBox.Show(files.Count() + " Files Found","Form List");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = string.Empty;
                comboBox1.Text = string.Empty;
                listBox1.DataSource = null;
                listBox1.Items.Clear();
                MessageBox.Show("Do you want to clear form?","Form List", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
