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
using System.Windows.Shapes;
using DakkaData;

namespace DakkaWPF
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window1 Window1 { get; set; }

        public string EmployeeCode { get; set; }

        private List<Button> buttons = new List<Button>();

        public Window2()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.Visibility = Visibility.Hidden;
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
            this.Visibility = Visibility.Visible;
        }

        public Window2(string EmployeeCode)
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.Visibility = Visibility.Hidden;
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
            this.Visibility = Visibility.Visible;

            this.EmployeeCode = EmployeeCode;

            InitButtons();
        }

        private void InitButtons()
        {
            List<WorkRecord.DTO> dtos = WorkRecord.GetFive(EmployeeCode, DateTime.Now);

            buttons.Add(button0);
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);

            int i = 0;
            foreach (WorkRecord.DTO dto in dtos)
            {
                buttons[i].Content = dto.WorkPoint;
                buttons[i].Content += "(" + dto.Status + ")";
                buttons[i].Tag = dto.ID;
                i++;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorkRecord.DakkaByID((sender as Button).Tag as string);

            MessageBox.Show("OK", "dakka success!");
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
