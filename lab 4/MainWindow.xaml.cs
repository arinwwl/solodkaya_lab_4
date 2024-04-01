using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Train<int>[] trains;
        private bool isDepartureTime = true;
        private bool isDestination = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {


            //TRAIN<int>[] trains = new TRAIN<int>[6];


            //for (int i = 0; i < trains.Length; i++)
            //{
            //    trains[i] = new TRAIN<int>
            //    {
            //        Destination = "Пункт назначения " + (i + 1),
            //        TrainNumber = i + 1,
            //        DepartureTime = DateTime.Now.AddHours(i)
            //    };
            //}


            //Array.Sort(trains);


            //List<TRAIN<int>> foundTrains = new List<TRAIN<int>>();
            //foreach (TRAIN<int> train in trains)
            //{
            //    if (train.Destination == destination)
            //    {
            //        foundTrains.Add(train);
            //    }
            //}


            //trainDataGrid.ItemsSource = foundTrains;


            //if (foundTrains.Count == 0)
            //{
            //    MessageBox.Show("Поездов, направляющихся в указанный пункт, не найдено.");
            //}
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbCreate_Click(object sender, RoutedEventArgs e)
        {

            if (trains!.Length > Train<int>.Count)
            {
                TrainAdd add = new TrainAdd();
                if (add.ShowDialog() == true)
                {
                    trains[Train<int>.Count] = new Train<int>();
                    trains[Train<int>.Count].Destination = add.Destination;
                    trains[Train<int>.Count].TrainNumber = add.TrainNumber;
                    trains[Train<int>.Count].DepartureTime = add.DepartureTime;
                    Train<int>.Count++;
                }
                trainDataGrid.ItemsSource = null;
                trainDataGrid.ItemsSource = trains;
                stCount.Content = "Создано " + Train<int>.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Массив полностью заполнен");
            }
        }
        void GridViewColumnHeaderClickedHandler(object sender,
                                      RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            if (headerClicked!.Content.ToString() == "DepartureTime")
            {
                if (isDepartureTime)
                {
                    Array.Sort(trains!);
                }
                else
                {
                    trains = trains!.OrderByDescending(p => p.DepartureTime).ToArray();
                }
                isDepartureTime = !isDepartureTime;
            }
            else if (headerClicked.Content.ToString() == "Destination")
            {
                if (isDestination)
                {
                    Array.Sort(trains!, new DestinationComparator());
                }
                else
                {
                    trains = trains!.OrderBy(p => p.Destination).ToArray();
                }
                isDestination = !isDestination;
            }
           trainDataGrid.ItemsSource = null;
            trainDataGrid.ItemsSource = trains;
        }
        private void tbCopy_Click(object sender, RoutedEventArgs e)
        {

            if (trainDataGrid.SelectedItems.Count!=0&&Train<int>.Count<trains.Length)
            {
                Train<int>? monster = trainDataGrid.SelectedItem as Train<int>;
                trains![Train<int>.Count] = (Train<int>)monster!.Clone();
                trainDataGrid.ItemsSource = null;
                trainDataGrid.ItemsSource = trains;
                Train<int>.Count++;
                stCount.Content = "Создано " + Train<int>.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Массив полностью заполнен");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbCount.Text.Length != 0)
            {
                trains = null;
                trains = new Train<int>[int.Parse(tbCount.Text)];
                MessageBox.Show("Массив размером " + trains.Length + " элемента создан");
                Train<int>.Count = 0;
                mmCopy.IsEnabled = true;
                mmCreate.IsEnabled = true;
                tbCreate.IsEnabled = true;
                tbCopy.IsEnabled = true;
                trainDataGrid.ItemsSource = null;
                stCount.Content = "Создано " + Train<int>.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Введите размер массива");
            }
        }
    }
}
