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

namespace UI_APP
{
    public partial class DANGKY : Form
    {
        public DANGKY()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtHoVaTen.Text != "" && txtTaiKhoan.Text != "" && txtMatKhau.Text != "" && txtGioiTinh.SelectedItem != null)
            {
                string filePath = "D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\Account.csv";
                string[] file = File.ReadAllLines(filePath);
                bool check = false;
                for (int i = 1; i < file.Length; i++)
                {
                    string[] s = file[i].Split(',');
                    if(txtTaiKhoan.Text == s[3])
                    {
                        check = true;
                        break;
                    }    
                }
                if (check == true)
                {
                    MessageBox.Show("Tên Đăng Nhập Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    string text1 = txtHoVaTen.Text + ",";
                    string dt = txtThoiGian.Text + ",";
                    string list = txtGioiTinh.SelectedItem.ToString() + ",";
                    string text2 = txtTaiKhoan.Text + ",";
                    string text3 = txtMatKhau.Text;
                    string newData = text1 + dt + list + text2 + text3;
                    try
                    {
                        // Mở file CSV với chế độ Append để thêm nội dung vào cuối file
                        //File.AppendAllText(filePath, newData);

                        using (StreamWriter sw = new StreamWriter(filePath, true))
                        {
                            sw.WriteLine(newData);
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //textBox1.Text, dateTimePicker1.Text, listBox1.Text, textBox2.Text, textBox3.Text
                    this.Hide();
                    DANGNHAP DN = new DANGNHAP();
                    DN.Show();
                }
            }
            else MessageBox.Show("Lỗi", "Thông Báo");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
