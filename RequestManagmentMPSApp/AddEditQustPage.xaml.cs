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
    /// Логика взаимодействия для AddEditQustPage.xaml
    /// </summary>
    public partial class AddEditQustPage : Page
    {
        Request request;
        User user;
        bool add;
        public AddEditQustPage( Request request,User user)
        {
            InitializeComponent();
            this.request = request;
            this.add = false;
            this.user = user;
        }
        public AddEditQustPage( User user)
        {
            InitializeComponent();
            this.request = new Request();
            this.add = true;
            this.user = user;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //save
            request.Name = tBox1.Text;
            request.MessageСontent = tBox2.Text;
            request.DateCreate = dPicer1.SelectedDate;

            request.User = cBox1.SelectedItem as User;
            request.Topic = cBox2.SelectedItem as Topic;
            request.Status = cBox3.SelectedItem as Status;


            if(add)
                RequestManagmentMPSDBEntities.GetContext().Request.Add(request);    

            RequestManagmentMPSDBEntities.GetContext().SaveChanges();
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //back
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cBox1.ItemsSource = RequestManagmentMPSDBEntities.GetContext().User.ToList();
            cBox1.DisplayMemberPath = "Name";
            cBox2.ItemsSource = RequestManagmentMPSDBEntities.GetContext().Topic.ToList();
            cBox2.DisplayMemberPath = "Name";
            cBox3.ItemsSource = RequestManagmentMPSDBEntities.GetContext().Status.ToList();
            cBox3.DisplayMemberPath = "Name";

            if (!add)
            {
                tBox1.Text = request.Name;
                tBox2.Text = request.MessageСontent ;
                dPicer1.SelectedDate = request.DateCreate;
                cBox1.SelectedItem = request.User;
                cBox2.SelectedItem = request.Topic;
                cBox3.SelectedItem = request.Status;


                dataGrid.ItemsSource = request.Message;
            }
        }

        private void btnDelQuast_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;

            RequestManagmentMPSDBEntities.GetContext().Message.Remove(dataGrid.SelectedItem as Message);
        }

        private void btnEditQuast_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;

            AddEditMessageWindow adw = new AddEditMessageWindow(request, user,dataGrid.SelectedItem as Message);
             adw.ShowDialog();
        }

        private void btnAddQuast_Click(object sender, RoutedEventArgs e)
        {
            AddEditMessageWindow adw = new AddEditMessageWindow(request,user);
             adw.ShowDialog();
        }
    }
}
