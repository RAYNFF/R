using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace погдготовка2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var n = im.Text;
            var p = pr.Text;

            var cont = new APDBCONT();

            var hum_exist = cont.Human.FirstOrDefault(x =>x.Name == n);

            if (hum_exist is not null)
            {
                MessageBox.Show("ты зареган уже чел");
                return;

            }

         
            var hu = new Humans {Name = n, Pasword = p};
            cont.Human.Add(hu);
            cont.SaveChanges();
            MessageBox.Show("теперь ты есть в базе");
        }

        private void Button_Click_delete(object sender, RoutedEventArgs e)
        {
            var context = new APDBCONT();

            var Huma = new Humans
            {
                ID= 4
            };

            context.Human.Attach(Huma);    
            context.Human.Remove(Huma);
            context.SaveChanges();




        }

        private void Button_Click_red(object sender, RoutedEventArgs e)
        {
            var cont = new APDBCONT();
            var ima = im_2.Text;
            var par = pr_2.Text;

            var reg = cont.Human.Where(x => x.Name == ima).FirstOrDefault();


            reg.Pasword = par;
            cont.SaveChanges();
        }
    }
}

