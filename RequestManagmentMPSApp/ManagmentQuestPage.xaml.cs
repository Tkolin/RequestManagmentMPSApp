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
    /// Логика взаимодействия для ManagmentQuestPage.xaml
    /// </summary>
    public partial class ManagmentQuestPage : Page
    {
        User user;
        public ManagmentQuestPage(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //назад
            NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //add
            NavigationService.Navigate(new AddEditQustPage(user));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //edit
            if (dataGrid.SelectedItem == null)
                return;

            NavigationService.Navigate(new AddEditQustPage(dataGrid.SelectedItem as Request,user));

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //del
            if (dataGrid.SelectedItem == null)
                return;

            RequestManagmentMPSDBEntities.GetContext().Request.Remove(dataGrid.SelectedItem as Request);
            RequestManagmentMPSDBEntities.GetContext().SaveChanges();
        }
        public void Filter()
        {
            List<Request> list = RequestManagmentMPSDBEntities.GetContext().Request.ToList();

            list = list.Where(l => tBox.Text.Length > 0 && l.Name.ToLower().Contains(tBox.Text.ToLower())).ToList();

            dataGrid.ItemsSource = list;

        }
    }
}
