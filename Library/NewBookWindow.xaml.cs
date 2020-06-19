using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for NewBookWindow.xaml
    /// </summary>
    public partial class NewBookWindow : Window
    {
        LibraryEntities1 db = new LibraryEntities1();

        public NewBookWindow()
        {
            InitializeComponent();
            GenreeCB.ItemsSource = db.Genres.ToList();
            SectionCB.ItemsSource = db.Sections.ToList();
            LocationCB.ItemsSource = db.BookLocations.ToList();

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (NameBookTB.Text == "" || AuthorTB.Text == "" || GenreeCB.Text == "" || SectionCB.Text == "" || LocationCB.Text == "")
            {
                Err.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                Book book = new Book();
                book.BookName = NameBookTB.Text;
                book.Autor = AuthorTB.Text;
                Genre gen = GenreeCB.SelectedItem as Genre;
                book.FK_GENRE = gen.GenreID;
                BookLocation bl = LocationCB.SelectedItem as BookLocation;
                book.FK_BookLocation = bl.BookLocationID;
                Section sec = SectionCB.SelectedItem as Section;
                book.FK_Section = sec.SectionID;
                book.FK_StatusId = 2;
                book.FK_RentID = null;
                db.Books.Add(book);
                db.SaveChanges();
                this.Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
