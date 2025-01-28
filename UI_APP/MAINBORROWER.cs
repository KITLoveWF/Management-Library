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
    public partial class MAINBORROWER : Form
    {
        public MAINBORROWER()
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
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void MAINBORROWER_Load(object sender, EventArgs e)
        {
            borrow1.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            borrow1.Show();
        }

        private void borrow1_Load(object sender, EventArgs e)
        {

        }
    }
}
