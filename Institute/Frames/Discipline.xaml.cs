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
    /// Логика взаимодействия для Discipline.xaml
    /// </summary>
    public partial class Discipline : Page
    {
        public Discipline()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = ConnectionDB.conDB.УчебныйПлан.ToList();
        }

        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.frmMain.Navigate(new Insert.AddPlan());
        }

        private void cb_orderBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb_orderBy.SelectedIndex)
            {
                case 0:
                    dataGrid.ItemsSource = ((List<Model.УчебныйПлан>)dataGrid.ItemsSource).OrderBy(u => u.Дисциплина.Название).ToList();
                    break;
                case 1:
                    dataGrid.ItemsSource = ((List<Model.УчебныйПлан>)dataGrid.ItemsSource).OrderByDescending(u => u.Дисциплина.Название).ToList();
                    break;
            }
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = tb_search.Text;
            dataGrid.ItemsSource = ConnectionDB.conDB.УчебныйПлан.Where(u => u.Дисциплина.Название.Contains(search)).ToList();
        }
    }
}
