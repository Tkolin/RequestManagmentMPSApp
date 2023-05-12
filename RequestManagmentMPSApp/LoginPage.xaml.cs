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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RequestManagmentMPSApp
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = tBox1.Text;
            string password = tBox2.Text;

            if (RequestManagmentMPSDBEntities.GetContext().User.Where(u => u.Login == login && u.Password == password).Count() != 0)
            {
                User users = RequestManagmentMPSDBEntities.GetContext().User.Where(u => u.Login == login && u.Password == password).First();
                NavigationService.Navigate(new MenyPage(users));
            }
        }
    }
}
