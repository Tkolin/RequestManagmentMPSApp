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
    /// Логика взаимодействия для ManagmentUsersPage.xaml
    /// </summary>
    public partial class ManagmentUsersPage : Page
    {
        User user;
        public ManagmentUsersPage(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //add
            NavigationService.Navigate(new AddEditUsersPage());

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //edit
            if (dataGrid.SelectedItem == null)
                return;

            NavigationService.Navigate(new AddEditUsersPage(dataGrid.SelectedItem as User));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //del
            if (dataGrid.SelectedItem == null)
                return;

            RequestManagmentMPSDBEntities.GetContext().User.Remove(dataGrid.SelectedItem as User);
            RequestManagmentMPSDBEntities.GetContext().SaveChanges();
            Filter();
        }
        public void Filter()
        {
            List<User> list = RequestManagmentMPSDBEntities.GetContext().User.ToList();

            if(tBox.Text.Length > 0)
            list = list.Where(l =>  (l.LastName.ToLower().Contains(tBox.Text.ToLower()) ||
                                                            l.FirstName.ToLower().Contains(tBox.Text.ToLower()) ||
                                                            l.Patronymic.ToLower().Contains(tBox.Text.ToLower()) )).ToList();

            dataGrid.ItemsSource = list;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Filter();
        }
    }
}
