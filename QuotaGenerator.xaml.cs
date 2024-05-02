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

namespace QuotaGeneratorApp
{
    /// <summary>
    /// Логика взаимодействия для QuotaGenerator.xaml
    /// </summary>
    public partial class QuotaGenerator : Window
    {
        //private readonly string _quote;
        public QuotaGenerator(string quote, string author, string status)
        {
            InitializeComponent();           
            
            QuotaTextBox.Text = quote;
            AuthorLabel.Content = author;
            StatusLabel.Content = status;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
