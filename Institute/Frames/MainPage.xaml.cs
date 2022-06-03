using System.Windows;
using System.Windows.Controls;
using Institute.Classes;

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
