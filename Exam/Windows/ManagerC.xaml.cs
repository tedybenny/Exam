using Exam.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Mall> mallList{ get;set; }
        public ManagerC()
        {
            InitializeComponent();
            DataContext = this;
            mallList = Tables.ReadMalls();

        }

    }
}
