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
    public partial class MembersForm : Form
    {
        LMSEntities db = new LMSEntities(); 
       
        public MembersForm()
        {
            InitializeComponent();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            Member newMember = new Member();


                newMember.FullName = txtFullName.Text;
            newMember.ContactInfo = txtContactInfo.Text;
            newMember.MemberID = int.Parse(txtID.Text);

            newMember.MembershipDate = dtpMembershipDate.Value.Year * 10000 + dtpMembershipDate.Value.Month * 100 + dtpMembershipDate.Value.Day;
            

            db.Members.Add(newMember); 
            db.SaveChanges(); 
            txtFullName.Text = "";
            txtContactInfo.Text = "";
            txtID.Text = "";
            MessageBox.Show("Member added successfully!");
            LoadMembers(); 

        }

        private void MembersForm_Load(object sender, EventArgs e)
        {
            LoadMembers(); 
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                int memberId = Convert.ToInt32(dgvMembers.SelectedRows[0].Cells["MemberID"].Value);
                var member = db.Members.FirstOrDefault(m => m.MemberID == memberId);

                if (member != null)
                {
                    member.FullName = txtFullName.Text;
                    member.ContactInfo = txtContactInfo.Text;
                    member.MembershipDate = dtpMembershipDate.Value.Year * 10000 + dtpMembershipDate.Value.Month * 100 + dtpMembershipDate.Value.Day;
                    member.MemberID = int.Parse(txtID.Text);

                    db.SaveChanges(); 
                    MessageBox.Show("Member updated successfully!");
                    ClearFields();
                    LoadMembers(); 
                }
            }
            else
            {
                MessageBox.Show("Please select a member to edit.");
            }
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                int memberId = Convert.ToInt32(dgvMembers.SelectedRows[0].Cells["MemberID"].Value);
                var member = db.Members.FirstOrDefault(m => m.MemberID == memberId);

                if (member != null)
                {
                    db.Members.Remove(member); 
                    db.SaveChanges(); 
                    MessageBox.Show("Member deleted successfully!");
                    LoadMembers(); 
                }
            }
            else
            {
                MessageBox.Show("Please select a member to delete.");
            }
        }

        private void btnSearchMember_Click(object sender, EventArgs e)
        {

            string searchText =txtsearch.Text.ToLower();
            var filteredMembers = db.Members
                .Where(m => m.FullName.ToLower().Contains(searchText)
                            || m.ContactInfo.ToLower().Contains(searchText)
                            || m.MemberID.ToString().Contains(searchText))
                .ToList();

            dgvMembers.DataSource = filteredMembers;

            var filteredBooks = db.Members
                    .Where(b => b.MemberID.ToString().Contains(searchText)
                             || b.FullName.ToLower().Contains(searchText)
                             || b.ContactInfo.ToLower().Contains(searchText)
                             || b.MembershipDate.ToString().Contains(searchText)
                             || b.BorrowingTransactions.Any(bt => bt.TransactionID.ToString().Contains(searchText)
                                                                 || bt.MemberID.ToString().Contains(searchText)))
                    .ToList();
        }

        private void dgvMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                txtFullName.Text = dgvMembers.SelectedRows[0].Cells["FullName"].Value.ToString();
                txtContactInfo.Text = dgvMembers.SelectedRows[0].Cells["ContactInfo"].Value.ToString();
                dtpMembershipDate.Value = Convert.ToDateTime(dgvMembers.SelectedRows[0].Cells["MembershipDate"].Value); // Converting to DateTime
            }
        }

        private void ClearFields()
        {
            txtFullName.Text = "";
            txtContactInfo.Text = "";
            dtpMembershipDate.Value = DateTime.Now; 
        }

        private void LoadMembers()
        {
            dgvMembers.DataSource = db.Members.ToList(); 
        }

        private void dtpMembershipDate_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
