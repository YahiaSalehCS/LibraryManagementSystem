namespace Library
{
    partial class Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtfind = new System.Windows.Forms.TextBox();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // txtfind
            // 
            this.txtfind.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtfind.Location = new System.Drawing.Point(0, 0);
            this.txtfind.Name = "txtfind";
            this.txtfind.Size = new System.Drawing.Size(933, 22);
            this.txtfind.TabIndex = 0;
            this.txtfind.Text = "Find";
            this.txtfind.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // dgvBooks
            // 
            this.dgvBooks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvBooks.Location = new System.Drawing.Point(0, 22);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowHeadersWidth = 51;
            this.dgvBooks.RowTemplate.Height = 24;
            this.dgvBooks.Size = new System.Drawing.Size(933, 428);
            this.dgvBooks.TabIndex = 2;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 450);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.txtfind);
            this.Name = "Search";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfind;
        private System.Windows.Forms.DataGridView dgvBooks;
    }
}