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

namespace Institute.Frames.Insert
{
    /// <summary>
    /// Логика взаимодействия для AddManager.xaml
    /// </summary>
    public partial class AddManager : Page, IUpdating
    {
        public AddManager()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCombobox();
        }
        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tb_lastName.Text) || String.IsNullOrWhiteSpace(tb_name.Text) || cb_rank.SelectedItem == null || cb_stepen.SelectedItem == null)
            {
                description.Text = "Не все данные были введены";
                notific.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    Model.ЗавКафедрой zav = new Model.ЗавКафедрой()
                    {
                        Фамилия = tb_lastName.Text,
                        Имя = tb_name.Text,
                        Отчество = tb_patronymic.Text,
                        IdСтепень = (int)cb_stepen.SelectedValue,
                        IdЗвание = (int)cb_rank.SelectedValue
                    };

                    ConnectionDB.conDB.ЗавКафедрой.Add(zav);
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
        public void UpdateCombobox()
        {
            cb_rank.ItemsSource = ConnectionDB.conDB.Звание.ToList();
            cb_stepen.ItemsSource = ConnectionDB.conDB.Степень.ToList();
        }
    }
}
