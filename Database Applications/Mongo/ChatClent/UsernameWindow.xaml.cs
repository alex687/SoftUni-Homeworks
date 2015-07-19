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
using ChatClent.Classes;

namespace ChatClent
{
    /// <summary>
    /// Interaction logic for UsernameWindow.xaml
    /// </summary>
    public partial class UsernameWindow : Window
    {
        public UsernameWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void LogIn_OnClick(object sender, RoutedEventArgs e)
        {
            var usernameBox = this.FindName("Username") as TextBox;
            var username = usernameBox.Text;
            if (!Utility.IsValidUsername(username))
            {
                MessageBox.Show("Please try again username must be between 3 and 10 symbols!");
            }
            else
            {
                Client.User = new User(username);
                var chatWindow = new ChatWindow();
                
                chatWindow.Show();
                this.Close();
            }
        }
    }
}
