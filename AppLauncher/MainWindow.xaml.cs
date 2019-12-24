using System;
using System.Collections.Generic;
using System.Windows;
using System.Diagnostics;
using System.Text.Json;
using System.IO;

namespace AppLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AppViewModel viewModel { get; set; }
        private readonly string jsonFileName;
        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            jsonFileName = "json.json";
            try
            {
                viewModel = new AppViewModel(JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(jsonFileName)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                viewModel = new AppViewModel(new Dictionary<string, string>());
            }
            DataContext = viewModel;
        }

        private void buttonLaunch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(viewModel.AppsDictionary[comboBoxApps.SelectedItem.ToString()]);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
