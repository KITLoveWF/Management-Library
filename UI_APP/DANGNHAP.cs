using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_APP
{
    public partial class DANGNHAP : Form
    {
        private List<Account> accountSS = new List<Account>();
        public DANGNHAP()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DANGKY DK = new DANGKY();
            DK.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {



            try
            {
                if(comboBox1.SelectedItem.ToString() == "Admin")
                {
                    string filePath = "D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\AccountAdmin.csv";
                    string[] file = File.ReadAllLines(filePath);
                    try
                    {
                        
                        if (textBox1.Text != "" && textBox2.Text != "")
                        {
                            bool check = false;
                            for (int i = 0; i < file.Length; i++)
                            {
                                string[] s = file[i].Split(',');
                                if (s[0] == textBox1.Text && s[1] == textBox2.Text)
                                {
                                    check = true;
                                }
                                
                            }
                            if (check == false)
                            {
                                // Console.WriteLine(1);
                                MessageBox.Show("Đăng Nhập Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBox1.Clear();
                                textBox2.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo", MessageBoxButtons.OK);
                                // Console.WriteLine(2);
                                this.Hide();
                                MAIN M = new MAIN();
                                M.Show();
                            }
                        }
                        else
                        {

                            MessageBox.Show("Đăng Nhập Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    File.WriteAllText("D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\AccountBorrowerNow.csv", string.Empty);
                    string filePath = "D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\Account.csv";
                    string filePathBorrowNow = "D:\\DAI HOC DUNG HOC DAI\\SECOND\\OOP\\NEW\\UI_APP\\AccountBorrowerNow.csv";
                    string[] file = File.ReadAllLines(filePath);
                    try
                    {
                        for (int i = 1; i < file.Length; i++)
                        {
                            //Console.WriteLine(file[i]);
                            string[] s = file[i].Split(',');
                            Account newAccount = new Account(s[0], s[1], s[2], s[3], s[4]);
                            accountSS.Add(newAccount);
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }


                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        bool check = false;
                        for (int i = 0; i < accountSS.Count; i++)
                        {
                            if (accountSS[i].UserName == textBox1.Text && accountSS[i].PassWord == textBox2.Text)
                            {
                                check = true;
                                string hoVaTen= accountSS[i].Name + ",";
                                string ngayThangNamSinh = accountSS[i].Birthday + ",";
                                string gioiTinh = accountSS[i].Gender + ",";
                                string taiKhoan = accountSS[i].UserName + ",";
                                string matKhau = accountSS[i].PassWord;
                                string newData = hoVaTen+ngayThangNamSinh+gioiTinh+taiKhoan+matKhau;
                                try
                                {
                                    // Mở file CSV với chế độ Append để thêm nội dung vào cuối file
                                    //File.AppendAllText(filePath, newData);

                                    using (StreamWriter sw = new StreamWriter(filePathBorrowNow, true))
                                    {
                                        sw.WriteLine(newData);
                                    }


                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }

                        //MessageBox.Show($"{}")
                        if (check == false)
                        {
                            // Console.WriteLine(1);
                            MessageBox.Show("Đăng Nhập Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo", MessageBoxButtons.OK);
                            // Console.WriteLine(2);
                            this.Hide();
                            MAINBORROWER MB = new MAINBORROWER();
                            MB.Show();
                        }
                    }
                    else
                    {

                        MessageBox.Show("Đăng Nhập Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }    
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đăng Nhập Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
