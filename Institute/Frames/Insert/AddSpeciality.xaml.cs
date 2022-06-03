using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Institute.Classes;
using System.Text.RegularExpressions;


namespace Institute.Frames.Insert
{
    /// <summary>
    /// Логика взаимодействия для AddSpeciality.xaml
    /// </summary>
    public partial class AddSpeciality : Page, IUpdating
    {
        public AddSpeciality()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCombobox();
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
        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tb_title.Text) || String.IsNullOrWhiteSpace(tb_year.Text) || cb_facult.SelectedItem == null
                || cb_forma.SelectedItem == null || cb_qualifi.SelectedItem == null)
            {
                description.Text = "Не все данные были введены";
                notific.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    Model.Специальность spec = new Model.Специальность()
                    {
                        Название = tb_title.Text,
                        IdКвалиф = (int)cb_qualifi.SelectedValue,
                        Продолжительность = MyDuration.ConnectDate(tb_year.Text, tb_month.Text),
                        IdФормаОбуч = (int)cb_forma.SelectedValue,
                        IdФакультет = (int)cb_facult.SelectedValue
                    };
                    ConnectionDB.conDB.Специальность.Add(spec);
                    ConnectionDB.conDB.SaveChanges();
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
