﻿using Microsoft.VisualBasic.Devices;
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
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Field_Service_Toolkit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string? hostName;
        public string HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }

        private void btnPing_Click(object sender, EventArgs e)
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
                catch (PingException p)
                {
                    pcInformation.Text = p.Message;
                }
            }

            if (isPingable)
            {                
                StartRemoteRegistry(HostName);                
                Host host = new Host();                
                host.GetPCInformation(HostName);
                SnowAPI snowAPI = new SnowAPI();
                snowAPI.SnowAPIClient();

                pcInformation.Text = $"Computer Name: {host.Name}\nOperating System: {host.OS}\nManufacturer: {host.Manufacturer}\nModel: {host.Model}\nSerial Number: {host.Serial}" +
                    $"\nCPU SPeed: {host.CpuSpeed}\nBios Version: {host.BiosVersion}\nDomain: {host.Domain}\nHDD Capacity: {host.HddCapacity}GB\nHDD Space: {host.HddUsedSpace}% | Free: {host.HddFreeSpace}" +
                    $"\nRAM: {host.TotalRam}GB | Free Memory: {host.FreeRam} | Total Memory Used: {host.UsedRam}\nUser Logged In: {host.CurrentUser}\nRDP: {host.Rdp}\nLast Reboot: {host.LastReboot}";

                snowInformation.Text = $"Department: {snowAPI.Department}\nLocation: {snowAPI.Location}\nRoom: {snowAPI.Room}\nRoom Type: {snowAPI.RoomType}\nAssigned To: {snowAPI.AssignedTo}";
                
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
            ServiceController sc = new ServiceController("RemoteRegistry", hostName);

            if (sc.Status.Equals(ServiceControllerStatus.Stopped))
            {
                sc.Start();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAssetTag.Text = "";
            txtUserName.Text = "";
            pcInformation.Text = "";
            snowInformation.Text = "";
        }
    }
}
