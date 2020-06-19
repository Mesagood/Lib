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
    /// Логика взаимодействия для ReaderList.xaml
    /// </summary>
    public partial class ReaderList : Window
    {
        LibraryEntities1 db = new LibraryEntities1();
        public ReaderList()
        {
            InitializeComponent();
            TenantGrid.ItemsSource = db.Tenants.ToList();
        }

        private void TenantGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            EditReader op = new EditReader();
            op.Show();
            this.Close();
        }
            

        private void EditClick(object sender, RoutedEventArgs e)
        {
            Tenant tenant = TenantGrid.SelectedItem as Tenant;
            db.Tenants.Remove(tenant);
            db.SaveChanges();
            TenantGrid.ItemsSource = db.Tenants.ToList();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow open = new MainWindow();
            open.Show();
            this.Close();
        }
    }
}
