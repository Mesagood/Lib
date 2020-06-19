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

    public partial class EditReader : Window
    {
        LibraryEntities1 db = new LibraryEntities1();
        public EditReader()
        {
            InitializeComponent();
        }

        private void InsertClick(object sender, RoutedEventArgs e)
        {
            if (FirstName != null && LastName != null && MiddleName != null && PhoneNumber != null && NumberList != null)
            {
                Tenant Tenant = new Tenant();
                Tenant.FirstName = FirstName.Text;
                Tenant.LastName = LastName.Text;
                Tenant.MiddleName = MiddleName.Text;
                Tenant.PhoneNumber = PhoneNumber.Text;
                Tenant.LibraryCard = int.Parse(NumberList.Text);
                db.Tenants.Add(Tenant);
                db.SaveChanges();
                MessageBox.Show("Создание прошло успешно");
                ReaderList op = new ReaderList();
                op.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильно введены ");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            ReaderList op = new ReaderList();
            op.Show();
            this.Close();
        }
    }



}
