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
    /// Логика взаимодействия для AddFacultet.xaml
    /// </summary>
    public partial class AddFacultet : Page
    {
        public AddFacultet()
        {
            InitializeComponent();
        }

        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            Model.Факультет facult = new Model.Факультет()
            { 
                Название = tb_title.Text
            };
            ConnectionDB.conDB.Факультет.Add(facult);
            ConnectionDB.conDB.SaveChanges();
        }
    }
}
