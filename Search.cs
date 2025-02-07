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
    
    public partial class Search : Form
    {
        LMSEntities db = new LMSEntities();

       

        public string FindText { get; private set; }
        public bool MatchCase { get; private set; }
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            txtsearch_TextChanged(sender, e);

        }

        private void Search_Load(object sender, EventArgs e)
        {            dgvBooks.DataSource = db.Books.ToList();

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtfind.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                var filteredBooks = db.Books
                    .Where(b => b.BookID.ToString().Contains(searchText)
                             || b.Title.ToLower().Contains(searchText)
                             || b.Author.ToLower().Contains(searchText)
                             || b.Category.ToLower().Contains(searchText)
                             || b.PublishedYear.ToString().Contains(searchText)
                             || b.BorrowingTransactions.Any(bt => bt.TransactionID.ToString().Contains(searchText)
                                                                 || bt.MemberID.ToString().Contains(searchText)))
                    .ToList();

                dgvBooks.DataSource = filteredBooks;
            }
            else
            {
                dgvBooks.DataSource = db.Books.ToList();
            }
        }
    }
}
