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
    /// Логика взаимодействия для AddPlan.xaml
    /// </summary>
    public partial class AddPlan : Page, IUpdating
    {
        public AddPlan()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCombobox();
        }

        public void UpdateCombobox()
        {
            cb_discip.ItemsSource = ConnectionDB.conDB.Дисциплина.ToList();
            cb_otchet.ItemsSource = ConnectionDB.conDB.ВидОтчетности.ToList();
            cb_spec.ItemsSource = ConnectionDB.conDB.Специальность.ToList();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tb_kurs.Text) || String.IsNullOrWhiteSpace(tb_lab.Text) || String.IsNullOrWhiteSpace(tb_lek.Text) || String.IsNullOrWhiteSpace(tb_parc.Text)
                || cb_discip.SelectedItem == null || cb_otchet.SelectedItem == null || cb_semestr.SelectedItem == null || cb_spec.SelectedItem == null)
            {
                description.Text = "Не все данные были введены";
                notific.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    Model.УчебныйПлан plan = new Model.УчебныйПлан()
                    {
                        IdДисцип = (int)cb_discip.SelectedValue,
                        IdСпец = (int)cb_spec.SelectedValue,
                        ЧасыЛекции = Convert.ToInt32(tb_lek.Text),
                        ЧасыЛабРабот = Convert.ToInt32(tb_lab.Text),
                        ЧасыПракРабот = Convert.ToInt32(tb_parc.Text),
                        ЧасыКурсового = Convert.ToInt32(tb_kurs.Text),
                        IdВидОтчет = (int)cb_otchet.SelectedValue,
                        Семестр = (int)cb_semestr.SelectedItem
                    };
                    ConnectionDB.conDB.УчебныйПлан.Add(plan);
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
        private void b_addDiscip_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddDiscipline facultet = new Windows.AddDiscipline(this);
            facultet.Show();
        }
    }
}
