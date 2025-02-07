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
    public partial class Edit : Form
    {
        LMSEntities db = new LMSEntities();
        Book book = new Book();
        public Edit()
        {
            InitializeComponent();
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void Show_Load(object sender, EventArgs e)
        {
            DG.DataSource = db.Books.ToList();

        }

        private void Show_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
           
            DG.DataSource = db.Books.ToList();
            DG.Update();
            db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }   
    }
}
