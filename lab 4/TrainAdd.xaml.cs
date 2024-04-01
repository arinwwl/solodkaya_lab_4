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

namespace lab_4
{
    /// <summary>
    /// Логика взаимодействия для TrainAdd.xaml
    /// </summary>
    public partial class TrainAdd : Window
    {
        public TrainAdd()
        {
            InitializeComponent();
        }

        public string Destination
        {
            get
            {
                return tbDestination.Text;
            }
            set
            {
                tbDestination.Text = value.ToString();
            }
        }
        public int TrainNumber
        {
            get
            {
                return int.Parse(tbTrainNumber.Text);
            }
            set
            {
                tbTrainNumber.Text = value.ToString();
            }
        }
        public DateTime DepartureTime
        {
            get
            {
                return DateTime.Parse(tbDepartureTime.Text);
            }
            set
            {
                tbDepartureTime.Text = value.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}
