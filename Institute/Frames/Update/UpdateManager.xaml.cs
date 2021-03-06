using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Institute.Classes;

namespace Institute.Frames.Update
{
    /// <summary>
    /// Логика взаимодействия для UpdateManager.xaml
    /// </summary>
    public partial class UpdateManager : Page
    {
        private int idZav;
        public UpdateManager(int idZav)
        {
            InitializeComponent();
            this.idZav = idZav;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cb_rank.ItemsSource = ConnectionDB.conDB.Звание.ToList();
            cb_stepen.ItemsSource = ConnectionDB.conDB.Степень.ToList();

            tb_lastName.Text = ConnectionDB.conDB.ЗавКафедрой.Find(idZav).Фамилия;
            tb_name.Text = ConnectionDB.conDB.ЗавКафедрой.Find(idZav).Имя;
            tb_patronymic.Text = ConnectionDB.conDB.ЗавКафедрой.Find(idZav).Отчество;
            cb_rank.SelectedValue = ConnectionDB.conDB.ЗавКафедрой.Find(idZav).IdЗвание;
            cb_stepen.SelectedValue = ConnectionDB.conDB.ЗавКафедрой.Find(idZav).IdСтепень;
        }

        private void b_save_Click(object sender, RoutedEventArgs e)
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
                    var result = ConnectionDB.conDB.ЗавКафедрой.SingleOrDefault(u => u.IdЗавКаф == idZav);
                    if (result != null)
                    {
                        result.Фамилия = tb_lastName.Text;
                        result.Имя = tb_name.Text;
                        result.Отчество = tb_patronymic.Text;
                        result.IdСтепень = (int)cb_stepen.SelectedValue;
                        result.IdЗвание = (int)cb_rank.SelectedValue;
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
    }
}
