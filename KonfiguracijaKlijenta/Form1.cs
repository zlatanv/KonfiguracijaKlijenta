using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using Telerik.WinControls.UI;
using System.DirectoryServices;
using System.IO;

namespace KonfiguracijaKlijenta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadPodataka();
            CheckRemoteDesktopStatus();
        }

        public void loadPodataka()
        {
            string userName = "operater";

            using (var context = new PrincipalContext(ContextType.Machine))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(context, userName);

                if (user != null)
                {
                    log.Text += $"Postoji User Operater\n";
                    btnDodajOperatera.Enabled = false;
                }
                else
                {
                    log.Text += $"NE Postoji User Operater\n";
                    btnDodajOperatera.Enabled = true;
                }
            }

            bool isAlwaysOn = CheckPowerOptionsAlwaysOn();

            if (isAlwaysOn)
            {
                //  MessageBox.Show("Power options are set to 'Always On' (Never turn off).", "Power Options Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                powerOptionsSwitch.Value = true;
                log.Text += $"Power options are set to 'Always On'(Never turn off)\n";
            }
            else
            {
              
              //  MessageBox.Show("Power options are not set to 'Always On'.", "Power Options Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.Text += $"Power options are not set to 'Always On'.\n";
                powerOptionsSwitch.Value = false;
            }

            

        }

        private bool CheckPowerOptionsAlwaysOn()
        {
            return IsPowerOptionSetToNever("monitor-timeout-ac") &&
                   IsPowerOptionSetToNever("standby-timeout-ac") &&
                   IsPowerOptionSetToNever("disk-timeout-ac");
        }

        private bool IsPowerOptionSetToNever(string option)
        {
            string result = ExecuteCommand($"powercfg /query SCHEME_CURRENT SUB_VIDEO {option}");
            return result.Contains("0x0") || result.Contains("(Never)");
        }

        private string ExecuteCommand(string command)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = processInfo })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return output;
            }
        }
        private void SetPowerOptionsToNever()
        {
            try
            {
                ExecuteCommandPowerOptions("powercfg /change standby-timeout-ac 0");
                ExecuteCommandPowerOptions("powercfg /change standby-timeout-dc 0");
                ExecuteCommandPowerOptions("powercfg /change hibernate-timeout-ac 0");
                ExecuteCommandPowerOptions("powercfg /change hibernate-timeout-dc 0");

                log.Text += "Power options set to never for all scenarios.\n";
            }
            catch (Exception ex)
            {
                log.Text += $"Error setting power options: {ex.Message}\n";
            }
        }

        private void ExecuteCommandPowerOptions(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                using (System.IO.StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    log.Text += result + "\n";
                }

                using (System.IO.StreamReader errorReader = process.StandardError)
                {
                    string error = errorReader.ReadToEnd();
                    if (!string.IsNullOrEmpty(error))
                    {
                        log.Text += "Error: " + error + "\n";
                    }
                }
            }
        }
        private void OpenNotificationSettings()
        {
            try
            {
                // Open the Notifications settings page in Windows Settings
                Process.Start("ms-settings:notifications");
            }
            catch (Exception ex)
            {
                log.Text += $"Error opening Settings: {ex.Message}\n";
            }
        }

       

      

        private void AddLocalUser(string username, string password)
        {
            try
            {
                using (var context = new PrincipalContext(ContextType.Machine))
                {
                    // Check if the user already exists
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, username);
                    if (user == null)
                    {
                        // Create the user
                        user = new UserPrincipal(context)
                        {
                            SamAccountName = username,
                            UserPrincipalName = username,
                            PasswordNeverExpires = true,
                            Enabled = true
                        };

                        // Save the user
                        user.Save();

                        // Set password using DirectoryServices
                        using (var search = new DirectorySearcher(new DirectoryEntry("WinNT://" + Environment.MachineName)))
                        {
                            search.Filter = $"(samAccountName={username})";
                            search.PropertiesToLoad.Add("UserPassword");
                            var result = search.FindOne();
                            if (result != null)
                            {
                                var entry = result.GetDirectoryEntry();
                                entry.Invoke("SetPassword", new object[] { password });
                                entry.CommitChanges();
                            }
                        }
                        log.Text += $"Account Operater kreiran uspješno!...\n";
                        //MessageBox.Show($"User '{username}' created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        log.Text += $"Account Operater već postoji...\n";
                       // MessageBox.Show($"User '{username}' already exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error creating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Text += $"Error prilikom kreiranja Account-a Operater: {ex.Message}\n";
            }
        }

        private void btnDodajOperatera_Click(object sender, EventArgs e)
        {
            string username = "Operater";
            string password = "Argon123";
            log.Text += $"Dodajem Operater Account...\n";
            AddLocalUser(username, password);
        }

        private void btnPokreniUpdate_Click(object sender, EventArgs e)
        {
            StartWindowsUpdates();
        }

        private void StartWindowsUpdates()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c usoclient.exe StartScan";
                process.StartInfo.Verb = "runas"; // Runs the command as administrator
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();

                //MessageBox.Show("Windows Update process started.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                log.Text += $"Windows Update pokrenut!\n";
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error starting Windows Update: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Text += $"Error starting Windows Update: {ex.Message}\n";
            }
        }

        private void CheckRemoteDesktopStatus()
        {
            try
            {
                const string registryKey = @"SYSTEM\CurrentControlSet\Control\Terminal Server";
                const string valueName = "fDenyTSConnections";

                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey, false))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(valueName);
                        if (value != null)
                        {
                            int denyTSConnections = (int)value;
                            if (denyTSConnections == 0)
                            {
                                log.Text += "Remote Desktop is enabled.\n";
                            }
                            else
                            {
                                log.Text += "Remote Desktop is disabled.\n";
                            }
                        }
                        else
                        {
                            log.Text += "Could not retrieve the status of Remote Desktop.\n";
                        }
                    }
                    else
                    {
                        log.Text += "Could not open the registry key.\n";
                    }
                }
            }
            catch (Exception ex)
            {
                log.Text += $"Error checking Remote Desktop status: {ex.Message}\n";
            }
        }

        private void remoteDesktopSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (remoteDesktopSwitch.Value == true)
            {
                remoteDesktopSwitch.OnText = "Uključen";
                EnableRemoteDesktop();
            }
            else
            {
                remoteDesktopSwitch.OffText = "Isključen";
                
            }
           
            
        }

        private void EnableRemoteDesktop()
        {
            try
            {
                const string registryKey = @"SYSTEM\CurrentControlSet\Control\Terminal Server";
                const string valueName = "fDenyTSConnections";

                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey, true))
                {
                    if (key != null)
                    {
                        key.SetValue(valueName, 0, RegistryValueKind.DWord);
                        log.Text += "Remote Desktop has been enabled.\n";

                        // Optionally, ensure the firewall allows Remote Desktop connections
                        EnableFirewallRule();
                    }
                    else
                    {
                        log.Text += "Could not open the registry key to enable Remote Desktop.\n";
                    }
                }
            }
            catch (Exception ex)
            {
                log.Text += $"Error enabling Remote Desktop: {ex.Message}\n";
            }
        }

        private void EnableFirewallRule()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c netsh advfirewall firewall set rule group=\"remote desktop\" new enable=Yes";
                process.StartInfo.Verb = "runas"; // Run as administrator
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();

                log.Text += "Firewall rule for Remote Desktop has been enabled.\n";
            }
            catch (Exception ex)
            {
                log.Text += $"Error enabling firewall rule: {ex.Message}\n";
            }
        }

        private void pokreniNETPLWIZ()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c reg ADD \"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\PasswordLess\\Device\" /v DevicePasswordLessBuildVersion /t REG_DWORD /d 0 /f";
                process.StartInfo.Verb = "runas"; // Run as administrator
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();

                log.Text += "Netplwiz Activated.\n";
            }
            catch (Exception ex)
            {
                log.Text += $"Error Netplwiz: {ex.Message}\n";
            }
        }

        private void btnKonfiguracijaNotifikacija_Click(object sender, EventArgs e)
        {
            OpenNotificationSettings();
        }

        private void powerOptionsSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (powerOptionsSwitch.Value == true)
            {
                SetPowerOptionsToNever();
            }
            else
            {

            }
        }

        private void btnJezikDatum_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "ms-settings:regionlanguage",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening language settings: {ex.Message}");
            }
        }

        private void btnTring_Click(object sender, EventArgs e)
        {
            string rootPath = @"C:\tring";
            string xmlPath = Path.Combine(rootPath, "xml");

            try
            {
                // Create the root directory
                Directory.CreateDirectory(rootPath);

                // Create the subdirectory inside the root directory
                Directory.CreateDirectory(xmlPath);

                log.Text += $"Directories created successfully:\n{rootPath}\n{xmlPath}\n";
            }
            catch (Exception ex)
            {
                log.Text += $"Error creating directories: {ex.Message}\n";
            }
        }

        private void btnAktivirajNetPlwiz_Click(object sender, EventArgs e)
        {
            pokreniNETPLWIZ();
        }
    }
}
