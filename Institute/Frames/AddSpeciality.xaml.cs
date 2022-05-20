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
using System.Text.RegularExpressions;


namespace Institute.Frames
{
    /// <summary>
    /// Логика взаимодействия для AddSpeciality.xaml
    /// </summary>
    public partial class AddSpeciality : Page
    {
        public AddSpeciality()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cb_qualifi.ItemsSource = ConnectionDB.conDB.Квалификация.ToList();
            cb_qualifi.SelectedValuePath = "IdКвалиф";
            cb_qualifi.DisplayMemberPath = "Название";

            cb_facult.ItemsSource = ConnectionDB.conDB.Факультет.ToList();
            cb_facult.SelectedValuePath = "IdФакульт";
            cb_facult.DisplayMemberPath = "Название";

            cb_forma.ItemsSource = ConnectionDB.conDB.ФормаОбучения.ToList();
            cb_forma.SelectedValuePath = "IdФорма";
            cb_forma.DisplayMemberPath = "Название";
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            Model.Специальность spec = new Model.Специальность()
            {
                IdСпец = 7,
                Название = tb_title.Text,
                IdКвалиф = (int)cb_qualifi.SelectedValue,
                Продолжительность = String.Format("{0} года {1} месяца", tb_year, tb_month), // add new method
                IdФормаОбуч = (int)cb_forma.SelectedValue,
                IdФакультет = (int)cb_facult.SelectedValue

                //IdСпец = 6,
                //Название = "История и обществознание",
                //IdКвалиф = 1,
                //Продолжительность = "4 года", // add new method
                //IdФормаОбуч = 1,
                //IdФакультет = 5
            };
            ConnectionDB.conDB.Специальность.Add(spec);
            ConnectionDB.conDB.SaveChanges();
        }
    }
}
