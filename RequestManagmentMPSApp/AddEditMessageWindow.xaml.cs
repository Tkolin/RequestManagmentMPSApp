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

namespace RequestManagmentMPSApp
{
    /// <summary>
    /// Логика взаимодействия для AddEditMessageWindow.xaml
    /// </summary>
    public partial class AddEditMessageWindow : Window
    {
        Message message;
        Request request;
        User user;
        bool add;
        public AddEditMessageWindow(Request request, User user)
        {
            InitializeComponent();
            message = new Message();
            add= true;

            this.request = request;
            this.user = user;
        }
        public AddEditMessageWindow(Request request, User user, Message message )
        {
            InitializeComponent();
            this.message = message;
            add = false;

            this.request = request;
            this.user = user;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tBlock1.Text += request.Name;
            tBlock2.Text += request.User.LastName + " " + request.User.FirstName[0] + ". " + request.User.Patronymic[0] + ".";
            tBlock3.Text += user.LastName + " " + user.FirstName[0] + ". " + user.Patronymic[0] + ".";
            if (add == true)
            {
                tBlox1.Text = message.Text;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            message.Request = request;
            message.User = user;
            message.Text = tBlox1.Text;

            if(add)
                RequestManagmentMPSDBEntities.GetContext().Message.Add(message);

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
