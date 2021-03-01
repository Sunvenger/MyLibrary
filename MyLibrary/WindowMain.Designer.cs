
namespace MyLibrary
{
    partial class MainWindow
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAllBooks = new System.Windows.Forms.TabPage();
            this.btnEditBooks = new System.Windows.Forms.Button();
           
            this.btnDeleteBooks = new System.Windows.Forms.Button();
            this.gvAllBooks = new System.Windows.Forms.DataGridView();
            this.tabAvailBooks = new System.Windows.Forms.TabPage();
            this.gvAvailBooks = new System.Windows.Forms.DataGridView();
            this.btnReserveBook = new System.Windows.Forms.Button();
            this.tabMyBooks = new System.Windows.Forms.TabPage();
            this.gvMyBooks = new System.Windows.Forms.DataGridView();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.tabCreateBook = new System.Windows.Forms.TabPage();
            this.btnBookAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBookName = new System.Windows.Forms.TextBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.súborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBtnUsrExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBtnImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menubtnExportLib = new System.Windows.Forms.ToolStripMenuItem();
            this.manuBtnImportLib = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabAllBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllBooks)).BeginInit();
            this.tabAvailBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAvailBooks)).BeginInit();
            this.tabMyBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMyBooks)).BeginInit();
            this.tabCreateBook.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAllBooks);
            this.tabControl1.Controls.Add(this.tabAvailBooks);
            this.tabControl1.Controls.Add(this.tabMyBooks);
            this.tabControl1.Controls.Add(this.tabCreateBook);
            this.tabControl1.Location = new System.Drawing.Point(12, 103);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(657, 335);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAllBooks
            // 
            this.tabAllBooks.Controls.Add(this.btnEditBooks);
            this.tabAllBooks.Controls.Add(this.btnDeleteBooks);
            this.tabAllBooks.Controls.Add(this.gvAllBooks);
            this.tabAllBooks.Location = new System.Drawing.Point(4, 22);
            this.tabAllBooks.Name = "tabAllBooks";
            this.tabAllBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllBooks.Size = new System.Drawing.Size(649, 309);
            this.tabAllBooks.TabIndex = 0;
            this.tabAllBooks.Text = "Všetky knihy";
            this.tabAllBooks.UseVisualStyleBackColor = true;
            // 
            // btnEditBooks
            // 
            this.btnEditBooks.Location = new System.Drawing.Point(210, 266);
            this.btnEditBooks.Name = "btnEditBooks";
            this.btnEditBooks.Size = new System.Drawing.Size(141, 23);
            this.btnEditBooks.TabIndex = 8;
            this.btnEditBooks.Text = "Editovať Položky";
            this.btnEditBooks.UseVisualStyleBackColor = true;
            this.btnEditBooks.Click += new System.EventHandler(this.btnEditBooks_Click);
            // 
            // btnDeleteBooks
            // 
            this.btnDeleteBooks.ForeColor = System.Drawing.Color.Chocolate;
            this.btnDeleteBooks.Location = new System.Drawing.Point(6, 267);
            this.btnDeleteBooks.Name = "btnDeleteBooks";
            this.btnDeleteBooks.Size = new System.Drawing.Size(170, 23);
            this.btnDeleteBooks.TabIndex = 7;
            this.btnDeleteBooks.Text = "Odstrániť označené položky";
            this.btnDeleteBooks.UseVisualStyleBackColor = true;
            this.btnDeleteBooks.Click += new System.EventHandler(this.btnDeleteBooks_Click);
            // 
            // gvAllBooks
            // 
            this.gvAllBooks.AllowUserToAddRows = false;
            this.gvAllBooks.AllowUserToDeleteRows = false;
            this.gvAllBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAllBooks.Location = new System.Drawing.Point(6, 3);
            this.gvAllBooks.Name = "gvAllBooks";
            this.gvAllBooks.ReadOnly = true;
            this.gvAllBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAllBooks.Size = new System.Drawing.Size(637, 258);
            this.gvAllBooks.TabIndex = 0;
            this.gvAllBooks.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gvAllBooks_RowPrePaint);
            // 
            // tabAvailBooks
            // 
            this.tabAvailBooks.Controls.Add(this.gvAvailBooks);
            this.tabAvailBooks.Controls.Add(this.btnReserveBook);
            this.tabAvailBooks.Location = new System.Drawing.Point(4, 22);
            this.tabAvailBooks.Name = "tabAvailBooks";
            this.tabAvailBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabAvailBooks.Size = new System.Drawing.Size(649, 309);
            this.tabAvailBooks.TabIndex = 1;
            this.tabAvailBooks.Text = "Voľné knihy";
            this.tabAvailBooks.UseVisualStyleBackColor = true;
            // 
            // gvAvailBooks
            // 
            this.gvAvailBooks.AllowUserToAddRows = false;
            this.gvAvailBooks.AllowUserToDeleteRows = false;
            this.gvAvailBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAvailBooks.Location = new System.Drawing.Point(6, 3);
            this.gvAvailBooks.Name = "gvAvailBooks";
            this.gvAvailBooks.ReadOnly = true;
            this.gvAvailBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAvailBooks.Size = new System.Drawing.Size(637, 279);
            this.gvAvailBooks.TabIndex = 1;
            // 
            // btnReserveBook
            // 
            this.btnReserveBook.Location = new System.Drawing.Point(18, 283);
            this.btnReserveBook.Name = "btnReserveBook";
            this.btnReserveBook.Size = new System.Drawing.Size(75, 23);
            this.btnReserveBook.TabIndex = 3;
            this.btnReserveBook.Text = "Rezervovať knihu";
            this.btnReserveBook.UseVisualStyleBackColor = true;
            this.btnReserveBook.Click += new System.EventHandler(this.btnReserveBook_Click);
            // 
            // tabMyBooks
            // 
            this.tabMyBooks.Controls.Add(this.gvMyBooks);
            this.tabMyBooks.Controls.Add(this.btnReturnBook);
            this.tabMyBooks.Location = new System.Drawing.Point(4, 22);
            this.tabMyBooks.Name = "tabMyBooks";
            this.tabMyBooks.Size = new System.Drawing.Size(649, 309);
            this.tabMyBooks.TabIndex = 2;
            this.tabMyBooks.Text = "Požičané knihy";
            this.tabMyBooks.UseVisualStyleBackColor = true;
            // 
            // gvMyBooks
            // 
            this.gvMyBooks.AllowUserToAddRows = false;
            this.gvMyBooks.AllowUserToDeleteRows = false;
            this.gvMyBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMyBooks.Location = new System.Drawing.Point(6, 3);
            this.gvMyBooks.Name = "gvMyBooks";
            this.gvMyBooks.ReadOnly = true;
            this.gvMyBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvMyBooks.Size = new System.Drawing.Size(640, 270);
            this.gvMyBooks.TabIndex = 1;
            this.gvMyBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMyBooks_CellContentClick);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Location = new System.Drawing.Point(6, 270);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(75, 23);
            this.btnReturnBook.TabIndex = 2;
            this.btnReturnBook.Text = "Vrátiť označené knihy";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // tabCreateBook
            // 
            this.tabCreateBook.Controls.Add(this.btnBookAdd);
            this.tabCreateBook.Controls.Add(this.label2);
            this.tabCreateBook.Controls.Add(this.tbAuthor);
            this.tabCreateBook.Controls.Add(this.label1);
            this.tabCreateBook.Controls.Add(this.tbBookName);
            this.tabCreateBook.Location = new System.Drawing.Point(4, 22);
            this.tabCreateBook.Name = "tabCreateBook";
            this.tabCreateBook.Size = new System.Drawing.Size(649, 309);
            this.tabCreateBook.TabIndex = 3;
            this.tabCreateBook.Text = "Vytvoriť knihu";
            this.tabCreateBook.UseVisualStyleBackColor = true;
            // 
            // btnBookAdd
            // 
            this.btnBookAdd.Location = new System.Drawing.Point(92, 82);
            this.btnBookAdd.Name = "btnBookAdd";
            this.btnBookAdd.Size = new System.Drawing.Size(75, 23);
            this.btnBookAdd.TabIndex = 4;
            this.btnBookAdd.Text = "Pridať knihu";
            this.btnBookAdd.UseVisualStyleBackColor = true;
            this.btnBookAdd.Click += new System.EventHandler(this.btnBookAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Autor";
            // 
            // tbAuthor
            // 
            this.tbAuthor.Location = new System.Drawing.Point(67, 56);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(100, 20);
            this.tbAuthor.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Názov";
            // 
            // tbBookName
            // 
            this.tbBookName.Location = new System.Drawing.Point(67, 30);
            this.tbBookName.Name = "tbBookName";
            this.tbBookName.Size = new System.Drawing.Size(100, 20);
            this.tbBookName.TabIndex = 0;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLogOut.Location = new System.Drawing.Point(558, 85);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(111, 34);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "Odhlásiť";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.LogOut);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.súborToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(715, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // súborToolStripMenuItem
            // 
            this.súborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBtnUsrExport,
            this.menuBtnImport,
            this.menubtnExportLib,
            this.manuBtnImportLib});
            this.súborToolStripMenuItem.Name = "súborToolStripMenuItem";
            this.súborToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.súborToolStripMenuItem.Text = "Súbor";
            // 
            // menuBtnUsrExport
            // 
            this.menuBtnUsrExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuBtnUsrExport.Name = "menuBtnUsrExport";
            this.menuBtnUsrExport.Size = new System.Drawing.Size(181, 22);
            this.menuBtnUsrExport.Text = "Export používateľov";
            this.menuBtnUsrExport.Click += new System.EventHandler(this.menuBtnExport_Click);
            // 
            // menuBtnImport
            // 
            this.menuBtnImport.Name = "menuBtnImport";
            this.menuBtnImport.Size = new System.Drawing.Size(181, 22);
            this.menuBtnImport.Text = "Import používateľov";
            this.menuBtnImport.Click += new System.EventHandler(this.menuBtnImport_Click);
            // 
            // menubtnExportLib
            // 
            this.menubtnExportLib.Name = "menubtnExportLib";
            this.menubtnExportLib.Size = new System.Drawing.Size(181, 22);
            this.menubtnExportLib.Text = "Export knižnice";
            this.menubtnExportLib.Click += new System.EventHandler(this.menuBtnExportLib_Click);
            // 
            // manuBtnImportLib
            // 
            this.manuBtnImportLib.Name = "manuBtnImportLib";
            this.manuBtnImportLib.Size = new System.Drawing.Size(181, 22);
            this.manuBtnImportLib.Text = "Import knižnice";
            this.manuBtnImportLib.Click += new System.EventHandler(this.manuBtnImportLib_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 519);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Knižnica";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.OnShow);
            this.tabControl1.ResumeLayout(false);
            this.tabAllBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvAllBooks)).EndInit();
            this.tabAvailBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvAvailBooks)).EndInit();
            this.tabMyBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMyBooks)).EndInit();
            this.tabCreateBook.ResumeLayout(false);
            this.tabCreateBook.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAllBooks;
        private System.Windows.Forms.TabPage tabAvailBooks;
        private System.Windows.Forms.TabPage tabMyBooks;
        private System.Windows.Forms.TabPage tabCreateBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnReserveBook;
        private System.Windows.Forms.DataGridView gvAllBooks;
        private System.Windows.Forms.DataGridView gvAvailBooks;
        private System.Windows.Forms.DataGridView gvMyBooks;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem súborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuBtnUsrExport;
        private System.Windows.Forms.ToolStripMenuItem menuBtnImport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menubtnExportLib;
        private System.Windows.Forms.ToolStripMenuItem manuBtnImportLib;
        private System.Windows.Forms.Button btnBookAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBookName;
        private System.Windows.Forms.Button btnDeleteBooks;
        private System.Windows.Forms.Button btnEditBooks;
    }
}

