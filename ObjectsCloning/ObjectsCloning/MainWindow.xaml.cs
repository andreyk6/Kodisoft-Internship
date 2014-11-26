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
            Test();
        }


        public class Evil
        {
            public int evilNum;
        }

        public class BaseClass
        {
            int x;
            string s;
            public Evil evil;
            public BaseClass()
            {
                x = 0;
                s = string.Empty;
                evil = new Evil() { evilNum = 1 };
            }

            public BaseClass(int x,string s)
            {
                this.x = x;
                this.s = s;
                evil = new Evil() { evilNum = 1 };
            }
        }

        public class MyClass
        {
            int n;
            public List<int> list = new List<int>() { 1, 2, 3 };

            public  BaseClass myClass = new BaseClass(10, "My.BaseClass");

            public MyClass()
            {
                n = 0;
                myClass = new BaseClass();
            }
            public MyClass(int n, BaseClass baseClass)
            {
                this.n = n;
                myClass = baseClass;
            }
        }


        public void Test()
        {
            MyClass c1 = new MyClass(32, new BaseClass(1, "c1_string"));

            MyClass c2 = c1.Clone();

            c2.myClass.evil.evilNum = 2;

            c2.myClass = new BaseClass(0, "newBaseClass");


            var c3 = c1.Clone();

            c3.myClass.evil.evilNum = 51;

            c3.list.Add(66);
        }
    }
}
