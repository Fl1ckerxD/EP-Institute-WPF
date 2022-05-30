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
    /// Логика взаимодействия для AddPlan.xaml
    /// </summary>
    public partial class AddPlan : Page
    {
        public AddPlan()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
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
    }
}
