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

namespace Library
{
    public partial class BorrowingForm : Form
    {
        LMSEntities db = new LMSEntities();
        public BorrowingForm()
        {
            InitializeComponent();
        }

        private void BorrowingForm_Load(object sender, EventArgs e)
        {
            LMSEntities db = new LMSEntities();
            BorrowingTransaction zz = new BorrowingTransaction();

            cmbMember.DataSource = db.Members.ToList();
            cmbMember.DisplayMember = "FullName";
            cmbMember.ValueMember = "MemberID";

            cmbBook.DataSource = db.Books.Where(b => b.AvailabilityStatus == "Available").ToList();
            cmbBook.DisplayMember = "Title";
            cmbBook.ValueMember = "BookID";
            txtSearch.Text = txtSearch.Text;

            LoadBorrowingTransactions();
        }

        private void LoadBorrowingTransactions()
        {
            LMSEntities db = new LMSEntities();

            var transactions = db.BorrowingTransactions
                .Select(t => new
                {
                    t.TransactionID,
                    t.Member.FullName,      
                    t.Book.Title,           
                    t.BorrowedDate,
                    t.DueDate,
                    t.ReturnedDate
                })
                .ToList(); 

            
            var transactionsWithLateFee = transactions.Select(t => new
            {
                t.TransactionID,
                MemberName = t.FullName,
                BookTitle = t.Title,
                t.BorrowedDate,
                t.DueDate,
                t.ReturnedDate,
                LateFee = (t.ReturnedDate.HasValue && t.ReturnedDate.Value > t.DueDate)
                            ? ((t.ReturnedDate.Value - t.DueDate).Days * 3).ToString() + "$" 
                            : "0$" 
            }).ToList();

            dgvBorrowing.DataSource = transactionsWithLateFee;
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {

            int memberId = (int)cmbMember.SelectedValue;
            int bookId = (int)cmbBook.SelectedValue;
            DateTime borrowedDate = dtpBorrowedDate.Value;
            DateTime dueDate = dtpDueDate.Value;

            LMSEntities db = new LMSEntities();

            int newTransactionID = (db.BorrowingTransactions.Any())
                ? db.BorrowingTransactions.Max(t => t.TransactionID) + 1
                : 1;

           
            BorrowingTransaction transaction = new BorrowingTransaction()
            {
                TransactionID = newTransactionID,
                MemberID = memberId,
                BookID = bookId,
                BorrowedDate = borrowedDate,
                DueDate = dueDate
            };

            db.BorrowingTransactions.Add(transaction);
            db.SaveChanges();

            
            var book = db.Books.FirstOrDefault(b => b.BookID == bookId);
            if (book != null)
            {
                book.AvailabilityStatus = "Borrowed";
                db.SaveChanges();
            }

            MessageBox.Show("Book borrowed successfully!");

            LoadBorrowingTransactions();

        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvBorrowing.SelectedRows.Count > 0)
            {
                int transactionId = Convert.ToInt32(dgvBorrowing.SelectedRows[0].Cells["TransactionID"].Value);
                LMSEntities db = new LMSEntities();

                var transaction = db.BorrowingTransactions.FirstOrDefault(t => t.TransactionID == transactionId);
                if (transaction != null)
                {
                    transaction.ReturnedDate = DateTime.Now;

                    var book = db.Books.FirstOrDefault(b => b.BookID == transaction.BookID);
                    if (book != null)
                    {
                        book.AvailabilityStatus = "Available";
                    }

                    db.SaveChanges();

                    MessageBox.Show("Book returned successfully!");

                    LoadBorrowingTransactions();  
                }
            }
            else
            {
                MessageBox.Show("Please select a borrowing transaction.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();

            using (LMSEntities db = new LMSEntities())
            {
                var transactions = db.BorrowingTransactions
                    .Where(t => t.Member.FullName.ToLower().Contains(searchTerm) ||   
                                t.Book.Title.ToLower().Contains(searchTerm) ||        
                                t.MemberID.ToString().Contains(searchTerm) ||         
                                t.BookID.ToString().Contains(searchTerm) ||           
                                t.BorrowedDate.ToString().Contains(searchTerm) ||     
                                t.DueDate.ToString().Contains(searchTerm) ||         
                                (t.ReturnedDate.HasValue && t.ReturnedDate.ToString().Contains(searchTerm)))  
                    .ToList();

                var transactionsWithLateFee = transactions.Select(t => new
                {
                    t.TransactionID,
                    MemberName = t.Member.FullName,
                    BookTitle = t.Book.Title,
                    t.BorrowedDate,
                    t.DueDate,
                    t.ReturnedDate,
                    LateFee = (t.ReturnedDate.HasValue && t.ReturnedDate.Value > t.DueDate)
                                ? ((t.ReturnedDate.Value - t.DueDate).Days * 3).ToString() + "$"
                                : "0$"
                }).ToList();

                dgvBorrowing.DataSource = transactionsWithLateFee;
            }
        }

    private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgvBorrowing.SelectedRows.Count > 0)
            {
                int transactionId = Convert.ToInt32(dgvBorrowing.SelectedRows[0].Cells["TransactionID"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    using (LMSEntities db = new LMSEntities())
                    {
                        var transaction = db.BorrowingTransactions.FirstOrDefault(t => t.TransactionID == transactionId);

                        if (transaction != null)
                        {
                            db.BorrowingTransactions.Remove(transaction);
                            db.SaveChanges();

                            MessageBox.Show("Record deleted successfully!");

                            LoadBorrowingTransactions();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void cmbBook_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
