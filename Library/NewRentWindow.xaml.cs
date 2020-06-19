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
    /// Interaction logic for NewRentWindow.xaml
    /// </summary>
    public partial class NewRentWindow : Window
    {
        LibraryEntities1 db = new LibraryEntities1();

        public NewRentWindow()
        {
            InitializeComponent();
            BookCB.ItemsSource = db.Books.ToList();
            TenantCB.ItemsSource = db.Tenants.ToList();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Rent rent = new Rent();
            
            Tenant ten = TenantCB.SelectedItem as Tenant;
            Book book = BookCB.SelectedItem as Book;
         
            book.FK_StatusId = 1;

            rent.FK_Tenant = ten.TenantID;
            rent.DateOfRent = DateTime.Now.Date;

            db.Rents.Add(rent);
            db.SaveChanges();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
