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
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Institute.Classes;

namespace Institute.Frames.Update
{
    /// <summary>
    /// Логика взаимодействия для UpdateSpeciality.xaml
    /// </summary>
    public partial class UpdateSpeciality : Page, IUpdating
    {
        private int idSpec;
        public UpdateSpeciality(int idSpec)
        {
            InitializeComponent();
            this.idSpec = idSpec;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCombobox();

            cb_qualifi.SelectedValue = ConnectionDB.conDB.Специальность.Find(idSpec).IdКвалиф;
            cb_facult.SelectedValue = ConnectionDB.conDB.Специальность.Find(idSpec).IdФакультет;
            cb_forma.SelectedValue = ConnectionDB.conDB.Специальность.Find(idSpec).IdФормаОбуч;
            tb_title.Text = ConnectionDB.conDB.Специальность.Find(idSpec).Название;
            tb_year.Text = MyDuration.OutputYear(ConnectionDB.conDB.Специальность.Find(idSpec).Продолжительность);
            tb_month.Text = MyDuration.OutputMonth(ConnectionDB.conDB.Специальность.Find(idSpec).Продолжительность);
        }
        public void UpdateCombobox()
        {
            cb_qualifi.ItemsSource = ConnectionDB.conDB.Квалификация.ToList();
            cb_facult.ItemsSource = ConnectionDB.conDB.Факультет.ToList();
            cb_forma.ItemsSource = ConnectionDB.conDB.ФормаОбучения.ToList();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void b_save_Click(object sender, RoutedEventArgs e)
        {
            if (tb_title.Text == string.Empty || tb_year.Text == string.Empty || cb_facult.SelectedItem == null
                || cb_forma.SelectedItem == null || cb_qualifi.SelectedItem == null)
            {
                description.Text = "Не все данные были введены";
                notific.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    var result = ConnectionDB.conDB.Специальность.SingleOrDefault(u => u.IdСпец == idSpec);
                    if (result != null)
                    {
                        result.IdКвалиф = (int)cb_qualifi.SelectedValue;
                        result.IdФакультет = (int)cb_facult.SelectedValue;
                        result.IdФормаОбуч = (int)cb_forma.SelectedValue;
                        result.Название = tb_title.Text;
                        result.Продолжительность = MyDuration.ConnectDate(tb_year.Text, tb_month.Text);
                        ConnectionDB.conDB.SaveChanges();
                    }
                }
                catch
                {
                    description.Text = "Ошибка сохранения данных";
                    notific.Visibility = Visibility.Visible;
                }
            }
        }
        private void b_close_Click(object sender, RoutedEventArgs e)
        {
            notific.Visibility = Visibility.Hidden;
        }

        private void b_addfacult_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddFacultet facultet = new Windows.AddFacultet(this);
            facultet.Show();
        }
    }
}
