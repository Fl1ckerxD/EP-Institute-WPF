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
    /// Логика взаимодействия для AddDiscipline.xaml
    /// </summary>
    public partial class AddDiscipline : Page
    {
        public AddDiscipline()
        {
            InitializeComponent();
        }

        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            Model.Дисциплина dis = new Model.Дисциплина()
            {
                Название = tb_title.Text
            };
            ConnectionDB.conDB.Дисциплина.Add(dis);
            ConnectionDB.conDB.SaveChanges();
        }
    }
}
