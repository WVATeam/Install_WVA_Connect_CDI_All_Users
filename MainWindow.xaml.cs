using System;
using System.Collections.Generic;
using System.IO;
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

namespace Install_WVA_Connect_CDI_All_Users
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGrid();
        }

        private void SetUpGrid()
        {
            foreach (string userName in GetUsers())
            {
                AvailableUsersTable.Items.Add(new AvailableUser()
                {
                    UserName = userName,
                    IsChecked = false
                });
            }
        }

        private List<string> GetUsers()
        {
            var users = new List<string>();
            foreach (string directory in Directory.GetDirectories(@"C:\Users\"))
            {
                string user = GetUserName(directory);
                if (!user.Contains("default") && !user.Contains("users"))
                {
                    users.Add(user);
                }
            }

            return users;
        }

        private string GetUserName(string directory)
        {
            return directory.ToLower().Replace(@"c:\users\", "").Replace(@"\", "");
        }

        private bool SetupExeExists()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists($@"{desktop}\Setup.exe"))
                return true;
            else
                return false;
        }

        private bool AppInstalled()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            if (Directory.Exists($@"{appData}\Wva_Connect_CDI"))
                return true;
            else
                return false;
        }

        private void RunSetupExe()
        {


        }

        private void Install(string user)
        {
            string path = $@"C:\Users\{user}\AppData\Local\";



        }

        private void AvailableUsersTable_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        { 
            e.Cancel = true;
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            if (SetupExeExists())
            {
                RunSetupExe();
                if (AppInstalled())
                {
                    foreach (AvailableUser user in AvailableUsersTable.Items)
                    {
                        if (user.IsChecked)
                        {
                            Install(user.UserName);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("App was not installed in AppData.", "", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Setup.exe not found on desktop! Please place Setup.exe on your desktop and try again.", "", MessageBoxButton.OK);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }

    public class AvailableUser
    {
        public string UserName { get; set; }
        public bool IsChecked { get; set; }
    }
}
