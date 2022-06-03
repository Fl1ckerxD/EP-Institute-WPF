using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Institute.Classes;

namespace Institute.Frames
{
    /// <summary>
    /// Логика взаимодействия для Speciality.xaml
    /// </summary>
    public partial class Speciality : Page
    {
        public Speciality()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = ConnectionDB.conDB.Специальность.ToList();
        }

        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frmMain.Navigate(new Insert.AddSpeciality());
        }

        private void cb_orderBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb_orderBy.SelectedIndex)
            {
                case 0:
                    dataGrid.ItemsSource = ((List<Model.Специальность>)dataGrid.ItemsSource).OrderBy(u => u.Название).ToList();
                    break;
                case 1:
                    dataGrid.ItemsSource = ((List<Model.Специальность>)dataGrid.ItemsSource).OrderByDescending(u => u.Название).ToList();
                    break;
            }
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = tb_search.Text;
            dataGrid.ItemsSource = ConnectionDB.conDB.Специальность.Where(u => u.Название.Contains(search)).ToList();
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem as Model.Специальность != null)
            {
                int id = (dataGrid.SelectedItem as Model.Специальность).IdСпец;
                FrameManager.frmMain.Navigate(new Update.UpdateSpeciality(id));
            }
        }
    }
}
