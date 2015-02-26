using System;
using System.Collections.Generic;
using System.Linq;
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
using DakkaData;

namespace DakkaWPF
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.Visibility = Visibility.Hidden;
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
            this.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = e.Source as Button;

            if (b != null)
            {
                CodeBox.Text += b.Content as string;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            CodeBox.Clear();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if(Employee.IsEmployeeCodeExist(CodeBox.Text))
            {
                Window2 w2 = new Window2(CodeBox.Text);
                w2.Window1 = this;
                this.CodeBox.Clear();
                w2.Show();
            }
            else
            {
                MessageBox.Show("No such code for employee!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
