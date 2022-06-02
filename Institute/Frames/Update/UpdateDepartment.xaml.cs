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
    /// Логика взаимодействия для UpdateDepartment.xaml
    /// </summary>
    public partial class UpdateDepartment : Page, IUpdating
    {
        private int idDepart;
        public UpdateDepartment(int idDepart)
        {
            InitializeComponent();
            this.idDepart = idDepart;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCombobox();

            tb_title.Text = ConnectionDB.conDB.Кафедра.Find(idDepart).Название;
            tb_phone.Text = ConnectionDB.conDB.Кафедра.Find(idDepart).Телефон;
            cb_facult.SelectedValue = ConnectionDB.conDB.Кафедра.Find(idDepart).IdФакультет;
            cb_manager.SelectedValue = ConnectionDB.conDB.Кафедра.Find(idDepart).IdЗавКаф;
        }
        public void UpdateCombobox()
        {
            cb_facult.ItemsSource = ConnectionDB.conDB.Факультет.ToList();
            cb_manager.ItemsSource = ConnectionDB.conDB.ЗавКафедрой.ToList();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void b_save_Click(object sender, RoutedEventArgs e)
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
                    var result = ConnectionDB.conDB.Кафедра.SingleOrDefault(u => u.IdКафедра == idDepart);
                    if (result != null)
                    {
                        result.Название = tb_title.Text;
                        result.Телефон = tb_phone.Text;
                        result.IdЗавКаф = (int)cb_manager.SelectedValue;
                        result.IdФакультет = (int)cb_facult.SelectedValue;
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
