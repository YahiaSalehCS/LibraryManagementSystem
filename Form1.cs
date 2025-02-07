using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            BooksForm a = new BooksForm();
            a.Show();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            MembersForm membersForm = new MembersForm();
            membersForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BorrowingForm borrowingForm = new BorrowingForm();
            borrowingForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
