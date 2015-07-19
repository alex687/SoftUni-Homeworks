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
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public HistoryWindow()
        {
            InitializeComponent();
            HistoryBox.Text = MakeHistory();
        }

        private string MakeHistory()
        {
            var allMassages = Client.GetAllMessages();
            return MakeList(allMassages);
        }

        private string MakeList(List<Message> messages )
        {
            var result = new StringBuilder();

            for (int i = 0; i < messages.Count; i++)
            {
                if (i == 0)
                {
                    result.Append(string.Format("{0}: {1}", messages[i].User, messages[i].Text));
                }
                else
                {
                    result.Append(string.Format("\n{0}: {1}", messages[i].User, messages[i].Text));
                }
            }

            return result.ToString();
        }
    }
}
