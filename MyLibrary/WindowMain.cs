using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary.AppLayer;
using MyLibrary.PresentationLayer;
using MyLibrary.Properties;

namespace MyLibrary
{
    public partial class MainWindow : Form
    {
        WindowLogin loginDialog;
        User CurrentUser { get; set; }
        Users UsersSnapshot { get; set; }
        public Library LibrarySnapshot { get; set; }
        String defaultCaption = "Library";
        String mainWindowCaption;
        String MainWindowCaption
        {
            get
            {
                return mainWindowCaption;
            }
            set
            {
                mainWindowCaption = value;
                Text = mainWindowCaption;

            }
        }

        bool unsavedChanges = false;
        bool UnsavedChanges
        {
            get
            {
                return unsavedChanges;
            }
            set
            {

                unsavedChanges = value;
                SetUnsavedState();

            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetUnsavedState()
        {
            MainWindowCaption = defaultCaption + "*";
        }

        public void SetŚavedState()
        {
            MainWindowCaption = defaultCaption;
        }
        private void OnLoad(object sender, EventArgs e)
        {

            LoginUser();
        }


        private void OnLoginSuccesful()
        {
            List<pBook> books = null;
            List<pBook> freeBooks = null;
            List<pBook> myBooks = null;
            UsersSnapshot.LoadFromSnapshot();

            try
            {
                
                books = pBook.GetBooks(LibrarySnapshot, UsersSnapshot);
                gvAllBooks.AutoGenerateColumns = true;
                gvAllBooks.DataSource = books;
                gvAllBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                gvAllBooks.CellContentClick += AllBooksGridClick;

                freeBooks = pBook.GetAvailableBooks(LibrarySnapshot, UsersSnapshot);
                gvAvailBooks.AutoGenerateColumns = true;
                gvAvailBooks.DataSource = freeBooks;


                myBooks = pBook.GetBookByBorrow(CurrentUser, LibrarySnapshot, UsersSnapshot);
                gvMyBooks.AutoGenerateColumns = true;
                gvMyBooks.DataSource = myBooks;


            }
            catch (Exception e)
            {
                var result = MessageBox.Show("Databáza kníh je nedostupná. Prajete si vytvoriť novú?", "Chyba", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Book.InitLibrary();
                }
                else
                {
                    Application.Exit();
                }

            }



        }

        private void AllBooksGridClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            e.RowIndex >= 0)
            {

                var row = senderGrid.Rows[e.RowIndex];
                var bookId = row.Cells[0];
                //Book book = Book.Get(bookId);
                UnsavedChanges = true;
            }
            // if(e.ColumnIndex=)
        }

        private void LoginUser()
        {
            loginDialog = new WindowLogin
            {
                UsersSnapshot = UsersSnapshot

            }; // rebuild login window to initial state
            loginDialog.ShowDialog(); // break and stay in login until login completed 
            if (loginDialog.CurrentUser is null) //second protection against unauthorized access
            {
                MessageBox.Show("Chybne zadané meno alebo heslo");
                Application.Exit();
            }
            else
            {
                CurrentUser = loginDialog.CurrentUser;
                this.Show();
                OnLoginSuccesful();
            }
        }

        private void LogOut(object sender, EventArgs e)
        {
            this.Hide();
            LoginUser();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LibrarySnapshot = new Library();
            LibrarySnapshot.RefreshFromFile();

            UsersSnapshot = new Users();
            UsersSnapshot.LoadXmlStreamSnapshot();
            UsersSnapshot.GetUsers();

        }

        private void OnShow(object sender, EventArgs e)
        {
            LoginUser();
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            var selected = gvAllBooks.SelectedRows;
            UnsavedChanges = true;


        }

        private void btnGetStream_Click(object sender, EventArgs e)
        {
            LibrarySnapshot = new Library();
            LibrarySnapshot.RefreshFromFile();
        }

        private void gvAllBooks_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gvAllBooks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex > 0)
            {

                                
            }
        }

        private void menuBtnExport_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Datový súbor(*.xml)|*.xml";
            saveDialog.ShowDialog();
            
            UsersSnapshot.SaveSnapshotToFile(saveDialog.FileName);

        }

        private void menuBtnImport_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Datový súbor(*.xml)|*.xml";
            openFileDialog.ShowDialog();
            UsersSnapshot.LoadXmlStreamSnapshot(openFileDialog.FileName);
            UsersSnapshot.GetUsers();
        }
    }
}
