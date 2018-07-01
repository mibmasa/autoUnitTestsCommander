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
        string VSTest = @"""C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\\vstest.console.exe""";

        public MainWindow()
        {
            InitializeComponent();
            pasetButton.IsEnabled = false;
            //if (!System.IO.File.Exists(VSTest))
            //{
            //    this.Close();
            //}
        }
        /// <summary>
        /// UnitTestDll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// ClipboardPaset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasetButton_Click(object sender, RoutedEventArgs e)
        {
            string lingString = VSTest;

            if ("" != unitTestDirectryText.Text)
            {
                lingString = lingString + " " + @"""" + unitTestDirectryText.Text + @"""" + " ";
            }
            if ("" != SettingsText.Text)
            {
                lingString += @"""/Settings:" + SettingsText.Text + @"""" + " ";
            }
            if ("" != loggerText.Text)
            {
                lingString += @"""/logger:" + loggerText.Text + @"""" + " ";
            }
            if ("" != TestCaseFilterText.Text)
            {
                lingString += @"""/TestCaseFilter:" + @"""" + TestCaseFilterText.Text + @"""" + @"""" + " ";
            }
            if ("" != testsText.Text)
            {
                lingString += @"""/Tests:" + testsText.Text + @"""" + " ";
            }
            if (InIsolationText.IsEnabled)
            {
                lingString += @"""" + InIsolationText.Text + @"""" + " ";
            }
            if (EnablecodecoverageText.IsEnabled)
            {
                lingString += @"""" + EnablecodecoverageText.Text + @"""" + " ";
            }
            if (UseVsixExtensionsText.IsEnabled)
            {
                lingString += @"""" + UseVsixExtensionsText.Text + @"""" + " ";
            }
            if (PlatformText.IsEnabled)
            {
                lingString += @"""" + PlatformText.Text + @"""" + " ";
            }
            if (FrameworkText.IsEnabled)
            {
                lingString += @"""" + FrameworkText.Text + @"""" + " ";
            }

            Clipboard.SetData(DataFormats.Text, (Object)lingString);
        }
        /// <summary>
        /// SettingOpen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            var settingOpen = new OpenFileDialog();
            settingOpen.Title = "testsettings Open";
            settingOpen.Filter = "*.testsettings,*.runsettings|*.testsettings,*.runsettings";
            if (true == settingOpen.ShowDialog())
            {
                this.unitTestDirectryText.Text = settingOpen.FileName;
            }
        }

        private void InIsolationCheck_Click(object sender, RoutedEventArgs e)
        {
            string fixCharactor = "/InIsolation:";
            if (InIsolationCheck.IsChecked == true)
            {
                if (!fixCharactor.Equals(InIsolationText.Text))
                {
                    InIsolationText.Text += fixCharactor;
                }
                InIsolationText.IsEnabled = true;
            }
            else
            {
                InIsolationText.Text = "";
                InIsolationText.IsEnabled = false;
            }
        }

        private void EnablecodecoverageCheck_Click(object sender, RoutedEventArgs e)
        {
            string fixCharactor = "/Enablecodecoverage:";
            if (EnablecodecoverageCheck.IsChecked == true)
            {
                if (!fixCharactor.Equals(EnablecodecoverageText.Text))
                {
                    EnablecodecoverageText.Text += fixCharactor;
                }
                EnablecodecoverageText.IsEnabled = true;
            }
            else
            {
                EnablecodecoverageText.Text = "";
                EnablecodecoverageText.IsEnabled = false;
            }
        }

        private void UseVsixExtensionsCheck_Click(object sender, RoutedEventArgs e)
        {
            string fixCharactor = "/UseVsixExtensions:";
            if (UseVsixExtensionsCheck.IsChecked == true)
            {
                if (!fixCharactor.Equals(UseVsixExtensionsText.Text))
                {
                    UseVsixExtensionsText.Text += fixCharactor;
                }
                UseVsixExtensionsText.IsEnabled = true;
            }
            else
            {
                UseVsixExtensionsText.Text = "";
                UseVsixExtensionsText.IsEnabled = false;
            }
        }

        private void PlatformCheck_Click(object sender, RoutedEventArgs e)
        {
            string fixCharactor = "/Platform:";
            if (PlatformCheck.IsChecked == true)
            {
                if (!fixCharactor.Equals(PlatformText.Text))
                {
                    PlatformText.Text += fixCharactor;
                }
                PlatformText.IsEnabled = true;
            }
            else
            {
                PlatformText.Text = "";
                PlatformText.IsEnabled = false;
            }
        }

        private void FrameworkCheck_Click(object sender, RoutedEventArgs e)
        {
            string fixCharactor = "/Framework:";
            if (FrameworkCheck.IsChecked == true)
            {
                if (!fixCharactor.Equals(FrameworkText.Text))
                {
                    FrameworkText.Text += fixCharactor;
                }
                FrameworkText.IsEnabled = true;
            }
            else
            {
                FrameworkText.Text = "";
                FrameworkText.IsEnabled = false;
            }
        }

        private void TestCategory_Click(object sender, RoutedEventArgs e)
        {
            string fixCharactor = "TestCategory=(Requirement Number)";
            if (TestCategoryCheck.IsChecked == true)
            {
                if (!fixCharactor.Equals(TestCaseFilterText.Text))
                {
                    TestCaseFilterText.Text = fixCharactor;
                }
            }
            else
            {
                TestCaseFilterText.Text = "";
            }
        }

        private void unitTestDirectryText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (unitTestDirectryText.Text != "" && SettingsText.Text != "")
            {
                pasetButton.IsEnabled = true;
            }
        }

        private void SettingsText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (unitTestDirectryText.Text != "" && SettingsText.Text != "")
            {
                pasetButton.IsEnabled = true;
            }
        }
    }
}