using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Institute.Frames.Insert
{
    /// <summary>
    /// Логика взаимодействия для AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Page
    {
        public AddDepartment()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cb_facult.ItemsSource = ConnectionDB.conDB.Факультет.ToList();
            cb_manager.ItemsSource = ConnectionDB.conDB.ЗавКафедрой.ToList();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            if (tb_title.Text == string.Empty || tb_phone.Text == string.Empty || cb_facult.SelectedItem == null || cb_manager.SelectedItem == null)
            {
                // error something
            }
            else
            {
                Model.Кафедра kaf = new Model.Кафедра()
                {
                    Название = tb_title.Text,
                    Телефон = tb_phone.Text,
                    IdФакультет = (int)cb_facult.SelectedValue,
                    IdЗавКаф = (int)cb_manager.SelectedValue
                };
                ConnectionDB.conDB.Кафедра.Add(kaf);
                ConnectionDB.conDB.SaveChanges();
            }
        }
    }
}
