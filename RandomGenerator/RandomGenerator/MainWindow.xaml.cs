using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace RandomGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RandomOrg random;

        public MainWindow()
        {
            InitializeComponent();
            //Create RandomOrg object
            random = new RandomOrg(10, 50);
        }

        private async void MainButton_Click(object sender, RoutedEventArgs e)
        {
            //Load numbers and add to ConsoleTextBlock
            await LoadNumbers(20000);
        }
        private Task LoadNumbers(int count)
        {
            return Task.Run(() =>
            {
                //Format result string
                string textBoxResult = "";

                this.Dispatcher.Invoke((Action)(() =>
                {
                    ConsoleTextBlock.Text += "Loading numbers...\n";
                }));

                foreach (int n in random.GetNumbers(count))
                {
                    textBoxResult += n + "; ";
                }

                this.Dispatcher.Invoke((Action)(() =>
                {
                    //Remove @"Loading numbers...\n" 
                    ConsoleTextBlock.Text = ConsoleTextBlock.Text.Substring(0, ConsoleTextBlock.Text.Length - "Loading numbers...\n".Length);
                    //Add random numbers
                    ConsoleTextBlock.Text += "Your numbers: \n" + textBoxResult + "\n";
                }));
            }
            );
        }
    }
}

