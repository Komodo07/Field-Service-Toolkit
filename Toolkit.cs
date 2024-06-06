using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Field_Service_Toolkit
{
    public partial class Toolkit : Form
    {
        public Toolkit()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall
                || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                return;
            }
            Application.Exit();
        }

        private string? hostName;
        public string HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }

        private async void btnPing_Click(object sender, EventArgs e)
        {
            txtAssetTag.Text = txtAssetTag.Text.ToUpper().Trim();
            HostName = txtAssetTag.Text;
            bool isPingable = false;

            if (string.IsNullOrWhiteSpace(HostName) || HostName == "")
            {
                MessageBox.Show("Please use a valid Asset Tag");
            }
            else
            {
                try
                {
                    isPingable = PingHost();
                }
                catch (PingException pingException)
                {
                    pcInformation.Text = pingException.Message;
                }
            }

            if (isPingable)
            {
                //Determines if the hostName is able to be pinged. If so it will attempt to start the Remote Registry Service
                //If the Remote Registry Services is successfully started it will call the GetPCInformation method and then
                //attepts to call the SnowAPIClient method.

                try
                {
                    StartRemoteRegistry(HostName);
                }
                catch (Exception RemoteRegistryException)
                {
                    pcInformation.Text = RemoteRegistryException.Message;
                    return;
                }

                Host host = new Host();
                host.GetPCInformation(HostName);

                SnowAPI snowAPI = new SnowAPI();

                try
                {
                    Task task = snowAPI.SnowAPIClient(HostName);
                    await task;
                }
                catch (JsonException jsonException)
                {
                    snowInformation.Text = jsonException.Message;
                    return;
                }

                pcInformation.Text = $"Computer Name: {host.Name}\nOperating System: {host.OS}\nManufacturer: {host.Manufacturer}\nModel: {host.Model}\nSerial Number: {host.Serial}" +
                    $"\nCPU SPeed: {host.CpuSpeed}\nBios Version: {host.BiosVersion}\nDomain: {host.Domain}\nHDD Capacity: {host.HddCapacity}GB\nHDD Space: {host.HddUsedSpace}% | Free: {host.HddFreeSpace}" +
                    $"\nRAM: {host.TotalRam}GB | Free Memory: {host.FreeRam} | Total Memory Used: {host.UsedRam}\nUser Logged In: {host.CurrentUser}\nRDP: {host.Rdp}\nLast Reboot: {host.LastReboot}";

                snowInformation.Text = $"Alias: {snowAPI.Alias}\nDepartment: {snowAPI.Department}\nLocation: {snowAPI.Location}\nRoom: {snowAPI.Room}\nRoom Type: {snowAPI.RoomType}\nAssigned To: {snowAPI.AssignedTo}";

                txtUserName.Text = host.CurrentUser;
            }


        }

        public bool PingHost()
        {
            //Uses the hostName variable to see if the PC is active on the network
            //then returns true or false and releases pinger resources.

            Ping pinger = new Ping();
            bool pingable = false;

            PingReply reply = pinger.Send(HostName);
            pingable = reply.Status == IPStatus.Success;

            if (!pingable)
            {
                throw new PingException($"{HostName} is offline");
            }

            if (pinger != null)
            {
                pinger.Dispose();
            }

            return pingable;
        }

        private static void StartRemoteRegistry(string hostName)
        {
            //Determines if the Remote Registry Service is stopped on the host PC
            // and (if so) starts it.

            ServiceController sc = new ServiceController("RemoteRegistry", hostName);

            if (sc.Status.Equals(ServiceControllerStatus.Stopped))
            {
                try
                {
                    sc.Start();
                }
                catch
                {
                    throw new Exception("Unable to start Remote Registry.");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAssetTag.Text = "";
            txtUserName.Text = "";
            pcInformation.Text = "";
            snowInformation.Text = "";
        }

        private void RestartWorkstation_Click(object sender, EventArgs e)
        {
            using ManagementObjectSearcher searcher = new ManagementObjectSearcher($@"\\{HostName}\root\cimv2", "SELECT * FROM Win32_OperatingSystem");

            foreach (ManagementObject mo in searcher.Get())
            {
                mo.InvokeMethod("Reboot", null);
                MessageBox.Show($"Rebooting {HostName}");
                mo.Dispose();
            }
        }
    }
}
