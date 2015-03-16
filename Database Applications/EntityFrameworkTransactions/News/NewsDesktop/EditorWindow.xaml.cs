using News.Data;
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

namespace NewsDesktop
{
    using System.Data.Entity.Infrastructure;

    using News.Model;

    public partial class EditorWindow : Window
    {
        private readonly NewsData newsData = new NewsData();

        private News news;

       public EditorWindow()
        {
            this.InitializeComponent();
            this.LoadNewsContentText();
        }


        private void LoadNewsContentText()
        {
            this.news = this.newsData.News.First();

            this.NewsContentBox.Text = this.news.Content.ToString();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            var text = this.NewsContentBox.Text;
            this.news.Content = text;

            try
            {
                this.newsData.SaveChanges();

                MessageBoxResult message = MessageBox.Show("News saved in DB", "Success", MessageBoxButton.OK);
                this.Close();
            }
            catch (DbUpdateConcurrencyException)
            {
                MessageBoxResult message = MessageBox.Show("Update conflict", "Error", MessageBoxButton.OK);
                this.newsData.News.Reload(this.news);
                this.NewsContentBox.Text = this.news.Content;
            }
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        
    }
}
