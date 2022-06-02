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
using System.Windows.Shapes;
using Institute.Classes;

namespace Institute.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddDiscipline.xaml
    /// </summary>
    public partial class AddDiscipline : Window
    {
        private IUpdating updating;
        public AddDiscipline(IUpdating page)
        {
            InitializeComponent();
            updating = page;
        }

        private void b_addNewClose_Click(object sender, RoutedEventArgs e)
        {
            if ( !String.IsNullOrWhiteSpace(tb_title.Text))
            {
                b_addNew_Click(sender, e);
                this.Close();
            }
        }

        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tb_title.Text))
            {
                Model.Дисциплина dis = new Model.Дисциплина()
                {
                    Название = tb_title.Text
                };
                ConnectionDB.conDB.Дисциплина.Add(dis);
                ConnectionDB.conDB.SaveChanges();

                updating.UpdateCombobox();
            }
        }
    }
}
