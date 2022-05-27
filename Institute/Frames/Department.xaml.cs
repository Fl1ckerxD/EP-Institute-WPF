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

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = tb_search.Text;
            dataGrid.ItemsSource = ConnectionDB.conDB.Кафедра.Where(u => u.Название.Contains(search)).ToList();
        }

        private void cb_orderBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb_orderBy.SelectedIndex)
            {
                case 0:
                    dataGrid.ItemsSource = ((List<Model.Кафедра>)dataGrid.ItemsSource).OrderBy(u => u.Название).ToList();
                    break;
                case 1:
                    dataGrid.ItemsSource = ((List<Model.Кафедра>)dataGrid.ItemsSource).OrderByDescending(u => u.Название).ToList();
                    break;
            }
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem as Model.Кафедра != null)
            {
                int id = (dataGrid.SelectedItem as Model.Кафедра).IdКафедра;
                FrameManager.frmMain.Navigate(new Update.UpdateDepartment(id));
            }
        }
    }
}
