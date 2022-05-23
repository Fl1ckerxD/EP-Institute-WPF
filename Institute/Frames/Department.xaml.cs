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
using Institute.Classes;

namespace Institute.Frames
{
    /// <summary>
    /// Логика взаимодействия для Department.xaml
    /// </summary>
    public partial class Department : Page
    {
        public Department()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = ConnectionDB.conDB.Кафедра.ToList();
        }

        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frmMain.Navigate(new Insert.AddDepartment());
        }
    }
}
