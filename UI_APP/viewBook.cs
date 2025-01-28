using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI_APP
{
    public partial class viewBook : UserControl
    {
        
        public viewBook()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manage manage = new Manage();
            manage.ReadFile1("D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\InforBook.csv");
           
            //dataGridView1.Columns[5]
            dataGridView1.DataSource = manage.Books;
            dataGridView1.Columns[0].Width = 250;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Width = 250;
            dataGridView1.Columns[5].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtISBN.Text!= "" && txtSoLuong.Text!= "" && txtTacGia.Text!= ""&&txtTenSach.Text!=""&&txtTheLoai.Text!="")
            {
                string filePath = "D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\InforBook.csv";
                string isbn = txtISBN.Text + ",";
                string soLuong = txtSoLuong.Text;
                string tacGia = txtTacGia.Text + ",";
                string tenSach = txtTenSach.Text + ",";
                string theLoai = txtTheLoai.Text+",";
                string newData = theLoai + tenSach + tacGia + isbn + soLuong ;
                try
                {
                    // Mở file CSV với chế độ Append để thêm nội dung vào cuối file
                    //File.AppendAllText(filePath, newData);

                    using (StreamWriter sw = new StreamWriter(filePath, true))
                    {
                        sw.WriteLine(newData);
                    }
                    MessageBox.Show("Thêm Sách Thành Công","Thông Báo",MessageBoxButtons.OK);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Lỗi", "Thông Báo");
        }
    }
}
