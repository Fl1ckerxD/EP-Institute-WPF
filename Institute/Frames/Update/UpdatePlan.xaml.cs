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
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Institute.Classes;

namespace Institute.Frames.Update
{
    /// <summary>
    /// Логика взаимодействия для UpdatePlan.xaml
    /// </summary>
    public partial class UpdatePlan : Page
    {
        private int idPlan;
        public UpdatePlan(int idPlan)
        {
            InitializeComponent();
            this.idPlan = idPlan;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cb_discip.ItemsSource = ConnectionDB.conDB.Дисциплина.ToList();
            cb_otchet.ItemsSource = ConnectionDB.conDB.ВидОтчетности.ToList();
            cb_spec.ItemsSource = ConnectionDB.conDB.Специальность.ToList();

            cb_discip.SelectedValue = ConnectionDB.conDB.УчебныйПлан.Find(idPlan).IdДисцип;
            cb_otchet.SelectedValue = ConnectionDB.conDB.УчебныйПлан.Find(idPlan).IdВидОтчет;
            cb_spec.SelectedValue = ConnectionDB.conDB.УчебныйПлан.Find(idPlan).IdСпец;
            tb_kurs.Text = ConnectionDB.conDB.УчебныйПлан.Find(idPlan).ЧасыКурсового.ToString();
            tb_lab.Text = ConnectionDB.conDB.УчебныйПлан.Find(idPlan).ЧасыЛабРабот.ToString();
            tb_lek.Text = ConnectionDB.conDB.УчебныйПлан.Find(idPlan).ЧасыЛекции.ToString();
            tb_parc.Text = ConnectionDB.conDB.УчебныйПлан.Find(idPlan).ЧасыПракРабот.ToString();
            tb_semestr.Text = ConnectionDB.conDB.УчебныйПлан.Find(idPlan).Семестр.ToString();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void b_save_Click(object sender, RoutedEventArgs e)
        {
            var result = ConnectionDB.conDB.УчебныйПлан.SingleOrDefault(u => u.IdПлан == idPlan);
            if(result != null)
            {
                result.IdДисцип = (int)cb_discip.SelectedValue;
                result.IdСпец = (int)cb_spec.SelectedValue;
                result.IdВидОтчет = (int)cb_otchet.SelectedValue;
                result.ЧасыКурсового = Convert.ToInt32(tb_kurs.Text);
                result.ЧасыЛабРабот = Convert.ToInt32(tb_lab.Text);
                result.ЧасыЛекции = Convert.ToInt32(tb_lek.Text);
                result.ЧасыПракРабот = Convert.ToInt32(tb_parc.Text);
                result.Семестр = Convert.ToInt32(tb_semestr.Text);
                ConnectionDB.conDB.SaveChanges();
            }
        }
    }
}
