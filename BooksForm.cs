using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Library
{
    public partial class BooksForm : Form
    {
        LMSEntities db = new LMSEntities();
        
        public BooksForm()
        {
            InitializeComponent();
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            this.booksTableAdapter.Fill(this.lMSDataSet.Books);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bookID = int.Parse(txtBookID.Text);

            var existingBook = db.Books.FirstOrDefault(b => b.BookID == bookID);

            if (existingBook != null)
            {
                MessageBox.Show("There is already a book with this ID.");
            }
            else
            {
                Book obj = new Book();
                obj.BookID = bookID;
                obj.Title = txtTitle.Text;
                obj.Author = txtAuthor.Text;
                obj.Category = txtCategory.Text;
                obj.AvailabilityStatus = cmbStatus.SelectedItem.ToString();
                obj.PublishedYear = int.Parse(txtPublishedYear.Text);

                db.Books.Add(obj);
                db.SaveChanges();

                txtBookID.Text = "";
                txtTitle.Text = "";
                txtAuthor.Text = "";
                txtCategory.Text = "";
                txtPublishedYear.Text = "";
                cmbStatus.Text = "";

                MessageBox.Show("The book has been added.");



            }



            }

            private void button2_Click(object sender, EventArgs e)
        {
            Edit editForm = new Edit();
            editForm.ShowDialog();


        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Show f = new Show();
            f.ShowDialog();



        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
          
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editbtn_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {

        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            Search find = new Search();
            find.ShowDialog();
        }
    }
}
