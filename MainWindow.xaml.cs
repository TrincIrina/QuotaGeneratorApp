using QuotaGeneratorApp.Database;
using QuotaGeneratorApp.File;
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

namespace QuotaGeneratorApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random r = new Random();
        private string quote = string.Empty;
        private string author = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            FileQuotes fq = new FileQuotes();
            fq.RandomQuote(r);
            quote = fq.Quote;
            author = fq.Author;
            OpenQuotaGenerator(quote, author, FileButton.Content.ToString());
        }

        private void DatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            RdbQuotaRepository repository = new RdbQuotaRepository();
            int count = repository.CountQuotes();
            int id = r.Next(1, count + 1);
            Quota quota = repository.FindById(id);
            quote = quota.Quote;
            author = quota.Author;
            OpenQuotaGenerator(quote, author, DatabaseButton.Content.ToString());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        // Вспомогательный метод - открытие окна QuotaGenerator
        private void OpenQuotaGenerator(string q, string a, string s)
        {
            QuotaGenerator generator = new QuotaGenerator(q, a, s);
            Hide();
            generator.ShowDialog();
            Show();
        }

    }
}
