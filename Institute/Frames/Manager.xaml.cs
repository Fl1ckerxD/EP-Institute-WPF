using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Institute.Classes;

namespace Institute.Frames
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Page
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = ConnectionDB.conDB.ЗавКафедрой.ToList();
        }

        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frmMain.Navigate(new Insert.AddManager());
        }

        private void cb_orderBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb_orderBy.SelectedIndex)
            {
                case 0:
                    dataGrid.ItemsSource = ((List<Model.ЗавКафедрой>)dataGrid.ItemsSource).OrderBy(u => u.FIO).ToList();
                    break;
                case 1:
                    dataGrid.ItemsSource = ((List<Model.ЗавКафедрой>)dataGrid.ItemsSource).OrderByDescending(u => u.FIO).ToList();
                    break;
            }
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = tb_search.Text;
            dataGrid.ItemsSource = ConnectionDB.conDB.ЗавКафедрой.Where(u => u.Фамилия.Contains(search)).ToList();
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem as Model.ЗавКафедрой != null)
            {
                int id = (dataGrid.SelectedItem as Model.ЗавКафедрой).IdЗавКаф;
                FrameManager.frmMain.Navigate(new Update.UpdateManager(id));
            }
        }
    }
}
