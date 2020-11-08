using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static Exam.Classes.Tables;

namespace Exam
{
    public partial class MainWindow : Window
    {
        Tables table = new Tables();
        int enterCount = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if ( enterCount <= 3)
            {
                if (table.Auth(login.Text, password.Password) == true)
                {
                    this.Close();
                }
                else
                {
                    enterCount++;
                    MessageBox.Show("Неправильный логин или пароль");
                    if(enterCount == 3)
                    {
                        Captcha();
                        captchaStack.Visibility = Visibility.Visible;
                    }
                }
            }

            else
            {
                captchaStack.Visibility = Visibility.Visible;
                if (captchaText.Text == captchaInput.Text)
                {
                    if (table.Auth(login.Text, password.Password) == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        enterCount++;
                        MessageBox.Show("Неправильный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Капча введена неверно!");
                }
                Captcha();
            }
            
        }
        private void Captcha()
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i++)
                sb.Append(combination[random.Next(combination.Length)]);

            captchaText.Text = sb.ToString();
        }

    }
}
