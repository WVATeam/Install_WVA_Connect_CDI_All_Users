using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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

        private bool AppInstalled()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            if (Directory.Exists($@"{appData}\Wva_Connect_CDI"))
                return true;
            else
                return false;
        }

        private void CreateIconOnDesktop(string userName)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = $@"C:\Users\{userName}\desktop\WVA_Connect_CDI.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "WVA Connect CDI";
            shortcut.TargetPath = $@"C:\Users\{userName}\AppData\Local\WVA_Connect_CDI\WVA_Connect_CDI.exe";
            shortcut.Save();
        }

        private bool Install(string user)
        {
            string appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string originDirectory = $@"{appDataLocal}\WVA_Connect_CDI";
            string newCopyPath = $@"C:\Users\{user}\AppData\Local\WVA_Connect_CDI";

            // Copy all child files and directories 
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "xcopy.exe",
                Arguments = $"\"{originDirectory}\" \"{newCopyPath}\" /E /I /Y",
                Verb = "runas"
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            // Delete files that are user specific
            // Delete selected act number set by user. If this is set, they won't be prompted to select an account upon startup
            System.IO.File.Delete(newCopyPath + @"\ActNum\ActNum.txt");

            // Delete copied error files
            var errorLogFiles = Directory.EnumerateFiles(newCopyPath + @"\ErrorLog\");
            foreach (string file in errorLogFiles)
            {
                try { System.IO.File.Delete(file); } catch { }
            }

            // Delete copied temp files
            var tempFiles = Directory.EnumerateFiles(newCopyPath + @"\Temp\");
            foreach (string file in tempFiles)
            {
                try { System.IO.File.Delete(file); } catch { }
            }

            // Wait a half second to allow the files to be created through command line
            //hread.Sleep(500);

            if (Directory.Exists(newCopyPath))
                return true;
            else
                return false;
        }

        private void AvailableUsersTable_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        { 
            e.Cancel = true;
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AppInstalled())
                {
                    int installedCount = 0;
                    foreach (AvailableUser user in AvailableUsersTable.Items)
                    {
                        if (user.IsChecked)
                        {
                            try
                            {
                                bool wasInstalled = Install(user.UserName);
                                CreateIconOnDesktop(user.UserName);

                                if (wasInstalled)
                                    installedCount++;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Install failed for user: {user.UserName}!", "", MessageBoxButton.OK);
                            }
                        }
                    }

                    if (installedCount == 1)
                        MessageBox.Show($"{installedCount} app successfully installed!", "", MessageBoxButton.OK);
                    else
                        MessageBox.Show($"{installedCount} apps successfully installed!", "", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("You must have WVA_Connect_CDI installed before continuing!", "", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The following exception has occurred: {ex.ToString()}", "", MessageBoxButton.OK);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SelectAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (AvailableUser user in AvailableUsersTable.Items)
                if (!user.IsChecked)
                    user.IsChecked = true;

            AvailableUsersTable.Items.Refresh();
        }

        private void DeselectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (AvailableUser user in AvailableUsersTable.Items)
                if (user.IsChecked)
                    user.IsChecked = false;

            AvailableUsersTable.Items.Refresh();
        }
    }

    public class AvailableUser
    {
        public string UserName { get; set; }
        public bool IsChecked { get; set; }
    }
}
