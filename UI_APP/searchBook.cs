using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_APP
{
    public partial class searchBook : UserControl
    {
        public searchBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            
                try
                {
                    Manage manage = new Manage();
                    manage.ReadFile1("D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\InforBook.csv");
                    manage.ReadDataContent();
                bool ok = false;
                    if (comboBox1.SelectedItem.ToString() == "Author")
                    {
                        if (manage.FindBookAuthor(txtFind.Text) == null) MessageBox.Show("Không Tìm Được Sách", "Thông Báo");
                        else dataGridView1.DataSource = manage.FindBookAuthor(txtFind.Text);
                    }
                    if (comboBox1.SelectedItem.ToString() == "Category")
                    {
                        if (manage.FindBookCategory(txtFind.Text) == null) MessageBox.Show("Không Tìm Được Sách", "Thông Báo");
                        else dataGridView1.DataSource = manage.FindBookCategory(txtFind.Text);
                    }
                    if (comboBox1.SelectedItem.ToString() == "Name")
                    {
                        if (manage.FindBookTitle(txtFind.Text) == null) MessageBox.Show("Không Tìm Được Sách", "Thông Báo");
                        else dataGridView1.DataSource = manage.FindBookTitle(txtFind.Text);
                    }
                    if (comboBox1.SelectedItem.ToString() == "Isbn")
                    {
                        if (manage.FindBookIsbn(txtFind.Text) == null) MessageBox.Show("Không Tìm Được Sách", "Thông Báo");
                        else dataGridView1.DataSource = manage.FindBookIsbn(txtFind.Text);
                    }
                    if(comboBox1.SelectedItem.ToString() == "Content")
                    {
                    if (manage.FindBookContent(txtFind.Text) == null) MessageBox.Show("Không Tìm Được Sách", "Thông Báo");
                    else
                    {
                        dataGridView1.DataSource = manage.FindBookContent(txtFind.Text);
                        ok = true;
                    }
                    
                    }
                if (ok == false)
                {

                    dataGridView1.Columns[0].Width = 250;
                    dataGridView1.Columns[1].Width = 250;
                    dataGridView1.Columns[2].Width = 250;
                    dataGridView1.Columns[3].Width = 250;
                    dataGridView1.Columns[4].Width = 250;
                    dataGridView1.Columns[5].Width = 100;
                }
                else
                {
                    dataGridView1.Columns[0].Width = 250;
                    dataGridView1.Columns[1].Width = 250;
                    dataGridView1.Columns[2].Width = 1000;
                }    

                }
                catch(Exception ex)
                {
                     MessageBox.Show("Không Tìm Được Sách", "Thông Báo");
                }
               
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
