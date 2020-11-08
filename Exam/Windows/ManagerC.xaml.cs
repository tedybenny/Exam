using Exam.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using static Exam.Classes.Tables;

namespace Exam.Windows
{
    /// <summary>
    /// Логика взаимодействия для ManagerC.xaml
    /// </summary>
    public partial class ManagerC : Window 
    {
        Tables table = new Tables();

        public List<Mall> mallList{ get;set; }
        public Mall mall { get; set; }
        public ManagerC()
        {
            InitializeComponent();
            DataContext = this;
            mallList = Tables.ReadMalls();
        }
        public List<Mall> Filter(ComboBoxItem status)
        {
            mallList = Tables.ReadMalls();
            List<Mall> mallListFilter = new List<Mall>();
            foreach(Mall mall in mallList)
            {
                if (mall.Status == status.Content.ToString())
                {
                    mallListFilter.Add(mall);
                }
            }
            return mallListFilter;
        }

        private void StatusBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if(selectedItem.Content.ToString() == "Без фильтров")
            {
                mallList = Tables.ReadMalls();
                malls.ItemsSource = mallList;
            }
            else
            {
                malls.ItemsSource = Filter(selectedItem);
            }

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            /* if (name.Text != "" && status.Text != "" && count.Text != "" && city.Text != "" && cost.Text != "" && ratio.Text != "" && floors.Text != "")
             {
                 if (table.AddMall(name.Text, status.Text, Convert.ToInt32(count.Text),city.Text,Convert.ToDouble(cost.Text), Convert.ToDouble(ratio.Text),Convert.ToInt32(floors.Text)) == true)
                 {
                     MessageBox.Show("Успешно");
                 }
                 else
                 {
                     MessageBox.Show("ПАЛУНДРА!!!");
                 }
             }
             */

             if (name.Text != "" && status.Text != "" && count.Text != "" && city.Text != "" && cost.Text != "" && ratio.Text != "" && floors.Text != "")
            {
                if (table.EditMall(name.Text, status.Text, Convert.ToInt32(count.Text),city.Text,Convert.ToDouble(cost.Text), Convert.ToDouble(ratio.Text),Convert.ToInt32(floors.Text), Convert.ToString(mall.Name)) == true)
                {
                    MessageBox.Show("Успешно");
                }
                else
                {
                    MessageBox.Show("ПАЛУНДРА!!!");
                }
            }
            
        }
    }
}
