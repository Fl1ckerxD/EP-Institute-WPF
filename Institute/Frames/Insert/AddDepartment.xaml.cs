using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Institute.Classes;

namespace Institute.Frames.Insert
{
    /// <summary>
    /// Логика взаимодействия для AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Page, IUpdating
    {
        public AddDepartment()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCombobox();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tb_title.Text) || String.IsNullOrWhiteSpace(tb_phone.Text) || cb_facult.SelectedItem == null || cb_manager.SelectedItem == null)
            {
                description.Text = "Не все данные были введены";
                notific.Visibility = Visibility.Visible;
            }
            else
            {
                try
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
        public void UpdateCombobox()
        {
            cb_facult.ItemsSource = ConnectionDB.conDB.Факультет.ToList();
            cb_manager.ItemsSource = ConnectionDB.conDB.ЗавКафедрой.ToList();
        }
    }
}
