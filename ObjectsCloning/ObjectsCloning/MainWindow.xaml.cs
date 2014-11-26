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

namespace ObjectsCloning
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




        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            TestObjectCloning();

            ListCloningDemo();
        }
        public void TestObjectCloning()
        {
            House baseHouse = new House()
            {
                Address = "Kiev, Metalistiv str., h. 7",
                Owner = new HouseOwner
                {
                    Name = "Mr. Mikle",
                    Pet = new Animal("Lucky")
                }
            };

            #region Create baseHouse clone and write current states
            House myHouse = baseHouse.Clone();

            ConsoleTextBox.Text += string.Format("baseHouse \n{0}\n", baseHouse);
            ConsoleTextBox.Text += string.Format("myHouse \n{0}\n", myHouse);
            #endregion

            #region Change Address in myHouse and write states
            myHouse.Address = "Ukraine, Kiev, Metalistiv str., h. 12a";

            ConsoleTextBox.Text += "***** After Address changing in myHouse *****\n";

            Console.WriteLine("baseHouse \n{0}", baseHouse);
            ConsoleTextBox.Text += string.Format("myHouse \n{0}\n", myHouse);
            #endregion

            #region Change Animal in myHouse and write states
            ConsoleTextBox.Text += "***** After Animal changing in myHouse *****\n";

            myHouse.Owner.Pet = new Animal("Star");

            ConsoleTextBox.Text += string.Format("baseHouse \n{0}\n", baseHouse);
            ConsoleTextBox.Text += string.Format("myHouse \n{0}\n", myHouse);
            #endregion

            #region Change Owner in myHouse and write states
            ConsoleTextBox.Text += "***** After Owner changing in myHouse *****\n";

            myHouse.Owner = new HouseOwner()
            {
                Name = "Jack",
                Pet = new Animal("Igor")
            };

            ConsoleTextBox.Text += string.Format("baseHouse \n{0}", baseHouse);
            ConsoleTextBox.Text += string.Format("myHouse \n{0}\n", myHouse);
            #endregion
        }
        private void ListCloningDemo()
        {
            List<int> baseList = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> copyList = baseList;
            List<int> cloneList = baseList.Clone();

            #region Change cloneList
            ConsoleTextBox.Text += "***** Change cloneList *****\n";
            cloneList.Add(-1);

            ConsoleTextBox.Text += "baseList:\n";
            baseList.ForEach(i => ConsoleTextBox.Text += i + " ");
            ConsoleTextBox.Text += '\n';

            ConsoleTextBox.Text += "cloneList:\n";
            cloneList.ForEach(i => ConsoleTextBox.Text += i + " ");
            ConsoleTextBox.Text += '\n';

            #endregion


        }
    }
}
