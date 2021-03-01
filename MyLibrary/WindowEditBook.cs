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
namespace MyLibrary
{
    public partial class WindowEditBook : Form
    {
        public Library LibrarySnapshot { get; set; }
        public List<Book> Books { get; set; }
        public List<int> IdsToSelect;
        public WindowEditBook()
        {
            InitializeComponent();
        }

        public void UpdateGrid()
        {
            gvEditBookExplorer.DataSource = pBook.GetBookByList(Books);
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tbConfirm_Click(object sender, EventArgs e)
        {
            foreach (Book book in Books)
            {
                LibrarySnapshot.EditBook(book);
            }
            this.Close();

        }

        private void WindowEditBook_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateEditorFields();
        }

        private void gvEditBookExplorer_Click(object sender, EventArgs e)
        {
            UpdateEditorFields();
        }

        private void UpdateEditorFields()
        {
            int CurrentBookId = Convert.ToInt32(gvEditBookExplorer.SelectedRows[0].Cells["Id"].Value);
            try
            {
                Book currentBook = (from b in Books where b.Id == CurrentBookId select b).First();


                tbBookName.Text = currentBook.Name;
                tbAuthor.Text = currentBook.Author;

            }
            catch
            {
                MessageBox.Show("Nebolo možné zobraziť vybranú položku dáta sú pravdepodobne poškodené");


            }
        }

        private void ApplyChangesToBookList()
        {
            if (tbAuthor.Text.Length == 0 || tbBookName.Text.Length == 0)
            {
                MessageBox.Show("Všetky polia sú povinné");
                return;
            }

            int CurrentBookId = Convert.ToInt32(gvEditBookExplorer.SelectedRows[0].Cells["Id"].Value);
            try
            {
                Book currentBook = (from b in Books where b.Id == CurrentBookId select b).First();

                currentBook.Name = tbBookName.Text;
                currentBook.Author = tbAuthor.Text;

            }
            catch
            {
                MessageBox.Show("Nie je vybratá žiadna položka");


            }
        }

        private void tbBookName_TextChanged(object sender, EventArgs e)
        {
            //ApplyChangesToBookList();
        }

        private void tbAuthor_TextChanged(object sender, EventArgs e)
        {
            //ApplyChangesToBookList();
        }

        private void btnChangeItem_Click(object sender, EventArgs e)
        {
            ApplyChangesToBookList();
            UpdateGrid();
        }
    }
}


