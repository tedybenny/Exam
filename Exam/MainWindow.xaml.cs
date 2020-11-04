using System;
using System.Collections.Generic;
using System.Data;
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
using Exam.Classes;
using MySql.Data.MySqlClient;

namespace Exam
{
    public partial class MainWindow : Window
    {
        Tables table = new Tables();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if(table.Auth(login.Text,password.Password) == true)
            {
                MessageBox.Show("Красава,Стас");
            }
            else
            {
                MessageBox.Show("666");
            }
        }
    }
}
