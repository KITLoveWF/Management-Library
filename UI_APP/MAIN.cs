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
    public partial class MAIN : Form
    {
        
        public MAIN()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Muốn Đăng Xuất", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        this.Hide();
                        DANGNHAP DN = new DANGNHAP();
                        DN.Show();
                        break;
                    }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Muốn Thoát", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        Application.Exit();
                        break;
                    }
            }
        }

        private void Book_Click(object sender, EventArgs e)
        {
            
            viewBook1.Show();
            searchBook1.Hide();
            historyUser1.Hide();
            borrower1.Hide();


        }

        private void MAIN_Load(object sender, EventArgs e)
        {
            viewBook1.Hide();
            searchBook1.Hide();
            historyUser1.Hide();
            borrower1.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            searchBook1.Show();
            viewBook1.Hide();
            historyUser1.Hide();
            borrower1.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            historyUser1.Show();
            viewBook1.Hide();
            searchBook1.Hide();
            borrower1.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            borrower1.Show();
            viewBook1.Hide();
            searchBook1.Hide();
            historyUser1.Hide();
            
        }
    }
}
