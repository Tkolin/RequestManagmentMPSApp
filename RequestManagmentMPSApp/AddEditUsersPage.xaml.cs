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
    /// Логика взаимодействия для AddEditUsersPage.xaml
    /// </summary>
    public partial class AddEditUsersPage : Page
    {
        User user;
        bool add;
        public AddEditUsersPage(User user)
        {
            InitializeComponent();
            this.user = user;
            add = false;
        }
        public AddEditUsersPage()
        {
            InitializeComponent();
            this.user = new User();
            add = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //save

            user.FirstName = tBox1.Text;
            user.LastName = tBox2.Text;
            user.Patronymic = tBox3.Text;
            user.Email = tBox4.Text;
            user.PhoneNumber = tBox5.Text;
            user.Login = tBox6.Text;
            user.Password = tBox7.Text;
            user.Role = cBox1.SelectedItem as Role;


            if (add)
                RequestManagmentMPSDBEntities.GetContext().User.Add(user);

            RequestManagmentMPSDBEntities.GetContext().SaveChanges();
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cBox1.ItemsSource = RequestManagmentMPSDBEntities.GetContext().Role.ToList();
            cBox1.DisplayMemberPath = "Name";


            if (!add)
            {
                tBox1.Text = user.FirstName;
                tBox2.Text = user.LastName;
                tBox3.Text = user.Patronymic;
                tBox4.Text = user.Email;
                tBox5.Text = user.PhoneNumber;
                tBox6.Text = user.Login;
                tBox7.Text = user.Password;
                cBox1.SelectedItem = user.Role;
            }
        }
    }
}
