using Institute.Classes;
using Institute.Frames;
using System;
using System.Windows;

namespace Institute
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameManager.frmMain = winFrame;
            FrameManager.frmMain.Navigate(new MainPage());
        }

        private void b_back_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frmMain.GoBack();
        }

        private void Window_LayoutUpdated(object sender, EventArgs e)
        {
            if (FrameManager.frmMain.CanGoBack)
                b_back.Visibility = Visibility.Visible;
            else
                b_back.Visibility = Visibility.Hidden;
        }
    }
}
