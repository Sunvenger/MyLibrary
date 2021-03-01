
namespace MyLibrary
{
    partial class WindowEditBook
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbBookName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.tbConfirm = new System.Windows.Forms.Button();
            this.gvEditBookExplorer = new System.Windows.Forms.DataGridView();
            this.btnChangeItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvEditBookExplorer)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tbBookName
            // 
            this.tbBookName.Location = new System.Drawing.Point(99, 168);
            this.tbBookName.Name = "tbBookName";
            this.tbBookName.Size = new System.Drawing.Size(516, 20);
            this.tbBookName.TabIndex = 0;
            this.tbBookName.TextChanged += new System.EventHandler(this.tbBookName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Názov knihy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Autor";
            // 
            // tbAuthor
            // 
            this.tbAuthor.Location = new System.Drawing.Point(99, 194);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(516, 20);
            this.tbAuthor.TabIndex = 3;
            this.tbAuthor.TextChanged += new System.EventHandler(this.tbAuthor_TextChanged);
            // 
            // tbConfirm
            // 
            this.tbConfirm.Location = new System.Drawing.Point(478, 220);
            this.tbConfirm.Name = "tbConfirm";
            this.tbConfirm.Size = new System.Drawing.Size(137, 23);
            this.tbConfirm.TabIndex = 5;
            this.tbConfirm.Text = "Aplikovať zmeny";
            this.tbConfirm.UseVisualStyleBackColor = true;
            this.tbConfirm.Click += new System.EventHandler(this.tbConfirm_Click);
            // 
            // gvEditBookExplorer
            // 
            this.gvEditBookExplorer.AllowUserToAddRows = false;
            this.gvEditBookExplorer.AllowUserToDeleteRows = false;
            this.gvEditBookExplorer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEditBookExplorer.Location = new System.Drawing.Point(30, 12);
            this.gvEditBookExplorer.MultiSelect = false;
            this.gvEditBookExplorer.Name = "gvEditBookExplorer";
            this.gvEditBookExplorer.ReadOnly = true;
            this.gvEditBookExplorer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvEditBookExplorer.Size = new System.Drawing.Size(585, 150);
            this.gvEditBookExplorer.TabIndex = 6;
            this.gvEditBookExplorer.Click += new System.EventHandler(this.gvEditBookExplorer_Click);
            // 
            // btnChangeItem
            // 
            this.btnChangeItem.Location = new System.Drawing.Point(99, 220);
            this.btnChangeItem.Name = "btnChangeItem";
            this.btnChangeItem.Size = new System.Drawing.Size(147, 28);
            this.btnChangeItem.TabIndex = 7;
            this.btnChangeItem.Text = "Zmeniť položnku";
            this.btnChangeItem.UseVisualStyleBackColor = true;
            this.btnChangeItem.Click += new System.EventHandler(this.btnChangeItem_Click);
            // 
            // WindowEditBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 275);
            this.Controls.Add(this.btnChangeItem);
            this.Controls.Add(this.gvEditBookExplorer);
            this.Controls.Add(this.tbConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAuthor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBookName);
            this.Name = "WindowEditBook";
            this.Text = "Editácia kníh";
            this.Load += new System.EventHandler(this.WindowEditBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvEditBookExplorer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbBookName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Button tbConfirm;
        private System.Windows.Forms.DataGridView gvEditBookExplorer;
        private System.Windows.Forms.Button btnChangeItem;
    }
}