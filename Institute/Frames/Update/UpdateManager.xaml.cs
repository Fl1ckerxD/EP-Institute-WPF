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

namespace Institute.Frames.Update
{
    /// <summary>
    /// Логика взаимодействия для UpdateManager.xaml
    /// </summary>
    public partial class UpdateManager : Page
    {
        private int idDepart;
        public UpdateManager(int idDepart)
        {
            InitializeComponent();
            this.idDepart = idDepart;
        }

        private void b_save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
