using System;
using System.Windows;
using Institute.Classes;

namespace Institute.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddFacultet.xaml
    /// </summary>
    public partial class AddFacultet : Window
    {
        private IUpdating updating;
        public AddFacultet(IUpdating page)
        {
            InitializeComponent();
            updating = page;
        }

        private void b_addNew_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tb_title.Text))
            {
                Model.Факультет facult = new Model.Факультет()
                {
                    Название = tb_title.Text
                };
                ConnectionDB.conDB.Факультет.Add(facult);
                ConnectionDB.conDB.SaveChanges();

                updating.UpdateCombobox();
            }
        }

        private void b_addNewClose_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tb_title.Text))
            {
                b_addNew_Click(sender, e);
                this.Close();
            }
        }
    }
}
