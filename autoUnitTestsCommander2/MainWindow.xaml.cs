using Microsoft.Win32;
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

namespace autoUnitTestsCommander2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*TODO:
             * VSTest.Console.exeが存在するディレクトリがわからないため
             * 起動時にあるかを確認する条件を追加する
             */
            string VSTest = @"VSTest.Console.exe";
            //if (!System.IO.File.Exists(VSTest))
            //{
            //    this.Close();
            //}
        }
        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            var dllOpen = new OpenFileDialog();
            dllOpen.Title = "dll Open";
            dllOpen.Filter = "*.dll|*.dll";
            if (true == dllOpen.ShowDialog())
            {
                this.unitTestDirectryText.Text = dllOpen.FileName;
            }
        }

        private void pasetButton_Click(object sender, RoutedEventArgs e)
        {
            string vsTestConsole = @"";
            string unitTestsDirectryToStrong = "";
            string tests = "";
            string testFilter = "";
            string logger = "";
            string lingString = "";
            if (0 == NullChecker(unitTestDirectryText.Text))
            {
                unitTestsDirectryToStrong = unitTestDirectryText.Text;
            }
            if (0 == NullChecker(testFilterText.Text))
            {
                tests = testsText.Text;
            }
            if (0 == NullChecker(loggerText.Text))
            {
                logger = loggerText.Text;
            }
            if (0 == NullChecker(testFilterText.Text))
            {
                testFilter = testFilterText.Text;
            }
            lingString = vsTestConsole + unitTestsDirectryToStrong + tests + testFilter + logger;

            Clipboard.SetData(DataFormats.Text, (Object)lingString);

        }

        public int NullChecker(string checkString)
        {
            if (null == checkString)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
