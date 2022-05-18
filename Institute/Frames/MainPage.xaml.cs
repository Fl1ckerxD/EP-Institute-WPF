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
using Institute.Frames;

namespace Institute.Frames
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void b_Speciality_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frmMain.Navigate(new Speciality());
        }

        private void b_Department_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frmMain.Navigate(new Department());
        }

        private void b_Discipline_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frmMain.Navigate(new Discipline());
        }

        private void b_Manager_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frmMain.Navigate(new Manager());
        }
    }
}
