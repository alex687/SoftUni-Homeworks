﻿namespace NewsDesktop
{
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

    public partial class MainWindow : Window
    {
        private EditorWindow editorWindow;

        public MainWindow()
        {
            this.InitializeComponent();
            
            this.editorWindow = new EditorWindow();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.editorWindow.Show(); 
            this.Close(); 
        }
    }
}
