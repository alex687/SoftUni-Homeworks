using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using ChatClent.Classes;

namespace ChatClent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private string onlineUsers;
        private StringBuilder messageList = new StringBuilder();
        private DateTime lastUpdate = DateTime.Now;

        public ChatWindow()
        {
            var isLoged = Client.AddUser();
            this.IsLoged(isLoged);

            InitializeComponent();
            SetOnlineUsers();

            this.StartDispatcher();
        }

        private void StartDispatcher()
        {
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3),
            };

            timer.Tick += this.CheckServerData;
            timer.Start();
        }

        private void CheckServerData(object sender, EventArgs e)
        {
            this.SetOnlineUsers();
            this.SetMessageList();
            MessageWindow.Text = this.messageList.ToString();
            this.lastUpdate = DateTime.Now;
        }

        private void SetMessageList()
        {
            var messages = Client.GetMessages(lastUpdate);
            foreach (var message in messages)
            {
                if (string.IsNullOrEmpty(MessageWindow.Text))
                {
                    this.messageList.Append(string.Format("{0}: {1}", message.User, message.Text));
                }
                else
                {
                    this.messageList.Append(string.Format("\n{0}: {1}", message.User, message.Text));
                }
            }
        }

        private void IsLoged(bool isLoged)
        {
            if (!isLoged)
            {
                MessageBox.Show("We have connection problem try again later!");
                var usernameWindow = new UsernameWindow();
                usernameWindow.Show();
                this.Close();
            }
        }

        private void SetOnlineUsers()
        {
            this.onlineUsers = Client.GetOnlineUser();
            Users.Text = this.onlineUsers;
        }

        private void AddMessageButton_OnClick(object sender, RoutedEventArgs e)
        {
            var newMessage = InputMessage.Text;
            if (!string.IsNullOrEmpty(newMessage))
            {
                var isMessageSend = Client.AddNewMessage(newMessage);
                if (isMessageSend)
                {
                    InputMessage.Text = string.Empty;
                    this.CheckServerData(AddMessageButton, e);
                }
            }
        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            Client.LogoutUser();
            this.Close();
        }

        private void HistoryButton_OnClick(object sender, RoutedEventArgs e)
        {
            var history = new HistoryWindow();
            history.Show();
        }
    }
}
